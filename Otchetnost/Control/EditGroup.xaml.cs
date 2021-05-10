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
    public partial class EditGroup : UserControl
    {
        Group group;

        public EditGroup()
        {
            InitializeComponent();
        }

        public EditGroup(Group group)
        {
            InitializeComponent();

            this.group = group;
            NameGroupText.Text = group.courseName + group.course + group.group;
        }

        private void EditGroup_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NameEditGroupText.Text = NameGroupText.Text;

            NormalView.Visibility = Visibility.Collapsed;
            EditView.Visibility = Visibility.Visible;
        }

        private void EditGroupAccept_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NameGroupText.Text = NameEditGroupText.Text;

            //SQL.Insert<dynamic>(new EditInfo().sql_UpdateDiscipineName, new { sql_name = NameEditGroupText.Text, sql_id = group.id }, SQL.CONNECTION_STRING);

            NormalView.Visibility = Visibility.Visible;
            EditView.Visibility = Visibility.Collapsed;
        }

        private void EditGroupDecline_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NormalView.Visibility = Visibility.Visible;
            EditView.Visibility = Visibility.Collapsed;
        }

        private void EditGroupDelete_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //SQL.Insert<dynamic>(new EditInfo().sql_DeleteDiscipine, new { sql_id = group.id }, SQL.CONNECTION_STRING);

            GroupControl.Visibility = Visibility.Collapsed;
        }

        private void Task_MouseEnter(object sender, MouseEventArgs e)
        {
            ((StackPanel)sender).Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(50, 25, 25, 25));
        }

        private void Task_MouseLeave(object sender, MouseEventArgs e)
        {
            ((StackPanel)sender).Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(0, 0, 0, 0));
        }
    }
}
