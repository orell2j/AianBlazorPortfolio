IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250212185218_SeedTestimonials'
)
BEGIN
    CREATE TABLE [Testimonials] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Comment] nvarchar(max) NOT NULL,
        [SubmittedOn] datetime2 NOT NULL,
        [Approved] bit NOT NULL,
        [Featured] bit NOT NULL,
        [Rating] float NOT NULL,
        CONSTRAINT [PK_Testimonials] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250212185218_SeedTestimonials'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Approved', N'Comment', N'Featured', N'Name', N'Rating', N'SubmittedOn') AND [object_id] = OBJECT_ID(N'[Testimonials]'))
        SET IDENTITY_INSERT [Testimonials] ON;
    EXEC(N'INSERT INTO [Testimonials] ([Id], [Approved], [Comment], [Featured], [Name], [Rating], [SubmittedOn])
    VALUES (1, CAST(1 AS bit), N''Great portfolio!'', CAST(1 AS bit), N''John Doe'', 5.0E0, ''2025-01-20T00:00:00.0000000''),
    (2, CAST(1 AS bit), N''Very professional work.'', CAST(0 AS bit), N''Jane Smith'', 4.5E0, ''2025-01-21T00:00:00.0000000''),
    (3, CAST(1 AS bit), N''Excellent design!'', CAST(0 AS bit), N''Alex Johnson'', 4.0E0, ''2025-01-22T00:00:00.0000000''),
    (4, CAST(1 AS bit), N''Impressive work.'', CAST(0 AS bit), N''Emily Davis'', 4.5E0, ''2025-01-23T00:00:00.0000000''),
    (5, CAST(1 AS bit), N''Really liked it!'', CAST(0 AS bit), N''Michael Brown'', 5.0E0, ''2025-01-24T00:00:00.0000000''),
    (6, CAST(1 AS bit), N''Could be better.'', CAST(0 AS bit), N''Sarah Wilson'', 3.5E0, ''2025-01-25T00:00:00.0000000''),
    (7, CAST(1 AS bit), N''Outstanding effort!'', CAST(1 AS bit), N''David Lee'', 5.0E0, ''2025-01-26T00:00:00.0000000''),
    (8, CAST(1 AS bit), N''Very creative!'', CAST(0 AS bit), N''Laura Martinez'', 4.0E0, ''2025-01-27T00:00:00.0000000''),
    (9, CAST(1 AS bit), N''Amazing results!'', CAST(1 AS bit), N''Chris Taylor'', 5.0E0, ''2025-01-28T00:00:00.0000000''),
    (10, CAST(1 AS bit), N''Satisfying work.'', CAST(0 AS bit), N''Olivia Harris'', 4.5E0, ''2025-01-29T00:00:00.0000000'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Approved', N'Comment', N'Featured', N'Name', N'Rating', N'SubmittedOn') AND [object_id] = OBJECT_ID(N'[Testimonials]'))
        SET IDENTITY_INSERT [Testimonials] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250212185218_SeedTestimonials'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250212185218_SeedTestimonials', N'9.0.2');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250212230428_AddSiteContent'
)
BEGIN
    CREATE TABLE [SiteContents] (
        [Id] int NOT NULL IDENTITY,
        [AboutText] nvarchar(max) NULL,
        [AboutImageUrl] nvarchar(max) NULL,
        [WorksContent] nvarchar(max) NULL,
        [SkillsContent] nvarchar(max) NULL,
        [ContactEmail] nvarchar(max) NULL,
        [ContactPhone] nvarchar(max) NULL,
        [CVFileFrenchUrl] nvarchar(max) NULL,
        [CVFileEnglishUrl] nvarchar(max) NULL,
        CONSTRAINT [PK_SiteContents] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250212230428_AddSiteContent'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250212230428_AddSiteContent', N'9.0.2');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250215063012_UpdateSiteContentModel'
)
BEGIN
    EXEC sp_rename N'[SiteContents].[WorksContent]', N'WorksContentFrench', 'COLUMN';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250215063012_UpdateSiteContentModel'
)
BEGIN
    EXEC sp_rename N'[SiteContents].[SkillsContent]', N'WorksContentEnglish', 'COLUMN';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250215063012_UpdateSiteContentModel'
)
BEGIN
    EXEC sp_rename N'[SiteContents].[AboutText]', N'SkillsContentFrench', 'COLUMN';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250215063012_UpdateSiteContentModel'
)
BEGIN
    ALTER TABLE [SiteContents] ADD [AboutTextEnglish] nvarchar(max) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250215063012_UpdateSiteContentModel'
)
BEGIN
    ALTER TABLE [SiteContents] ADD [AboutTextFrench] nvarchar(max) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250215063012_UpdateSiteContentModel'
)
BEGIN
    ALTER TABLE [SiteContents] ADD [GithubUrl] nvarchar(max) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250215063012_UpdateSiteContentModel'
)
BEGIN
    ALTER TABLE [SiteContents] ADD [LinkedInUrl] nvarchar(max) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250215063012_UpdateSiteContentModel'
)
BEGIN
    ALTER TABLE [SiteContents] ADD [SkillsContentEnglish] nvarchar(max) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250215063012_UpdateSiteContentModel'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250215063012_UpdateSiteContentModel', N'9.0.2');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250215234411_UpdateSiteContentSeed'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AboutImageUrl', N'AboutTextEnglish', N'AboutTextFrench', N'CVFileEnglishUrl', N'CVFileFrenchUrl', N'ContactEmail', N'ContactPhone', N'GithubUrl', N'LinkedInUrl', N'SkillsContentEnglish', N'SkillsContentFrench', N'WorksContentEnglish', N'WorksContentFrench') AND [object_id] = OBJECT_ID(N'[SiteContents]'))
        SET IDENTITY_INSERT [SiteContents] ON;
    EXEC(N'INSERT INTO [SiteContents] ([Id], [AboutImageUrl], [AboutTextEnglish], [AboutTextFrench], [CVFileEnglishUrl], [CVFileFrenchUrl], [ContactEmail], [ContactPhone], [GithubUrl], [LinkedInUrl], [SkillsContentEnglish], [SkillsContentFrench], [WorksContentEnglish], [WorksContentFrench])
    VALUES (1, NULL, N''Passionate Computer Science student proficient in multiple programming languages and cloud services. Experienced in developing IoT solutions, microservices and full-stack web applications. Seeking an internship to leverage my skills in software development and cloud computing.'', N''Étudiant passionné d''''informatique maîtrisant plusieurs langages de programmation et services cloud. Expérimenté dans le développement de solutions IoT, de microservices et d''''applications web full-stack. À la recherche d''''un stage pour mettre à profit mes compétences en développement de logiciels et en cloud computing.'', N''/files/CV Aian Batoochirov EN.pdf'', N''/files/CV Aian Batoochirov FR.pdf'', N''aianbat50@gmail.com'', N''+1 (438) 528-3019'', N''https://github.com/orell2j'', N''http://www.linkedin.com/in/aian-batoochirov-50521318b'', N''<p>Skills:<br>Java / Springboot, Agile / Scrum, Github / Git, Jira, Rest API, JavaScript / React, Micro Services, Linux, HTML / CSS, SQL / Databases, Teamwork, Problem Solver</p>'', N''<p>Compétences:<br>Java / Springboot, Agile / Scrum, Github / Git, Jira, Rest API, JavaScript / React, Micro Services, HTML / CSS, SQL / Databases, Travail d''''équipe, Résolution de problèmes</p>'', N''<p>Projects:<br>• WEB DEV - Pet Clinic Project<br>• WEB DEV - Billing Project Automation</p>'', N''<p>Projets:<br>• WEB DEV - Pet Clinic Project<br>• WEB DEV - CompteExpress</p>'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AboutImageUrl', N'AboutTextEnglish', N'AboutTextFrench', N'CVFileEnglishUrl', N'CVFileFrenchUrl', N'ContactEmail', N'ContactPhone', N'GithubUrl', N'LinkedInUrl', N'SkillsContentEnglish', N'SkillsContentFrench', N'WorksContentEnglish', N'WorksContentFrench') AND [object_id] = OBJECT_ID(N'[SiteContents]'))
        SET IDENTITY_INSERT [SiteContents] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250215234411_UpdateSiteContentSeed'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250215234411_UpdateSiteContentSeed', N'9.0.2');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250215234713_UpdateSiteContentSeed2'
)
BEGIN
    EXEC(N'UPDATE [SiteContents] SET [AboutTextEnglish] = N''Passionate Computer Science student proficient in multiple programming languages and cloud services. Experienced in developing IoT solutions, microservices and full-stack web applications. Seeking an internship to leverage my skills in software development and cloud computing.'', [AboutTextFrench] = N''Étudiant passionné d''''informatique maîtrisant plusieurs langages de programmation et services cloud. Expérimenté dans le développement de solutions IoT, de microservices et d''''applications web full-stack. À la recherche d''''un stage pour mettre à profit mes compétences en développement de logiciels et en cloud computing.'', [CVFileEnglishUrl] = N''/files/CV Aian Batoochirov EN-1.pdf'', [CVFileFrenchUrl] = N''/files/CV Aian Batoochirov FR-4.pdf'', [ContactEmail] = N''aianbat50@gmail.com'', [ContactPhone] = N''+1 (438) 528-3019'', [GithubUrl] = N''https://github.com/orell2j'', [LinkedInUrl] = N''http://www.linkedin.com/in/aian-batoochirov-50521318b'', [SkillsContentEnglish] = N''<p>Skills:<br>Java / Springboot, Agile / Scrum, Github / Git, Jira, Rest API, JavaScript / React, Micro Services, Linux, HTML / CSS, SQL / Databases, Teamwork, Problem Solver</p>'', [SkillsContentFrench] = N''<p>Compétences:<br>Java / Springboot, Agile / Scrum, Github / Git, Jira, Rest API, JavaScript / React, Micro Services, HTML / CSS, SQL / Databases, Travail d''''équipe, Résolution de problèmes</p>'', [WorksContentEnglish] = N''<p>Projects:<br>• WEB DEV - Pet Clinic Project<br>• WEB DEV - Billing Project Automation</p>'', [WorksContentFrench] = N''<p>Projets:<br>• WEB DEV - Pet Clinic Project<br>• WEB DEV - CompteExpress</p>''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250215234713_UpdateSiteContentSeed2'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250215234713_UpdateSiteContentSeed2', N'9.0.2');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250215235848_PendingModelChanges'
)
BEGIN
    EXEC(N'UPDATE [SiteContents] SET [AboutTextEnglish] = N''Passionate Computer Science student proficient in multiple programming languages and cloud services. Experienced in developing IoT solutions, microservices and full-stack web applications. Seeking an internship to leverage my skills in software development and cloud computing.'', [AboutTextFrench] = N''Étudiant passionné d''''informatique maîtrisant plusieurs langages de programmation et services cloud. Expérimenté dans le développement de solutions IoT, de microservices et d''''applications web full-stack. À la recherche d''''un stage pour mettre à profit mes compétences en développement de logiciels et en cloud computing.'', [CVFileEnglishUrl] = N''/files/CV Aian Batoochirov EN-1.pdf'', [CVFileFrenchUrl] = N''/files/CV Aian Batoochirov FR-4.pdf'', [ContactEmail] = N''aianbat50@gmail.com'', [ContactPhone] = N''+1 (438) 528-3019'', [GithubUrl] = N''https://github.com/orell2j'', [LinkedInUrl] = N''http://www.linkedin.com/in/aian-batoochirov-50521318b'', [SkillsContentEnglish] = N''<p>Skills:<br>Java / Springboot, Agile / Scrum, Github / Git, Jira, Rest API, JavaScript / React, Micro Services, Linux, HTML / CSS, SQL / Databases, Teamwork, Problem Solver</p>'', [SkillsContentFrench] = N''<p>Compétences:<br>Java / Springboot, Agile / Scrum, Github / Git, Jira, Rest API, JavaScript / React, Micro Services, HTML / CSS, SQL / Databases, Travail d''''équipe, Résolution de problèmes</p>'', [WorksContentEnglish] = N''<p>Projects:<br>• WEB DEV - Pet Clinic Project<br>• WEB DEV - Billing Project Automation</p>'', [WorksContentFrench] = N''<p>Projets:<br>• WEB DEV - Pet Clinic Project<br>• WEB DEV - CompteExpress</p>''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250215235848_PendingModelChanges'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250215235848_PendingModelChanges', N'9.0.2');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250216000556_mssql.local_migration_624'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250216000556_mssql.local_migration_624', N'9.0.2');
END;

COMMIT;
GO