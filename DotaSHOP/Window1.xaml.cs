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
    public partial class Window1 : Window
    {
        int userID = 1;
        public Window1(int userid)
        {
            InitializeComponent();
            items.entity = new Entities9();
            ListView1.ItemsSource = FindMain();
            userID = userid;
            sortItems.Items.Add("Фильтрация");
            foreach (var item in AppConnect.model0db.rarcategory.ToList()) 
            {
                sortItems.Items.Add(item.rarity.ToString());
            }
            sortItems.SelectedIndex = 0;
        }

        private void card_Click(object sender, RoutedEventArgs e)
        {
            card card = new card(userID);
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

            if (sortItems.SelectedIndex != 0)
            {
                mains = mains.Where(x => x.rarityID.ToString() == sortItems.SelectedIndex.ToString()).ToList();
            }

            var mainAll = mains;
            return mains.ToArray();
        }
        private void findSkins_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListView1.ItemsSource = FindMain();
        }

        private void buy_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var id = button.DataContext as skins;
            int userId = (int)App.Current.Properties["userEmail"];

            try
            {
                cart cart = new cart()
                {
                    user_id = userId,
                    skin_id = id.skin_id,
                };
                Entities9.GetContext().cart.Add(cart);
                Entities9.GetContext().SaveChanges();
                MessageBox.Show("Товар отправлен в корзину");
            }
            catch (Exception ex) { MessageBox.Show("Товар не отправлен в корзину"); }
        }

        private void sortItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView1.ItemsSource = FindMain();
        }
    }
}