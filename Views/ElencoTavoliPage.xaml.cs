using Microsoft.Maui.Controls;
using System;
using System.Net.Http;
using TavoliApp.ViewModels;

namespace TavoliApp.Views
{
    public partial class ElencoTavoliPage : ContentPage
    {
        private readonly ElencoTavoliViewModel _viewModel;

        public ElencoTavoliPage(HttpClient httpClient, string nomeOperatore, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _viewModel = new ElencoTavoliViewModel(httpClient, nomeOperatore, serviceProvider);
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.CaricaTavoli();
        }

        private void OnLogoutClicked(object sender, EventArgs e)
        {
            _viewModel.LogoutCommand.Execute(null);
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count > 0 && e.CurrentSelection[0] is Models.TavoloDto tavolo)
            {
                _viewModel.GestisciSelezioneTavolo(tavolo);
            }
        }
    }
}
