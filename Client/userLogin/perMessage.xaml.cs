using Client.ServiceReference1;
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

namespace Client.userLogin
{
    /// <summary>
    /// perMessage.xaml 的交互逻辑
    /// </summary>
    public partial class perMessage : Window
    {
        Service1Client Client;
        int age1;
        string sex1;
        int price1;
        string country1;
        string selectName;
        string[] friend;
        public perMessage()
        {
            InitializeComponent();
        }
        public perMessage(Service1Client Client,string userName)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Client = Client;
            user1Label.Content = userName;
            try
            {
                Client.PerMessage(userName, ref age1, ref sex1, ref price1, ref country1);
                
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
                return;
            }
            age.Text = age1.ToString();
            country.Text = country1;
            sex.Text = sex1;
            price.Content = price1.ToString();
            showfriendList(userName);
        }

        private void showfriendList(string userName)
        {
            friend = Client.FriendList(userName);
            Uri uri = new Uri(@"..\image\player.jpg", UriKind.Relative);
            ImageSource imgSource = new BitmapImage(uri);
            for (int i = 0; i < friend.Length; i++)
            {
                StackPanel sp = new StackPanel()
                {
                    Orientation = Orientation.Horizontal,
                    Margin = new Thickness(10)
                };
                
                Image image = new Image()
                {
                    Source = imgSource,
                    Height = 30
                };
                TextBlock text = new TextBlock()
                {
                    Text = friend[i].ToString(),
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                    Width = 40
                };
                sp.Children.Add(image);
                sp.Children.Add(text);
                friendList.Items.Add(sp);
            }
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            age.IsEnabled = true;
            country.IsEnabled = true;
            sex.IsEnabled = true;
            age.BorderThickness = new Thickness(1);
            country.BorderThickness = new Thickness(1);
            sex.BorderThickness = new Thickness(1);
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client.MessageOk(user1Label.Content.ToString(), int.Parse(age.Text.ToString()), sex.Text.ToString(), country.Text.ToString());
                MessageBox.Show("保存成功");
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
                age.Text = age1.ToString();
                country.Text = country1;
                sex.Text = sex1;
            }
            age.BorderThickness = new Thickness(0);
            country.BorderThickness = new Thickness(0);
            sex.BorderThickness = new Thickness(0);
            age.IsEnabled = false;
            country.IsEnabled = false;
            sex.IsEnabled = false;
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Client.PerMessage(user1Label.Content.ToString(), ref age1, ref sex1, ref price1, ref country1);
            age.BorderThickness = new Thickness(0);
            country.BorderThickness = new Thickness(0);
            sex.BorderThickness = new Thickness(0);
            age.Text = age1.ToString();
            country.Text = country1;
            sex.Text = sex1;
            age.IsEnabled = false;
            country.IsEnabled = false;
            sex.IsEnabled = false;
        }
    }
}
