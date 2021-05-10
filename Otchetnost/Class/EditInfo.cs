using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otchetnost
{
    public class Teachers
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string fio { get; set; }
    }

    public class EditInfo
    {
        public string sql_SelectDiscipine = "SELECT d.id discipline_id, d.name FROM disciplines d;";
        public string sql_InsertDiscipine = "INSERT INTO disciplines(`name`) VALUES(@sql_name);";
        public string sql_UpdateDiscipineName = "UPDATE disciplines d SET d.name = @sql_name WHERE d.id = @sql_id;";
        public string sql_DeleteDiscipine = "DELETE FROM disciplines d WHERE d.id = @sql_id;";

        public string sql_SelectGroup = "SELECT g.id, c.name AS courseName, g.`course` , g.`group` FROM `groups` g  JOIN course c ON g.course_id = c.id WHERE g.`course` != 'empty' && g.`course` != '0'";
        public string sql_UpdateGroupName = "UPDATE disciplines d SET d.name = @sql_name WHERE d.id = @sql_id;";
        public string sql_DeleteGroup = "DELETE FROM disciplines d WHERE d.id = @sql_id;";

        public string sql_SelectGroupDiscipline = "SELECT d.id discipline_id, d.name, gd.teacher_id, t.fio FROM group_discipline gd JOIN disciplines d ON d.id = gd.discipline_id JOIN teacher t ON t.id = gd.teacher_id WHERE gd.group_id = @sql_group_id;";
        public string sql_InsertGroupDiscipline = "INSERT INTO group_discipline(group_id, discipline_id, teacher_id) VALUES(@sql_group_id, @sql_discipline_id, @sql_teacher_id);";
        public string sql_DeleteGroupDiscipline = "DELETE FROM group_discipline gd WHERE gd.group_id = @sql_group_id && gd.discipline_id = @sql_discipline_id;";

        public string sql_SelectStudent = " SELECT u.id, u.login, u.name, c.name AS courseName, g.course, g.`group`, ug.subgroup FROM users u left JOIN user_group ug ON ug.user_id = u.id left  JOIN `groups` g ON g.id = ug.group_id LEFT JOIN `course` c ON c.id = g.course_id  WHERE u.`type` = 0;";
        public string sql_UpdateUserGroup = "UPDATE user_group ug SET ug.group_id = @sql_group_id WHERE ug.user_id = @sql_user_id;";
        public string sql_UpdateUserName = "UPDATE users u SET u.name = @sql_name WHERE u.id = @sql_user_id;";

        public string sql_SelectTeacher = "SELECT * FROM users u lEFT JOIN teacher t ON t.user_id = u.id WHERE u.`type` = 1;";
        public string sql_InsertTeacher = "START TRANSACTION;                                                     " +
                                          "INSERT INTO teacher(user_id, fio) VALUES(@sql_user_id, @sql_name);     " +
                                          "UPDATE users u SET u.`type` = 1 WHERE u.id = @sql_user_id;             " +
                                          "DELETE FROM user_group ug WHERE ug.user_id = @sql_user_id;             " +
                                          "COMMIT;                                                                ";
        public string sql_DeleteTeacher = "START TRANSACTION;                                                     " +
                                          "DELETE FROM teacher t WHERE t.user_id = @sql_user_id;                  " +
                                          "UPDATE users u SET u.`type` = 0 WHERE u.id = @sql_user_id;             " +
                                          "COMMIT;                                                                ";


        //public string sql_UpdateGroupName = "UPDATE disciplines d SET d.name = @sql_name WHERE d.id = @sql_id;";
        //public string sql_DeleteGroup = "DELETE FROM disciplines d WHERE d.id = @sql_id;";
    }
}
