using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AntYecai.Models
{
    [DataContract]
    public class UserLoginInfo
    {
        [DataMember(Name = "loginName")]
        public String LoginName { get; set; }

        [DataMember(Name = "password")]
        public String Password { get; set; }
    }
}
