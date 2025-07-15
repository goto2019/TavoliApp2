using Microsoft.Maui.Controls;
using Microsoft.Maui.Dispatching;

namespace TavoliTestCollectionView.Views
{
    public partial class TestPage : ContentPage
    {
        public TestPage()
        {
            InitializeComponent();
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("CLICK RICEVUTO");
            if (e.CurrentSelection.FirstOrDefault() is string tavolo)
            {

                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Click", $"Hai selezionato: {tavolo}", "OK");
                });
            }

            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
