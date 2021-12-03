using System.Threading.Tasks;
using System.Collections.Generic;
using WebAPI01.Domain.Model;

namespace WebAPI01.Domain.Repositories
{
    public interface ITextFileRepository
    {
        public Task<List<TextFile>> GetAllAsync();

        public Task<TextFile> GetByIdAsync(int id);

        public Task AddAsync(TextFile textFile);
        public Task UpdateAsync(TextFile textFile);
        public Task DeleteAsync(int id);
    }
}