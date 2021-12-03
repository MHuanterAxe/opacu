using System;

namespace WebAPI01.Domain.Model
{
    public class VideoFile
    {
        public Guid Id { get; set; }

        public string Resolution { get; set; }
        
        public int Length { get; set; }
        
        public int Bitrate { get; set; }
        
        public string Encoding { get; set; }
        
        public Guid FileId { get; set; }
        public File File { get; set; }
    }
}