using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var user = await _context.Users.FindAsync(id);
            return user.Files;
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