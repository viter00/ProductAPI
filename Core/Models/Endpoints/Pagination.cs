using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Endpoints
{
    public class Pagination
    {
        [JsonProperty("total")]
        public int Total { get; set; }
        [JsonProperty("page")]
        public int Page { get; set; }
        [JsonProperty("limit")]
        public int Limit { get; set; }
    }
}
