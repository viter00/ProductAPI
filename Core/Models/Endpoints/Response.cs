using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Endpoints
{
    public class Response<T>
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
