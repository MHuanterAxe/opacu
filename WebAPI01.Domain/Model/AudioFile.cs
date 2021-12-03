using System;

namespace WebAPI01.Domain.Model
{
    public class AudioFile : File
    {
        public int Length { get; set; }
        
        public int Bitrate { get; set; }
    }
}