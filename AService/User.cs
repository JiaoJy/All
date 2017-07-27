using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AService
{
    [DataContract]
    [Serializable] 
    public class User
    {
        /// <summary>登录的用户名</summary>
        public string UserName { get; set; }

        /// <summary>与该用户通信的回调接口</summary>
        public readonly IService1CallBack callback;

        /// <summary>用户所坐的桌号(-1:大厅)</summary>
        public int Index { get; set; }

        /// <summary>用户所坐的座位号(0:黑方，1:白方)</summary>
        public int Side { get; set; }

        /// <summary>是否已单击【开始】按钮</summary>
        public bool IsStarted { get; set; }

        public User(string userName, IService1CallBack callback)
        {
            this.UserName = userName;
            this.callback = callback;
        }

    }
}