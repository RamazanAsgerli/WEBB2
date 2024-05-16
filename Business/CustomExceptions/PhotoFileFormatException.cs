using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CustomExceptions
{
    public class PhotoFileFormatException : Exception
    {
        public PhotoFileFormatException(string? message, string v) : base(message)
        {
            V = v;
        }

        public string V { get; }
    }
}
