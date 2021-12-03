using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI01.Domain.Repositories
{
    public interface IPersonRepository
    {
        public Task<List<Person>> GetAllAsync();

        public Task<Person> GetByIdAsync(int id);

        public Task AddAsync(Person person);
        public Task UpdateAsync(Person person);
        public Task DeleteAsync(int id);
    }
}