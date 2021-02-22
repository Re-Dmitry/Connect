using System;
using System.Collections.Generic;
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
    public partial class ChatMessageControl : UserControl
    {
        public ChatMessageControl()
        {
            InitializeComponent();
        }

        public ChatMessageControl(int user_id, string user, string date, string text)
        {
            InitializeComponent();
            cUserName.Text = user;
            cDate.Text = date;
            cText.Text = text;
            Tag = user_id;
        }

        public ChatMessageControl(int user_id, string text)
        {
            InitializeComponent();
            cUserName.Visibility = Visibility.Collapsed;
            cDate.Visibility = Visibility.Collapsed;
            Img.Visibility = Visibility.Collapsed;
            Main.Margin = new Thickness(50, 0, 0, 0);
            cText.Text = text;
            Tag = user_id;
        }


        public ChatMessageControl(int id, int user_id, string user, string date, string text)
        {
            InitializeComponent();
            cUserName.Text = user;
            cDate.Text = date;
            cText.Text = text;
            Tag = new id_message(id, user_id);
        }

        public ChatMessageControl(int id, int user_id, string text)
        {
            InitializeComponent();
            cUserName.Visibility = Visibility.Collapsed;
            cDate.Visibility = Visibility.Collapsed;
            Img.Visibility = Visibility.Collapsed;
            Main.Margin = new Thickness(50, 0, 0, 0);
            cText.Text = text;
            Tag = new id_message(id, user_id);
        }
    }
}
