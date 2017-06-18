using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektSemi.Models
{
    using Newtonsoft.Json;    
    public class Dom
    {
        [JsonProperty(PropertyName = "rodzaj")]
        public string Rodzaj { get; set; }
        [JsonProperty(PropertyName = "garaż")]
        public string Garaż { get; set; }
        [JsonProperty(PropertyName = "taras")]
        public string Taras { get; set; }
        [JsonProperty(PropertyName = "iloscpieter")]
        public string IloscPieter { get; set; }
        [JsonProperty(PropertyName = "balkon")]
        public string Balkon { get; set; }

        public Dom()
        { }
    }
}