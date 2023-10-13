using System;
using System.Collections.Generic;
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

namespace Task___hw
{
    public partial class MainWindow : Window
    {
        private int sentences { get; set; } = 0;
        private int symbols { get; set; } = 0;
        private int words { get; set; } = 0;
        private int asks { get; set; } = 0;
        private int exclamatorys { get; set; } = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AnalysClick(object sender, RoutedEventArgs e)
        {
            sentensesTBX.Text = "Sentences: ";
            symbolsTBX.Text = "Symbols: ";
            wordsTBX.Text = "Words: ";
            asksTBX.Text = "Asks: ";
            exclamatoriesTBX.Text = "Exclamatories: ";

            if(sentensesCBX.IsChecked == true)
            {
                sentences = text.Text.Count(x => x == '.' || x == '!' || x == '?');
                sentensesTBX.Text = "Sentences: " + sentences.ToString();
            }

            if(symbolsCBX.IsChecked == true)
            {
                symbols = text.Text.Count();
                symbolsTBX.Text = "Symbols: " + symbols.ToString();
            }

            if(wordsCBX.IsChecked == true)
            {
                words = text.Text.Count(x => x == ' ') + 1;
                wordsTBX.Text = "Words: " + words.ToString();
            }

            if(asksCBX.IsChecked == true)
            {
                asks = text.Text.Count(x => x == '?');
                asksTBX.Text = "Asks: " + asks.ToString();
            }

            if(exclamatoriesCBX.IsChecked == true)
            {
                exclamatorys = text.Text.Count(x => x == '!');
                exclamatoriesTBX.Text = "Exclamatories: " + exclamatorys.ToString();
            }
        }
    }
}