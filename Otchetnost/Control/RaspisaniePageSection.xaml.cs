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
    public partial class RaspisaniePageSection : UserControl
    {
        public RaspisaniePageSection()
        {
            InitializeComponent();
        }

        public RaspisaniePageSection(Schedule sched)
        {
            InitializeComponent();

            timeStart.Text = sched.timeStart.ToString();
            timeStop.Text = sched.timeStop.ToString();

            discipline.Text = sched.discipline;
            teacher.Text = sched.teacher;

            subgroup.Text = sched.subgroup;
            type.Text = sched.type;
            cabinet.Text = sched.cabinet;
        }
    }
}
