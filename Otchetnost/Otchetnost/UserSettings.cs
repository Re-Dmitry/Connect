using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otchetnost
{
    public class UserSettings
    {
        public string login { get; set; }
        public string password { get; set; }
        public string img { get; set; }
        public string name { get; set; }
        public string course { get; set; }
        public string group { get; set; }
        public string subgroup { get; set; }
        public bool admin { get; set; }
    }
}
