using Microsoft.Maui.Controls;
using System;
using TavoliApp.Models;
using TavoliApp.ViewModels;

namespace TavoliApp.Views
{
    public partial class TavoloPage : ContentPage
    {
        private readonly TavoloPageViewModel _viewModel;

        public TavoloPage(TavoloDto tavolo)
        {
            InitializeComponent();

            _viewModel = new TavoloPageViewModel(tavolo);
            BindingContext = _viewModel;

            // Scroll automatico verso l'ultimo articolo inserito
            _viewModel.ScrolledToLastItemRequested += (s, e) =>
            {
                if (ArticoliCollection?.ItemsSource is System.Collections.IList lista && lista.Count > 0)
                {
                    ArticoliCollection.ScrollTo(lista[lista.Count - 1], position: ScrollToPosition.End, animate: true);
                }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        protected override bool OnBackButtonPressed()
        {
            // Disabilita il tasto fisico "indietro"
            return true;
        }
    }
}
