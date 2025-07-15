using System.Net.Http;
using System.Windows.Input;
using TavoliApp.Models;
using Microsoft.Maui.Controls;

namespace TavoliApp.ViewModels
{
    public class TavoloPageViewModel : BindableObject
    {
        public TavoloDto Tavolo { get; }
        public string TitoloPagina => $"Tavolo {Tavolo?.NumeroTavolo}";
        public ICommand IndietroCommand { get; }

        private readonly HttpClient _httpClient;
        private readonly string _operatore;
        private readonly IServiceProvider _serviceProvider;

        public TavoloPageViewModel(TavoloDto tavolo, HttpClient httpClient, string operatore, IServiceProvider serviceProvider)
        {
            Tavolo = tavolo;
            _httpClient = httpClient;
            _operatore = operatore;
            _serviceProvider = serviceProvider;

            IndietroCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            });
        }
    }
}
