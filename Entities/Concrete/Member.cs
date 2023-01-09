using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Member:IEntity
    {
        public int MemberId { get; set; }
        public string MemberUserName { get; set; }
        public string MemberEmail { get; set; }
        public string MemberBirthDay { get; set; }
        public string MemberPassword { get; set; }
    }
}
