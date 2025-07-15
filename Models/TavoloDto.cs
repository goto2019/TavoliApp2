using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json.Serialization;

namespace TavoliApp.Models
{
    public class TavoloDto
    {
        [JsonPropertyName("numeroTavolo")]
        public string NumeroTavolo { get; set; }

        [JsonPropertyName("stato")]
        public string Stato { get; set; }

        [JsonPropertyName("orarioAperturaTavolo")]
        public string OrarioAperturaTavolo { get; set; }

        [JsonPropertyName("orarioChiusuraTavolo")]
        public string OrarioChiusuraTavolo { get; set; }

        [JsonPropertyName("articolis")]
        public List<Articolo> Articolis { get; set; } = new();

        [JsonPropertyName("totale")]
        public string TotaleStringaRaw { get; set; }

        [JsonIgnore]
        public decimal Totale
        {
            get
            {
                // Se gli articoli esistono e hanno prezzi > somma
                if (Articolis != null && Articolis.Any())
                    return Articolis.Sum(a => a.PrezzoUnitario * a.Quantita);

                // Altrimenti, prova a leggere il valore da TotaleStringaRaw
                if (decimal.TryParse(TotaleStringaRaw, NumberStyles.Any, CultureInfo.GetCultureInfo("it-IT"), out var valore))
                    return valore;

                return 0m;
            }
        }

        [JsonIgnore]
        public string TotaleStringa
        {
            get => Totale.ToString("F2", CultureInfo.GetCultureInfo("it-IT"));
        }

        [JsonIgnore]
        public bool IsOccupato => Stato?.Trim().ToLowerInvariant() == "occupato";

        [JsonIgnore]
        public string OrarioAperturaShort
        {
            get
            {
                if (DateTime.TryParse(OrarioAperturaTavolo, CultureInfo.InvariantCulture, out var orario))
                    return orario.ToString("HH:mm");
                return string.Empty;
            }
        }
    }
}
