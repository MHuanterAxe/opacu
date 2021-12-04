using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPI01.Domain.Model;
using WebAPI01.Domain.Repositories;
using WebAPI01.Infrastructure;
using WebAPI01.Infrastructure.Repositories;

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
    }
}