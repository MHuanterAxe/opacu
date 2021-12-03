using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI01.Domain.Model
{
    public class File
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }

        public string Format { get; set; }

        public float Size { get; set; }

        public string Path { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }
        public int UserId{ get; set; }
        public User User { get; set; }
        
        public TextFile TextFile { get; set; }
        public ImageFile ImageFile { get; set; }
        public VideoFile VideoFile { get; set; }
        public AudioFile AudioFile { get; set; }
        
    }
}