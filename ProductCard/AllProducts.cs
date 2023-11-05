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
        /// Метод для использования дочерними классами
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual List<double> GetMoreExpensive(List<AllProducts> products)
            => throw new NotImplementedException();
    }
}
