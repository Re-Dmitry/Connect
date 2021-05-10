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
    public partial class EditGroupDiscipline : UserControl
    {
        int group_id;
        Discipline discipline;
        List<Discipline> disciplines;
        List<Teachers> teachers;

        public EditGroupDiscipline()
        {
            InitializeComponent();
        }

        public EditGroupDiscipline(int group_id, Discipline discipline, List<Teachers> teachers, List<Discipline> disciplines)
        {
            InitializeComponent();

            this.group_id = group_id;
            this.discipline = discipline;
            this.disciplines = disciplines;
            this.teachers = teachers;

            NameDisciplineText.Text = this.discipline.name;
            NameTeacherText.Text = this.discipline.fio;
        }

        private void EditDiscipline_MouseDown(object sender, MouseButtonEventArgs e)
        {
            EditNameDisciplineText.Text = NameDisciplineText.Text;
            EditNameTeacherText.Text = NameTeacherText.Text;

            NormalView.Visibility = Visibility.Collapsed;
            EditView.Visibility = Visibility.Visible;
        }


        //private void EditDisciplineAccept_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    NameDisciplineText.Text = NameEditDisciplineText.Text;

        //    SQL.Insert<dynamic>(new EditInfo().sql_UpdateDiscipineName, new { sql_name = NameEditDisciplineText.Text, sql_id = discipline.discipline_id }, SQL.CONNECTION_STRING);

        //    NormalView.Visibility = Visibility.Visible;
        //    EditView.Visibility = Visibility.Collapsed;
        //}

        private void EditDisciplineDecline_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NormalView.Visibility = Visibility.Visible;
            EditView.Visibility = Visibility.Collapsed;
        }

        private void EditDisciplineDelete_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SQL.Insert<dynamic>(new EditInfo().sql_DeleteGroupDiscipline, new { sql_group_id = group_id, sql_discipline_id = discipline.discipline_id }, SQL.CONNECTION_STRING);

            GroupDisciplineControl.Visibility = Visibility.Collapsed;
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
