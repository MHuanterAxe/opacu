using System.Threading.Tasks;
using System.Collections.Generic;
using WebAPI01.Domain.Model;

namespace WebAPI01.Domain.Repositories
{
    public interface IFileRepository
    {
        public Task<List<File>> GetAllAsync();

        public Task<File> GetByIdAsync(int id);

        public Task AddAsync(File textFile);
        public Task UpdateAsync(File textFile);
        public Task DeleteAsync(int id);
    }
}