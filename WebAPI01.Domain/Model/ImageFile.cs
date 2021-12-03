using System;

namespace WebAPI01.Domain.Model
{
    public class ImageFile
    {
        public Guid Id { get; set; }
        
        public string Resolution { get; set; }
        
        public string ColorPalette { get; set; }
        
        public Guid FileId { get; set; }
        public File File { get; set; }
    }
}