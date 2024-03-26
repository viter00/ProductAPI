using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Endpoints
{
    public class ResponseError
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("success")]
        public bool Success {  get; set; }
        
        public static ResponseError Get(bool success, string message)
        {
            return new ResponseError { Message = message, Success = success };
        }
    }
}
