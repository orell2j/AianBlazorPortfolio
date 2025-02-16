﻿// <auto-generated />
using System;
using AianBlazorPortfolio.Components.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AianBlazorPortfolio.Migrations
{
    [DbContext(typeof(TestimonialDbContext))]
    partial class TestimonialDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AianBlazorPortfolio.Components.Models.SiteContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AboutImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutTextEnglish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutTextFrench")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CVFileEnglishUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CVFileFrenchUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GithubUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkedInUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkillsContentEnglish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkillsContentFrench")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorksContentEnglish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorksContentFrench")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SiteContents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AboutTextEnglish = "Passionate Computer Science student proficient in multiple programming languages and cloud services. Experienced in developing IoT solutions, microservices and full-stack web applications. Seeking an internship to leverage my skills in software development and cloud computing.",
                            AboutTextFrench = "Étudiant passionné d'informatique maîtrisant plusieurs langages de programmation et services cloud. Expérimenté dans le développement de solutions IoT, de microservices et d'applications web full-stack. À la recherche d'un stage pour mettre à profit mes compétences en développement de logiciels et en cloud computing.",
                            CVFileEnglishUrl = "/files/CV Aian Batoochirov EN.pdf",
                            CVFileFrenchUrl = "/files/CV Aian Batoochirov FR.pdf",
                            ContactEmail = "aianbat50@gmail.com",
                            ContactPhone = "+1 (438) 528-3019",
                            GithubUrl = "https://github.com/orell2j",
                            LinkedInUrl = "http://www.linkedin.com/in/aian-batoochirov-50521318b",
                            SkillsContentEnglish = "<p>Skills:<br>Java / Springboot, Agile / Scrum, Github / Git, Jira, Rest API, JavaScript / React, Micro Services, Linux, HTML / CSS, SQL / Databases, Teamwork, Problem Solver</p>",
                            SkillsContentFrench = "<p>Compétences:<br>Java / Springboot, Agile / Scrum, Github / Git, Jira, Rest API, JavaScript / React, Micro Services, HTML / CSS, SQL / Databases, Travail d'équipe, Résolution de problèmes</p>",
                            WorksContentEnglish = "<p>Projects:<br>• WEB DEV - Pet Clinic Project<br>• WEB DEV - Billing Project Automation</p>",
                            WorksContentFrench = "<p>Projets:<br>• WEB DEV - Pet Clinic Project<br>• WEB DEV - CompteExpress</p>"
                        });
                });

            modelBuilder.Entity("AianBlazorPortfolio.Components.Models.Testimonial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Featured")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<DateTime>("SubmittedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Testimonials");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Approved = true,
                            Comment = "Great portfolio!",
                            Featured = true,
                            Name = "John Doe",
                            Rating = 5.0,
                            SubmittedOn = new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Approved = true,
                            Comment = "Very professional work.",
                            Featured = false,
                            Name = "Jane Smith",
                            Rating = 4.5,
                            SubmittedOn = new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Approved = true,
                            Comment = "Excellent design!",
                            Featured = false,
                            Name = "Alex Johnson",
                            Rating = 4.0,
                            SubmittedOn = new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Approved = true,
                            Comment = "Impressive work.",
                            Featured = false,
                            Name = "Emily Davis",
                            Rating = 4.5,
                            SubmittedOn = new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Approved = true,
                            Comment = "Really liked it!",
                            Featured = false,
                            Name = "Michael Brown",
                            Rating = 5.0,
                            SubmittedOn = new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            Approved = true,
                            Comment = "Could be better.",
                            Featured = false,
                            Name = "Sarah Wilson",
                            Rating = 3.5,
                            SubmittedOn = new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7,
                            Approved = true,
                            Comment = "Outstanding effort!",
                            Featured = true,
                            Name = "David Lee",
                            Rating = 5.0,
                            SubmittedOn = new DateTime(2025, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 8,
                            Approved = true,
                            Comment = "Very creative!",
                            Featured = false,
                            Name = "Laura Martinez",
                            Rating = 4.0,
                            SubmittedOn = new DateTime(2025, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 9,
                            Approved = true,
                            Comment = "Amazing results!",
                            Featured = true,
                            Name = "Chris Taylor",
                            Rating = 5.0,
                            SubmittedOn = new DateTime(2025, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 10,
                            Approved = true,
                            Comment = "Satisfying work.",
                            Featured = false,
                            Name = "Olivia Harris",
                            Rating = 4.5,
                            SubmittedOn = new DateTime(2025, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
