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
    public class ImageFileRepository : IImageFileRepository
    {
        private readonly Context _context;

        public ImageFileRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ImageFile>> GetUserFilesAsync(Guid id)
        {
            var files = from textFile in _context.Set<ImageFile>().Include(f => f.File)
                join file in _context.Set<File>() on textFile.FileId equals file.Id
                orderby file.CreatedAt 
                where file.UserId == id
                select textFile;

            return await files.ToListAsync();
        }

        public async Task<ImageFile> AddAsync(ImageFile file)
        {
            await _context.ImageFiles.AddAsync(file);
            await _context.SaveChangesAsync();
            return file;
        }

        public async Task<ImageFile> UpdateAsync(Guid id, ImageFile file)
        {
            _context.ImageFiles.Update(file);
            await _context.SaveChangesAsync();
            return file;
        }

        public async Task<ImageFile> DeleteAsync(Guid id)
        {
            var file = await _context.ImageFiles.FindAsync(id);
            _context.ImageFiles.Remove(file);
            await _context.SaveChangesAsync();
            return file;
        }
    }
}