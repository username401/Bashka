using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Bashka
{
    internal class ViewModel : BaseViewModel
    {
        public ViewModel()
        {
            ClearText = new RelayCommand(ExecuteClearText, CanExecuteClearText);
            DeleteStringis = new RelayCommand(ExecuteDeleteStringis, CanExecuteDeleteStringis);
            selectedStringis = Stringis.FirstOrDefault();
        }

        public AnotherViewModel AnotherVM { get; set; } = new AnotherViewModel();

        private string selectedStringis;
        public string SelectedStringis
        {
            get { return selectedStringis; }
            set
            {
                selectedStringis = value;
                OnPropertyChanged(nameof(SelectedStringis));
            }
        }

        private string text = "drocheniy Huy";
        public string Text
        { 
            get { return text; } 
            set 
            {  
                text = value; 
                OnPropertyChanged("Text");
            }
        }

        private int i = 0;
        private ICommand editText;
        public ICommand EditText
        {
            get 
            {
                return editText ??
                   (editText = new RelayCommand(obj =>
                   {
                      Text = (i ++).ToString() + "Harley Davidson";
                   }));
            }
        }
        //private ICommand clearText;
        public ICommand ClearText { get; }
        private bool CanExecuteClearText (object parameter)
        {
            if (Text == string.Empty) 
                return false;

            return true; 
        }
        
        private void ExecuteClearText (object parameter)
        {
            Text = string.Empty;
        }

        private ObservableCollection<string> strigis = new ObservableCollection<string> { "Стринги бабули", "Стринги дедули", "Стринги сабули", "Стринг чашушули" };
        public ObservableCollection<string> Stringis
        {
            get
            {
                return strigis; 
            }
            set
            {
                strigis = value;
            }
        }

        public ICommand DeleteStringis { get; }
        private bool CanExecuteDeleteStringis (object parameter)
        {
            if (Stringis.Count == 0)
                return false;
            return true;
        }
        private void ExecuteDeleteStringis (Object parameter)
        {
            strigis.Remove(SelectedStringis);
            if (Stringis.Count > 0)
                SelectedStringis = Stringis.FirstOrDefault();
        }
    }
}
