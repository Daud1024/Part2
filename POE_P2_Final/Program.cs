
using System;
//ST10071193
//FOR MARKER CONVENIENCE
//ERROR HANDLING was implemented in the AdditionalFunctions class, the error handling methods were then used in the Functionality class
//ALL OF THE FUNCTIONAL REQUIREMENTS FOR POE PART 2 were implemented in the Functionality class,
//^ this includes the generic lists used to store recipes and the implementation of a calorie tracking delegate

//THE GENERIC LISTS use the constructors that were instantiated in the Recipe and RecipeSteps class
//THE DELEGATE USED IN the Functionality class was established in the delegate class
namespace POE_P2_Final
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AdditionalFunctions AF = new AdditionalFunctions();
            Functionality func = new Functionality();
            AF.GreetUser();

            String input = "0";

            do
            {
                Console.WriteLine("Please select a valid option \n[1] Store Recipe \n[2] Display Recipe \n[3] Exit");//Main menu allowing user to store a recipe or view an existing recipe
                input = Console.ReadLine();
                switch (input)
                {
                    case "1"://Stores Recipe
                        func.StoreRecipe();
                        Console.Clear();
                        break;
                    case "2"://Allows user to view existing recipes in alphabetical order
                        String SelectedRecipe = func.DisplayRecipe();

                        if (SelectedRecipe != null)
                        {
                            func.UpdateQuantities(SelectedRecipe);//Allows users to update the quantities as per the POE requirements
                        }
                        break;
                    case "3":
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please Select a valid option");
                        break;
                }
            } while (input != "3");//loops if user inserts a invalid input
        }
    }
}





