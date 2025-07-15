using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TavoliApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string nomeProprieta = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomeProprieta));
        }
    }
}
