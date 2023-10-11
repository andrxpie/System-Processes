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
        public static int DuplicatesCount { get; set; } = 0;

        public override string ToString()
        {
            return FileName;
        }
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
            List<Result> res = await Search(searchWord.Text);
            foreach (var result in res)
                foundFiles.Items.Add(result);
        }

        private async Task<List<Result>> Search(string text)
        {
            List<Result> res = new();
            await Task<List<Result>>.Run(async () =>
            {
                List<string> files = Directory.GetFiles(vm.To, "*.txt", SearchOption.AllDirectories).ToList();

                foreach (string file in files)
                {
                    int count = await SearchWord(file, text);
                    if (count > 0)
                    {
                        res.Add(new Result { FileName = System.IO.Path.GetFileName(file), FilePath = file } );
                        Result.DuplicatesCount += count;
                    }
                }
            });

            return res;
        }

        private async Task<int> SearchWord(string filepath, string text)
        {
            int duplicates = 0;

            duplicates += (await File.ReadAllTextAsync(filepath)).Split(text).Count() - 1;

            return duplicates;
        }

        private void ChooseButton(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog ofd = new()
            {
                IsFolderPicker = true
            };

            if(ofd.ShowDialog() == CommonFileDialogResult.Ok ) { vm.To = ofd.FileName; }
        }

        private void FileSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            resultFilePath.Text = ((Result)foundFiles.SelectedItem).FilePath;
            resultWordDuplicates.Text = Result.DuplicatesCount.ToString();
        }
    }
}