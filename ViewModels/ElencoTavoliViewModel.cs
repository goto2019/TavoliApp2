using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using TavoliApp.AppViews;
using TavoliApp.Models;
using TavoliApp.Views;

namespace TavoliApp.ViewModels
{
    public class ElencoTavoliViewModel
    {
        private readonly HttpClient _http;
        private readonly IServiceProvider _serviceProvider;

        public string NomeOperatore { get; }

        public ObservableCollection<TavoloDto> Tavoli { get; } = new();

        public ICommand LogoutCommand { get; }

        public ElencoTavoliViewModel(HttpClient http, string nomeOperatore, IServiceProvider serviceProvider)
        {
            _http = http;
            NomeOperatore = nomeOperatore;
            _serviceProvider = serviceProvider;

            LogoutCommand = new Command(EseguiLogout);
        }

        public async Task CaricaTavoli()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<TavoliResponseDto>("api/Tavoli/GetTavoliOccupatiSummar");
                if (response?.Tavoli != null)
                {
                    Tavoli.Clear();
                    foreach (var tavolo in response.Tavoli)
                        Tavoli.Add(tavolo);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Errore", "Errore caricamento tavoli", "OK");
#if DEBUG
                System.Diagnostics.Debug.WriteLine(ex.Message);
#endif
            }
        }

        public void GestisciSelezioneTavolo(TavoloDto tavolo)
        {
            if (tavolo != null)
            {
                Application.Current.MainPage.Navigation.PushAsync(new TavoloPage(tavolo));
            }
        }

        private void EseguiLogout()
        {
            Application.Current.MainPage = new NavigationPage(new LoginPage(_serviceProvider));
        }
    }
}
