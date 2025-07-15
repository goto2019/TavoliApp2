using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TavoliApp.Models
{
    public class TavoliResponseDto
    {
        [JsonPropertyName("tavoli")]
        public List<TavoloDto> Tavoli { get; set; }

        [JsonPropertyName("numeroMassimoTavoli")]
        public int NumeroMassimoTavoli { get; set; }
    }
}
