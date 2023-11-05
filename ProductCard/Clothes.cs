using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCard
{
    /// <summary>
    /// Класс с информацией об одежде
    /// </summary>
    internal class Clothes : AllProducts
    {
        public override string Name { get; set; }
        public override double Price { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }

        #region[Перегрузка конструктора]
        public Clothes(string name, double price) : base (name, price)
        {
            Name = name;
            Price = price;
        }
        public Clothes()
        {

        }
        #endregion

        /// <summary>
        /// Переопределенный метод для получения наибольшей суммы товара
        /// </summary>
        /// <param name="price"></param>
        /// <param name="products"></param>
        /// <returns></returns>
        public override List<double> GetMoreExpensive(List<AllProducts> products)
        {
            var sort = products.Select(s => s.Price).ToList().OrderByDescending(n => n).ToList();
            return sort;
        }
    }
}
