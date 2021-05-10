using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otchetnost
{
    public class Courses
    {
        public int id { get; set; }
        public string name { get; set; }
    }


    public class Profile
    {
        string sql_selectCourses = "SELECT g.id, CONCAT( c.name,'-',g.`course`,g.`group`) AS `name` FROM `groups` g " +
                                   "JOIN course c ON c.id = g.course_id;                                            ";

        string sql_deleteUserGroup = "DELETE FROM user_group ug WHERE ug.user_id = @sql_user_id;";

        string sql_insertUserGroup = "INSERT INTO user_group SET user_id = @sql_user_id, group_id = @sql_group_id;";



        public List<Courses> GetCourses()
        {
            var ccc = SQL.Select<Courses, dynamic>(sql_selectCourses, new { }, SQL.CONNECTION_STRING);
            return ccc;
        }

        public void DeleteUserGroup(int user_id)
        {
            SQL.Insert<dynamic>(sql_deleteUserGroup, new { @sql_user_id = user_id }, SQL.CONNECTION_STRING);
        }

        public void InsertUserGroup(int user_id, int group_id)
        {
            SQL.Insert<dynamic>(sql_insertUserGroup, new { @sql_user_id = user_id, @sql_group_id = group_id }, SQL.CONNECTION_STRING);
        }

    }


}
