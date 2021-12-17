using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI01.Domain.Model;
using WebAPI01.Infrastructure.Repositories;

namespace WebAPI01.API.Controllers
{
    [ApiController]
    public class AudioFileController
    {
        private FileRepository _fileRepository;

        public AudioFileController(FileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        [HttpGet]
        [Route("api/users/{userId}/audio-files")]
        public async Task<ActionResult<List<AudioFile>>> Get(Guid userId)
        {
            return await _fileRepository.GetUserAudioFilesAsync(userId);
        }
    }
}