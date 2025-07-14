
using System.Collections.Generic;

namespace TavoliApp.Models
{
    public class TavoliResponseDto
    {
        public List<TavoloDto> Tavoli { get; set; }
        public int NumeroMassimoTavoli { get; set; }
    }
}
