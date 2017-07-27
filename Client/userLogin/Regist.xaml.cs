using Client.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

namespace Client.userLogin
{
    /// <summary>
    /// Regist.xaml 的交互逻辑
    /// </summary>
    public partial class Regist : Window
    {
        string userName = "";
        string password = "";
        string repassword = "";
        public Service1Client client;

        public Regist()
        {
            InitializeComponent();
        }
        public Regist(Service1Client client)
        {
            this.client = client;
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            userName = rgtUserName.Text;
            password = rgtPassWord.Password.ToString();
            repassword = RePassWord.Password.ToString();
            if(userName == "")
            {
                nameLabel.Visibility = Visibility.Visible;
                return;
            }
            if (password == "" || repassword == "")
            {
                pwdLable.Visibility = Visibility.Visible;
                return;
            }
            if(repassword != password)
            {
                rePwdLable.Visibility = Visibility.Visible;
                return;
            }
            rePwdLable.Visibility = Visibility.Hidden;
            nameLabel.Visibility = Visibility.Hidden;
            pwdLable.Visibility = Visibility.Hidden;
            if (client.Register(userName, password))
            {
                MessageBox.Show("注册成功");
                this.Close();
            }
           // client.Close();
            return;  
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
        public void ShowLogin(string loginUserName, int maxTables)
        {
            MainStart.usered = loginUserName;
        }

    }
}
