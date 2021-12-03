using System;

namespace WebAPI01.Domain.Model
{
    public class TextFile : File
    {
        public int SymbolCount { get; set; }
        
        public string Encoding { get; set; }
    }
}