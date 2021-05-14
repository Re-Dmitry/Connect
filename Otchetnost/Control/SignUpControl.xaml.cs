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
    public partial class SignUpControl : UserControl
    {
        string sql_SignUpLogin = "SELECT COUNT(*) FROM users u WHERE u.login = @sql_login";
        string sql_InsertUser = "INSERT INTO users SET login = @sql_login, `password` = @sql_password";

        public SignUpControl()
        {
            InitializeComponent();
            login_tb.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 200, 200, 200));
            password_tb.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 200, 200, 200));
            passwordConfirm_tb.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 200, 200, 200));
        }

        public void SignInCheck(object sender, MouseButtonEventArgs e)
        {
            if (SignUpCheckLogin(login_tb.Text))
            {
                if (SignUpCheckPassword(password_tb.Password, passwordConfirm_tb.Password))
                {
                    string json = File.ReadAllText("userconfig.json");
                    dynamic jsonObj = JsonConvert.DeserializeObject(json);
                    jsonObj["login"] = login_tb.Text;
                    jsonObj["password"] = password_tb.Password;
                    string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText("userconfig.json", output);

                    SQL.Insert<dynamic>(sql_InsertUser, new { @sql_login = login_tb.Text, @sql_password = password_tb.Password }, SQL.CONNECTION_STRING);

                    System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();

                    return;
                }
                else
                {
                    login_tb.Text = String.Empty;
                    password_tb.Password = String.Empty;
                    passwordConfirm_tb.Password = String.Empty;
                    login_tb.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 0, 0));
                    password_tb.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 0, 0));
                    passwordConfirm_tb.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 0, 0));
                }
            }
            else
            {
                login_tb.Text = String.Empty;
                password_tb.Password = String.Empty;
                passwordConfirm_tb.Password = String.Empty;
                login_tb.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 0, 0));
                password_tb.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 0, 0));
                passwordConfirm_tb.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 0, 0));
            }
        }


        public bool SignUpCheckLogin(string txt)
        {
            if (txt == string.Empty 
                || txt.Length < 5 
                || txt.Length > 15 
                || SQL.Select<int, dynamic>(sql_SignUpLogin, new { @sql_login = txt }, SQL.CONNECTION_STRING)[0] != 0) return false;
            else return true;
        }

        public bool SignUpCheckPassword(string txt1, string txt2)
        {
            if (txt1 == string.Empty 
                || txt1.Length < 5 
                || txt1.Length > 15 
                || txt1 != txt2) return false;
            else return true;
        }

        private void ik_MouseDown   (object sender, MouseButtonEventArgs e)
        {
            suc.Children.Clear();
            suc.Children.Add(new SignInControl());
        }

        private void login_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            login_tb.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 200, 200, 200));
            password_tb.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 200, 200, 200));
            passwordConfirm_tb.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 200, 200, 200));
        }
    }
}


