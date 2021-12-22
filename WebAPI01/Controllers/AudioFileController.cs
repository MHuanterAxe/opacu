using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI01.Domain.Model;
using WebAPI01.Domain.Repositories;

namespace WebAPI01.API.Controllers
{
    [ApiController]
    public class AudioFileController
    {
        private IAudioFileRepository _fileRepository;

        public AudioFileController(IAudioFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        [HttpGet]
        [Route("api/users/{userId}/audio-files")]
        public async Task<ActionResult<List<AudioFile>>> Get(Guid userId)
        {
            return await _fileRepository.GetUserFilesAsync(userId);
        }
        
        [HttpPatch]
        [Route("api/users/{userId}/audio-files/{fileId}")]
        public async Task<ActionResult<List<AudioFile>>> Update(Guid userId, Guid fileId, AudioFile file)
        {
            if (!_fileRepository.Has(fileId))
            {
                return new NotFoundResult();
            }

            if (!_fileRepository.BelongsToUser(userId, fileId))
            {
                return new ForbidResult();
            }

            await _fileRepository.UpdateAsync(fileId, file);

            return new AcceptedResult();
        }

        [HttpDelete]
        [Route("api/users/{userId}/audio-files/{fileId}")]
        public async Task<ActionResult<List<AudioFile>>> Delete(Guid userId, Guid fileId)
        {
            if (!_fileRepository.Has(fileId))
            {
                return new NotFoundResult();
            }

            if (!_fileRepository.BelongsToUser(userId, fileId))
            {
                return new ForbidResult();
            }

            await _fileRepository.DeleteAsync(fileId);

            return new NoContentResult();
        }
    }
}