
using System.Collections.Generic;
using System.Linq;

namespace TavoliApp.Models
{
    public class TavoloDto
    {
        public string NumeroTavolo { get; set; }
        public string Stato { get; set; }
        public string PrimaRigaTotaleTavolo { get; set; }
        public string SecondaRigaIntestazioni { get; set; }
        public List<string> RigheExtra { get; set; } = new List<string>();
        public string OrarioAperturaTavolo { get; set; }
        public List<Articolo> Articolis { get; set; } = new List<Articolo>();

        // Valore totale da calcolo articoli (fallback)
        public decimal Totale => Articolis?.Sum(a => a.PrezzoUnitario) ?? 0;

        // Valore totale come ricevuto dal JSON
        public string TotaleStringa { get; set; }
    }
}
