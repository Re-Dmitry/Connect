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
    public partial class EditPermissionStudent : UserControl
    {
        Student student;

        public EditPermissionStudent()
        {
            InitializeComponent();
        }

        public EditPermissionStudent(Student student)
        {
            InitializeComponent();

            this.student = student;
            UserLogin.Text = student.login;
            UserGroup.Text = (student.courseName + student.course + student.group).ToString();

            UserName.Text = student.name == null ? "unnamed" : student.name;
            UserNameEdit.Text = student.name;

            UserLoginEdit.Text = student.login;

            var group = SQL.Select<Group, dynamic>(new EditInfo().sql_SelectGroup, new { }, SQL.CONNECTION_STRING);

            ComboBoxItem cis = new ComboBoxItem();
            ComboGroup.SelectionChanged += GroupBox_SelectionChanged;

            foreach (var item in group)
            {
                cis = new ComboBoxItem();
                cis.Content = (item.courseName + "-" + item.course + item.group).ToString();
                cis.Tag = item.id;

                ComboGroup.Items.Add(cis);
            }

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
            if((ComboBoxItem)ComboGroup.SelectedItem != null)
            {
                SQL.Insert<dynamic>(new EditInfo().sql_UpdateUserGroup, new { sql_group_id = Convert.ToInt32(((ComboBoxItem)ComboGroup.SelectedItem).Tag), sql_user_id = student.id }, SQL.CONNECTION_STRING);
                UserGroup.Text = ((ComboBoxItem)ComboGroup.SelectedItem).Content.ToString();
            }

            SQL.Insert<dynamic>(new EditInfo().sql_UpdateUserName, new { sql_name = UserNameEdit.Text, sql_user_id = student.id }, SQL.CONNECTION_STRING);
            UserName.Text = UserNameEdit.Text;

            NormalView.Visibility = Visibility.Visible;
            EditView.Visibility = Visibility.Collapsed;
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
