using Aspose.BarCode.Generation;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace DotaSHOP
{
    public partial class card : Window
    {
        int userID = 1;
        public card(int userid)
        {
            InitializeComponent();
            items.entity = new Entities9();
            ListCard.ItemsSource = AppConnect.model0db.cart.ToList();

            var a = AppConnect.model0db.cart.ToList();
            int sumPrice = 0;

            for (int i = 0; i < a.Count; i++)
            {
                int gooid = (int)a[i].skin_id;
                skins b = AppConnect.model0db.skins.FirstOrDefault(x => x.skin_id == gooid);
                sumPrice += (int)b.price;
            }
            Coast.Text = sumPrice.ToString();

            userID = userid;
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
        private void PDF()
        {
            //Document docPdf = new Document();
        }


        int a = 1;

        private void doQR()
        {
            BitmapImage bitmap = new BitmapImage();
            BarcodeGenerator gen = new BarcodeGenerator(EncodeTypes.QR, "https://youtu.be/2GLwFdnnWH0?si=Wu_3BMvNHb18eXSa");
            gen.Parameters.Barcode.XDimension.Pixels = 34;
            string dataDir = @"S:\USERS\51-02\Генералов Сергей Владиславович\DotaSHOP\DotaSHOP";
            gen.Save(dataDir + a.ToString() + "picture.png", BarCodeImageFormat.Png);
            bitmap.BeginInit();
            bitmap.UriSource = new System.Uri(dataDir + a.ToString() + "picture.png");
            bitmap.EndInit();
            QRcode.Source = bitmap;
            a++;
        }
        private void buy_Click(object sender, RoutedEventArgs e)
        {
            doQR();
        }
    }
}
