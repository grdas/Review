using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;

namespace Promotion_UnitTest
{
    [TestClass]
    public class PromotionTest
    {
        private ProductStock products;
        private PromotionRuleExexcutor promotionExecutor;
        [TestInitialize]
        public void TestInitiate()
        {
            products = new ProductStock();
            promotionExecutor = new PromotionRuleExexcutor();
        }

        [TestMethod]
        public void TestMethod_ScenarioA()
        {
            var shoppingCart = new Dictionary<Product,int>();

            shoppingCart.Add(products["A"], 1);
            shoppingCart.Add(products["B"], 1);
            shoppingCart.Add(products["C"], 1);

            decimal finalCartAmount = promotionExecutor.ApplyPromotionsAll(shoppingCart);

            Assert.AreEqual(100, finalCartAmount);
        }

        [TestMethod]
        public void TestMethod_ScenarioB()
        {
            var shoppingCart = new Dictionary<Product, int>();

            shoppingCart.Add(products["A"], 5);
            shoppingCart.Add(products["B"], 5);
            shoppingCart.Add(products["C"], 1);

            decimal finalCartAmount = promotionExecutor.ApplyPromotionsAll(shoppingCart);

            Assert.AreEqual(370, finalCartAmount);

        }

        [TestMethod]
        public void TestMethod_Scenario_C_D()
        {
            var shoppingCart = new Dictionary<Product, int>();

            shoppingCart.Add(products["A"], 3);
            shoppingCart.Add(products["B"], 5);
            shoppingCart.Add(products["C"], 1);
            shoppingCart.Add(products["D"], 1);

            decimal finalCartAmount = promotionExecutor.ApplyPromotionsAll(shoppingCart);

            Assert.AreEqual(285, finalCartAmount);

        }
    }
}
