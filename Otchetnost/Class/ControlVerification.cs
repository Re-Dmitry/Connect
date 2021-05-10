using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otchetnost
{
    public class ControlVerification
    {
        public bool EditTaskVerification(string text)
        {
            if (text.Length < 10) return false;
            //Если нужно придумайте сами, я не вижу в этом нужды

            return true;
        }

        public bool AddTaskVerification(string text)
        {
            if (text.Length < 10) return false;
            //Если нужно придумайте сами, я не вижу в этом нужды

            return true;
        }
    }
}
