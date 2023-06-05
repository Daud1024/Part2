using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_P2_Final
{
  
        public class Tests
        {
            public double TotalCals(List<Recipe> recipebook, String Recipe)
            {
                double Calories = 0;
                foreach (Recipe recipe in recipebook)
                {
                    if (Recipe == recipe.RecipeName)
                    {
                        Calories += (recipe.Calories * recipe.Quantities);
                    }
                }
                return Calories;
            }
        }
    }
