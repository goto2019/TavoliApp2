using Microsoft.Maui.Controls;
using System.Net.Http;
using TavoliApp.Models;
using TavoliApp.ViewModels;

namespace TavoliApp.Views
{
    public partial class TavoloPage : ContentPage
    {
        public TavoloPage(TavoloDto tavolo, HttpClient httpClient, string operatore, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            BindingContext = new TavoloPageViewModel(tavolo, httpClient, operatore, serviceProvider);
        }
    }
}
