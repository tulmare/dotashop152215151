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
                mains = mains.Where(x => x.hero.ToString() == sortItems.SelectedIndex.ToString()).ToList();
            }

            var mainAll = mains;
            return mains.ToArray();
        }
        private void findSkins_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListView2.ItemsSource = FindMain();
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void sortItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
