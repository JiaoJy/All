using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract(SessionMode = SessionMode.Required,CallbackContract = typeof(IService1CallBack))]
    public interface IService1
    {        
        [OperationContract(IsOneWay = false)]
        bool Login(string UserName, string psw);
        [OperationContract(IsOneWay = true)]
        void LoginOk(string userName);
        [OperationContract(IsOneWay = true)]
        void SendRoomsInfoToAllUsers();

        /// <summary>
        /// 由于登陆时用时太长，故而将用户进入游戏厅放入此函数来执行
        /// </summary>
        //[OperationContract(IsOneWay = true)]
        //void DisplayUsersState();

        [OperationContract(IsOneWay = false)]
        bool Register(string UserName, string psw);

        [OperationContract(IsOneWay = false)]
        void Logout(string username);

        //TODO: 在此添加您的服务操作
       [OperationContract(IsOneWay = true)]
        void SitDown(string userName, int index, int side);

        [OperationContract(IsOneWay = true)]
        void Start(string userName, int index, int side);

        //[OperationContract(IsOneWay = true)]
        //void SearchOpponent(string userName);

        [OperationContract(IsOneWay = true)]
        void GetUp(int index, int side);
        [OperationContract(IsOneWay = true)]
        void pertalk(string usernames, string usernamel, string str, Boolean end);
        [OperationContract(IsOneWay = true)]
        void Talk(int index, string userName, string message);
        [OperationContract(IsOneWay = true)]
        void SetDot(int index, int i, int j);
        [OperationContract(IsOneWay = false)]
        void PerMessage(string userName, ref int age1, ref string sex1, ref int price1, ref string country1);
        [OperationContract(IsOneWay = true)]
        void MessageOk(string userName,int age1, string sex1, string country1);

        [OperationContract(IsOneWay = false)]
        List<string> FriendList(string userName);

        //[OperationContract(IsOneWay = false)]
        //List<string> getActivtiesUserInfo();

        //[OperationContract(IsOneWay = false)]
        //List<string> getAliveUserArray();
    }
    public interface IService1CallBack
    {
        [OperationContract(IsOneWay = true)]
        void ShowLogin(string loginUserName, int maxTables);

        [OperationContract(IsOneWay = true)]
        void ShowLogout(string userName);

        [OperationContract(IsOneWay = true)]
        void ShowSitDown(string userName, int side);

        [OperationContract(IsOneWay = true)]
        void ShowGetUp(int side);

        [OperationContract(IsOneWay = true)]
        void ShowStart(int side);

        [OperationContract(IsOneWay = true)]
        void ShowTalk(string userName, string message);

        [OperationContract(IsOneWay = true)]
        void ShowSetDot(int i, int j, int color);

        [OperationContract(IsOneWay = true)]
        void GameStart();

        [OperationContract(IsOneWay = true)]
        void GameWin(string message);

        [OperationContract(IsOneWay = true)]
        void UpdateTablesInfo(string tablesInfo, int userCount);
    }
}
