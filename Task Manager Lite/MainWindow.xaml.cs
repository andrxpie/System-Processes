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
        Timer timer = new Timer(UpdateTasks);
        public int UpdateInterval { get; set; } = 1000;
        public static DataGrid g { get; set; } = new();
        public MainWindow()
        {
            InitializeComponent();

            grid.ItemsSource = Process.GetProcesses();
            timer.Change(10, UpdateInterval);
        }

        private static void UpdateTasks(object obj)
        {
            g.ItemsSource = Process.GetProcesses();
        }
    }
}