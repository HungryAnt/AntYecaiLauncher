using System;
using System.Runtime.Serialization;

namespace AntYecai.Models
{
    [DataContract]
    public class UserRegisterInfo
    {
        [DataMember(Name = "loginName")]
        public String LoginName { get; set; }

        [DataMember(Name = "password")]
        public String Password { get; set; }

        [DataMember(Name = "relatedUserId")]
        public String RelatedUserId { get; set; }

        [DataMember(Name = "gender")]
        public String Gender { get; set; }

        [DataMember(Name = "qq")]
        public String QQ { get; set; }

        [DataMember(Name = "email")]
        public String Email { get; set; }

        [DataMember(Name = "introduction")]
        public String Introduction { get; set; }
    }
}
