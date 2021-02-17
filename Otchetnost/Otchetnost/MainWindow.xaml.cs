using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace Otchetnost
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            UserSettings us = new UserSettings();

            if(new Authorization().Auh(ref us))
            {

            }
            else
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string last_id = "you";
            //if ()
            Chat.Children.Add(new messageusercontrol(gg.Text, "you"));


        }
    }
}
