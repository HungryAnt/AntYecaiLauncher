using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntYecai.Models
{
    class User
    {
        public String UserId { get; set; } // 用户uuid
        public String LoginName { get; set; } // 登录账号
        public String UserName { get; set; } // 昵称
        public String Password { get; set; }
    }
}
