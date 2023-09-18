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

namespace Async_Await___task_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int x;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void GetFactorialBtn(object sender, RoutedEventArgs e)
        {
            x = Convert.ToInt32(tbx.Text);
            int res = await GetFactorial();
            list.Items.Add(res);
        }

        private async Task<int> GetFactorial()
        {
            return await Task.Run(() =>
            {
                int factorial = 1;

                for (int i = 1; i <= x; i++)
                    factorial *= i;

                return factorial;
            });
        }
    }
}