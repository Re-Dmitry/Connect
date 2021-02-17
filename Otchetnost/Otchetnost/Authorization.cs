using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otchetnost
{
    public class Authorization
    {
        public bool Auh(ref UserSettings us)
        {
            string json = File.ReadAllText("userconfig.json");
            dynamic jsonObj = JsonConvert.DeserializeObject(json);

            string sqlSelectUserSettings = "SELECT u.login,u.password,u.img,c.name,g.course,g.`group`,ug.subgroup FROM `users` AS u " +
                                           "JOIN `user_group` AS ug ON u.id = ug.user_id " +
                                           "JOIN `groups` AS g ON g.id = ug.group_id " +
                                           "JOIN `course` AS c ON c.id = g.course_id " +
                                           "WHERE login = @login";

            List<UserSettings> usBuf = new List<UserSettings>();

            if (jsonObj["login"] != string.Empty)
            {
                usBuf = SQL.Select<UserSettings, dynamic>(sqlSelectUserSettings, new { login = jsonObj["login"] }, SQL.CONNECTION_STRING);
                if(usBuf.Count != 0)
                {
                    if(usBuf[0].password == Convert.ToString(jsonObj["password"]))
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }
    }
}
