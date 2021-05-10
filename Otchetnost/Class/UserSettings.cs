using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otchetnost
{
    public class UserSettings
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string img { get; set; }
        public string name { get; set; }
    }

    public class Group
    {
        public int id { get; set; }
        public string courseName { get; set; }
        public string course { get; set; }
        public string group { get; set; }
    }

    public class Teacher : UserSettings
    {
        public int teacher_id { get; set; }
        public string fio { get; set; }
        public List<Group> groups { get; set; }
    }

    public class Student : UserSettings
    {
        public int group_id { get; set; }
        public string courseName { get; set; }
        public string course { get; set; }
        public string group { get; set; }
        public string subgroup { get; set; }
    }

    public class Admin : UserSettings
    {
       
    }
}

