using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ThreadPool
{
    class Stat
    {
        public int Words { get; set; } = 0;
        public int Lines { get; set; } = 0;
        public int Punctuation { get; set; } = 0;
    }

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            Stat statistic = new();
            string[] files = Directory.GetFiles(tbx.Text, "*.txt");
            Thread[] threads = new Thread[files.Length];

            for (int i = 0; i < files.Length; i++)
            {
                threads[i].Start(File.ReadAllText(files[i]));

            }

            for (int i = 0; i < files.Length; i++)
                threads[i].Join();
        }

        static void TextAnalyze(object stat)
        {
            lock (typeof(Stat))
            {
                ((Stat)stat).Lines = 
            }
        }
    }
}