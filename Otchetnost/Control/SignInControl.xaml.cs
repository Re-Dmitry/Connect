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

namespace Otchetnost
{
    public partial class SignInControl : UserControl
    {
        string sql_SignInLogin = "SELECT COUNT(*) FROM users u WHERE u.login = @sql_login";
        string sql_SignInPassword = "SELECT COUNT(*) FROM users u WHERE u.password = @sql_password";


        public SignInControl()
        {
            InitializeComponent();
            login_tb.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 200, 200, 200));
            password_tb.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 200, 200, 200));
        }

        public void SignInCheck(object sender, MouseButtonEventArgs e)
        {
            if (SignInCheckLogin(login_tb.Text))
            {
                if(SignInCheckPassword(password_tb.Password))
                {
                    string json = File.ReadAllText("userconfig.json");
                    dynamic jsonObj = JsonConvert.DeserializeObject(json);
                    jsonObj["login"] = login_tb.Text;
                    jsonObj["password"] = password_tb.Password;
                    string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText("userconfig.json", output);

                    System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();

                    return;
                }
                else
                {
                    login_tb.Text = String.Empty;
                    password_tb.Password = String.Empty;
                    login_tb.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 0, 0));
                    password_tb.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 0, 0));
                }
            }
            else
            {
                login_tb.Text = String.Empty;
                password_tb.Password = String.Empty;
                login_tb.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 0, 0));
                password_tb.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 0, 0));
            }
        }


        public bool SignInCheckLogin(string txt)
        {
            if (txt == string.Empty 
                || txt.Length < 5 
                || txt.Length > 15 
                || SQL.Select<int,dynamic>(sql_SignInLogin, new {@sql_login = txt }, SQL.CONNECTION_STRING)[0] == 0) return false;
            else return true;
        }

        public bool SignInCheckPassword(string txt)
        {
            if (txt == string.Empty 
                || txt.Length < 5 
                || txt.Length > 15 
                || SQL.Select<int, dynamic>(sql_SignInPassword, new { sql_password = txt }, SQL.CONNECTION_STRING)[0] == 0) return false;
            else return true;
        }

        private void idk_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sic.Children.Clear();
            sic.Children.Add(new SignUpControl());
        }

        private void login_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            login_tb.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 200, 200, 200));
            password_tb.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 200, 200, 200));
        }
    }
}
