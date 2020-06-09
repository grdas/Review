using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotionEngine;


namespace ConsoleApp1
{
    public class ManualTest
    {

        ProductStock products;
        PromotionRuleExexcutor promotionExecutor;
       
        public void initialize()
        {
            products = new ProductStock();
            promotionExecutor = new PromotionRuleExexcutor();
        }


        public void TestMethod_ScenarioA()
        {
            var shoppingCart = new Dictionary<Product, int>();

            shoppingCart.Add(products["A"], 1);
            shoppingCart.Add(products["B"], 1);
            shoppingCart.Add(products["C"], 1);

            decimal finalCartAmount = promotionExecutor.ApplyPromotionsAll(shoppingCart);

            Console.WriteLine("The expected cart amount {0} and final amount {1}", 100, finalCartAmount);

            //Assert.AreEqual(100, finalCartAmount);
        }


        public void TestMethod_ScenarioB()
        {
            var shoppingCart = new Dictionary<Product, int>();

            shoppingCart.Add(products["A"], 5);
            shoppingCart.Add(products["B"], 5);
            shoppingCart.Add(products["C"], 1);

            decimal finalCartAmount = promotionExecutor.ApplyPromotionsAll(shoppingCart);

            Console.WriteLine("The expected cart amount {0} and final amount {1}", 370, finalCartAmount);
                        
        }


        public void TestMethod_Scenario_C_D()
        {
            var shoppingCart = new Dictionary<Product, int>();

            shoppingCart.Add(products["A"], 3);
            shoppingCart.Add(products["B"], 5);
            shoppingCart.Add(products["C"], 1);
            shoppingCart.Add(products["D"], 1);

            decimal finalCartAmount = promotionExecutor.ApplyPromotionsAll(shoppingCart);

            Console.WriteLine("The expected cart amount {0} and final amount {1}", 285, finalCartAmount);
           
        }
    }
}
