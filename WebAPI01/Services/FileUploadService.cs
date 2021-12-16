using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using WebAPI01.Domain.Repositories;
using WebAPI01.Infrastructure.Facades;
using Microsoft.Extensions.Configuration;
using WebAPI01.Domain.Model;
using File = WebAPI01.Domain.Model.File;

namespace WebAPI01.API.Services
{
    public sealed class FileUploadProperties
    {
        private readonly String folder;
        private readonly HashSet<String> mimeTypes;
        private readonly int value;

        public static readonly FileUploadProperties TEXT =
            new FileUploadProperties(
                1,
                "text",
                new HashSet<string>() {"text/txt", "text/doc", "text/pdf"}
            );

        public static readonly FileUploadProperties IMAGE =
            new FileUploadProperties(
                2,
                "img",
                new HashSet<string>() {"image/png", "image/jpg", "image/gif", "image/bmp", "image/webp"}
            );

        public static readonly FileUploadProperties VIDEO =
            new FileUploadProperties(
                3,
                "video",
                new HashSet<string>() {"video/mpeg", "video/mp4", "video/avi"}
            );

        public static readonly FileUploadProperties AUDIO =
            new FileUploadProperties(
                4,
                "audio",
                new HashSet<string>() {"audio/mp3", "audio/flac"}
            );

        private FileUploadProperties(int value, String folder, HashSet<String> mimeTypes)
        {
            this.folder = folder;
            this.mimeTypes = mimeTypes;
            this.value = value;
        }

        public override String ToString()
        {
            return folder;
        }
    }

    public class FileUploadService
    {
        private FileUploadFacade _fileUploadFacade;
        private IFileRepository _fileRepository;
        private IConfiguration _configuration;

        public FileUploadService(FileUploadFacade fileUploadFacade, IFileRepository fileRepository,
            IConfiguration configuration)
        {
            _fileUploadFacade = fileUploadFacade;
            _fileRepository = fileRepository;
            _configuration = configuration;
        }

        public async Task<File> UploadFile(Guid userId, IFormFile file, String title, String description)
        {
            var size = file.Length;
            var format = file.ContentType;
            var fileName = GetFileName(userId, file);

            var folderName = GetFolderName(FileUploadProperties.IMAGE);
            var pathToSave = GetPathToSave(folderName);

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

            var i = new ImageFile()
            {
                File = f,
                Resolution = "2333x3213",
                ColorPalette = "RGB",
            };

            await _fileRepository.AddAsync(i);

            return f;
        }

        private static string GetPathToSave(string folderName)
        {
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            return pathToSave;
        }

        private string GetFolderName(FileUploadProperties uploadProperties)
        {
            return Path.Combine(_configuration.GetSection("Static").Value, uploadProperties.ToString());
        }

        private static string GetFileName(Guid userId, IFormFile file)
        {
            var fileName = userId.ToString() + "__" +
                           ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim();
            return fileName;
        }
    }
}