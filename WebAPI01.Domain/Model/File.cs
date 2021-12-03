using System;

namespace WebAPI01.Domain
{
    public class File
    {
        public Guid Id { get; set; }
        
        public float Size { get; set; }
        
        public string Path { get; set; }
        
        public string Type { get; set; }
        
        public Person PersonId { get; set; }
    }
}