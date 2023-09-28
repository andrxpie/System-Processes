using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace HyperThreading___Async
{
    public partial class MainWindow : Window
    {
        public static int from;
        public static int to;
        
        int lastInT1;
        int lastInT2;
        int lastInT3;

        Thread Task1;
        Thread Task2;
        Thread Task3;

        CancellationTokenSource cts1 = new CancellationTokenSource();
        CancellationTokenSource cts2 = new CancellationTokenSource();
        CancellationTokenSource cts3 = new CancellationTokenSource();

        CancellationToken token1;
        CancellationToken token2;
        CancellationToken token3;

        public MainWindow()
        {
            InitializeComponent();

            stop1.IsEnabled = false;
            stop2.IsEnabled = false;
            stop3.IsEnabled = false;

            pause1.IsEnabled = false;
            pause2.IsEnabled = false;
            pause3.IsEnabled = false;

            resume1.IsEnabled = false;
            resume2.IsEnabled = false;
            resume3.IsEnabled = false;

            Task1 = new Thread(AddT1);
            Task2 = new Thread(AddT2);
            Task3 = new Thread(AddT3);

            Task1.IsBackground = true;
            Task2.IsBackground = true;
            Task3.IsBackground = true;

            token1 = cts1.Token;
            token2 = cts2.Token;
            token2 = cts2.Token;
        }

        private void StartButton(object sender, RoutedEventArgs e)
        {
            stop1.IsEnabled = true;
            //stop2.IsEnabled = true;
            //stop3.IsEnabled = true;

            pause1.IsEnabled = true;
            //pause2.IsEnabled = true;
            //pause3.IsEnabled = true;

            resume1.IsEnabled = true;
            //resume2.IsEnabled = true;
            //resume3.IsEnabled = true;

            from = Convert.ToInt32(fromTbx.Text);
            to = Convert.ToInt32(toTbx.Text);

            if(from > to)
            {
                int tmp = from;
                from = to;
                to = tmp;
            }

            Task1.Start(new KeyValuePair<KeyValuePair<int, int>, CancellationToken>(new KeyValuePair<int, int>(from, to), token1));
        }

        private void AddT3(object obj)
        {

        }

        private void AddT2(object obj)
        {

        }

        private void AddT1(object obj)
        {
            var tmp = (KeyValuePair<KeyValuePair<int, int>, CancellationToken>)obj;
            while(tmp.Value.IsCancellationRequested == false)
            {
                Application.Current.Dispatcher.Invoke(new Action(() =>
                { 
                    task1.Items.Add(GetRandom(tmp.Key.Key, tmp.Key.Value));
                }));
                Thread.Sleep(1000);
            }
        }

        private int GetRandom(int a, int b)
        {
            return new Random().Next(a, b);
        }

        private static List<int> GenSimpleNum(object obj)
        {
            List<int> list = new();
            for (int i = from; i <= to; i++)
            {
                for (int j = 2; j <= to; j++)
                {
                    if (i % j == 0) break;
                    else
                    {
                        list.Add(i);
                    }
                }
            } return list;
        }

        private void StopButton1(object sender, RoutedEventArgs e)
        {
            pause1.IsEnabled = false;
            resume1.IsEnabled = false;

            cts1.Cancel();
        }

        private void PauseButton1(object sender, RoutedEventArgs e)
        {
            cts1.Cancel();
            lastInT1 = Convert.ToInt32(task1.Items.OfType<ListViewItem>().LastOrDefault());
        }

        private void ResumeButton1(object sender, RoutedEventArgs e)
        {
            cts1 = new CancellationTokenSource();
            token1 = cts1.Token;

            Task1 = new Thread(AddT1);
            Task1.Start(new KeyValuePair<KeyValuePair<int, int>, CancellationToken>(new KeyValuePair<int, int>(from, to), token1));
        }
    }
}