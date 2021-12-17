using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI01.Domain.Model;
using WebAPI01.Infrastructure.Repositories;

namespace WebAPI01.API.Controllers
{
    [ApiController]
    public class VideoFileController
    {
        private FileRepository _fileRepository;

        public VideoFileController(FileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        [HttpGet]
        [Route("api/users/{userId}/video-files")]
        public async Task<ActionResult<List<VideoFile>>> Get(Guid userId)
        {
            return await _fileRepository.GetUserVideoFilesAsync(userId);
        }
    }
}