using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI01.Domain;
using WebAPI01.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace TestProject1
{
    public class TestHelper
    {
        private readonly Context _context;
        public TestHelper()
        {
            var builder = new DbContextOptionsBuilder<Context>();
            builder.UseInMemoryDatabase(databaseName: "PersonDB");

            var dbContextOptions = builder.Options;
            _context = new Context(dbContextOptions);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        public PersonRepository PersonRepository
        {
            get
            {
                return new PersonRepository(_context);
            }
        }
    }
}
