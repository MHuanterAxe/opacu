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

        public async Task<File> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task AddAsync(File textFile)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateAsync(File textFile)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}