using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TavoliApp.Models;

namespace TavoliApp.ViewModels
{
    public class TavoloPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private TavoloDto _tavolo;
        public TavoloDto Tavolo
        {
            get => _tavolo;
            set
            {
                _tavolo = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Articolo> ArticoliOrdinati { get; set; } = new();

        public ICommand AggiungiArticoloCommand { get; }
        public ICommand RimuoviArticoloCommand { get; }
        public ICommand AggiungiArticoloManualeCommand { get; }
        public ICommand AggiungiNotaArticoloCommand { get; }
        public ICommand ChiudiTavoloCommand { get; }

        public event EventHandler ScrolledToLastItemRequested;

        public TavoloPageViewModel(TavoloDto tavolo)
        {
            Tavolo = tavolo;
            ArticoliOrdinati = new ObservableCollection<Articolo>(tavolo.Articolis ?? new List<Articolo>());

            AggiungiArticoloCommand = new Command<Articolo>(AggiungiArticolo);
            RimuoviArticoloCommand = new Command<Articolo>(RimuoviArticolo);
            AggiungiArticoloManualeCommand = new Command(AggiungiArticoloManuale);
            AggiungiNotaArticoloCommand = new Command(AggiungiNotaArticolo);
            ChiudiTavoloCommand = new Command(ChiudiTavolo);
        }

        public void OnAppearing()
        {
            ScrolledToLastItemRequested?.Invoke(this, EventArgs.Empty);
        }

        private void AggiungiArticolo(Articolo articolo)
        {
            if (articolo != null)
            {
                ArticoliOrdinati.Add(articolo);
                ScrolledToLastItemRequested?.Invoke(this, EventArgs.Empty);
            }
        }

        private void RimuoviArticolo(Articolo articolo)
        {
            if (articolo != null && ArticoliOrdinati.Contains(articolo))
            {
                ArticoliOrdinati.Remove(articolo);
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    

        private void AggiungiArticoloManuale()
        {
            // Esempio: aggiunge un articolo fittizio
            var nuovo = new Articolo
            {
                Codice = "MANUALE",
                Denominazione = "Articolo Inserito Manualmente",
                PrezzoUnitario = 0.0m
            };
            ArticoliOrdinati.Add(nuovo);
            ScrolledToLastItemRequested?.Invoke(this, EventArgs.Empty);
        }

    

        private void AggiungiNotaArticolo()
        {
            if (ArticoliOrdinati.Any())
            {
                ArticoliOrdinati[^1].Denominazione += " (nota)";
                ScrolledToLastItemRequested?.Invoke(this, EventArgs.Empty);
            }
        }

    

        private void ChiudiTavolo()
        {
            // Logica semplificata per chiusura tavolo
            ArticoliOrdinati.Clear();
        }

    }
}