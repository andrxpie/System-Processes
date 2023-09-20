using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Async_Await___task_2
{
    public partial class MainWindow : Window
    {
        ViewModel vm = new();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void FromButton(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new();
            if(ofd.ShowDialog() == true ) { vm.from = ofd.FileName; }
        }

        private void ToButton(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog ofd = new()
            {
                IsFolderPicker= true,
            };

            if(ofd.ShowDialog() == CommonFileDialogResult.Ok ) { vm.to = ofd.FileName + "\\" + System.IO.Path.GetFileName(vm.from); }
        }

        private async void CopyClickButton(object sender, RoutedEventArgs e)
        {
            await CopyClickAsync();
        }

        private async Task CopyClickAsync()
        {
            await Task.Run(() =>
            {
                File.Copy(vm.from, vm.to);
            });
        }
    }
}