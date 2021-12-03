using System;

namespace WebAPI01.Domain.Model
{
    public class AudioFile
    {
        public Guid Id { get; set; }
        
        public int Length { get; set; }
        
        public int Bitrate { get; set; }
        
        public Guid FileId { get; set; }
        public File File { get; set; }
    }
}