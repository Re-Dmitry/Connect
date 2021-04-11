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

            string sqlSelectStudentSettings = "SELECT u.id, u.login,u.password, u.name,u.img,c.name as courseName,g.id as group_id, g.course,g.`group`,ug.subgroup FROM `users` AS u " +
                                              "JOIN `user_group` AS ug ON u.id = ug.user_id " +
                                              "JOIN `groups` AS g ON g.id = ug.group_id " +
                                              "JOIN `course` AS c ON c.id = g.course_id " +
                                              "WHERE login = @sql_login";

            string sqlSelectTeacherSettings = "SELECT u.id, u.login,u.password,u.img, t.fio, t.id AS teacher_id FROM `users` AS u  " +
                                              "JOIN teacher AS t ON t.user_id = u.id                                               " +
                                              "WHERE login = @sql_login                                                            ";

            string sqlSelectTeacherGroup = "SELECT g.id,c.`name` as courseName, g.`course`, g.`group` FROM group_discipline AS gd " +
                                           "JOIN `groups` AS g ON g.id = gd.group_id                                              " +
                                           "JOIN course AS c ON c.id = g.course_id                                                " +
                                           "WHERE gd.teacher_id = @sql_teacher_id                                                 " +
                                           "GROUP BY g.id;                                                                        ";


            if (jsonObj["login"] != string.Empty)
            {
                int type = SQL.Select<int, dynamic>(sqlSelectUserType, new { login = jsonObj["login"] }, SQL.CONNECTION_STRING)[0];

                switch (type)
                {
                    case 0:
                        us = SQL.Select<Student, dynamic>(sqlSelectStudentSettings, new { sql_login = jsonObj["login"] }, SQL.CONNECTION_STRING)[0];
                        break;
                    case 1:
                        us = SQL.Select<Teacher, dynamic>(sqlSelectTeacherSettings, new { sql_login = jsonObj["login"] }, SQL.CONNECTION_STRING)[0];
                        ((Teacher)us).groups = SQL.Select<Group, dynamic>(sqlSelectTeacherGroup, new { sql_teacher_id = us.id }, SQL.CONNECTION_STRING);
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
