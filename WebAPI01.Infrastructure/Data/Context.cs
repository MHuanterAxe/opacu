using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI01.Domain;
using Microsoft.EntityFrameworkCore;
using WebAPI01.Domain.Model;

namespace WebAPI01.Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        
        public DbSet<ImageFile> ImageFiles { get; set; }
        
        public DbSet<VideoFile> VideoFiles { get; set; }
        
        public DbSet<TextFile> TextFiles { get; set; }
        
        public  DbSet<AudioFile> AudioFiles { get; set; }

    }
}
