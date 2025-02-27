using Microsoft.AspNetCore.Mvc;
using AianBlazorPortfolio.Components.Models;
using AianBlazorPortfolio.Components.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace AianBlazorPortfolio.Components.Controller
{
  [ApiController]
  [Route("api/[controller]")]
  public class ContentController : ControllerBase
  {
    private readonly MongoDbService _mongoService;
    private readonly IWebHostEnvironment _env;

    public ContentController(MongoDbService mongoService, IWebHostEnvironment env)
    {
      _mongoService = mongoService;
      _env = env;
    }

    // GET api/content
    [HttpGet]
    public IActionResult GetContent()
    {
      var content = _mongoService.SiteContents.Find(_ => true).FirstOrDefault();
      if (content == null)
      {
        content = new SiteContent();
        _mongoService.SiteContents.InsertOne(content);
      }
      return Ok(content);
    }

    // POST api/content/update
    [HttpPost("update")]
    public async Task<IActionResult> UpdateContent([FromBody] SiteContent updatedContent)
    {
      if (updatedContent == null)
        return BadRequest();

      var filter = Builders<SiteContent>.Filter.Eq(sc => sc.Id, updatedContent.Id);
      await _mongoService.SiteContents.ReplaceOneAsync(filter, updatedContent);
      return Ok();
    }

    // POST api/content/upload
    [HttpPost("upload")]
    [RequestSizeLimit(104857600)] // 100 MB
    public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
    {
      if (file == null || file.Length == 0)
        return BadRequest("No file provided.");

      var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
      if (!Directory.Exists(uploadsFolder))
        Directory.CreateDirectory(uploadsFolder);

      var filePath = Path.Combine(uploadsFolder, file.FileName);
      using (var stream = new FileStream(filePath, FileMode.Create))
      {
        await file.CopyToAsync(stream);
      }
      var fileUrl = $"/uploads/{file.FileName}";
      return Ok(new { fileUrl });
    }
  }
}
