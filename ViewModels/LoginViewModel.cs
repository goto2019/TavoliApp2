using Microsoft.Maui.Controls;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Storage;
using TavoliApp.AppViews;
using TavoliApp.Views;

namespace TavoliApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly IServiceProvider _serviceProvider;

        private string _ip;
        private string _password;
        private string _messaggio;

        public string Ip
        {
            get => _ip;
            set { _ip = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public string Messaggio
        {
            get => _messaggio;
            set { _messaggio = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            LoginCommand = new Command(async () => await EseguiLoginAsync());
        }

        private async Task EseguiLoginAsync()
        {
            Messaggio = "";

            if (string.IsNullOrWhiteSpace(Ip) || string.IsNullOrWhiteSpace(Password))
            {
                Messaggio = "Inserisci IP e Password.";
                return;
            }

            if (Password != "1234")
            {
                Messaggio = "Password errata.";
                return;
            }

            try
            {
                // Salva l'IP corrente
                Preferences.Set("UltimoIp", Ip);

                var http = new HttpClient { BaseAddress = new Uri($"http://{Ip}:50000") };

                string nomeOperatore = "OPERATORE"; // oppure recupera dinamicamente

                // Passa IP, nome operatore e serviceProvider
                var elencoTavoliPage = new ElencoTavoliPage(http, nomeOperatore, _serviceProvider);

                App.Current.MainPage = new NavigationPage(elencoTavoliPage);
            }
            catch (Exception ex)
            {
                Messaggio = "Errore di connessione.";
#if DEBUG
                System.Diagnostics.Debug.WriteLine(ex);
#endif
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
