using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AntYecai.Http
{
    [DataContract]
    public class GameServerErrorInfo
    {
//        public const String LoginUserAlreadyExistsCode = "LoginUserAlreadyExists";

        [DataMember(Name = "requestId")]
        public String RequestId { get; set; }

        [DataMember(Name = "code")]
        public String Code { get; set; }

        [DataMember(Name = "message")]
        public new String Message { get; set; }
    }
}
