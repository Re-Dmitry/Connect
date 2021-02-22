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
        UserSettings user = new UserSettings();
        public int chat_type { get; set; }
        public int chat_id { get; set; }

        public int now_discipline_id { get; set; }
        public int now_student_id { get; set; }
        public int now_group_id { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            AddTask.Visibility = Visibility.Hidden;
            Init();
        }

        public async void Init()
        {
            chat_type = 0;
            chat_id = 0;
            Chat.Children.Add(new ChatMessageControl(0, ""));

            if (new Authorization().Auh(ref user))
            {

            }
            else
            {

            }

            LoadTasksSection();
            UpdateChatAsync();
        }


        public async Task UpdateChatAsync()
        {
            while (true)
            {
                await Task.Delay(2500);

                ChatMessageControl cmc = null;
                if (Chat.Children.Count > 0) cmc = (ChatMessageControl)Chat.Children[Chat.Children.Count - 1];
                else
                {
                    Chat.Children.Add(new ChatMessageControl(0,0, " "));
                    cmc = (ChatMessageControl)Chat.Children[Chat.Children.Count - 1];
                }

                List<Message> message = null;

                switch (chat_type)
                {
                    case 1:
                        message = new Chat().ReceiveAllGlobal(((id_message)cmc.Tag).id);
                        break;
                    case 2:
                        message = new Chat().ReceiveAllGlobal(((id_message)cmc.Tag).id);
                        break;
                    case 3:
                        message = new Chat().ReceiveAllGlobal(((id_message)cmc.Tag).id);
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
                    AddTask.Visibility = Visibility.Collapsed;
                    discipline = new Tasks().GetDisciplineStudent(((Student)user).group_id);

                    foreach (var item in discipline)
                    {
                        var oc = new ObjectControl(item.discipline_id, item.name, item.fio);
                        oc.MouseDown += StackPanel_MouseDown;
                        ObjectsPanel.Children.Add(oc);
                    }

                    break;
                case "Teacher":
                    TaskSettings.Visibility = Visibility.Visible;
                    AddTask.Visibility = Visibility.Visible;

                    GroupBox.SelectionChanged += GroupBox_SelectionChanged;
                    foreach (var item in ((Teacher)user).groups)
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

        }

        #endregion

        #region Events

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string text = TextInputBox.Text;
            Message message = null;
            if (text != String.Empty && text.Length < 1000)
            {
                switch (chat_type)
                {
                    case 1:
                        message = new Chat().SendGlobal(text, user.id);
                        break;
                    case 2:
                        message = new Chat().SendGlobal(text, user.id);
                        break;
                    case 3:
                        message = new Chat().SendGlobal(text, user.id);
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
            chat_id = (int)button.Tag;
            Chat.Children.Clear();
        }

        private void ChatTypeDirect_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            chat_type = 3;
            chat_id = (int)button.Tag;
            Chat.Children.Clear();
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TasksPanel.Children.Clear();
            ObjectControl sp = (ObjectControl)sender;
            now_discipline_id = Convert.ToInt32(sp.Tag);
            List<TasksExtend> task = null;
            int countUser = 0;
            if (user.GetType().Name == "Student")
            {
                task = new Tasks().GetTask(((Student)user).group_id, user.id, now_discipline_id);
            }
            else if (user.GetType().Name == "Teacher")
            {
                if((ComboBoxItem)StudentBox.SelectedItem == null)
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
                    if ((ComboBoxItem)StudentBox.SelectedItem == null)
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

        private void GroupBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TasksPanel.Children.Clear();
            ComboBox cb = (ComboBox)sender;
            ComboBoxItem ci = (ComboBoxItem)cb.SelectedItem;
            ObjectsPanel.Children.Clear();
            now_group_id = Convert.ToInt32(ci.Tag);

            var discipline = new Tasks().GetDisciplineStudent(Convert.ToInt32(ci.Tag), user.id);
            var student = new Tasks().GetAllStudent(Convert.ToInt32(ci.Tag));

            foreach (var item in discipline)
            {
                var oc = new ObjectControl(item.discipline_id, item.name, item.fio);
                oc.MouseDown += StackPanel_MouseDown;
                ObjectsPanel.Children.Add(oc);
            }

            StudentBox.Items.Clear();
            ComboBoxItem cis = new ComboBoxItem();
            foreach (var item in student)
            {
                cis = new ComboBoxItem();
                if(item.name == null) cis.Content = item.login;
                else cis.Content = item.name;
                cis.Tag = item.id;

                StudentBox.Items.Add(cis);
            }

        }

        #endregion

        private void StudentBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TasksPanel.Children.Clear();

            var task = new Tasks().GetTask(Convert.ToInt32(((ComboBoxItem)GroupBox.SelectedItem).Tag), Convert.ToInt32(((ComboBoxItem)StudentBox?.SelectedItem).Tag), now_discipline_id);

            if (task != null)
            {
                foreach (var item in task)
                {
                    TasksPanel.Children.Add(new TaskControl(item.id, item.global_complete, item.text, item.date, item.deadline));
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string text = TaskBox.Text;
            new Tasks().AddTask(now_group_id, now_discipline_id, text);

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
    }
}
