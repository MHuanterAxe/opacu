using System;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI01.Domain.Repositories;
using WebAPI01.Infrastructure;
using WebAPI01.Infrastructure.Repositories;
using File = WebAPI01.Domain.Model.File;

namespace WebAPI01.API.Controllers
{
    [ApiController]
    public class FileController : ControllerBase
    {
        public Context _context;
        public IFileRepository _fileRepository;

        public FileController(Context context)
        {
            _context = context;
            _fileRepository = new FileRepository(_context);
        }

        [HttpGet]
        [Route("api/users/{userId}/files")]
        public async Task<ActionResult<List<File>>> GetUserFiles(Guid userId)
        {
            return await _fileRepository.GetUserFilesAsync(userId);
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("api/users/{userId}/files"),]
        public async Task<ActionResult<File>> Upload(
            Guid userId,
            [FromForm] String title,
            [FromForm] String description,
            IFormFile file
        )
        {
            try
            {
                var folderName = Path.Combine("static", "img");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file != null)
                {
                    var size = file.Length;
                    var format = file.ContentType;
                    var fileName = userId.ToString() + "__" + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    await using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var f = new File()
                    {
                        Size = size,
                        Path = dbPath,
                        Format = format,
                        UserId = userId,
                        Title = title,
                        Description = description,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    };
                    await _fileRepository.AddAsync(f);

                    return Ok(f);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}