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
    public partial class Adminka : Window
    {
        public Adminka()
        {
            InitializeComponent();
            ListView1.ItemsSource = FindMain();
            sortItems.SelectedIndex = 0;
            sortItems.Items.Add("Фильтрация");
            foreach (var item in AppConnect.model0db.rarcategory.ToList())
            {
                sortItems.Items.Add(item.rarity.ToString());
            }
            sortItems.SelectedIndex = 0;
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

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            AddItem addItem = new AddItem();
            addItem.Show();
            Close();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var itemSend = button.DataContext as skins;
            AddItem addItem = new AddItem(itemSend);
            addItem.Show();
            Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var id = button.Tag;
            var itemDel = AppConnect.model0db.skins.Where(x => x.skin_id == (int?)id);
            try
            {
                AppConnect.model0db.skins.RemoveRange(itemDel);
                AppConnect.model0db.SaveChanges();
                AppConnect.model0db.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                ListView1.ItemsSource = AppConnect.model0db.skins.ToList();
            }
            catch
            {
                MessageBox.Show("Объект не удалён");
            }
        }

        private void sortItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView1.ItemsSource = FindMain();
        }
    }
}
