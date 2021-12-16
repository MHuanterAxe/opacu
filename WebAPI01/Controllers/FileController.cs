using System;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI01.API.Services;
using WebAPI01.Domain.Repositories;
using WebAPI01.Infrastructure;
using WebAPI01.Infrastructure.Data;
using WebAPI01.Infrastructure.Repositories;
using File = WebAPI01.Domain.Model.File;

namespace WebAPI01.API.Controllers
{
    [ApiController]
    public class FileController : ControllerBase
    {
        private Context _context;
        private IFileRepository _fileRepository;
        private FileUploadService _fileUploadService;

        public FileController(Context context, FileUploadService fileUploadService)
        {
            _context = context;
            _fileRepository = new FileRepository(_context);
            _fileUploadService = fileUploadService;
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
                if (file != null)
                {
                    var result = await _fileUploadService.UploadFile(
                        userId,
                        file,
                        title,
                        description
                    );

                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}