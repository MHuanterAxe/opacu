using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebAPI01.Domain.Model;

namespace WebAPI01.Domain.Repositories
{
    public interface IFileTypeRepository<T>
    {
        public Task<List<T>> GetUserFilesAsync(Guid id);
        public Task<T> GetById(Guid id);

        public Task<T> AddAsync(T file);
        public Task<T> UpdateAsync(Guid id, T textFile);
        
        public Task<T> DeleteAsync(Guid id);
    }
}