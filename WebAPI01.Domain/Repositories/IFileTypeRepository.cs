using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebAPI01.Domain.Model;

namespace WebAPI01.Domain.Repositories
{
    public interface IFileTypeRepository<T>
    {
        public Task<List<T>> GetUserFilesAsync(Guid id);

        public Task<T> AddAsync(T file);

        public bool Has(Guid id);

        public bool BelongsToUser(Guid userId, Guid fileId);
        public Task<T> UpdateAsync(Guid id, T textFile);
        
        public Task<T> DeleteAsync(Guid id);
    }
}