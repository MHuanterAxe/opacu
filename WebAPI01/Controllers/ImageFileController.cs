using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI01.Domain.Model;
using WebAPI01.Domain.Repositories;

namespace WebAPI01.API.Controllers
{
    [ApiController]
    public class ImageFileController
    {
        private IImageFileRepository _fileRepository;

        public ImageFileController(IImageFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        [HttpGet]
        [Route("api/users/{userId}/image-files")]
        public async Task<ActionResult<List<ImageFile>>> Get(Guid userId)
        {
            return await _fileRepository.GetUserFilesAsync(userId);
        }
        
        [HttpPatch]
        [Route("api/users/{userId}/image-files/{fileId}")]
        public async Task<ActionResult<List<ImageFile>>> Update(Guid userId, Guid fileId, ImageFile file)
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
        [Route("api/users/{userId}/image-files/{fileId}")]
        public async Task<ActionResult<List<ImageFile>>> Delete(Guid userId, Guid fileId)
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