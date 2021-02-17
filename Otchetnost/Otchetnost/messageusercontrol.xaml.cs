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
    /// <summary>
    /// Логика взаимодействия для messageusercontrol.xaml
    /// </summary>
    public partial class messageusercontrol : UserControl
    {
        public messageusercontrol(string message_text, string user)
        {
            InitializeComponent();
            gg.Text = message_text;

        }
    }
}
