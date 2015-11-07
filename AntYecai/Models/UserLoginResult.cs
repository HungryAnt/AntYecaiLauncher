using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AntYecai.Models
{
    [DataContract]
    public class UserLoginResult
    {
        [DataMember(Name = "success")]
        public bool Success { get; set; }

        [DataMember(Name = "userId")]
        public String UserId { get; set; }
    }
}
