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

            string sqlSelectUserType = "SELECT u.type FROM users AS u WHERE u.login = @login";

            string sqlSelectStudentSettings = "SELECT u.id, u.login,u.password,u.img,c.name,g.course,g.`group`,ug.subgroup FROM `users` AS u " +
                                              "JOIN `user_group` AS ug ON u.id = ug.user_id " +
                                              "JOIN `groups` AS g ON g.id = ug.group_id " +
                                              "JOIN `course` AS c ON c.id = g.course_id " +
                                              "WHERE login = @login";

            string sqlSelectTeacherSettings = "SELECT u.id, u.login,u.password,u.img,c.name FROM `users` AS u " +
                                              "JOIN `user_group` AS ug ON u.id = ug.user_id " +
                                              "JOIN `groups` AS g ON g.id = ug.group_id " +
                                              "JOIN `course` AS c ON c.id = g.course_id " +
                                              "WHERE login = @login";

            if (jsonObj["login"] != string.Empty)
            {
                int type = SQL.Select<int, dynamic>(sqlSelectUserType, new { login = jsonObj["login"] }, SQL.CONNECTION_STRING)[0];

                switch (type)
                {
                    case 0:
                        us = SQL.Select<Student, dynamic>(sqlSelectStudentSettings, new { login = jsonObj["login"] }, SQL.CONNECTION_STRING)[0];
                        break;
                    case 1:
                        us = SQL.Select<Teacher, dynamic>(sqlSelectTeacherSettings, new { login = jsonObj["login"] }, SQL.CONNECTION_STRING)[0];
                        break;
                    default:
                        return false;
                        break;
                }

                if (us != null)
                {
                    if (us.password == Convert.ToString(jsonObj["password"]))
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
