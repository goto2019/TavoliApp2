
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace TavoliApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string greeting;

        public ICommand SayHelloCommand { get; }

        public MainViewModel()
        {
            SayHelloCommand = new RelayCommand(() =>
            {
                Greeting = "Ciao Alfonso!";
            });
        }
    }
}
