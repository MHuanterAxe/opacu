using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebAPI01.Domain.Model;

namespace WebAPI01.Domain.Repositories
{
    public interface IFileRepository
    {
        public Task<List<File>> GetUserFilesAsync(Guid id);
        public Task<List<TextFile>> GetUserTextFilesAsync(Guid id);
        public Task<List<ImageFile>> GetUserImageFilesAsync(Guid id);
        public Task<List<VideoFile>> GetUserVideoFilesAsync(Guid id);
        public Task<List<AudioFile>> GetUserAudioFilesAsync(Guid id);

        public Task<File> AddAsync(File file);
        public Task<ImageFile> AddAsync(ImageFile file);
        public Task<TextFile> AddAsync(TextFile file);
        public Task<VideoFile> AddAsync(VideoFile file);
        public Task<AudioFile> AddAsync(AudioFile file);
        public Task<File> UpdateAsync(File textFile);
        public Task<File> DeleteAsync(Guid id);
    }
}