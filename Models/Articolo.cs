
namespace TavoliApp.Models
{
    public class Articolo
    {
        public string Codice { get; set; }
        public string Denominazione { get; set; }
        public decimal PrezzoUnitario { get; set; }
        public int Quantita { get; set; }
        public decimal TotaleEuro => PrezzoUnitario * Quantita;
        public string KgOPacchi { get; set; }
        public string Pz { get; set; }
        public string CodiceIva { get; set; }
        public string CodiceReparto { get; set; }
        public string Nonserve { get; set; }
        public string ComandaSiNo { get; set; }
        public string Padre { get; set; }
        public string CodiceCategoria { get; set; }
        public string NomeOperatore { get; set; }
        public string Listino { get; set; }
        public string Sconto { get; set; }
        public string TipoDiSconto { get; set; }
        public string GiornoEOra { get; set; }
    }
}
