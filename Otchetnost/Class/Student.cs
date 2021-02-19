using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otchetnost
{
    public class Student: UserSettings
    {
        public string course { get; set; }
        public string group { get; set; }
        public string subgroup { get; set; }
    }
}
