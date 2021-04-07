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
        }

        public TaskControl(int id, int status, string text, string date, string deadline)
        {
            InitializeComponent();

            //TaskStatus.Visibility = Visibility.Collapsed;


            if (status == 1)
            {
                TaskStatus.Tag = 1;
                TaskStatus.Text = "Yes";
            }
            else
            {
                TaskStatus.Tag = 0;
                TaskStatus.Text = "No";
            }

            TaskText.Text = text;
            TaskDate.Text = date;
            TaskDeadLine.Text = deadline;
            Tag = id;
        }

        public TaskControl(int id, string text, string date, string deadline, int countUser, int countComplete)
        {
            InitializeComponent();

            ImageTaskStatus.Visibility = Visibility.Collapsed;
            if(countUser != 0) TaskStatus.Text = (100 / countUser) * countComplete +"%";


            TaskText.Text = text;
            TaskDate.Text = date;
            TaskDeadLine.Text = deadline;
            Tag = id;
        }

        public void TaskStatus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Convert.ToInt32(((TextBlock)sender).Tag) != 1)
            {
                TaskStatus.Tag = 1;
                TaskStatus.Text = "Yes";
            }
            else
            {
                TaskStatus.Tag = 0;
                TaskStatus.Text = "No";
            }

            new Tasks().ChangeTaskStatus(Convert.ToInt32(Tag), MainWindow.now_student_id);
        }
    }
}
