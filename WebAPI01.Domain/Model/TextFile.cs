using System;

namespace WebAPI01.Domain.Model
{
    public class TextFile
    {
        public Guid Id { get; set; }

        public int SymbolCount { get; set; }
        
        public string Encoding { get; set; }
        
        public Guid FileId { get; set; }
        public File File { get; set; }
    }
}