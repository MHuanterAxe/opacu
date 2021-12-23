using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebAPI01.Domain.DTO;
using WebAPI01.Domain.Model;
using WebAPI01.Domain.Repositories;

namespace WebAPI01.API.Controllers
{
    [ApiController]
    public class ImageFileController
    {
        private IImageFileRepository _imageFileRepository;
        private readonly IMapper _mapper;

        public ImageFileController(
            IImageFileRepository imageImageFileRepository)
        {
            _imageFileRepository = imageImageFileRepository;
        }

        [HttpGet]
        [Route("api/users/{userId}/image-files")]
        public async Task<ActionResult<List<ImageFile>>> Get(Guid userId)
        {
            return await _imageFileRepository.GetUserFilesAsync(userId);
        }

        [HttpPatch]
        [Route("api/users/{userId}/image-files/{fileId}")]
        public async Task<ActionResult<ImageFile>> Update(Guid userId, Guid fileId, [FromBody] ImageFileDto fileDto)
        {
            if (!_imageFileRepository.Has(fileId))
            {
                return new NotFoundResult();
            }

            if (!_imageFileRepository.BelongsToUser(userId, fileId))
            {
                return new ForbidResult();
            }

            var file = await _imageFileRepository.GetById(fileId);

            var newFile =_mapper.Map(fileDto, file);
            
            await _imageFileRepository.UpdateAsync(fileId, newFile);

            return new AcceptedResult();
        }
    }
}