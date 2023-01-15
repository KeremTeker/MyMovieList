using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Editor:IEntity
    {
        public int EditorId { get; set; }
        public string EditorUserName { get; set; }
        public string EditorEmail { get; set; }
        public string EditorBirthDay { get; set; }
        public string EditorPassword { get; set; }
        public int EditorSalary { get; set; }
    }
}
