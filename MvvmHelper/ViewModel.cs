using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvvmHelper
{
    /// <summary>
    /// Базовый класс модели представления.
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
