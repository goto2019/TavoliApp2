using System.Collections.Generic;
using TavoliApp.Models;

namespace TavoliApp.ApiClients
{
    public class ElencoTavoliResponse
    {
        public List<TavoloDto> Tavoli { get; set; } = new();
        public int NumeroMassimoTavoli { get; set; }
    }
}
