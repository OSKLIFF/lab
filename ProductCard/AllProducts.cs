using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCard
{
    /// <summary>
    /// Базовый класс для всех  продуктов
    /// </summary>
    internal class AllProducts 
    {
        public virtual string Name { get; set; }
        public virtual double Price { get; set; }

        #region[Перегрузка конструктора]
        public AllProducts()
        {
            
        }
        public AllProducts(string name, double price)
        {
            Name = name;
            Price = price;
        }
        #endregion[]

        /// <summary>
        /// Метод для получения наибольшей суммы товара
        /// </summary>
        /// <param name="price"></param>
        /// <param name="products"></param>
        /// <returns></returns>
        public List<double> GetMoreExpensive(List<AllProducts> products)
             => products.Select(s => s.Price).ToList().OrderByDescending(n => n).ToList();

        /// <summary>
        /// Метод для переопределения дочерними классами
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual List<AllProducts> GetInfoForMoreExpensive(List<AllProducts> allProducts, List<double> sortedPrice)
            => throw new NotImplementedException();
    }
}
