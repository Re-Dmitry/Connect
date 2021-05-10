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
    public partial class ObjectControl : UserControl
    {
        public ObjectControl()
        {
            InitializeComponent();
            InitComponent();
        }

        public ObjectControl(int id, string name, string teacher)
        {
            InitializeComponent();
            InitComponent();

            Tag = id;
            ObjectName.Text = name;
            TeachertName.Text = teacher;
        }

        public void InitComponent()
        {
            ObjectName.FontSize = 15;
            ObjectName.FontFamily = new FontFamily("Century Gothic");
            ObjectName.FontStyle = FontStyles.Normal;
            ObjectName.FontWeight = FontWeights.Normal;
            ObjectName.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 100, 100, 100));

            TeachertName.FontSize = 10;
            TeachertName.FontFamily = new FontFamily("Century Gothic");
            TeachertName.FontStyle = FontStyles.Italic;
            TeachertName.FontWeight = FontWeights.Normal;
            TeachertName.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 150, 150, 150));
        }

        private void Object_MouseEnter(object sender, MouseEventArgs e)
        {
            ((StackPanel)sender).Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(50, 25, 25, 25));
        }

        private void Object_MouseLeave(object sender, MouseEventArgs e)
        {
            ((StackPanel)sender).Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(0, 0, 0, 0));
        }
    }
}
