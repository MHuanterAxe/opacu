using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI01.Domain.Model;
using WebAPI01.Infrastructure.Repositories;

namespace WebAPI01.API.Controllers
{
    [ApiController]
    public class ImageFileController
    {
        private FileRepository _fileRepository;

        public ImageFileController(FileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        [HttpGet]
        [Route("api/users/{userId}/image-files")]
        public async Task<ActionResult<List<ImageFile>>> Get(Guid userId)
        {
            return await _fileRepository.GetUserImageFilesAsync(userId);
        }
    }
}