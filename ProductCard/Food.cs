using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCard
{
    /// <summary>
    /// Класс с информацией о еде
    /// </summary>
    internal class Food : AllProducts
    {
        public override string Name { get; set; }
        public override double Price { get; set; }
        public int Ccal { get; set; }

        #region[Перегрузка конструктора]
        public Food(string name, double price, int ccal) : base(name, price)
        {
            Name = name;
            Price = price;
            Ccal = ccal;
        }
        public Food()
        {

        }
        #endregion

        /// <summary>
        /// Получение данных товара с самой высокой ценой из списка
        /// </summary>
        /// <param name="allProducts"></param>
        /// <param name="sortedPrice"></param>
        /// <returns></returns>
        public override List<AllProducts> GetInfoForMoreExpensive(List<AllProducts> allProducts, List<double> sortedPrice)
            => allProducts.Where(w => w.Price == sortedPrice[0]).ToList();
    }
}
