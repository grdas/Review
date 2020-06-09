using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    //A place holder class for Promotion with standard structure of a Name and \
    //a delegate for promotion calculation
    public class Promotion
    {
        public readonly string promotionName;

        public delegate decimal PromotionRule(Dictionary<Product, int> productsInCart);

        public readonly PromotionRule Rule;

        public Promotion(string promoName, PromotionRule rule)
        {
            promotionName = promoName;
            Rule = rule;
        }

        public decimal afterPromotionApplied(Dictionary<Product, int> productsInCart)
        {
            if (Rule!=null)
                return Rule.Invoke(productsInCart);

            return 0m;
        }
    }
}
