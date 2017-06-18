using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektSemi.Models
{
    using Newtonsoft.Json;
    public class Nieruchomosci
    {
        
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "nazwa")]
        public string Nazwa { get; set; }
        [JsonProperty(PropertyName = "kategoria")]
        public Kategoria Kategoria { get; set; }
        public string SelectedCategory { get; set; }
        [JsonProperty(PropertyName = "adres")]
        public string Adres { get; set; }
        [JsonProperty(PropertyName = "cena")]
        public string Cena { get; set; }
        [JsonProperty(PropertyName = "powierzchnia")]
        public string Powierzchnia { get; set; }
        [JsonProperty(PropertyName = "czySprzedane")]
        public bool CzySprzedane { get; set; }
        [JsonProperty(PropertyName = "opis")]
        public Opis Opis { get; set; }
        [JsonProperty(PropertyName = "isComplete")]
        public bool Completed { get; set; }

        public Nieruchomosci()
        { }
    }
}