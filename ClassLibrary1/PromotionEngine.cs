using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    //This class can be modified to add new promotion or deactivate any promotion
    public class PromotionRuleExexcutor
    {
        //Instantiate product stock
        ProductStock productsStock;

        //Create a of promotions and placeholder for promotion amount
        Dictionary<Promotion, Decimal> promotionsList;

        // Apply Promotions mutually exclusive which will be called from user after fillling the cart 
        public decimal ApplyPromotionsMutuallyExclusive(Dictionary<Product, int> productsInCart)
        {
            productsStock = new ProductStock();
            promotionsList = new Dictionary<Promotion, decimal>();
            Promotion prom1 = new Promotion("Promotion For Product A", promotionForProd_A);
            Promotion prom2 = new Promotion("Promotion For Product B", promotionForProd_B);
            Promotion prom3 = new Promotion("Promotion For Product C_D", promotionForProd_C_D);

            //All promotions will be applied for cart individually
            promotionsList.Add(prom1, prom1.afterPromotionApplied(productsInCart));
            promotionsList.Add(prom2, prom2.afterPromotionApplied(productsInCart));
            promotionsList.Add(prom3, prom3.afterPromotionApplied(productsInCart));

            //The promotion which return minimum of cart values will be returned
            return promotionsList.Aggregate((l, r) => l.Value < r.Value ? l : r).Value;

        }

        // Apply Promotions mutually exclusive which will be called from user after fillling the cart 
        public decimal ApplyPromotionsAll(Dictionary<Product, int> productsInCart)
        {
            productsStock = new ProductStock();
            promotionsList = new Dictionary<Promotion, decimal>();
            Promotion prom1 = new Promotion("Applied All Promotions", promotionForAll);
            return prom1.afterPromotionApplied(productsInCart);

        }

        //New Promotion rule for Product A
        private decimal promotionForProd_A(Dictionary<Product, int> productsInCart)
        {
            decimal totAmount = 0m;
            decimal promotionAmount = 130m;
            foreach (KeyValuePair<Product, int> product in productsInCart)
            {
                if (product.Key.Sku_Id.Equals("A"))
                {
                    int countOfA = product.Value;
                    totAmount += (countOfA / 3) * promotionAmount + (countOfA % 3) * product.Key.Price;
                }
                else
                    totAmount += product.Key.Price * product.Value;
            }

            return totAmount;
        }

        //New Promotion rule for Product B
        private decimal promotionForProd_B(Dictionary<Product, int> productsInCart)
        {
            decimal totAmount = 0m;
            decimal promotionAmount = 45m;
            foreach (KeyValuePair<Product, int> product in productsInCart)
            {
                if (product.Key.Sku_Id.Equals("B"))
                {
                    int countOfB = product.Value;
                    totAmount += (countOfB / 2) * promotionAmount + (countOfB % 2) * product.Key.Price;
                }
                else
                    totAmount += product.Key.Price * product.Value;
            }

            return totAmount;
        }

        //New Promotion rule for Product C and D
        private decimal promotionForProd_C_D(Dictionary<Product, int> productsInCart)
        {
            decimal totAmount = 0m;
            decimal promotionAmount = 30m;
            int countC = 0;
            int countD = 0;

            countC = productsInCart.FirstOrDefault(p => p.Key.Sku_Id.Equals("C")).Value;
            countD = productsInCart.FirstOrDefault(p => p.Key.Sku_Id.Equals("D")).Value;

            //if both C and D added to Cart
            if (countC > 1 && countD > 1)
            {
                if (countD >= countC)
                    totAmount = (countD - (countD - countC)) * promotionAmount + (countD - countC) * productsStock["C"].Price;
                else
                    totAmount = (countC - (countC - countD)) * promotionAmount + (countC - countD) * productsStock["D"].Price;
            }
            else //otherwise below will calculate for individual item whichever available
            {
                totAmount = countC * productsStock["C"].Price + countD * productsStock["D"].Price;
            }

            foreach (KeyValuePair<Product, int> product in productsInCart)
            {
                if (product.Key.Sku_Id.Equals("C") || product.Key.Sku_Id.Equals("D"))
                {
                    totAmount = totAmount; //Skip it
                }
                else
                    totAmount += product.Key.Price * product.Value;
            }
            return totAmount;            
        }

        private Decimal promotionForAll(Dictionary<Product, int> productsInCart)
        {
            decimal totAmount = 0m;
            decimal promotionAmountA = 130m;
            decimal promotionAmountB = 45m;
            decimal promotionAmountCD = 30m;
            int countC = 0;
            int countD = 0;

            countC = productsInCart.FirstOrDefault(p => p.Key.Sku_Id.Equals("C")).Value;
            countD = productsInCart.FirstOrDefault(p => p.Key.Sku_Id.Equals("D")).Value;

            //starting with if both C and D added to Cart
            if (countC > 1 && countD > 1)
            {
                if (countD >= countC)
                    totAmount = (countD - (countD - countC)) * promotionAmountCD + (countD - countC) * productsStock["C"].Price;
                else
                    totAmount = (countC - (countC - countD)) * promotionAmountCD + (countC - countD) * productsStock["D"].Price;
            }
            else //otherwise below will calculate for individual item whichever available
            {
                totAmount = countC * productsStock["C"].Price + countD * productsStock["D"].Price;
            }

            foreach (KeyValuePair<Product, int> product in productsInCart)
            {
                if (product.Key.Sku_Id.Equals("C") || product.Key.Sku_Id.Equals("D"))
                {
                    totAmount = totAmount; //Skip it
                }
                else if (product.Key.Sku_Id.Equals("A"))
                {
                    int countOfA = product.Value;
                    totAmount += (countOfA / 3) * promotionAmountA + (countOfA % 3) * product.Key.Price;
                }
                else if (product.Key.Sku_Id.Equals("B"))
                {
                    int countOfB = product.Value;
                    totAmount += (countOfB / 2) * promotionAmountB + (countOfB % 2) * product.Key.Price;
                }
                
            }

            return totAmount;
        }
    }
}
