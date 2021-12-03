using System;

namespace WebAPI01.Domain.Model
{
    public class TextFile
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string KeyWords { get; set; }
        
        public string ContentType { get; set; }

        public float Size { get; set; }

        public string Path { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }
    }
}