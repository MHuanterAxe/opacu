using System;

namespace WebAPI01.Domain.Model
{
    public class VideoFile : File
    {
        public string Resolution { get; set; }
        
        public int Length { get; set; }
        
        public int Bitrate { get; set; }
        
        public string Encoding { get; set; }
    }
}