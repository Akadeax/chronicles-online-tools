using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChroniclesOnlineTools.Models
{
    public class ItemDataContainer
    {
        [JsonProperty("armorSets")]
        public List<ArmorSet>? ArmorSets { get; set; }
        [JsonProperty("armorItems")]
        public List<ArmorItem>? ArmorItems { get; set; }
        [JsonProperty("weaponItems")]
        public List<WeaponItem>? WeaponItems { get; set; }
    }
}
