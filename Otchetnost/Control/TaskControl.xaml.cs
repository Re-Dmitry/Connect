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
    public partial class TaskControl : UserControl
    {
        public TaskControl()
        {
            InitializeComponent();
            InitComponent();
        }

        public TaskControl(int id, int status, string text, string date, string deadline)
        {
            InitializeComponent();
            InitComponent();

            if(MainWindow.user.GetType().Name == "Student")
            {
                ed.Visibility = Visibility.Collapsed;
            }

            //TaskStatus.Visibility = Visibility.Collapsed;

            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            bi1.UriSource = new Uri("/Image/plus.png", UriKind.Relative);
            bi1.EndInit();

            BitmapImage bi2 = new BitmapImage();
            bi2.BeginInit();
            bi2.UriSource = new Uri("/Image/minus.png", UriKind.Relative);
            bi2.EndInit();

            if (status == 1)
            {
                TaskStatus.Tag = 1;
                TaskStatusImage.Source = bi1;
            }
            else
            {
                TaskStatus.Tag = 0;
                TaskStatusImage.Source = bi2;
            }

            TaskText.Text = text;
            TaskDateInfo.Text = date;
            TaskDeadLineInfo.Text = deadline != null ? deadline.Substring(0, 10) : "nope";
            Tag = id;
        }

        public TaskControl(int id, string text, string date, string deadline, int countUser, int countComplete)
        {
            InitializeComponent();
            InitComponent();

            //ImageTaskStatus.Visibility = Visibility.Collapsed;
            //if(countUser != 0) TaskStatus.Text = (100 / countUser) * countComplete + "%";

            TaskText.Text = text;
            TaskDateInfo.Text = date;
            TaskDeadLineInfo.Text = deadline != null ? deadline.Substring(0, 10) : "nope";
            Tag = id;
        }

        public void InitComponent()
        {
            TaskDeadLine.FontSize = 12;
            TaskDeadLine.FontFamily = new FontFamily("Century Gothic");
            TaskDeadLine.FontStyle = FontStyles.Normal;
            TaskDeadLine.FontWeight = FontWeights.Normal;
            TaskDeadLine.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 100, 100, 100));

            TaskDate.FontSize = 12;
            TaskDate.FontFamily = new FontFamily("Century Gothic");
            TaskDate.FontStyle = FontStyles.Normal;
            TaskDate.FontWeight = FontWeights.Normal;
            TaskDate.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 100, 100, 100));

            TaskDeadLineInfo.FontSize = 12;
            TaskDeadLineInfo.FontFamily = new FontFamily("Century Gothic");
            TaskDeadLineInfo.FontStyle = FontStyles.Italic;
            TaskDeadLineInfo.FontWeight = FontWeights.Normal;
            TaskDeadLineInfo.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 150, 150, 150));

            TaskDateInfo.FontSize = 12;
            TaskDateInfo.FontFamily = new FontFamily("Century Gothic");
            TaskDateInfo.FontStyle = FontStyles.Italic;
            TaskDateInfo.FontWeight = FontWeights.Normal;
            TaskDateInfo.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 150, 150, 150));
            
            TaskText.FontSize = 15;
            TaskText.FontFamily = new FontFamily("Century Gothic");
            TaskText.FontStyle = FontStyles.Normal;
            TaskText.FontWeight = FontWeights.SemiBold;
            TaskText.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 80, 80, 80));
        }

        public void TaskStatus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            bi1.UriSource = new Uri("/Image/plus.png", UriKind.Relative);
            bi1.EndInit();

            BitmapImage bi2 = new BitmapImage();
            bi2.BeginInit();
            bi2.UriSource = new Uri("/Image/minus.png", UriKind.Relative);
            bi2.EndInit();

            if (MainWindow.user.GetType().Name != "Student" && MainWindow.now_student_id > 0)
            {
                if (Convert.ToInt32(TaskStatus.Tag) != 1)
                {
                    TaskStatus.Tag = 1;
                    TaskStatusImage.Source = bi1;
                }
                else
                {
                    TaskStatus.Tag = 0;
                    TaskStatusImage.Source = bi2;
                }

                new Tasks().ChangeTaskStatus(Convert.ToInt32(Tag), MainWindow.now_student_id);
            }
        }

        private void Task_MouseEnter(object sender, MouseEventArgs e)
        {
            ((StackPanel)sender).Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(50, 25, 25, 25));
        }

        private void Task_MouseLeave(object sender, MouseEventArgs e)
        {
            ((StackPanel)sender).Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(0, 0, 0, 0));
        }

        private void EditTask_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TaskTextEdit.Text = TaskText.Text;

            NormalView.Visibility = Visibility.Collapsed;
            EditView.Visibility = Visibility.Visible;
        }

        private void EditTaskAccept_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(new ControlVerification().EditTaskVerification(TaskTextEdit.Text))
            {
                TaskText.Text = TaskTextEdit.Text;
                SQL.Insert<dynamic>("UPDATE tasks t SET t.text = @sql_text WHERE t.id = @sql_id;", new { sql_text = (TaskTextEdit.Text).ToString(), sql_id = Convert.ToInt32(Tag)}, SQL.CONNECTION_STRING);
            }
           
            NormalView.Visibility = Visibility.Visible;
            EditView.Visibility = Visibility.Collapsed;
        }



        private void EditTaskDecline_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NormalView.Visibility = Visibility.Visible;
            EditView.Visibility = Visibility.Collapsed;
        }

        private void EditTaskDelete_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SQL.Insert<dynamic>(new EditInfo().sql_DeleteDiscipine, new { sql_id = Convert.ToInt32(Tag) }, SQL.CONNECTION_STRING);

            gg.Visibility = Visibility.Collapsed;
        }
    }
}
