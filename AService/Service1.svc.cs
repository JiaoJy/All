using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Windows;

namespace AService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    public class Service1 : IService1
    {
        //public List<string> getActivtiesUserInfo()
        //{
        //    throw new NotImplementedException();
        //}

        //public List<string> getAliveUserArray()
        //{
        //    throw new NotImplementedException();
        //}
        public Service1()
        {
            if (CC.Users == null)
            {
                CC.Users = new List<User>();
                CC.Rooms = new GameTables[CC.maxRooms];
                for (int i = 0; i < CC.maxRooms; i++)
                {
                    CC.Rooms[i] = new GameTables();
                }
            }
        }

        public void GetUp(int index, int side)
        {
            User p0 = CC.Rooms[index].players[side];
            User p1 = CC.Rooms[index].players[(side + 1) % 2];
            p0.callback.ShowGetUp(side);
            CC.Rooms[index].players[side] = null; //注意该语句执行后p0!=null
            if (p1 != null)
            {
                p1.callback.ShowGetUp(side);
                p1.IsStarted = false;
            }
            //重新将游戏室各桌情况发送给所有用户
            SendRoomsInfoToAllUsers();
        }
        private string GetTablesInfo()
        {
            string str = "";
            for (int i = 0; i < CC.Rooms.Length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    str += CC.Rooms[i].players[j] == null ? "0" : "1";
                }
            }
            return str;
        }
        public void SendRoomsInfoToAllUsers()
        {
            int userCount = CC.Users.Count;
            string roomInfo = this.GetTablesInfo();
            for (int i = 0; i < CC.Users.Count; i++)
            {
                CC.Users[i].callback.UpdateTablesInfo(roomInfo, CC.maxRooms);
            }
            //foreach (var user in CC.Users)
            //{
            //    user.callback.UpdateTablesInfo(roomInfo, userCount);
            //}
        }
        public bool Register(string userName, string psw)
        {
            if (userName != "" && psw != "")
            {
                using (var con = new UserEntities())
                {
                    Login ad = new Login()
                    {
                        UserName = userName,
                        Password = psw

                    };
                    try
                    {
                        con.Login.Add(ad);
                        con.SaveChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "添加失败！");
                        return false;
                    }
                }
            }
            else
            {
                MessageBox.Show("所填内容不能为空！");
                return false;
            }
        }
        public bool Login(string userName, string psw)
        {
            foreach(var user in CC.Users)
            {
                if(userName == user.UserName)
                {
                    MessageBox.Show("您已登录！");
                    return false;
                }
            }
            using (var con = new UserEntities())
            {
                var q1 = from t in con.Login
                         where t.UserName.Equals(userName) == true && t.Password.Equals(psw) == true
                         select t;
                if (q1.Count() != 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("登录失败\n输入有错误!或所填内容有空！");
                    return false;
                }
            }
        }
        public void LoginOk(string userName)
        {
            OperationContext context = OperationContext.Current;
            IService1CallBack callback = context.GetCallbackChannel<IService1CallBack>();
            User newUser = new User(userName, callback);
            CC.Users.Add(newUser);
            //for (int i = 0; i < CC.Users.Count; i++)
            //{
            //    CC.Users[i].callback.ShowLogin(UserName, CC.maxRooms);
            //}
            foreach (var user in CC.Users)
            {
                user.callback.ShowLogin(userName, CC.maxRooms);
            }
            SendRoomsInfoToAllUsers();
        }
        
        public void Logout(string userName)
        {
            User logoutUser = CC.GetUser(userName);
            foreach (var user in CC.Users)
            {
                //不需要发给退出用户
                if (user.UserName != logoutUser.UserName)
                {
                    user.callback.ShowLogout(userName);
                }
            }
            CC.Users.Remove(logoutUser);
            logoutUser = null; //将其设置为null后，WCF会自动关闭该客户端
            SendRoomsInfoToAllUsers();
        }


        public void SitDown(string userName, int index, int side)
        {
            User p = CC.GetUser(userName);
            p.Index = index;
            p.Side = side;
            CC.Rooms[index].players[side] = p;
            //告诉入座玩家入座信息
            p.callback.ShowSitDown(userName, side);

            int anotherSide = (side + 1) % 2;  //同一桌的另一个玩家
            User p1 = CC.Rooms[index].players[anotherSide];
            if (p1 != null)
            {
                //告诉入座玩家另一个玩家是谁
                p.callback.ShowSitDown(p1.UserName, anotherSide);
                //告诉另一个玩家入座玩家是谁
                p1.callback.ShowSitDown(p.UserName, side);
            }
            //重新将游戏室各桌情况发送给所有用户
            SendRoomsInfoToAllUsers();
        }

        public void Start(string userName, int index, int side)
        {
            User p0 = CC.Rooms[index].players[side];
            p0.IsStarted = true;
            p0.callback.ShowStart(side);
            int anotherSide = (side + 1) % 2;   //对方座位号
            User p1 = CC.Rooms[index].players[anotherSide];
            if (p1 != null)
            {
                p1.callback.ShowStart(side);
                if (p1.IsStarted)
                {
                    CC.Rooms[index].ResetGrid();
                    p0.callback.GameStart();
                    p1.callback.GameStart();
                }
            }
        }
        public void SetDot(int index, int row, int col)
        {
            CC.Rooms[index].SetGridDot(row, col);
        }

        public void Talk(int index, string userName, string message)
        {
            User p0 = CC.Rooms[index].players[0];
            User p1 = CC.Rooms[index].players[1];
            if (p0 != null) p0.callback.ShowTalk(userName, message);
            if (p1 != null) p1.callback.ShowTalk(userName, message);
        }

        public void pertalk(string usernames, string usernamel, string str, bool end)
        {
            throw new NotImplementedException();
        }

        public static void win(string userName)
        {
            using (var con = new UserEntities())
            {
                var q = from t in con.Login
                        where t.UserName == userName
                        select t;
                try
                {
                    if (q.Count() != 0)
                    {
                        foreach (var v in q)
                        {
                            v.Price += 10;
                        }
                        con.SaveChanges();  //将更改后的用户数据库进行保存

                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                    return;
                }
            }
        }
        public static void fail(string userName)
        {
            using (var con = new UserEntities())
            {
                var q = from t in con.Login
                        where t.UserName == userName
                        select t;
                try
                {
                    if (q.Count() != 0)
                    {
                        foreach (var v in q)
                        {
                            v.Price -= 10;
                        }
                        con.SaveChanges();  //将更改后的用户数据库进行保存


                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                    return;
                }
            }
        }

        public void PerMessage(string userName,ref int age1,ref string sex1,ref int price1,ref string country1)
        {
            using (var con = new UserEntities())
            {
                var q = from t in con.Login
                        where t.UserName == userName
                        select t;
                try
                {
                    if (q.Count() != 0)
                    {
                        foreach (var v in q)
                        {
                            age1 = v.age;
                            sex1 = v.sex.ToString();
                            country1 = v.country.ToString();
                            price1 = v.Price;
                        }
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                    return;
                }
            }
        }

        public void MessageOk(string userName, int age1, string sex1, string country1)
        {
            using (var con = new UserEntities())
            {
                var q = from t in con.Login
                        where t.UserName == userName
                        select t;
                try
                {
                    if (q.Count() != 0)
                    {
                        foreach (var v in q)
                        {
                            v.age = age1;
                            v.sex = sex1;
                            v.country = country1;
                        }
                        con.SaveChanges();  //将更改后的用户数据库进行保存

                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                    return;
                }
            }
        }

        public List<string> FriendList(string userName)
        {
            List<string> friend = new List<string>();
            using (var con = new UserEntities())
            {
                var q = from t in con.Friend
                        where t.Uname == userName
                        select t;
                try
                {
                    if (q.Count() != 0)
                    {
                        foreach (var v in q)
                        {
                            friend.Add(v.Fname);
                        }
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
                return friend;
            }
        }
    }
}
