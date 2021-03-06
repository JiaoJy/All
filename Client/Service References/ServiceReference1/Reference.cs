﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1", CallbackContract=typeof(Client.ServiceReference1.IService1Callback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Login", ReplyAction="http://tempuri.org/IService1/LoginResponse")]
        bool Login(string UserName, string psw);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Login", ReplyAction="http://tempuri.org/IService1/LoginResponse")]
        System.Threading.Tasks.Task<bool> LoginAsync(string UserName, string psw);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/LoginOk")]
        void LoginOk(string userName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/LoginOk")]
        System.Threading.Tasks.Task LoginOkAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/SendRoomsInfoToAllUsers")]
        void SendRoomsInfoToAllUsers();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/SendRoomsInfoToAllUsers")]
        System.Threading.Tasks.Task SendRoomsInfoToAllUsersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Register", ReplyAction="http://tempuri.org/IService1/RegisterResponse")]
        bool Register(string UserName, string psw);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Register", ReplyAction="http://tempuri.org/IService1/RegisterResponse")]
        System.Threading.Tasks.Task<bool> RegisterAsync(string UserName, string psw);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Logout", ReplyAction="http://tempuri.org/IService1/LogoutResponse")]
        void Logout(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Logout", ReplyAction="http://tempuri.org/IService1/LogoutResponse")]
        System.Threading.Tasks.Task LogoutAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/SitDown")]
        void SitDown(string userName, int index, int side);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/SitDown")]
        System.Threading.Tasks.Task SitDownAsync(string userName, int index, int side);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/Start")]
        void Start(string userName, int index, int side);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/Start")]
        System.Threading.Tasks.Task StartAsync(string userName, int index, int side);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/GetUp")]
        void GetUp(int index, int side);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/GetUp")]
        System.Threading.Tasks.Task GetUpAsync(int index, int side);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/pertalk")]
        void pertalk(string usernames, string usernamel, string str, bool end);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/pertalk")]
        System.Threading.Tasks.Task pertalkAsync(string usernames, string usernamel, string str, bool end);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/Talk")]
        void Talk(int index, string userName, string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/Talk")]
        System.Threading.Tasks.Task TalkAsync(int index, string userName, string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/SetDot")]
        void SetDot(int index, int i, int j);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/SetDot")]
        System.Threading.Tasks.Task SetDotAsync(int index, int i, int j);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/PerMessage", ReplyAction="http://tempuri.org/IService1/PerMessageResponse")]
        Client.ServiceReference1.PerMessageResponse PerMessage(Client.ServiceReference1.PerMessageRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/PerMessage", ReplyAction="http://tempuri.org/IService1/PerMessageResponse")]
        System.Threading.Tasks.Task<Client.ServiceReference1.PerMessageResponse> PerMessageAsync(Client.ServiceReference1.PerMessageRequest request);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/MessageOk")]
        void MessageOk(string userName, int age1, string sex1, string country1);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/MessageOk")]
        System.Threading.Tasks.Task MessageOkAsync(string userName, int age1, string sex1, string country1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/FriendList", ReplyAction="http://tempuri.org/IService1/FriendListResponse")]
        string[] FriendList(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/FriendList", ReplyAction="http://tempuri.org/IService1/FriendListResponse")]
        System.Threading.Tasks.Task<string[]> FriendListAsync(string userName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Callback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/ShowLogin")]
        void ShowLogin(string loginUserName, int maxTables);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/ShowLogout")]
        void ShowLogout(string userName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/ShowSitDown")]
        void ShowSitDown(string userName, int side);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/ShowGetUp")]
        void ShowGetUp(int side);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/ShowStart")]
        void ShowStart(int side);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/ShowTalk")]
        void ShowTalk(string userName, string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/ShowSetDot")]
        void ShowSetDot(int i, int j, int color);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/GameStart")]
        void GameStart();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/GameWin")]
        void GameWin(string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/UpdateTablesInfo")]
        void UpdateTablesInfo(string tablesInfo, int userCount);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PerMessage", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class PerMessageRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string userName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public int age1;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string sex1;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public int price1;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=4)]
        public string country1;
        
        public PerMessageRequest() {
        }
        
        public PerMessageRequest(string userName, int age1, string sex1, int price1, string country1) {
            this.userName = userName;
            this.age1 = age1;
            this.sex1 = sex1;
            this.price1 = price1;
            this.country1 = country1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PerMessageResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class PerMessageResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public int age1;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string sex1;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public int price1;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public string country1;
        
        public PerMessageResponse() {
        }
        
        public PerMessageResponse(int age1, string sex1, int price1, string country1) {
            this.age1 = age1;
            this.sex1 = sex1;
            this.price1 = price1;
            this.country1 = country1;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : Client.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.DuplexClientBase<Client.ServiceReference1.IService1>, Client.ServiceReference1.IService1 {
        
        public Service1Client(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public Service1Client(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public Service1Client(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public bool Login(string UserName, string psw) {
            return base.Channel.Login(UserName, psw);
        }
        
        public System.Threading.Tasks.Task<bool> LoginAsync(string UserName, string psw) {
            return base.Channel.LoginAsync(UserName, psw);
        }
        
        public void LoginOk(string userName) {
            base.Channel.LoginOk(userName);
        }
        
        public System.Threading.Tasks.Task LoginOkAsync(string userName) {
            return base.Channel.LoginOkAsync(userName);
        }
        
        public void SendRoomsInfoToAllUsers() {
            base.Channel.SendRoomsInfoToAllUsers();
        }
        
        public System.Threading.Tasks.Task SendRoomsInfoToAllUsersAsync() {
            return base.Channel.SendRoomsInfoToAllUsersAsync();
        }
        
        public bool Register(string UserName, string psw) {
            return base.Channel.Register(UserName, psw);
        }
        
        public System.Threading.Tasks.Task<bool> RegisterAsync(string UserName, string psw) {
            return base.Channel.RegisterAsync(UserName, psw);
        }
        
        public void Logout(string username) {
            base.Channel.Logout(username);
        }
        
        public System.Threading.Tasks.Task LogoutAsync(string username) {
            return base.Channel.LogoutAsync(username);
        }
        
        public void SitDown(string userName, int index, int side) {
            base.Channel.SitDown(userName, index, side);
        }
        
        public System.Threading.Tasks.Task SitDownAsync(string userName, int index, int side) {
            return base.Channel.SitDownAsync(userName, index, side);
        }
        
        public void Start(string userName, int index, int side) {
            base.Channel.Start(userName, index, side);
        }
        
        public System.Threading.Tasks.Task StartAsync(string userName, int index, int side) {
            return base.Channel.StartAsync(userName, index, side);
        }
        
        public void GetUp(int index, int side) {
            base.Channel.GetUp(index, side);
        }
        
        public System.Threading.Tasks.Task GetUpAsync(int index, int side) {
            return base.Channel.GetUpAsync(index, side);
        }
        
        public void pertalk(string usernames, string usernamel, string str, bool end) {
            base.Channel.pertalk(usernames, usernamel, str, end);
        }
        
        public System.Threading.Tasks.Task pertalkAsync(string usernames, string usernamel, string str, bool end) {
            return base.Channel.pertalkAsync(usernames, usernamel, str, end);
        }
        
        public void Talk(int index, string userName, string message) {
            base.Channel.Talk(index, userName, message);
        }
        
        public System.Threading.Tasks.Task TalkAsync(int index, string userName, string message) {
            return base.Channel.TalkAsync(index, userName, message);
        }
        
        public void SetDot(int index, int i, int j) {
            base.Channel.SetDot(index, i, j);
        }
        
        public System.Threading.Tasks.Task SetDotAsync(int index, int i, int j) {
            return base.Channel.SetDotAsync(index, i, j);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Client.ServiceReference1.PerMessageResponse Client.ServiceReference1.IService1.PerMessage(Client.ServiceReference1.PerMessageRequest request) {
            return base.Channel.PerMessage(request);
        }
        
        public void PerMessage(string userName, ref int age1, ref string sex1, ref int price1, ref string country1) {
            Client.ServiceReference1.PerMessageRequest inValue = new Client.ServiceReference1.PerMessageRequest();
            inValue.userName = userName;
            inValue.age1 = age1;
            inValue.sex1 = sex1;
            inValue.price1 = price1;
            inValue.country1 = country1;
            Client.ServiceReference1.PerMessageResponse retVal = ((Client.ServiceReference1.IService1)(this)).PerMessage(inValue);
            age1 = retVal.age1;
            sex1 = retVal.sex1;
            price1 = retVal.price1;
            country1 = retVal.country1;
        }
        
        public System.Threading.Tasks.Task<Client.ServiceReference1.PerMessageResponse> PerMessageAsync(Client.ServiceReference1.PerMessageRequest request) {
            return base.Channel.PerMessageAsync(request);
        }
        
        public void MessageOk(string userName, int age1, string sex1, string country1) {
            base.Channel.MessageOk(userName, age1, sex1, country1);
        }
        
        public System.Threading.Tasks.Task MessageOkAsync(string userName, int age1, string sex1, string country1) {
            return base.Channel.MessageOkAsync(userName, age1, sex1, country1);
        }
        
        public string[] FriendList(string userName) {
            return base.Channel.FriendList(userName);
        }
        
        public System.Threading.Tasks.Task<string[]> FriendListAsync(string userName) {
            return base.Channel.FriendListAsync(userName);
        }
    }
}
