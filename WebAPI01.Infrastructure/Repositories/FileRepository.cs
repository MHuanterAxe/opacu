using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI01.Domain.Model;
using WebAPI01.Domain.Repositories;
using WebAPI01.Infrastructure.Data;

namespace WebAPI01.Infrastructure.Repositories
{
    public class FileRepository : IFileRepository
    {
        public Context _context;
        public FileRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<File>> GetUserFilesAsync(Guid id)
        {
            if (await _context.Users.AnyAsync(u => u.Id == id))
            {
                var files = _context.Files.Where(f => f.UserId == id);

                return await files.ToListAsync();
            }

            return new List<File>();
        }

        public async Task<List<TextFile>> GetUserTextFilesAsync(Guid id)
        {
            return await _context.TextFiles.Where(f => f.File.UserId == id).ToListAsync();
        }

        public async Task<List<ImageFile>> GetUserImageFilesAsync(Guid id)
        {
            return await _context.ImageFiles.Where(f => f.File.UserId == id).ToListAsync();
        }

        public async Task<List<VideoFile>> GetUserVideoFilesAsync(Guid id)
        {
            return await _context.VideoFiles.Where(f => f.File.UserId == id).ToListAsync();
        }

        public async Task<List<AudioFile>> GetUserAudioFilesAsync(Guid id)
        {
            return await _context.AudioFiles.Where(f => f.File.UserId == id).ToListAsync();
        }

        public async Task<File> AddAsync(File file)
        {
            await _context.Files.AddAsync(file);
            await _context.SaveChangesAsync();
            return file;
        }
        
        public async Task<ImageFile> AddAsync(ImageFile file)
        {
            await _context.ImageFiles.AddAsync(file);
            await _context.SaveChangesAsync();
            return file;
        }

        public async Task<TextFile> AddAsync(TextFile file)
        {
            await _context.TextFiles.AddAsync(file);
            await _context.SaveChangesAsync();
            return file;
        }

        public async Task<VideoFile> AddAsync(VideoFile file)
        {
            await _context.VideoFiles.AddAsync(file);
            await _context.SaveChangesAsync();
            return file;
        }

        public async Task<AudioFile> AddAsync(AudioFile file)
        {
            await _context.AudioFiles.AddAsync(file);
            await _context.SaveChangesAsync();
            return file;
        }

        public async Task<File> UpdateAsync(File file)
        {
            _context.Files.Update(file);
            await _context.SaveChangesAsync();
            return file;
        }

        public async Task<File> DeleteAsync(Guid id)
        {
            var file = await _context.Files.FindAsync(id);
            _context.Files.Remove(file);
            await _context.SaveChangesAsync();
            return file;
        }
    }
}