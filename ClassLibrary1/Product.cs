using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class Product
    {
        public readonly string Sku_Id;

        public readonly decimal Price;

        internal Product(string sku_Id, decimal price)
        {
            Sku_Id = sku_Id;
            Price = price;
        }
    }
}
