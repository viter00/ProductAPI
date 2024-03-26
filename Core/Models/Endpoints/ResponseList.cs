using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Endpoints
{
    public class ResponseList<T>
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
        [JsonProperty("data")]
        public List<T> Data { get; set; }
    }
}
