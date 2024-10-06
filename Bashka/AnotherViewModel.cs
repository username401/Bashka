using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bashka
{
    internal class AnotherViewModel : BaseViewModel
    {
        
        public AnotherViewModel() 
        { 

        }

        private string anotherText = "Милый котик";
        public string AnotherText
        {
            get { return anotherText; }
            set
            {
                anotherText = value;
                OnPropertyChanged("AnotherText");
            }
        }
    }
}
