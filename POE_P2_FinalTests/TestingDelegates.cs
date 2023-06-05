using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POE_P2_Final;
using System.Security.Cryptography;

namespace POE_P2_Final.TestClass.Tests
{
    [TestClass()]
    public class TestingDelegates
    {
        [TestMethod()]
        public void TotalCalsTest_True()
        {
            List<Recipe> recipebook = new List<Recipe>();
            string Recipename = "apple sauce";
            Recipe recipe = new Recipe(Recipename, "apple", 3 , "(N/A)", 50, "Fruits"); //3 apples * 50 cals per apple = 150 calories,

            Recipe recipeNull = new Recipe("Cake", "milk", 10, "(N/A)", 100, "Dairy");//should not be included because its an ingredient related to another recipe

            Recipe recipe2 = new Recipe(Recipename, "pear", 10, "(N/A)", 100, "Fruits");//10 pears * 100 cals per apple = 1000 calories,
                                                                                       
            recipebook.Add(recipe);
            recipebook.Add(recipeNull);
            recipebook.Add(recipe2);


            double expected = 150 + 1000;

            POE_P2_Final.Tests test = new POE_P2_Final.Tests();
            double actual = test.TotalCals(recipebook, Recipename);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TotalCalsTest_False()
        {
            List<Recipe> recipebook = new List<Recipe>();
            string Recipename = "smoothie";
            Recipe recipe = new Recipe(Recipename, "apple", 3, "(N/A)", 50, "Fruits"); //3 apples * 50 cals per apple = 150 calories,

            Recipe recipeNull = new Recipe("Cake", "milk", 10, "(N/A)", 100, "Dairy");//should not be included because its an ingredient related to another recipe

            Recipe recipe2 = new Recipe(Recipename, "pear", 10, "(N/A)", 100, "Fruits");//10 pears * 100 cals per apple = 1000 calories,

            recipebook.Add(recipe);
            recipebook.Add(recipeNull);
            recipebook.Add(recipe2);


            double expected = 150 + 1000 + 1000; //This is incorrect as the ingredient recipeNull does not fall under the same recipe

            POE_P2_Final.Tests test = new POE_P2_Final.Tests();
            double actual = test.TotalCals(recipebook, Recipename);

            Assert.AreNotEqual(expected, actual);
        }
    }
}