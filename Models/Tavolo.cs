
namespace TavoliApp.Models;

public class Tavolo
{
    public int Numero { get; set; }
    public double Importo { get; set; }
    public string Stato { get; set; } = "Libero";
}
