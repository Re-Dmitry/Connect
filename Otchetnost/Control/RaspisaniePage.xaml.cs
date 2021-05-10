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
    public partial class RaspisaniePage : UserControl
    {
        public RaspisaniePage()
        {
            InitializeComponent();
        }

        public RaspisaniePage(List<Schedule> sched, int day)
        {
            InitializeComponent();

            switch (day)
            {
                case 0:
                    dayName.Text = "Monday";
                    break;
                case 1:
                    dayName.Text = "Tuesday";
                    break;
                case 2:
                    dayName.Text = "Wednesday";
                    break;
                case 3:
                    dayName.Text = "Thursday";
                    break;
                case 4:
                    dayName.Text = "Friday";
                    break;
                case 5:
                    dayName.Text = "Saturday";
                    break;
                default:
                    break;
            }

            foreach (var item in sched)
            {
                SchedulePage.Children.Add(new RaspisaniePageSection(item));
            }
        }
    }
}
