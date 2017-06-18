using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektSemi.Models
{
    public class Opis
    {
        public String opis { get; set; }

        public Dictionary<string, string> Parameters { get; set; }

        public Opis()
        {
        }

        public Opis(Kategoria category)
        {
            Parameters = new Dictionary<string, string>();
            switch (category)
            {
                case Kategoria.Dom:
                    this.Parameters.Add("Rodzaj", "");
                    this.Parameters.Add("Garaż", "");
                    this.Parameters.Add("Taras", "");
                    this.Parameters.Add("Ilość pięter", "");
                    this.Parameters.Add("Balkon", "");
                    break;
                case Kategoria.Lokal:
                    this.Parameters.Add("Użytkowy", "");
                    this.Parameters.Add("Cel", "");
                    this.Parameters.Add("Asortyment", "");
                    break;
                case Kategoria.Magazyn:
                    this.Parameters.Add("Sprzęt", "");
                    break;
                case Kategoria.Mieszkanie:
                    this.Parameters.Add("Piętro", "");
                    this.Parameters.Add("Balkon", "");
                    break;

            }
        }
        
    }
}