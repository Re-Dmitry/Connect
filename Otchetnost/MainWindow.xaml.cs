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

        public MainWindow()
        {
            InitializeComponent();
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

            UpdateChatAsync();
        }

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
    }
}
