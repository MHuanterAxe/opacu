using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI01.Domain;
using Microsoft.EntityFrameworkCore;
using WebAPI01.Domain.Repositories;

namespace WebAPI01.Infrastructure
{
    public class PersonRepository : IPersonRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public PersonRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<Person>> GetAllAsync()
        {
            return await _context.Persons.OrderBy(p => p.Name).ToListAsync();
        }
        public async Task<Person> GetByIdAsync(int id)
        {
            return await _context.Persons.FindAsync(id);
        }
        public async Task AddAsync(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Person person)
        {
            var existPerson = await _context.Persons.FindAsync(person.Id);
            _context.Entry(existPerson).CurrentValues.SetValues(person);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Person person = await _context.Persons.FindAsync(id);
            _context.Remove(person);
            await _context.SaveChangesAsync();
        }
    }
}
