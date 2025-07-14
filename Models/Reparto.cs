
using System.Collections.ObjectModel;

namespace TavoliApp.Models;

public class Reparto
{
    public string Nome { get; set; }
    public ObservableCollection<Articolo> Articoli { get; set; } = new();
}
