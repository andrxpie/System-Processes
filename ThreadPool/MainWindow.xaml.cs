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
        }

        private void SubmitButton(object sender, RoutedEventArgs e)
        {
            Stat statistic = new();
            string[] files = Directory.GetFiles(tbx.Text, "*.txt");
            Thread[] threads = new Thread[files.Length];

            for (int i = 0; i < files.Length; i++)
                threads[i] = new Thread(TextAnalyze);

            for (int i = 0; i < files.Length; i++)
                threads[i].Start(new KeyValuePair<Stat, string>(statistic, files[i]));

            for (int i = 0; i < files.Length; i++)
                threads[i].Join();

            ++statistic.Words;
            ++statistic.Lines;

            wordsTb.Text = statistic.Words.ToString();
            linesTb.Text = statistic.Lines.ToString();
            punctuationTb.Text = statistic.Punctuation.ToString();
        }

        static void TextAnalyze(object obj)
        {
            var tmp = (KeyValuePair<Stat, string>)obj;
            string text = File.ReadAllText(tmp.Value);
            lock (typeof(Stat))
            {
                tmp.Key.Lines += text.Count(x => x == '\n');
                tmp.Key.Words += text.Count(x => x == ' ' || x == '\n');
                tmp.Key.Punctuation += text.Count(x => x == '.' || x == '-'  || x == '_'  ||
                                                       x == ',' || x == '!'  || x == '?'  ||
                                                       x == ';' || x == '\"' || x == '\'' ||
                                                       x == ':' || x == '('  || x == ')'  ||
                                                       x == '{' || x == '}'  || x == '['  ||
                                                       x == ']' || x == '<'  || x == '>'  ||
                                                       x == '/' || x == '\\');
            }
        }
    }
}