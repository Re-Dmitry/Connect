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
    public partial class EditPermissionTeacher : UserControl
    {
        Teacher teacher;

        public EditPermissionTeacher()
        {
            InitializeComponent();
        }

        public EditPermissionTeacher(Teacher teacher)
        {
            InitializeComponent();

            this.teacher = teacher;
            UserLogin.Text = teacher.login;
            UserLoginEdit.Text = teacher.login;

            UserName.Text = teacher.name == null ? "unnamed" : teacher.name;
            UserNameEdit.Text = teacher.name;
        }

        private void EditDiscipline_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NormalView.Visibility = Visibility.Collapsed;
            EditView.Visibility = Visibility.Visible;
        }

        private void EditUserDecline_MouseDown(object sender, MouseButtonEventArgs e)
        {

            NormalView.Visibility = Visibility.Visible;
            EditView.Visibility = Visibility.Collapsed;
        }

        private void EditUserAccept_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SQL.Insert<dynamic>(new EditInfo().sql_UpdateUserName, new { sql_name = UserNameEdit.Text, sql_user_id = teacher.id }, SQL.CONNECTION_STRING);
            UserName.Text = UserNameEdit.Text;

            NormalView.Visibility = Visibility.Visible;
            EditView.Visibility = Visibility.Collapsed;
        }

        private void EditDisciplineDelete_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SQL.Insert<dynamic>(new EditInfo().sql_DeleteTeacher, new { sql_group_id = teacher.id}, SQL.CONNECTION_STRING);

            UserPermissionControl.Visibility = Visibility.Collapsed;
        }


        private void Task_MouseEnter(object sender, MouseEventArgs e)
        {
            ((StackPanel)sender).Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(50, 25, 25, 25));
        }

        private void Task_MouseLeave(object sender, MouseEventArgs e)
        {
            ((StackPanel)sender).Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(0, 0, 0, 0));
        }

        private void GroupBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
