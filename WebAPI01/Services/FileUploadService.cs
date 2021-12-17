using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebAPI01.Domain.Repositories;
using WebAPI01.Infrastructure.Facades;
using WebAPI01.Domain.Model;
using File = WebAPI01.Domain.Model.File;

namespace WebAPI01.API.Services
{
    public class FileUploadService
    {
        private FileUploadFacade _fileUploadFacade;
        private IFileRepository _fileRepository;

        public FileUploadService(FileUploadFacade fileUploadFacade, IFileRepository fileRepository)
        {
            _fileUploadFacade = fileUploadFacade;
            _fileRepository = fileRepository;
        }

        public async Task<File> UploadFile(Guid userId, IFormFile file, String title, String description)
        {
            var (uploadedFile, uploadProperties) = await _fileUploadFacade.Upload(userId, file, title, description);
            
            await _fileRepository.AddAsync(uploadedFile);

            await CreateFileRecord(uploadedFile, uploadProperties);

            return uploadedFile;
        }

        private async Task CreateFileRecord(File uploadedFile, FileUploadProperties uploadProperties)
        {
            switch (uploadProperties.folder)
            {
                case "img":
                {
                    await _fileRepository.AddAsync(new ImageFile()
                    {
                        File = uploadedFile,
                        Resolution = "2333x3213",
                        ColorPalette = "RGB",
                    });
                    break;
                }
                case "audio":
                {
                    await _fileRepository.AddAsync(new AudioFile()
                    {
                        File = uploadedFile,
                        Bitrate = 1800,
                        Length = 2400,
                    });
                    break;
                }
                case "text":
                {
                    await _fileRepository.AddAsync(new TextFile()
                    {
                        File = uploadedFile,
                        Encoding = "utf-8",
                        SymbolCount = 2843842
                    });
                    break;
                }
                case "video":
                {
                    await _fileRepository.AddAsync(new VideoFile()
                    {
                        File = uploadedFile,
                        Encoding = "pro res",
                        Bitrate = 1800,
                        Length = 2400,
                        Resolution = "1920x1080"
                    });
                    break;
                }
            }
        }
    }
}