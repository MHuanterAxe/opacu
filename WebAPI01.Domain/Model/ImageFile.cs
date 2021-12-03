using System;

namespace WebAPI01.Domain.Model
{
    public class ImageFile : File
    {
        public string Resolution { get; set; }
        
        public string ColorPalette { get; set; }
    }
}