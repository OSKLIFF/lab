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

namespace ProductCard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Делает видимой выбранную карточку товаров
            GetCardOfChosenProductType_BT.Click += (object sender, RoutedEventArgs e) =>
            {
                ClothCard_BD.Visibility = (ChooseTypeOfProduct_CB.Text == "Одежда") ? Visibility.Visible : Visibility.Hidden;
                FoodCard_BD.Visibility = (ChooseTypeOfProduct_CB.Text == "Одежда") ? Visibility.Hidden : Visibility.Visible;
            };

            ChooseTypeOfProduct_CB.DropDownOpened += (object sender, EventArgs e) => { _allProducts.Clear(); }; //Очистка списка 
            SaveChangesForClothCard_BT.Click += SaveChangesForClothCard_BT_Click;
            GetExpensiveInfo_BT.Click += GetExpensiveInfoClothes_BT_Click;
        }

        /// <summary>
        /// Сохранение товаров в список _allProducts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveChangesForClothCard_BT_Click(object sender, RoutedEventArgs e)
        {
            _allProducts.Add(new Clothes(ClothName_TB.Text, double.TryParse(ClothPrice_TB.Text, out double d) ? double.Parse(ClothPrice_TB.Text) : throw new Exception("Не удалось переопределить тип данных !"))
            {
                Size = Convert.ToInt32(ClothSize_TB.Text),
                Color = ClothColor_TB.Text
            });
            ClearAllTextBoxes(ChooseTypeOfProduct_CB.Text);
        }

        /// <summary>
        /// Очищает значения в карточке продуктов после сохранения
        /// </summary>
        /// <param name="chosenProductType"></param>
        private void ClearAllTextBoxes(string chosenProductType)
        {
            switch (chosenProductType)
            {
                case "Одежда":
                    ClothName_TB.Clear();
                    ClothPrice_TB.Clear();
                    ClothSize_TB.Clear();
                    ClothColor_TB.Clear();
                    break;
                case "Продукты питания":
                    FoodName_TB.Clear();
                    FoodPrice_TB.Clear();
                    FoodCcal_TB.Clear();
                    break;
                default:
                    MessageBox.Show("Не выбрана карточка продуктов!");
                    break;
            }
        }

        /// <summary>
        /// Возвращает самый дорогой товар - одежду
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetExpensiveInfoClothes_BT_Click(object sender, RoutedEventArgs e)
        {
            var getExpensive = new Clothes();
            var sorted = getExpensive.GetMoreExpensive(_allProducts);
            var result = _allProducts.Where(w => w.Price == sorted[0]).ToList();
            result.ForEach(f =>
            {
                GetExpensiveName_TB.Text = f.Name;
                GetExpensivePrice_TB.Text = f.Price.ToString();
            });           
        }

        /// <summary>
        /// Список продуктов 
        /// </summary>
        List<AllProducts> _allProducts = new List<AllProducts>();
    }
}
