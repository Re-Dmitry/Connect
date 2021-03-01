using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otchetnost
{
    public class id_message
    {
        public int id;
        public int user_id;

        public id_message(int id, int user_id)
        {
            this.id = id;
            this.user_id = user_id;
        }
    }

    public class Message
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string login { get; set; }
        public string text { get; set; }
        public string date { get; set; }
    }

    public class Chat
    {
        string sqlInsertGlobalMessage = "INSERT INTO chat_global(`user_id`,`text`) VALUES(@sql_user_id, @sql_text);";
        string sqlInsertGroupMessage = "INSERT INTO `otchentnost`.`chat_group` (`group_id`, `semestr_id`, `user_id`, `text`) VALUES (@sql_group_id, '18', @sql_user_id, @sql_text);";
        string sqlInsertDirectMessage = "INSERT INTO `otchentnost`.`chat_user` (`user_id_s`, `user_id_r`, `text`) VALUES (@sql_s, @sql_r, @sql_text);";

        string sqlSelectGlobalMessage = "SELECT ch.id, ch.user_id, u.login, ch.`text`, ch.`date` FROM chat_global AS ch JOIN users AS u ON u.id = ch.user_id WHERE ch.user_id = @sql_user_id ORDER BY ch.id DESC LIMIT 1;";
        string sqlSelectGroupMessage = "SELECT ch.id, ch.user_id, u.login, ch.`text`, ch.`date` FROM chat_global AS ch JOIN users AS u ON u.id = ch.user_id WHERE ch.user_id = @sql_user_id ORDER BY ch.id DESC LIMIT 1;";
        string sqlSelectDirectMessage = "SELECT ch.id, ch.user_id, u.login, ch.`text`, ch.`date` FROM chat_global AS ch JOIN users AS u ON u.id = ch.user_id WHERE ch.user_id = @sql_user_id ORDER BY ch.id DESC LIMIT 1;";

        string sqlSelectAllGlobalMessage = "SELECT ch.id, ch.user_id, u.login, ch.`text`, ch.`date` FROM chat_global AS ch JOIN users AS u ON u.id = ch.user_id WHERE ch.id > @sql_id;";

        string sqlSelectAllGroupMessage = "SELECT ch.id, ch.user_id, u.login, ch.`text`, ch.`date` FROM chat_group AS ch JOIN users AS u ON u.id = ch.user_id WHERE ch.id > @sql_id AND ch.group_id = @sql_gr_id;";
       // string sqlSelectAllDirectMessage = "SELECT ch.id, ch.user_id, u.login, ch.`text`, ch.`date` FROM chat_global AS ch JOIN users AS u ON u.id = ch.user_id WHERE ch.id > @sql_id;";

        string sqlSelectAllDirectMessage = "SELECT ch.id, ch.user_id_s AS user_id, u.login, ch.text, ch.date FROM chat_user AS ch                                     " +
                                           "JOIN users AS u ON u.id = ch.user_id_s                                                                             " +
                                           "WHERE ((user_id_s = @sql_s AND USER_id_r = @sql_r) OR (user_id_s = @sql_r AND USER_id_r = @sql_s)) AND ch.id > @sql_id;  ";



        public Message SendGlobal(string text, int user_id)
        {
            SQL.Insert<dynamic>(sqlInsertGlobalMessage, new { sql_user_id = user_id, sql_text = text }, SQL.CONNECTION_STRING);
            var ms = SQL.Select<Message, dynamic>(sqlSelectGlobalMessage, new { sql_user_id = user_id }, SQL.CONNECTION_STRING)[0];

            return ms;
        }

        public Message SendGroup(string text, int user_id, int group_id)
        {
            SQL.Insert<dynamic>(sqlInsertGroupMessage, new { sql_group_id = group_id, sql_user_id = user_id, sql_text = text }, SQL.CONNECTION_STRING);
            //var ms = SQL.Select<Message, dynamic>(sqlSelectGroupMessage, new { sql_user_id = user_id }, SQL.CONNECTION_STRING)[0];

            return null;
        }

        public Message SendDirect(string text, int user_id, int user_id_frend)
        {
            SQL.Insert<dynamic>(sqlInsertDirectMessage, new { sql_r = user_id_frend, sql_s = user_id, sql_text = text }, SQL.CONNECTION_STRING);
            //var ms = SQL.Select<Message, dynamic>(sqlSelectDirectMessage, new { sql_user_id = user_id }, SQL.CONNECTION_STRING)[0];

            return null;
        }

        public List<Message> ReceiveAllGlobal(int id)
        {
            var ms = SQL.Select<Message, dynamic>(sqlSelectAllGlobalMessage, new { sql_id = id }, SQL.CONNECTION_STRING);

            return ms;
        }

        public List<Message> ReceiveMessage(int id, int iD_with_frend, int iD_My)
        {
            var ms = SQL.Select<Message, dynamic>(sqlSelectAllDirectMessage, new { @sql_r = iD_with_frend, sql_s = iD_My, @sql_id = id }, SQL.CONNECTION_STRING);

            return ms;
        }

        public List<Message> ReceiveAllGroup(int id, int Group_id)
        {
            var ms = SQL.Select<Message, dynamic>(sqlSelectAllGroupMessage, new { sql_id = id, sql_gr_id = Group_id }, SQL.CONNECTION_STRING);

            return ms;
        }

        public List<Message> ReceiveAllDirect(int id)
        {
            //var ms = SQL.Select<Message, dynamic>(sqlSelectAllDirectMessage, new { sql_id = id }, SQL.CONNECTION_STRING);

            return null;
        }
    }
}
