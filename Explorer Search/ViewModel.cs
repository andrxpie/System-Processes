using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer_Search
{
    class ViewModel : INotifyPropertyChanged
    {
        public string To { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
