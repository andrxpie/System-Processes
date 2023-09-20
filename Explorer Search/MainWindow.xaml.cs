using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

namespace Explorer_Search
{
    public class Result
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int DuplicatesCount { get; set; } = 0;
    }

    public partial class MainWindow : Window
    {
        ViewModel vm = new();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private async void SearchButton(object sender, RoutedEventArgs e)
        {
            Result res = await Search();
            resultList.Items.Add(res);
        }

        private async Task<Result> Search()
        {
            Result res = new();
            await Task<Result>.Run(() =>
            {
                
            });

            return res;
        }

        private void ChooseButton(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog ofd = new()
            {
                IsFolderPicker= true
            };

            if(ofd.ShowDialog() == CommonFileDialogResult.Ok ) { vm.To = ofd.FileName; }
        }
    }
}
