using PromotionEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {

        static void Main(string[] args)
        {
            ManualTest mTest = new ManualTest();
            mTest.initialize();
            mTest.TestMethod_ScenarioA();
            mTest.TestMethod_ScenarioB();
            mTest.TestMethod_Scenario_C_D();

            Console.ReadKey();
        }
    }
}

