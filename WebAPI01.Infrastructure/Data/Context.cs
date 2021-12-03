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
        
        public DbSet<File> Files { get; set; }

        public DbSet<ImageFile> ImageFiles { get; set; }
        
        public DbSet<VideoFile> VideoFiles { get; set; }
        
        public DbSet<TextFile> TextFiles { get; set; }
        
        public  DbSet<AudioFile> AudioFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<File>()
                .HasOne(u => u.User)
                .WithMany(f => f.Files)
                .HasForeignKey(f => f.UserId)
                .IsRequired();

            modelBuilder.Entity<TextFile>()
                .HasOne(f => f.File)
                .WithOne(f => f.TextFile)
                .HasForeignKey<TextFile>(f => f.FileId)
                .IsRequired();
            
            modelBuilder.Entity<ImageFile>()
                .HasOne(f => f.File)
                .WithOne(f => f.ImageFile)
                .HasForeignKey<ImageFile>(f => f.FileId)
                .IsRequired();
            
            modelBuilder.Entity<VideoFile>()
                .HasOne(f => f.File)
                .WithOne(f => f.VideoFile)
                .HasForeignKey<VideoFile>(f => f.FileId)
                .IsRequired();
            
            modelBuilder.Entity<AudioFile>()
                .HasOne(f => f.File)
                .WithOne(f => f.AudioFile)
                .HasForeignKey<AudioFile>(f => f.FileId)
                .IsRequired();
        }
    }
}
