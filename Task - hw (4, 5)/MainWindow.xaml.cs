using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Task___hw__4__5_
{
    public partial class MainWindow : Window
    {
        public string source { get; set; }
        public string copyDirectory { get; set; }
        private IEnumerable<string> sourceFilesPaths { get; set; }
        private List<string> sourceFiles { get; set; } = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if(sourceTBX.Text != "")
                    source = sourceTBX.Text;

                if(copyTBX.Text != "")
                    copyDirectory = copyTBX.Text;

                sourceFilesPaths = Directory.GetFiles(source, "*.*", SearchOption.AllDirectories);

                foreach (var path in sourceFilesPaths)
                    sourceFiles.Add(System.IO.Path.GetFileName(path));

                IEnumerable<string> duplicateFiles;
                Task.Run(() => 
                {
                    duplicateFiles = sourceFiles.GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x.Key);

                    if (duplicateFiles.Any())
                    {
                        File.Create("log.txt").Close();
                        
                        foreach(var file in duplicateFiles)
                        {
                            File.WriteAllText("log.txt", file + "\n");

                            if(!Directory.Exists(copyDirectory))
                                Directory.CreateDirectory(copyDirectory);
                            File.Copy(sourceFilesPaths.Where(x => System.IO.Path.GetFileName(x) == file).FirstOrDefault(), System.IO.Path.Combine(copyDirectory, file));
                        }
                    }
                });

                if(CBX.IsChecked == true)
                    Process.Start("notepad.exe", "files.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}