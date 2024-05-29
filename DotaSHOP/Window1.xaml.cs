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
using System.Windows.Shapes;

namespace DotaSHOP
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            items.entity = new Entities5();
            ListView1.ItemsSource = FindMain();
        }

        private void card_Click(object sender, RoutedEventArgs e)
        {
            card card = new card();
            card.Show();
            Close();
        }


        skins[] FindMain()
        {
            List<skins> mains = AppConnect.model0db.skins.ToList();

            if (String.IsNullOrEmpty(findSkins.Text) || String.IsNullOrWhiteSpace(findSkins.Text))
            {

            }
            else
            {
                mains = mains.Where(x => x.skinname.ToLower().Contains(findSkins.Text.ToLower())).ToList();
            }

            var mainAll = mains;
            return mains.ToArray();
        }
        private void findItems_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListView1.ItemsSource = FindMain();
        }

        private void buy_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var id = button.Tag;
            int userId = (int)App.Current.Properties["userEmail"];

            try
            {
                cart cart = new cart()
                {
                    user_id = userId,
                    skin_id = Convert.ToInt32(id),
                };
                AppConnect.model0db.cart.Add(cart);
                MessageBox.Show("Товар отправлен в корзину + " + userId + " + " + Convert.ToInt32(id));
            }
            catch (Exception ex) { MessageBox.Show("Товар не отправлен в корзину"); }
        }

        private void sortItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView1.ItemsSource = FindMain();
        }
    }
}