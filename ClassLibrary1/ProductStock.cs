using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class ProductStock
    {
        private HashSet<Product> productsAvailable;

        public ProductStock()
        {
            productsAvailable = new HashSet<Product>()
                {   new Product("A", 50m),
                    new Product("B", 30m),
                    new Product("C", 20m),
                    new Product("D", 15m)
                }; 
        }

        public Product this[string sku_Id]
        {
            get
            {
                return productsAvailable.FirstOrDefault(p => p.Sku_Id.Equals(sku_Id));
            }
        }        
    }
}
