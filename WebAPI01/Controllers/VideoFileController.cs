using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI01.Domain.Model;
using WebAPI01.Domain.Repositories;

namespace WebAPI01.API.Controllers
{
    [ApiController]
    public class VideoFileController
    {
        private IVideoFileRepository _fileRepository;

        public VideoFileController(IVideoFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        [HttpGet]
        [Route("api/users/{userId}/video-files")]
        public async Task<ActionResult<List<VideoFile>>> Get(Guid userId)
        {
            return await _fileRepository.GetUserFilesAsync(userId);
        }
        
        [HttpPatch]
        [Route("api/users/{userId}/video-files/{fileId}")]
        public async Task<ActionResult<List<VideoFile>>> Update(Guid userId, Guid fileId, VideoFile file)
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
        [Route("api/users/{userId}/video-files/{fileId}")]
        public async Task<ActionResult<List<VideoFile>>> Delete(Guid userId, Guid fileId)
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