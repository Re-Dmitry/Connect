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
    public partial class EditDiscipline : UserControl
    {
        Discipline discipline;
        public EditDiscipline()
        {
            InitializeComponent();
        }

        public EditDiscipline(Discipline discipline)
        {
            InitializeComponent();

            this.discipline = discipline;
            NameDisciplineText.Text = discipline.name;
        }

        private void EditDiscipline_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NameEditDisciplineText.Text = NameDisciplineText.Text;

            NormalView.Visibility = Visibility.Collapsed;
            EditView.Visibility = Visibility.Visible;
        }

        private void EditDisciplineAccept_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NameDisciplineText.Text = NameEditDisciplineText.Text;

            SQL.Insert<dynamic>(new EditInfo().sql_UpdateDiscipineName, new { sql_name = NameEditDisciplineText.Text, sql_id = discipline.discipline_id }, SQL.CONNECTION_STRING);

            NormalView.Visibility = Visibility.Visible;
            EditView.Visibility = Visibility.Collapsed;
        }

        private void EditDisciplineDecline_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NormalView.Visibility = Visibility.Visible;
            EditView.Visibility = Visibility.Collapsed;
        }

        private void EditDisciplineDelete_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SQL.Insert<dynamic>(new EditInfo().sql_DeleteDiscipine, new { sql_id = discipline.discipline_id }, SQL.CONNECTION_STRING);

            DisciplineControl.Visibility = Visibility.Collapsed;
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
