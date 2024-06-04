using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DotaSHOP
{
    public partial class card : Window
    {
        int userID = 1;
        public card(int userid)
        {
            InitializeComponent();
            items.entity = new Entities8();
            ListCard.ItemsSource = AppConnect.model0db.cart.ToList();
        }
        //Вернуться на главную
        private void back_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1(userID);
            window.Show();
            Close();
        }

        private void deleteItem_Click_1(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var id = button.DataContext as cart;
            var itemDel = AppConnect.model0db.cart.Where(x => x.transaction_id == id.transaction_id);
            try
            {
                AppConnect.model0db.cart.RemoveRange(itemDel);
                AppConnect.model0db.SaveChanges();
                AppConnect.model0db.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                ListCard.ItemsSource = AppConnect.model0db.cart.ToList();
                MessageBox.Show("Товар удалён");
            }
            catch
            {
                MessageBox.Show("Товар не удалён");
            }
        }
    }
}
