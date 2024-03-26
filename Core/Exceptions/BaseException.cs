using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    [Serializable]
    public abstract class BaseException : Exception
    {
        private const int DEFAULT_CODE = 999;

        public int Code { get; set; }
        public BaseException()
        {
            Code = DEFAULT_CODE;
        }

        public BaseException(string message) : base(message) { }
        public BaseException(string message, int code) : base(message) => Code = code;


        public BaseException(string message, Exception exception) : base(message, exception) { }

        public BaseException(string message, int code, Exception exception) : base(message, exception)
        {
            Code = code;
        }
    }
}
