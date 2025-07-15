using Microsoft.Maui.Controls;
using System;
using System.Net.Http;
using TavoliApp.Models;
using TavoliApp.ViewModels;

namespace TavoliApp.Views
{
    public partial class ElencoTavoliPage : ContentPage
    {
        private readonly ElencoTavoliViewModel _viewModel;

        public ElencoTavoliPage(HttpClient httpClient, string operatore, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _viewModel = new ElencoTavoliViewModel(httpClient, operatore, serviceProvider);
            BindingContext = _viewModel;
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count > 0)
            {
                var tavoloSelezionato = e.CurrentSelection[0] as TavoloDto;
                _viewModel?.GestisciSelezioneTavolo(tavoloSelezionato);
            }
        }
    }
}

