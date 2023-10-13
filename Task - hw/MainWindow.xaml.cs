using System;
using System.Collections.Generic;
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

namespace Task___hw
{
    public partial class MainWindow : Window
    {
        private int sentences { get; set; } = 0;
        private int symbols { get; set; } = 0;
        private int words { get; set; } = 0;
        private int asks { get; set; } = 0;
        private int exclamatories { get; set; } = 0;

        private Task countSentences;
        private Task countSymbols;
        private Task countWords;
        private Task countAsks;
        private Task countExclamatories;

        CancellationTokenSource cts;
        CancellationToken token;

        public MainWindow()
        {
            InitializeComponent();

            cts = new CancellationTokenSource();
            token = cts.Token;

            countSentences = new Task(CountSentences);
            countSymbols = new Task(CountSymbols);
            countWords = new Task(CountWords);
            countAsks = new Task(CountAsks);
            countExclamatories = new Task(CountExclamatories);
        }

        private void CountSentences()
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                if(sentensesCBX.IsChecked == true)
                {
                    sentences = text.Text.Count(x => x == '.' || x == '!' || x == '?');
                    sentensesTBX.Text = "Sentences: " + sentences.ToString();
                }
            }));
        }

        private void CountSymbols()
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                if(symbolsCBX.IsChecked == true)
                {
                    symbols = text.Text.Count();
                    symbolsTBX.Text = "Symbols: " + symbols.ToString();
                }
            }));
        }

        private void CountWords()
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                if(wordsCBX.IsChecked == true)
                {
                    words = text.Text.Count(x => x == ' ') + 1;
                    wordsTBX.Text = "Words: " + words.ToString();
                }
            }));
        }

        private void CountAsks()
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                if(asksCBX.IsChecked == true)
                {
                    asks = text.Text.Count(x => x == '?');
                    asksTBX.Text = "Asks: " + asks.ToString();
                }
            }));
        }

        private void CountExclamatories()
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                if(exclamatoriesCBX.IsChecked == true)
                {
                    exclamatories = text.Text.Count(x => x == '!');
                    exclamatoriesTBX.Text = "Exclamatories: " + exclamatories.ToString();
                }
            }));
        }

        private void AnalysClick(object sender, RoutedEventArgs e)
        {
            sentensesTBX.Text = "Sentences: ";
            symbolsTBX.Text = "Symbols: ";
            wordsTBX.Text = "Words: ";
            asksTBX.Text = "Asks: ";
            exclamatoriesTBX.Text = "Exclamatories: ";

            try
            {
                if(token.IsCancellationRequested == false)
                {
                    stop.IsEnabled = true; // time to stop

                    countSentences.Start();
                    countSymbols.Start();
                    countWords.Start();
                    countAsks.Start();
                    countExclamatories.Start();

                    stop.IsEnabled = false; // end of time
                    
                    MessageBox.Show("Done!");
                }

                restart.IsEnabled = true;
                start.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void StopClick(object sender, RoutedEventArgs e)
        {
            cts.Cancel();
            stop.IsEnabled = false;
        }

        private void RestartClick(object sender, RoutedEventArgs e)
        {
            cts = new CancellationTokenSource();
            token = cts.Token;

            countSentences = new Task(CountSentences);
            countSymbols = new Task(CountSymbols);
            countWords = new Task(CountWords);
            countAsks = new Task(CountAsks);
            countExclamatories = new Task(CountExclamatories);

            sentensesTBX.Text = "Sentences: ";
            symbolsTBX.Text = "Symbols: ";
            wordsTBX.Text = "Words: ";
            asksTBX.Text = "Asks: ";
            exclamatoriesTBX.Text = "Exclamatories: ";

            try
            {
                if(token.IsCancellationRequested == false)
                {
                    stop.IsEnabled = true; // time to stop

                    countSentences.Start();
                    countSymbols.Start();
                    countWords.Start();
                    countAsks.Start();
                    countExclamatories.Start();

                    stop.IsEnabled = false; // end of time

                    MessageBox.Show("Done!");
                }

                restart.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}