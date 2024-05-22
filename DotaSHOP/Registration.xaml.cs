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

namespace DotaSHOP
{
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Otmena_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.mainframe.Navigate(new Authorization());
        }

        private void Regis_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                users person = new users()
                {
                    name = Name.Text,
                    surname = Surname.Text,
                    patronymic = Patronymic.Text,
                    email = Email.Text,
                    password = Password.Password,
                    phone_number = Phone_number.Text,
                    username = Username.Text,
                    date_of_birth = DateTime.Parse(Date_of_birth.SelectedDate.ToString()),
                };

                AppConnect.model0db.users.Add(person);
                AppConnect.model0db.SaveChanges();
                MessageBox.Show("Вы успешно зарегистрировались");
                AppFrame.mainframe.Navigate(new Authorization());
            }
            catch (Exception ex) { MessageBox.Show("Ошибка"); }
        }
    }
}
