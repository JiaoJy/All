using Client.ServiceReference1;
using Client.userLogin;
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

namespace Client
{
    /// <summary>
    /// MainStart.xaml 的交互逻辑
    /// </summary>
    public partial class MainStart : Window,IService1Callback
    {
        public Service1Client Client;
        public static string usered;
        public static string username = "";
        string password = "";
        public string UserName
        {
            get { return userLabel.Content.ToString(); }
            set { userLabel.Content = value; }
        }
        private int nextColor = -1;        //该哪一方放置棋子（-1:不允许，0：黑方，1：白方）
        private bool isGameStart = false;  //是否已开始游戏
        private const int max = 16;       //棋盘行列最大值（0～16）
        private int maxTables;            //服务端开设的最大房间号
        private int tableIndex = -1;      //房间号（所坐的游戏桌号）
        private int tableSide = -1;       //座位号
        private Border[,] gameTables;        //开设的房间（每个房间一桌）
        private int[,] grid = new int[max, max];  //保存棋盘上每个棋子的颜色(16*16的交叉点）
        private Image[,] images = new Image[max, max];  //保存棋盘上每个棋
        public MainStart()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            this.Closing += MainStart_Closing;
            InstanceContext context = new InstanceContext(this);
            Client = new Service1Client(context);         
            ChangeRoomsInfoVisible(true);
            ChangeRoomVisible(false);
            SetNextColor(-1);
        }
        
        private void MainStart_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //ChangeState(btnLogin, true, btnLogout, false);
            if (Client != null)
            {
                if (tableIndex != -1) //如果在房间内，要求先返回大厅
                {
                    MessageBox.Show("请先返回大厅，然后再退出");
                    e.Cancel = true;
                }
                else
                {
                    Client.Logout(UserName); //从大厅退出
                    Client.Close();
                }
            }
        }

        private void ChangeRoomsInfoVisible(bool visible)
        {
            if (visible == false)
            {
                listBoxRooms.Visibility = System.Windows.Visibility.Collapsed;
                St1.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                listBoxRooms.Visibility = System.Windows.Visibility.Visible;
                St1.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void ChangeRoomVisible(bool visible)
        {
            if (visible == false)
            {
                gridRoom.Visibility = Visibility.Collapsed;
            }
            else
            {
                gridRoom.Visibility = Visibility.Visible;
            }
        }
        private void SetNextColor(int next)
        {
            nextColor = next;
            if (nextColor == 0)
            {
                stackPanelGameTip.Visibility = System.Windows.Visibility.Visible;
                blackImage.Visibility = System.Windows.Visibility.Visible;
                whiteImage.Visibility = System.Windows.Visibility.Collapsed;
            }
            else if (nextColor == 1)
            {
                stackPanelGameTip.Visibility = System.Windows.Visibility.Visible;
                blackImage.Visibility = System.Windows.Visibility.Collapsed;
                whiteImage.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                stackPanelGameTip.Visibility = System.Windows.Visibility.Collapsed;
                blackImage.Visibility = System.Windows.Visibility.Collapsed;
                whiteImage.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void AddMessage(string str)
        {
            TextBlock t = new TextBlock();
            t.Text = str;
            t.Foreground = Brushes.Blue;
            listBoxMessage.Items.Add(t);
        }

        private void AddColorMessage(string str, SolidColorBrush color)
        {
            TextBlock t = new TextBlock();
            t.Text = str;
            t.Foreground = color;
            listBoxMessage.Items.Add(t);
        }

        private static void ChangeState(Button btnStart, bool isStart, Button btnStop, bool isStop)
        {
            btnStart.IsEnabled = isStart;
            btnStop.IsEnabled = isStop;
        }
        #region 鼠标和键盘事件
        //单击退出按钮引发的事件
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); //在窗口的Closing事件中处理退出操作
        }

        //在某个座位坐下时引发的事件
        private void RoomSide_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("nihao");
            Border border = e.Source as Border;
            if (border != null)
            {
                string s = border.Tag.ToString();
                tableIndex = int.Parse(s[0].ToString());
                tableSide = int.Parse(s[1].ToString());
                Client.SitDown(UserName, tableIndex, tableSide);
            }
        }

        //单击发送按钮引发的事件
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            Client.Talk(tableIndex, UserName, textBoxTalk.Text);
        }

        //在对话文本框中按回车键时引发的事件
        private void textBoxTalk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Client.Talk(tableIndex, UserName, textBoxTalk.Text);
            }
        }

        //单击开始按钮引发的事件
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {            
            Client.Start(UserName, tableIndex, tableSide);
            btnStart.IsEnabled = false;
            SetNextColor(-1);
        }

        //单击返回大厅按钮引发的事件
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            Client.GetUp(tableIndex, tableSide);
        }

        //在棋盘上单击鼠标左键时引发的事件
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isGameStart == false) return;
            Point point = e.GetPosition(canvas1);
            int x = (int)(point.X + 10) / 20;
            int y = (int)(point.Y + 10) / 20;
            if (!(x < 1 || x > max || y < 1 || y > max))
            {
                int i = x - 1;
                int j = y - 1;
                if (grid[i, j] == -1 && nextColor == tableSide)
                {
                    Client.SetDot(tableIndex, i, j);
                }
            }
        }
        #endregion //鼠标和键盘事件

        public void ShowLogin(string loginUserName, int maxTables)
        {
            
            if (loginUserName == username)
            {

                LoginGrid.Visibility = Visibility.Collapsed;
                mainstart.Visibility = Visibility.Visible;
                //ChangeRoomsInfoVisible(true);
                this.maxTables = maxTables;
                this.CreateTables();
            }    
        }

        public void ShowLogout(string userName)
        {
            AddMessage(userName + "退出大厅。");
        }

        public void ShowSitDown(string userName, int side)
        {            
            stackPanelGameTip.Visibility = System.Windows.Visibility.Collapsed;
            if (side == tableSide)
            {
                isGameStart = false;
                btnLogout.IsEnabled = false;
                btnLogout.Visibility = Visibility.Collapsed;
                btnStart.IsEnabled = true;
                listBoxRooms.Visibility = Visibility.Hidden;//返回大厅前不允许再坐到另一个位置
                ChangeRoomVisible(false);
                textBlockRoomNumber.Text = "桌号：" + (tableIndex + 1);
                ChangeRoomVisible(true);
            }
            if (side == 0)
            {
                textBlockBlackUserName.Text = "黑方：" + userName;
                AddMessage(string.Format("{0}在房间{1}黑方入座。", userName, tableIndex + 1));
            }
            else
            {
                textBlockWhiteUserName.Text = "白方：" + userName;
                AddMessage(string.Format("{0}在房间{1}白方入座。", userName, tableIndex + 1));
            }
        }

        public void ShowGetUp(int side)
        {
            stackPanelGameTip.Visibility = System.Windows.Visibility.Collapsed;
            listBoxRooms.Visibility = Visibility.Visible;
            if (side == tableSide)
            {
                isGameStart = false;
                btnLogout.IsEnabled = true;
                btnLogout.Visibility = Visibility.Visible;
                listBoxRooms.IsEnabled = true;//返回大厅后允许再坐到另一个位置
                AddMessage(UserName + "返回大厅。");
                this.tableIndex = -1;
                this.tableSide = -1;
                ChangeRoomVisible(false);
            }
            else
            {
                if (isGameStart)
                {
                    AddMessage("对方回大厅了，游戏终止。");
                    isGameStart = false;
                    btnStart.IsEnabled = true;
                }
                else
                {
                    AddMessage("对方返回大厅。");
                }
                if (side == 0) textBlockBlackUserName.Text = "";
                else textBlockWhiteUserName.Text = "";
            }
        }

        public void ShowStart(int side)
        {
            ResetGrid();
            if (side == 0) AddMessage("黑方已开始。");
            else AddMessage("白方已开始。");
        }

        public void ShowTalk(string userName, string message)
        {
            AddColorMessage(string.Format("{0}：{1}", userName, message), Brushes.Black);
        }

        public void ShowSetDot(int i, int j, int color)
        {
            grid[i, j] = color;
            if (color == 0) images[i, j] = new Image() { Source = blackImage.Source };
            else images[i, j] = new Image() { Source = whiteImage.Source };
            Canvas.SetLeft(images[i, j], (i + 1) * 20 - 10);
            Canvas.SetTop(images[i, j], (j + 1) * 20 - 10);
            canvas1.Children.Add(images[i, j]);
            SetNextColor((color + 1) % 2);
        }

        public void GameStart()
        {
            stackPanelGameTip.Visibility = System.Windows.Visibility.Visible;
            this.isGameStart = true;  //为true时才可以放棋子
            SetNextColor(0);
            blackImage.Visibility = System.Windows.Visibility.Visible;
        }

        public void GameWin(string message)
        {
            AddColorMessage("\n" + message + "\n", Brushes.Red);
            btnStart.IsEnabled = true;
            stackPanelGameTip.Visibility = System.Windows.Visibility.Collapsed;
            this.isGameStart = false;
            SetNextColor(-1);
            blackImage.Visibility = System.Windows.Visibility.Collapsed;
            whiteImage.Visibility = System.Windows.Visibility.Collapsed;
        }

        public void UpdateTablesInfo(string tablesInfo, int userCount)
        {
            textBlockMessage.Text = string.Format("在线人数：{0}", userCount);

            for (int i = 0; i < maxTables; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (tableIndex == -1)
                    {
                        if (tablesInfo[2 * i + j] == '0')
                        {
                            gameTables[i, j].Child.Visibility = System.Windows.Visibility.Hidden;
                            gameTables[i, j].Child.IsEnabled = true;
                        }
                        else
                        {
                            gameTables[i, j].Child.Visibility = System.Windows.Visibility.Visible;
                            gameTables[i, j].Child.IsEnabled = false;
                        }
                    }
                    else
                    {
                        gameTables[i, j].Child.IsEnabled = false;
                        if (tablesInfo[2 * i + j] == '0')
                        {
                            gameTables[i, j].Child.Visibility = System.Windows.Visibility.Hidden;
                        }
                        else gameTables[i, j].Child.Visibility = System.Windows.Visibility.Visible;
                    }
                }
            }
        }
        

        private void imageGameTable_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isGameStart == false) return;
            Point point = e.GetPosition(canvas1);
            int x = (int)(point.X + 10) / 20;
            int y = (int)(point.Y + 10) / 20;
            if (!(x < 1 || x > max || y < 1 || y > max))
            {
                int i = x - 1;
                int j = y - 1;
                if (grid[i, j] == -1 && nextColor == tableSide)
                {
                    Client.SetDot(tableIndex, i, j);
                }
            }
        }



        #region 接口调用的方法
        /// <summary>创建游戏桌</summary>
        private void CreateTables()
        {
            this.gameTables = new Border[maxTables, 2];
            //isFromServer = false;
            //创建游戏大厅中的房间（每房间一个游戏桌）
            for (int i = 0; i < maxTables; i++)
            {
                int j = i + 1;
                Uri uri = new Uri(@"image\player.jpg", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                StackPanel sp = new StackPanel()
                {
                    Orientation = Orientation.Horizontal,
                    Margin = new Thickness(10)
                };
                TextBlock text = new TextBlock()
                {
                    Text = "房间" + (i + 1),
                    FontSize = 14,
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                    Width = 50
                };
                gameTables[i, 0] = new Border()
                {
                    Margin = new Thickness(10, 0, 10, 0),
                    Tag = i + "0",
                    Background = Brushes.White,

                    Child = new Image()
                    {
                        Source = imgSource,
                        Height = 30
                    }
                };
                uri = new Uri(@"image\timg.jpg", UriKind.Relative);
                imgSource = new BitmapImage(uri);
                Image image = new Image()
                {
                    Margin = new Thickness(10, 0, 10, 0),
                    Source = imgSource,
                    Height = 30
                };
                uri = new Uri(@"image\player.jpg", UriKind.Relative);
                imgSource = new BitmapImage(uri);
                gameTables[i, 1] = new Border()
                {
                    Margin = new Thickness(10, 0, 10, 0),
                    Tag = i + "1",
                    Background = Brushes.White,
                    Child = new Image()
                    {
                        Source = imgSource,
                        Height = 30
                    }
                };
                gameTables[i, 0].MouseDown += RoomSide_MouseDown;
                gameTables[i, 1].MouseDown += RoomSide_MouseDown;
                sp.Children.Add(text);
                sp.Children.Add(gameTables[i, 0]);
                sp.Children.Add(image);
                sp.Children.Add(gameTables[i, 1]);
                listBoxRooms.Items.Add(sp);
            }
        }

        /// <summary>重置棋盘</summary>
        private void ResetGrid()
        {
            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < max; j++)
                {
                    if (grid[i, j] != -1)
                    {
                        grid[i, j] = -1;
                        canvas1.Children.Remove(images[i, j]);
                        images[i, j] = null;
                    }
                }
            }
        }
        #endregion //接口调用的方法

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            username = NameText.Text;
            password = PswText.Password.ToString();
            if (username == "")
            {
                nameLabel.Visibility = Visibility.Visible;
                return;
            }
            if (password == "")
            {
                pwdLable.Visibility = Visibility.Visible;
                return;
            }
            
            if(Client.Login(username, password))
            {
                pwdLable.Visibility = Visibility.Hidden;
                nameLabel.Visibility = Visibility.Hidden;
                MessageBox.Show("登录成功");
                
                Client.LoginOk(username);
            }
            else
            {
                MessageBox.Show("登录失败");
                return;
            }
            UserName = username;

        }

        private void RegistBtn_Click(object sender, RoutedEventArgs e)
        {
            Regist r = new Regist(Client);
            r.ShowDialog();
        }

        private void Image_MouseDown_perMessage(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show(UserName);
            perMessage p = new perMessage(Client, UserName);
            p.Show();
        }
    }
}
