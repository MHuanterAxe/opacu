using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebAPI01.Domain.Model;

namespace WebAPI01.Domain.Repositories
{
    public interface IFileRepository
    {
        public Task<List<File>> GetAllAsync();

        public Task<List<File>> GetUserFilesAsync(Guid id);

        public Task<File> GetByIdAsync(Guid id);
        
        public Task<File> AddAsync(File file);
        public Task<ImageFile> AddAsync(ImageFile file);
        public Task<TextFile> AddAsync(TextFile file);
        public Task<VideoFile> AddAsync(VideoFile file);
        public Task<AudioFile> AddAsync(AudioFile file);
        public Task<File> UpdateAsync(File textFile);
        public Task<File> DeleteAsync(Guid id);
    }
}