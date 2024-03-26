using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class CustomException : BaseException
    {
        public CustomException(string message)
            : base(message)
        {
        }

        public CustomException(string message, int code) : base(message, code) { }

        public CustomException(string message, int code, Exception exception) : base(message, code, exception) { }
    }
}
