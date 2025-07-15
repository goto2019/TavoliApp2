namespace TavoliApp.Models
{
    public class ElementoMenu
    {
        // Nome visualizzato nel pulsante
        public string Nome { get; set; }

        // Codice (può essere utile per reparti o articoli)
        public string Codice { get; set; }

        // Tipo: ad es. "Reparto", "Articolo", "Manuale"
        public string Tipo { get; set; }

        // Prezzo (se è un articolo)
        public decimal Prezzo { get; set; }

        // Eventuale riferimento ad altro oggetto (opzionale)
        public object Tag { get; set; }

        // Proprietà utile per distinguere rapidamente se è un articolo
        public bool IsArticolo
        {
            get => Tipo?.ToUpper() == "ARTICOLO" || Tipo?.ToUpper() == "MANUALE";
            set { /* setter vuoto per evitare CS0200, MAI usato, serve solo per compatibilità binding */ }
        }
    }
}
