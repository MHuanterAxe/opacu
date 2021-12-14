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
        public Guid UserId{ get; set; }
        public virtual User User { get; set; }
    }
}