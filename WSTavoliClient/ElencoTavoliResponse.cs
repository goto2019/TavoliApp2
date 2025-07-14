namespace TavoliApp.WSTavoliClient
{
    public class ElencoTavoliResponse
    {
        public List<TavoliOccupati> Tavoli { get; set; } = new();
        public int NumeroMassimoTavoli { get; set; }
    }
}
