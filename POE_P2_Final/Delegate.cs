using System;
using System.Collections.Generic;

namespace POE_P2_Final
{

    internal class Delegate
    {
            public double CalorieAlert(List<Recipe> recipebook, String Recipe)
            {
                double Calories = 0;
                foreach (Recipe recipe in recipebook)
                {
                    if (Recipe == recipe.RecipeName)
                    {
                        Calories += recipe.Calories ;
                    }
                }
                if (Calories > 300)
                {
                    Console.WriteLine("Recipe " + Recipe + " exceeds 300 calories");
                    Console.WriteLine("Recipe " + Recipe + " contains " + Calories + " calories");
                    Console.WriteLine(" ");
                    Console.WriteLine("Press [Enter] to continue");
                    Console.ReadLine();
                }
                return Calories;
            }

            public double TotalCals(List<Recipe> recipebook, String Recipe)
            {
                double Calories = 0;
                foreach (Recipe recipe in recipebook)
                {
                    if (Recipe == recipe.RecipeName)
                    {
                        Calories += recipe.Calories;
                    }
                }
                return Calories;
            }
        }
    }

