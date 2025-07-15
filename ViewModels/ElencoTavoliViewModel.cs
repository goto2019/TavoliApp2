using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using TavoliApp.Models;
using TavoliApp.Views;

namespace TavoliApp.ViewModels
{
    public class ElencoTavoliViewModel
    {
        private readonly HttpClient _httpClient;
        private readonly string _operatore;
        private readonly IServiceProvider _serviceProvider;

        public ObservableCollection<TavoloDto> Tavoli { get; } = new();

        public ICommand LogoutCommand { get; }

        public ElencoTavoliViewModel(HttpClient httpClient, string operatore, IServiceProvider serviceProvider)
        {
            _httpClient = httpClient;
            _operatore = operatore;
            _serviceProvider = serviceProvider;

            LogoutCommand = new Command(async () => await Logout());

            _ = CaricaTavoli();
        }

        private async Task Logout()
        {
            await Application.Current.MainPage.DisplayAlert("Logout", "Sei stato disconnesso", "OK");
            Application.Current.MainPage = new NavigationPage(new AppViews.LoginPage(_serviceProvider));
        }

        private async Task CaricaTavoli()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Tavoli/GetTavoloDtoSummary");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var lista = JsonSerializer.Deserialize<List<TavoloDto>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    Tavoli.Clear();
                    foreach (var tavolo in lista)
                        Tavoli.Add(tavolo);

                    System.Diagnostics.Debug.WriteLine($"Caricati {Tavoli.Count} tavoli");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Errore", "Errore nel caricamento tavoli", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Errore", ex.Message, "OK");
            }
        }

        public void GestisciSelezioneTavolo(TavoloDto tavolo)
        {
            if (tavolo == null)
                return;

            Application.Current.MainPage.Navigation.PushAsync(new TavoloPage(tavolo, _httpClient, _operatore, _serviceProvider));
        }
    }
}
