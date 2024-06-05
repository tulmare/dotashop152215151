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
using System.Data.Entity.Migrations;

namespace DotaSHOP
{
    public partial class AddItem : Window
    {
        public AddItem()
        {
            InitializeComponent();
            rarityID.Items.Add("Фильтрация");
            foreach (var item in AppConnect.model0db.rarcategory.ToList())
            {
                rarityID.Items.Add(item.rarity.ToString());
            }
            rarityID.SelectedIndex = 0;
        }
        private skins editSkins;

        public AddItem(skins editSkins)
        {
            InitializeComponent();
            this.editSkins = editSkins;

            //получение данных из admin для изменение
            var skinnameCh = editSkins.skinname.ToString();
            var priceCh = editSkins.price.ToString();
            var heroCh = editSkins.hero.ToString();
            var imageurlCh = editSkins.image_url.ToString();
            var rarityIDCh = editSkins.rarityID;
            var slotIDCh = editSkins.slotID;
            var descriptionCh = editSkins.description.ToString();


            //ввод этих данных на их места
            skinname.Text = skinnameCh;
            price.Text = Convert.ToString(priceCh);
            hero.Text = heroCh;
            image_url.Text = imageurlCh;
            rarityID.SelectedIndex = Convert.ToInt32(rarityIDCh) - 1;
            slotID.SelectedIndex = Convert.ToInt32(slotIDCh) - 1;
            description.Text = descriptionCh;
        }


        //Добавление товара в main
        private void Additem_Click(object sender, RoutedEventArgs e)
        {

            //получение данных в переменную
            var SN = skinname.Text.ToString();
            var PR = price.Text.ToString();
            var HR = hero.Text.ToString();
            var PHOTOITEM = image_url.Text.ToString();
            var RAR = rarityID.SelectedIndex + 1;
            var SL = slotID.SelectedIndex + 1;
            var DS = description.Text.ToString(); 


            //проверка данных на корректность
            int error = 0;
            if (SN.Length < 1)
            {
                error++;
            }
            if (PR.Length < 1)
            {
                error++;
            }
            if (HR.Length < 1)
            {
                error++;
            }
            if (PHOTOITEM.Length < 1)
            {
                error++;
            }
            if (RAR == 0)
            {
                error++;
            }
            if (SL == 0)
            {
                error++;
            }
            if (DS.Length < 1)
            {
                error++;
            }

            //если нету ошибок то добавляем товар
            if (error == 0)
            {
                try
                {
                    //проверка на изменение или добавлнеие
                    var skin_id = 0;
                    if (editSkins != null)
                    {
                        skin_id = editSkins.skin_id;
                    }
                    skins mainItems = new skins()
                    {
                        skin_id = skin_id,
                        skinname = skinname.Text,
                        price = Convert.ToInt32(price.Text),
                        hero = hero.Text,
                        image_url = image_url.Text,
                        rarityID = rarityID.SelectedIndex + 1,
                        slotID = slotID.SelectedIndex + 1 
                    };

                    //если данные уже есть тоесть мы изменяем, мы это ловим с помошью переменной и меняем данные
                    AppConnect.model0db.skins.AddOrUpdate(mainItems);
                    AppConnect.model0db.SaveChanges();
                    MessageBox.Show("товар добавлен");

                    //переход на страницу с товаром
                    Adminka adminka = new Adminka();
                    adminka.Show();
                    Close();
                }
                catch (Exception ex) { MessageBox.Show("Что-то пошло не так"); }


            }
            //если есть ошибки то предупреждаем
            else
            {
                MessageBox.Show("Обнаружены пустые данные");
            }
        }

        //вернутся на страницу с товарами 
        private void back_Click(object sender, RoutedEventArgs e)
        {
            Adminka adminka = new Adminka();
            adminka.Show();
            Close();
        }
    }
}
