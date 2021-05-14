using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Otchetnost
{
    public partial class MainWindow : Window
    {
        public static UserSettings user = new UserSettings();
        public int chat_type { get; set; }
        public int chat_id { get; set; }

        public int now_discipline_id { get; set; }
        public static int now_student_id { get; set; }
        public int now_group_id { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            Control.Visibility = Visibility.Collapsed;
            Init();
        }

        public async void Init()
        {
            chat_type = 0;
            chat_id = 0;
            Chat.Children.Add(new ChatMessageControl(0, ""));
            string json = File.ReadAllText("userconfig.json");

            if (new Authorization().Auh(ref user, json))
            {
                Control.Visibility = Visibility.Visible;
                LoadTasksSection();
                LoadProfileSection();
                LoadScheduleSection();

                if (user.GetType().Name == "Admin")
                {
                    LoadDiscipline();
                    LoadGroupDiscipline();
                    LoadUserPermission();

                    UserSettings.Visibility = Visibility.Visible;

                }
                else
                {
                    UserSettings.Visibility = Visibility.Collapsed;
                }

                UpdateChatAsync();
            }
            else
            {
                MainBar.Children.Add(new SignInControl());
                Control.Visibility = Visibility.Collapsed;
            }
        }

        public async Task UpdateChatAsync()
        {
            while (true)
            {
                await Task.Delay(2500);

                ChatMessageControl cmc = null;
                if (Chat.Children.Count > 0)
                    cmc = (ChatMessageControl)Chat.Children[Chat.Children.Count - 1];
                else
                {
                    Chat.Children.Add(new ChatMessageControl(0, 0, " "));
                    cmc = (ChatMessageControl)Chat.Children[Chat.Children.Count - 1];
                }

                List<Message> message = null;

                switch (chat_type)
                {
                    case 1:
                        message = new Chat().ReceiveAllGlobal(((id_message)cmc.Tag).id);
                        break;
                    case 2:
                        message = new Chat().ReceiveAllGroup(((id_message)cmc.Tag).id, 118);
                        int f = 10;
                        break;
                    case 3:
                        message = new Chat().ReceiveMessage(((id_message)cmc.Tag).id, 5, 1);
                        break;
                    case 4:


                        break;
                    default:
                        break;
                }

                if (message != null)
                {
                    foreach (var item in message)
                    {
                        if (Chat.Children[Chat.Children.Count - 1] is ChatMessageControl cmcNow)
                        {
                            if (((id_message)cmcNow.Tag).user_id == item.user_id)
                            {
                                Chat.Children.Add(new ChatMessageControl(item.id, item.user_id, item.text));
                            }
                            else
                            {
                                Chat.Children.Add(new ChatMessageControl(item.id, item.user_id, item.login, item.date, item.text));
                            }
                        }
                    }
                    if (ScrollChat.ExtentHeight - ScrollChat.VerticalOffset < 800)
                        ScrollChat.ScrollToVerticalOffset(ScrollChat.ExtentHeight);
                }

            }
        }

        #region Load

        public void LoadTasksSection()
        {
            List<Discipline> discipline = null;
            switch (user.GetType().Name)
            {
                case "Student":
                    TaskSettings.Visibility = Visibility.Collapsed;
                    AddTasks.Visibility = Visibility.Collapsed;
                    discipline = new Tasks().GetDisciplineStudent(((Student)user).group_id);
                    fff.Visibility = Visibility.Collapsed;

                    foreach (var item in discipline)
                    {
                        var oc = new ObjectControl(item.discipline_id, item.name, item.fio);
                        oc.MouseDown += StackPanel_MouseDown;
                        ObjectsPanel.Children.Add(oc);
                    }

                    break;
                case "Teacher":
                    TaskSettings.Visibility = Visibility.Visible;
                    AddTasks.Visibility = Visibility.Visible;

                    GroupBox.SelectionChanged += GroupBox_SelectionChanged;
                    foreach (var item in ((Teacher)user).groups)
                    {
                        ComboBoxItem ci = new ComboBoxItem();
                        ci.Content = item.courseName + item.course + item.group;
                        ci.Tag = item.id;

                        GroupBox.Items.Add(ci);
                    }

                    break;

                case "Admin":
                    TaskSettings.Visibility = Visibility.Visible;
                    AddTasks.Visibility = Visibility.Visible;

                    var group = SQL.Select<Group, dynamic>(new EditInfo().sql_SelectGroup, new { }, SQL.CONNECTION_STRING);
                   
                    GroupBox.SelectionChanged += GroupBox_SelectionChanged;
                    foreach (var item in group)
                    {
                        ComboBoxItem ci = new ComboBoxItem();
                        ci.Content = item.courseName + item.course + item.group;
                        ci.Tag = item.id;

                        GroupBox.Items.Add(ci);
                    }

                    break;
                default:
                    break;
            }
        }

        public void LoadTask()
        {
            List<TasksExtend> task = null;
            int countUser = 0;

            if (user.GetType().Name == "Student")
            {
                task = new Tasks().GetTask(((Student)user).group_id, user.id, now_discipline_id);
            }
            else if (user.GetType().Name == "Teacher" || user.GetType().Name == "Admin")
            {
                if ((ComboBoxItem)StudentBox.SelectedItem == null || ((ComboBoxItem)StudentBox.SelectedItem).Content == "All")
                {
                    task = new Tasks().GetTask(Convert.ToInt32(((ComboBoxItem)GroupBox.SelectedItem).Tag), now_discipline_id);
                    countUser = new Tasks().GetCountUser(Convert.ToInt32(((ComboBoxItem)GroupBox.SelectedItem).Tag));
                }
                else
                {
                    task = new Tasks().GetTask(Convert.ToInt32(((ComboBoxItem)GroupBox.SelectedItem).Tag), Convert.ToInt32(((ComboBoxItem)StudentBox?.SelectedItem).Tag), now_discipline_id);
                }
            }

            if (task != null)
            {
                foreach (var item in task)
                {
                    if (((ComboBoxItem)StudentBox.SelectedItem == null || ((ComboBoxItem)StudentBox.SelectedItem).Content == "All") && user.GetType().Name != "Student")
                    {
                        TasksPanel.Children.Add(new TaskControl(item.id, item.text, item.date, item.deadline, countUser, item.count_complete));
                    }
                    else
                    {
                        TasksPanel.Children.Add(new TaskControl(item.id, item.global_complete, item.text, item.date, item.deadline));
                    }
                }
            }
        }

        #endregion

        #region Events

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string text = TextInputBox.Text;
            TextInputBox.Text = "";
            Message message = null;
            if (text != String.Empty && text.Length < 1000)
            {
                switch (chat_type)
                {
                    case 1:
                        message = new Chat().SendGlobal(text, user.id);
                        break;
                    case 2:
                        message = new Chat().SendGroup(text, user.id, 118);
                        break;
                    case 3:
                        message = new Chat().SendDirect(text, user.id, 5);
                        break;
                    default:
                        break;
                }

                if (message != null)
                {
                    if (Chat.Children[Chat.Children.Count - 1] is ChatMessageControl cmc)
                    {
                        if (((id_message)cmc.Tag).id == user.id)
                        {
                            Chat.Children.Add(new ChatMessageControl(message.id, message.user_id, message.text));
                        }
                        else
                        {
                            Chat.Children.Add(new ChatMessageControl(message.id, message.user_id, message.login, message.date, message.text));
                        }
                    }
                }
            }
        }

        private void DragMoveMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void ChatTypeGlobal_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            chat_type = 1;
            chat_id = Convert.ToInt32(button.Tag);
            Chat.Children.Clear();
            //UpdateChatAsync();

        }

        private void ChatTypeGroup_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            chat_type = 2;
            chat_id = Convert.ToInt32(button.Tag);
            Chat.Children.Clear();
        }

        private void ChatTypeDirect_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            chat_type = 3;
            chat_id = Convert.ToInt32(button.Tag);
            Chat.Children.Clear();
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TasksPanel.Children.Clear();
            ObjectControl sp = (ObjectControl)sender;
            now_discipline_id = Convert.ToInt32(sp.Tag);
            LoadTask();
        }

        private void GroupBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TasksPanel.Children.Clear();
            ComboBox cb = (ComboBox)sender;
            ComboBoxItem ci = (ComboBoxItem)cb.SelectedItem;
            ObjectsPanel.Children.Clear();
            now_group_id = Convert.ToInt32(ci.Tag);

            var discipline = new List<Discipline>();

            if (user.GetType().Name == "Admin")
            {
                discipline = new Tasks().GetDisciplineStudent(Convert.ToInt32(ci.Tag), -1);
            }
            else
            {
                discipline = new Tasks().GetDisciplineStudent(Convert.ToInt32(ci.Tag), ((Teacher)user).teacher_id);
            }

            var student = new Tasks().GetAllStudent(Convert.ToInt32(ci.Tag));

            foreach (var item in discipline)
            {
                var oc = new ObjectControl(item.discipline_id, item.name, item.fio);
                oc.MouseDown += StackPanel_MouseDown;
                ObjectsPanel.Children.Add(oc);
            }

            StudentBox.Items.Clear();
            ComboBoxItem cis = new ComboBoxItem();
            cis.Content = "All";
            cis.Tag = 0;
            StudentBox.Items.Add(cis);

            foreach (var item in student)
            {
                cis = new ComboBoxItem();
                if (item.name == null) cis.Content = item.login;
                else cis.Content = item.name;
                cis.Tag = item.id;

                StudentBox.Items.Add(cis);
            }

        }

        private void StudentBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TasksPanel.Children.Clear();

            LoadTask();

            now_student_id = Convert.ToInt32(((ComboBoxItem)((ComboBox)sender).SelectedItem)?.Tag);

            //var task = new Tasks().GetTask(Convert.ToInt32(((ComboBoxItem)GroupBox.SelectedItem).Tag), Convert.ToInt32(((ComboBoxItem)StudentBox?.SelectedItem).Tag), now_discipline_id);

            //if (task != null)
            //{
            //    foreach (var item in task)
            //    {
            //        TasksPanel.Children.Add(new TaskControl(item.id, item.global_complete, item.text, item.date, item.deadline));
            //    }
            //}


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(new ControlVerification().AddTaskVerification(TaskBox.Text))
            {
                string text = TaskBox.Text;
                string unixDateTime = "NULL";

                if (Deadline.SelectedDate.HasValue)
                {
                    var dateTimeOffset = new DateTimeOffset((DateTime)Deadline.SelectedDate);
                    unixDateTime = dateTimeOffset.ToUnixTimeSeconds().ToString();
                }

                new Tasks().AddTask(now_group_id, now_discipline_id, text, unixDateTime);

                TasksPanel.Children.Clear();

                var task = new Tasks().GetTask(Convert.ToInt32(((ComboBoxItem)GroupBox.SelectedItem).Tag), now_discipline_id);
                var countUser = new Tasks().GetCountUser(Convert.ToInt32(((ComboBoxItem)GroupBox.SelectedItem).Tag));
                if (task != null)
                {
                    foreach (var item in task)
                    {
                        TasksPanel.Children.Add(new TaskControl(item.id, item.text, item.date, item.deadline, countUser, item.count_complete));
                    }
                }
            }
            else
            {
                TaskBox.Text = "";
            }
        }

        private void chat_users_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            chat_type = 4;
        }

        private void AppExit(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void AppMinimize(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if ((ComboBoxItem)ComboCourse.SelectedItem != null)
            {
                new Profile().DeleteUserGroup(user.id);
                new Profile().InsertUserGroup(user.id, (int)((ComboBoxItem)ComboCourse.SelectedItem).Tag);

                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Convert.ToInt32(((TextBlock)sender).Tag) == 0)
            {
                ((TextBlock)sender).Tag = 1;
                AddTasksFields.Visibility = Visibility.Visible;
            }
            else
            {
                ((TextBlock)sender).Tag = 0;
                AddTasksFields.Visibility = Visibility.Collapsed;
            }
        }

        #endregion

        #region Schedule

        public void LoadScheduleSection()
        {
            if (user.GetType().Name == "Student")
            {
                string gr = (((Student)user).courseName + '-' + ((Student)user).course + ((Student)user).group).ToString();
                ScheduleGroupBox.Visibility = Visibility.Collapsed;
                for (int i = 0; i < 6; i++)
                {
                    if (i < 3) SchedUpper.Children.Add(new RaspisaniePage(SQL.Select<Schedule, dynamic>(new SqlSchedule().sql_SelectScheduleDay, new { sql_group = gr, sql_date = i }, SQL.CONNECTION_STRING_IATU), i));
                    else SchedLower.Children.Add(new RaspisaniePage(SQL.Select<Schedule, dynamic>(new SqlSchedule().sql_SelectScheduleDay, new { sql_group = gr, sql_date = i }, SQL.CONNECTION_STRING_IATU), i));
                }
            }
            else
            {
                var group = SQL.Select<Group, dynamic>(new EditInfo().sql_SelectGroup, new { }, SQL.CONNECTION_STRING);

                ComboBoxItem cis = new ComboBoxItem();
                ScheduleGroupBox.SelectionChanged += ScheduleGroupBox_SelectionChanged;

                foreach (var item in group)
                {
                    cis = new ComboBoxItem();
                    cis.Content = (item.courseName + "-" + item.course + item.group).ToString();
                    cis.Tag = item.id;

                    ScheduleGroupBox.Items.Add(cis);
                }
            }
        }

        private void ScheduleGroupBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SchedUpper.Children.Clear();
            SchedLower.Children.Clear();
            for (int i = 0; i < 6; i++)
            {
                if (i < 3) SchedUpper.Children.Add(new RaspisaniePage(SQL.Select<Schedule, dynamic>(new SqlSchedule().sql_SelectScheduleDay, new { sql_group = ((ComboBoxItem)((ComboBox)sender).SelectedItem)?.Content, sql_date = i }, SQL.CONNECTION_STRING_IATU), i));
                else SchedLower.Children.Add(new RaspisaniePage(SQL.Select<Schedule, dynamic>(new SqlSchedule().sql_SelectScheduleDay, new { sql_group = ((ComboBoxItem)((ComboBox)sender).SelectedItem)?.Content, sql_date = i }, SQL.CONNECTION_STRING_IATU), i));
            }
        }

        #endregion

        #region Profile

        private void ChangeAccount_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainBar.Children.Clear();
            MainBar.Children.Add(new SignInControl());
        }

        private void LoadProfileSection()
        {
            var AllCourses = new Profile().GetCourses();

            login_txt.Content = user.login;
            switch (user.GetType().Name)
            {
                case "Student":
                    status_txt.Content = "Student";
                    if (((Student)user).group_id == 0)
                    {
                        UGroup.Visibility = Visibility.Collapsed;

                        foreach (var item in AllCourses)
                        {
                            ComboBoxItem ci = new ComboBoxItem();
                            ci.Content = item.name;
                            ci.Tag = item.id;
                            ci.FontSize = 10;

                            ComboCourse.Items.Add(ci);
                        }
                    }
                    else
                    {
                        UnGroup.Visibility = Visibility.Collapsed;
                        group_txt.Content = ((Student)user).courseName + ((Student)user).course + ((Student)user).group + " | " + ((Student)user).subgroup;
                    }
                    break;
                case "Teacher":
                    status_txt.Content = "Teacher";
                    group_txt.Content = "All";
                    UnGroup.Visibility = Visibility.Collapsed;
                    break;

                case "Admin":
                    status_txt.Content = "Admin";
                    group_txt.Content = "All";
                    UnGroup.Visibility = Visibility.Collapsed;
                    break;

                default:
                    break;
            }
        }

        #endregion

        #region Edit

        public void LoadDiscipline()
        {
            DisciplineList.Children.Clear();
            var disc = SQL.Select<Discipline, dynamic>(new EditInfo().sql_SelectDiscipine, new { }, SQL.CONNECTION_STRING);

            foreach (var item in disc)
            {
                DisciplineList.Children.Add(new EditDiscipline(item));
            }
        }

        private void AddDiscipline_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (AddDisciplineBoxxx.Text.Length > 5)
            {
                SQL.Insert<dynamic>(new EditInfo().sql_InsertDiscipine, new { sql_name = AddDisciplineBoxxx.Text }, SQL.CONNECTION_STRING);
                AddDisciplineBoxxx.Text = "";
                LoadDiscipline();
            }
        }

        public void LoadGroup()
        {
            var group = SQL.Select<Group, dynamic>(new EditInfo().sql_SelectGroup, new { }, SQL.CONNECTION_STRING);

            foreach (var item in group)
            {
                //DisciplineList.Children.Add(new EditGroup(item));
            }
        }




        public void LoadGroupDiscipline()
        {
            AddGroupDisciplineList.Visibility = Visibility.Collapsed;

            var group = SQL.Select<Group, dynamic>(new EditInfo().sql_SelectGroup, new { }, SQL.CONNECTION_STRING);

            ComboBoxItem cis = new ComboBoxItem();
            EditGroupDisciplineBox.SelectionChanged += GroupDisciplineBox_SelectionChanged;

            foreach (var item in group)
            {
                cis = new ComboBoxItem();
                cis.Content = (item.courseName + "-" + item.course + item.group).ToString();
                cis.Tag = item.id;

                EditGroupDisciplineBox.Items.Add(cis);
            }
        }

        private void GroupDisciplineBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AddGroupDisciplineList.Visibility = Visibility.Visible;

            LoadGroupDisciplineList();
            ReLoadGroupDiscipline();
        }

        private void AddGroupDiscipline_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ComboBoxItem egdbS = (ComboBoxItem)EditGroupDisciplineBox.SelectedItem;

            ComboBoxItem adbS = (ComboBoxItem)AddDisciplineBox.SelectedItem;

            ComboBoxItem atb = (ComboBoxItem)AddTeacherBox.SelectedItem;

            if (egdbS != null && adbS != null && atb != null)
            {
                AddDisciplineBox.SelectedItem = null;
                AddTeacherBox.SelectedItem = null;
                SQL.Insert<dynamic>(new EditInfo().sql_InsertGroupDiscipline, new { sql_group_id = Convert.ToInt32(egdbS.Tag), sql_discipline_id = Convert.ToInt32(adbS.Tag), sql_teacher_id = Convert.ToInt32(atb.Tag) }, SQL.CONNECTION_STRING);
                LoadGroupDisciplineList();
                ReLoadGroupDiscipline();
            }
        }

        public void LoadGroupDisciplineList()
        {
            GroupDisciplineList.Children.Clear();
            ComboBoxItem ci = (ComboBoxItem)EditGroupDisciplineBox.SelectedItem;

            var disciplines = SQL.Select<Discipline, dynamic>("SELECT d.id discipline_id, d.name FROM disciplines d", new { }, SQL.CONNECTION_STRING);
            var teachers = SQL.Select<Teachers, dynamic>("SELECT * FROM teacher", new { }, SQL.CONNECTION_STRING);

            var discipline = SQL.Select<Discipline, dynamic>(new EditInfo().sql_SelectGroupDiscipline, new { sql_group_id = Convert.ToInt32(ci?.Tag) }, SQL.CONNECTION_STRING);

            foreach (var item in discipline)
            {
                GroupDisciplineList.Children.Add(new EditGroupDiscipline(Convert.ToInt32(ci?.Tag),
                    item, teachers, disciplines));
            }
        }

        public void ReLoadGroupDiscipline()
        {
            var disciplines = SQL.Select<Discipline, dynamic>("SELECT d.id discipline_id, d.name FROM disciplines d WHERE d.id NOT IN (SELECT gd.discipline_id FROM group_discipline gd WHERE gd.group_id = @sql_group_id)", new { sql_group_id = Convert.ToInt32(((ComboBoxItem)EditGroupDisciplineBox?.SelectedItem)?.Tag) }, SQL.CONNECTION_STRING);
            var teachers = SQL.Select<Teachers, dynamic>("SELECT * FROM teacher", new { }, SQL.CONNECTION_STRING);

            AddDisciplineBox.Items.Clear();
            AddTeacherBox.Items.Clear();

            ComboBoxItem cis = new ComboBoxItem();


            foreach (var item in disciplines)
            {
                cis = new ComboBoxItem();
                cis.Content = item.name;
                cis.Tag = item.discipline_id;

                AddDisciplineBox.Items.Add(cis);
            }

            foreach (var item in teachers)
            {
                cis = new ComboBoxItem();
                cis.Content = item.fio;
                cis.Tag = item.id;

                AddTeacherBox.Items.Add(cis);
            }
        }

        public void LoadUserPermission()
        {
            var students = SQL.Select<Student, dynamic>(new EditInfo().sql_SelectStudent, new { }, SQL.CONNECTION_STRING);
            var teachers = SQL.Select<Teacher, dynamic>(new EditInfo().sql_SelectTeacher, new { }, SQL.CONNECTION_STRING);

            ComboBoxItem cis = new ComboBoxItem();

            foreach (var item in students)
            {
                UserListStudent.Children.Add(new EditPermissionStudent(item));

                cis = new ComboBoxItem();
                cis.Content = item.login + " " + item.name;
                cis.Tag = item.id;

                UserListStudentToTeacher.Items.Add(cis);
            }

            foreach (var item in teachers)
            {
                UserListTeacher.Children.Add(new EditPermissionTeacher(item));


            }
        }

        #endregion


    }
}