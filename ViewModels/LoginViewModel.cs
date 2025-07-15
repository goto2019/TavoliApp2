using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using TavoliApp.AppViews;
using TavoliApp.Views;

namespace TavoliApp.ViewModels
{
    public class LoginViewModel
    {
        private readonly IServiceProvider _serviceProvider;

        public string Ip { get; set; }

        public string Password { get; set; } = "1234";

        public ICommand LoginCommand { get; }
        public ICommand ClearIpCommand { get; }

        public LoginViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            LoginCommand = new Command(async () => await EseguiLogin());
            ClearIpCommand = new Command(CancellaIp);

            // Ripristina l’ultimo IP usato
            Ip = Preferences.Get("UltimoIp", string.Empty);
        }

        private async Task EseguiLogin()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Ip))
                {
                    await Application.Current.MainPage.DisplayAlert("Errore", "Inserisci l'indirizzo IP", "OK");
                    return;
                }

                if (Password != "1234")
                {
                    await Application.Current.MainPage.DisplayAlert("Errore", "Password errata", "OK");
                    return;
                }

                var baseUrl = $"http://{Ip}:50000/";
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri(baseUrl),
                    Timeout = TimeSpan.FromSeconds(10)
                };

                // Salva l’IP usato
                Preferences.Set("UltimoIp", Ip);

                // Vai alla schermata ElencoTavoli
                Application.Current.MainPage = new NavigationPage(
                    new ElencoTavoliPage(httpClient, "Operatore", _serviceProvider));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Errore imprevisto", $"Impossibile collegarsi al server.\n{ex.Message}", "OK");
            }
        }

        private void CancellaIp()
        {
            Preferences.Remove("UltimoIp");
            Ip = string.Empty;
            Application.Current.MainPage.DisplayAlert("Reset", "IP cancellato", "OK");
        }
    }
}
