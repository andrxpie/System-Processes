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

namespace Task_Manager_Lite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Thread timer = new Thread(DoUpdate);
        private static int UpdateInterval { get; set; } = 1000;
        private static int UpdateIntervalOld { get; set; } = 1000;
        public static DataGrid g { get; set; } = new();
        public MainWindow()
        {
            InitializeComponent();

            timer.Start();
            grid.ItemsSource = g.Items;
        }

        private static void DoUpdate(object obj)
        {
            UpdateIntervalOld = UpdateInterval;
            while (UpdateInterval == UpdateIntervalOld)
            {
                Thread.Sleep(UpdateInterval);
                UpdateTasks();
            }
        }

        private static void UpdateTasks()
        {
            Application.Current.Dispatcher.Invoke(() =>
            { 
                g.ItemsSource = Process.GetProcesses();
            });
        }

        private void SetIntervalTo1(object sender, RoutedEventArgs e)
        {
            UpdateInterval = 1000;
            timer = new Thread(DoUpdate);
            timer.Start();
        }

        private void SetIntervalTo2(object sender, RoutedEventArgs e)
        {
            UpdateInterval = 2000;
            timer = new Thread(DoUpdate);
            timer.Start();
        }

        private void SetIntervalTo3(object sender, RoutedEventArgs e)
        {
            UpdateInterval = 3000;
            timer = new Thread(DoUpdate);
            timer.Start();
        }

        private void SetIntervalToValue(object sender, RoutedEventArgs e)
        {
            UpdateInterval = Convert.ToInt32(tbx.Text) * 1000;
            timer = new Thread(DoUpdate);
            timer.Start();
        }
    }
}