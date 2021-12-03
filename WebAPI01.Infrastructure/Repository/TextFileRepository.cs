using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebAPI01.Domain;
using WebAPI01.Domain.Model;
using WebAPI01.Domain.Repositories;

namespace WebAPI01.Infrastructure.Repository
{
    public class TextFileRepository : ITextFileRepository
    {
        private readonly Context _context;
        public TextFileRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        
        public async Task<List<TextFile>> GetAllAsync()
        {
            return await _context.TextFiles.OrderBy(p => p.Title).ToListAsync();
        }

        public async Task<TextFile> GetByIdAsync(int id)
        {
            return await _context.TextFiles.FindAsync(id);
        }

        public async Task AddAsync(TextFile textFile)
        {
            _context.TextFiles.Add(textFile);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TextFile textFile)
        {
            var existPerson = await _context.TextFiles.FindAsync(textFile.Id);
            _context.Entry(existPerson).CurrentValues.SetValues(textFile);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var person = await _context.TextFiles.FindAsync(id);
            _context.Remove(person);
            await _context.SaveChangesAsync();
        }
    }
}