using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otchetnost
{
    public class TasksInfo
    {
        public int count_complete { get; set; }
        public int id { get; set; }
        public int group_id { get; set; }
        public int discipline_id { get; set; }
        public string text { get; set; }
        public string date { get; set; }
        public string deadline { get; set; }
        public int local_complete { get; set; }
        public int global_complete { get; set; }
        public string last_update { get; set; }
    }

    public class TasksExtend: TasksInfo
    {
        public string extend_text { get; set; }
        public string link { get; set; }
        public string img { get; set; }
    }

    public class Discipline
    {
        public int discipline_id { get; set; }
        public string name { get; set; }
        public string teacher_id { get; set; }
        public string fio { get; set; }
    }

    public class Tasks
    {
        string sql_SelectTask = "SELECT t.id, t.group_id,t.discipline_id, t.`text`,  DATE(t.`date`) date, DATE(t.deadline) deadline , tus.local_complete, tus.global_complete, tus.last_update, ti.`text` AS extend_text, ti.link, ti.img FROM tasks AS t  " +
                                "left JOIN task_user_status AS tus ON tus.task_id = t.id                                                                                                                                       " +
                                "left JOIN task_information AS ti ON ti.task_id= t.id                                                                                                                                          " +
                                "WHERE t.group_id = @sql_group_id && tus.user_id = @sql_user_id && t.discipline_id = @sql_discipline_id;                                                                                       ";

        string sql_SelectDiscipline = "SELECT gd.discipline_id, d.name, t.fio FROM group_discipline AS gd    " +
                                      "left JOIN disciplines AS d ON d.id = gd.discipline_id                 " +
                                      "left JOIN teacher AS t ON t.id = gd.teacher_id                        " +
                                      "WHERE gd.group_id = @sql_group_id && gd.teacher_id = @sql_teacher_id; ";

        string sql_SelectDisciplineStudent = "SELECT gd.discipline_id, d.name, t.fio FROM group_discipline AS gd    " +
                                             "left JOIN disciplines AS d ON d.id = gd.discipline_id                 " +
                                             "left JOIN teacher AS t ON t.id = gd.teacher_id                        " +
                                             "WHERE gd.group_id = @sql_group_id;                                    ";

        string sql_SelectStudent = "SELECT u.id, u.login, u.name, u.img, c.name AS courseName, g.id as group_id, g.course, g.`group`, ug.subgroup FROM `users` AS u  " +
                                   "JOIN `user_group` AS ug ON u.id = ug.user_id                                                                                     " +
                                   "JOIN `groups` AS g ON g.id = ug.group_id                                                                                         " +
                                   "JOIN `course` AS c ON c.id = g.course_id                                                                                         " +
                                   "WHERE ug.group_id = @sql_group_id;                                                                                               ";

        string sql_SelectPrevTask = "SELECT sum(tus.global_complete) AS count_complete, t.id, t.group_id,t.discipline_id, t.`text`, t.`date`,t.deadline, ti.`text` AS extend_text, ti.link, ti.img FROM tasks AS t  " +
                                    "left JOIN task_user_status AS tus ON t.id = tus.task_id                                                                                                                        " +
                                    "left JOIN task_information AS ti ON t.id = ti.task_id                                                                                                                          " +
                                    "WHERE t.group_id = @sql_group_id && t.discipline_id = @sql_discipline_id                                                                                                       " +
                                    "GROUP BY t.id, extend_text, link, img;                                                                                                                                         ";

        string sql_SelectCountUser = "SELECT COUNT(ug.user_id) AS count_user FROM user_group AS ug " +
                                     "WHERE ug.group_id = @sql_group_id;                            ";

        string sql_InsertTask = "INSERT INTO tasks                                              " +
                                "SET `group_id` = @sql_group_id,                                " +
                                "`discipline_id` = @sql_discipline_id,                          " +
                                "`semestr` = (SELECT id FROM semestr ORDER BY id DESC LIMIT 1), " +
                                "`text` = @sql_text,                                            " +
                                "`deadline` = date(FROM_UNIXTIME(@sql_unixtime));               ";

        string sql_InsertTaskNull = "INSERT INTO tasks                                              " +
                                    "SET `group_id` = @sql_group_id,                                " +
                                    "`discipline_id` = @sql_discipline_id,                          " +
                                    "`semestr` = (SELECT id FROM semestr ORDER BY id DESC LIMIT 1), " +
                                    "`text` = @sql_text;                                            ";


        string sql_ChangeTaskStatus = "UPDATE task_user_status tus                                                           " +
                                      "SET tus.global_complete = !tus.global_complete, tus.last_update = CURRENT_TIMESTAMP() " +
                                      "WHERE tus.task_id = @sql_task_id && tus.user_id = @sql_user_id;                       ";

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        public List<TasksExtend> GetTask(int group_id, int user_id, int discipline_id)
        {
            var task = SQL.Select<TasksExtend, dynamic>(sql_SelectTask, new { sql_group_id= group_id, sql_user_id= user_id, sql_discipline_id  = discipline_id }, SQL.CONNECTION_STRING);
            return task; 
        }

        public List<TasksExtend> GetTask(int group_id, int discipline_id)
        {
            var task = SQL.Select<TasksExtend, dynamic>(sql_SelectPrevTask, new { sql_group_id = group_id, sql_discipline_id = discipline_id }, SQL.CONNECTION_STRING);
            return task;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<Discipline> GetDisciplineStudent(int group_id)
        {
            var discipline = SQL.Select<Discipline, dynamic>(sql_SelectDisciplineStudent, new { sql_group_id = group_id }, SQL.CONNECTION_STRING);
            return discipline;  
        }

        public List<Discipline> GetDisciplineStudent(int group_id, int teacher_id)
        {
            var discipline = SQL.Select<Discipline, dynamic>(sql_SelectDiscipline, new { sql_group_id = group_id, sql_teacher_id = teacher_id}, SQL.CONNECTION_STRING);
            return discipline;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<Student> GetAllStudent(int group_id)
        {
            var student = SQL.Select<Student, dynamic>(sql_SelectStudent, new { sql_group_id = group_id }, SQL.CONNECTION_STRING);
            return student;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public int GetCountUser(int group_id)
        {
            var student = SQL.Select<int, dynamic>(sql_SelectCountUser, new { sql_group_id = group_id }, SQL.CONNECTION_STRING)[0];
            return student;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool AddTask(int group_id, int discipline_id,string text, string unixtime)
        {
            if (unixtime != "NULL") SQL.Insert<dynamic>(sql_InsertTask, new { sql_group_id = group_id, sql_discipline_id = discipline_id, sql_text = text, sql_unixtime = unixtime}, SQL.CONNECTION_STRING);
            else SQL.Insert<dynamic>(sql_InsertTaskNull, new { sql_group_id = group_id, sql_discipline_id = discipline_id, sql_text = text}, SQL.CONNECTION_STRING);
           
            return true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool ChangeTaskStatus(int task_id, int user_id)
        {
            SQL.Insert<dynamic>(sql_ChangeTaskStatus, new { sql_task_id = task_id, sql_user_id = user_id }, SQL.CONNECTION_STRING);

            return true;
        }
    }
}
