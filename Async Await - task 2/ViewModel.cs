using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async_Await___task_2
{
    public class ViewModel : INotifyPropertyChanged
    {
        public string from { get; set; } = "";
        public string to { get; set; } = "";

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
