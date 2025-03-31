using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChroniclesOnlineTools.Models
{
    public class ArmorItem
    {
        [JsonProperty("id")]
        public string? Id { get; set; }
        [JsonProperty("name")]
        public string? Name { get; set; }
        [JsonProperty("setId")]
        public string? SetId { get; set; }
        [JsonProperty("defence")]
        public int? Defence { get; set; }
    }
}
