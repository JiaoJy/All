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
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// mainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class mainWindow : Window
    {
        public mainWindow()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            StartWindow( 580, 300);
            StartWindow( 0, 0);
        }
        private void StartWindow( int left, int top)
        {
            MainStart w = new MainStart();
            w.Left = left;
            w.Top = top;
            w.Owner = this;
            w.Closed += (sender, e) => this.Activate();
            w.Show();
        }
    }
}
