using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI01.Domain.Model;
using WebAPI01.Domain.Repositories;

namespace WebAPI01.Infrastructure.Repositories
{
    public class FileRepository : IFileRepository
    {
        public Context _context;
        public FileRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<File>> GetAllAsync()
        {
            throw new System.NotImplementedException();
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

        public async Task<File> GetByIdAsync(Guid id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<File> AddAsync(File file)
        {
            await _context.Files.AddAsync(file);
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