﻿using System;
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

namespace DotaSHOP
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.mainframe.Navigate(new Registration());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var userObj = AppConnect.model0db.users.FirstOrDefault(x => x.email == Email.Text && x.password == Password.Password);
            if (userObj != null)
            {
                App.Current.Properties["userEmail"] = userObj.user_id;
                Window1 window = new Window1((int)userObj.roleID);
                if (userObj.roleID == 1) 
                {
                    App.Current.Properties["userEmail"] = userObj.user_id;
                    Adminka adminka = new Adminka();
                    adminka.Show();
                    Application.Current.MainWindow.Close();
                }
                else
                {
                    window.Show();
                    Application.Current.MainWindow.Close();
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
