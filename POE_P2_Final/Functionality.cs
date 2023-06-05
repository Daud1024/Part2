
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace POE_P2_Final
{
   
    internal class Functionality
    {
        public delegate double CalorieDelegate(List<Recipe> recipebook, String Recipe);

        AdditionalFunctions AF = new AdditionalFunctions();
        AdditionalFunctions f1 = new AdditionalFunctions();
         List<Recipe> recipebook = new List<Recipe>();            //NUMBER 1 IN POE PART 2 REQUIREMENTS - Allows users to enter an unlimited number of recipes (Number 2 under StoreRecipe method recipe in this class)
        List<RecipeSteps> stepsbook = new List<RecipeSteps>();
        

        public void StoreRecipe()
        {
            //QUESTION 1.b

            // The method listed above is responsible for generating the necessary prompts required for each recipe, while using the Functionality class to ensure
            // that user input maintains it's integrity and complies to the data types of the arrays
            String recipename = null;
            String singleIngredients = null; // Variables are initialized
            double ingredientQuantity = 0;
            string unitOfMeasuring = null;
            double NoOfCals = 0;
            
            String FoodGroup = null;
            string[] foodGroups = { "Vegetables", "Fruits", "Grains", "Proteins", "Dairy" };//foodGroups array created to loop through and display all of the valid foodgroups to the user

            String StepDetail = null;
            String singleStep = null;




            Console.WriteLine("Please Insert A Name For The Recipe"); //NUMBER 2 OF POE PART 2's REQUIREMENTS - Use can insert a recipe name in addition to everything in part 1 (Number 3 in DisplayRecipe in this class)
            recipename = f1.CheckValidityOfStringInput(recipename, "Recipe Name");
            int NoOfIngredients = AF.NumberOfIngredientsPrompt();
            int NoOfSteps = AF.NumberOfStepsPrompt();

            for (int i = 0; i < NoOfIngredients; i++) //For Loop prompts the user for the necessary details regarding each ingredient in the recipe, using the functionality to maintain data integrity 
            {
                String detail = "Ingredient";
                Console.WriteLine("\nPlease insert " + detail + " " + (i + 1) + "\n");
                singleIngredients = f1.CheckValidityOfStringInput(singleIngredients, detail);

                detail = "Unit Of Measurement";
                Console.WriteLine("\nPlease insert " + detail + " for the " + singleIngredients + "\n");
                unitOfMeasuring = f1.CheckValidityOfStringInput(singleIngredients, detail);

                detail = "Quantity";
                Console.WriteLine("\nPlease insert the " + detail + " of " + singleIngredients + "\n");
                ingredientQuantity = f1.CheckValidityOfDoubleInput();

                detail = "the number of calories";
                Console.WriteLine("\nPlease insert " + detail + " for a single serving of " + singleIngredients + "\n"); //5.a IN THE POE PART 2 REQUIREMENTS -
                                                                                                                         //user is able to insert calories of each ingredient
                NoOfCals = f1.CheckValidityOfDoubleInput() * ingredientQuantity;

                detail = "the food group that";
                Console.WriteLine("\nPlease insert " + detail + " " + singleIngredients + " belongs to\n");//5.b IN THE POE PART 2 REQUIREMENTS -
                                                                                                           //user is able to insert calories of each ingredient
                                                                                                           //NUMBER 6 OF THE POE REQUIREMENTS DONE UNDER - DisplayRecipe method in this class



                // Loop until the user enters a valid selection
                bool validSelection = false;
                int selection = 0;
                while (!validSelection)
                {
                    // Prints all of the food groups as required by the POE
                    Console.WriteLine("Please select a food group:");
                    for (int k = 0; k < foodGroups.Length; k++)
                    {
                        Console.WriteLine((k + 1) + " " + foodGroups[k]);
                    }

                    // Get the user's selection
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out selection))
                    {
                        if (selection >= 1 && selection <= foodGroups.Length)
                        {
                            validSelection = true;
                            FoodGroup = foodGroups[selection - 1];
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection. Please enter a number between 1 and " + foodGroups.Length);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Please enter a number.");
                    }
                }
              

                Recipe recipe = new Recipe(recipename, singleIngredients, ingredientQuantity, unitOfMeasuring, NoOfCals, FoodGroup);
                recipebook.Add(recipe);
                Console.ForegroundColor = ConsoleColor.Red;
                Delegate del = new Delegate();
                CalorieDelegate CD = new CalorieDelegate(del.CalorieAlert);//NUMBER 7 DONE - KEEPING TRACK AND NOTIFYING THE USER WHEN CALORIES EXCEED 300
                                                                           //THE DELEGATE INVOLVED IN THE COMPLETION OF NUMBER 7 IS IN THE Delegate class

                CD(recipebook, recipename);
                Console.ForegroundColor = ConsoleColor.White;
            }
         

            //After the loop is done executing the user is promped to fill in the number of steps required to fulfill the recipe

            //QUESTION 1.c
            String StepPrompt = "the number of steps";



            StepPrompt = "step";
            for (int j = 0; j < NoOfSteps; j++) //QUESTION 1.d    The For Loop prompts the user for the necessary details regarding each step involved in the recipe
            {
                Console.WriteLine("\nPlease Insert step " + (j + 1) + "\n");
                singleStep = f1.CheckValidityOfStringInput(StepDetail, StepPrompt);
                RecipeSteps recipesteps = new RecipeSteps(recipename, singleStep);
                stepsbook.Add(recipesteps);
            }

        }

        public string DisplayRecipe()//provides the list of recipes in alphabetical order and displays the selected recipe accordingly
        {
            Console.Clear();
            Console.WriteLine("Available Recipes \n---------------------------------------------------");
            //Question 2
            //The line below sorts the recipe book list of type 'Recipe' by name in alphabetical order
            IEnumerable<Recipe> sorted = recipebook.OrderBy(x => x.RecipeName).ToList(); //NUMBER 3 IN POE PART2 REQUIREMENTS - DISPLAY RECIPES IN ALPHABETICAL ORDER
                                                                                         //(Number four is done within this method below)
            String EliminateRepetitions = " ";
            //because the recipe list has no unique IDs I eliminated the repetition of the recipe name in the alphabetical list
            //(e.g. many ingredients fall under a single recipe and because they are under the same list to save space the recipe name will repeat)
 
            List<String> NoReps = new List<String>();
            String concatString = null;

            int i = 1;
            foreach (Recipe item in sorted)
            {
                if (EliminateRepetitions.Contains(item.RecipeName) == false)//if the string does not contain the repetition the recipe name is printed in the menu in alphabetical order
                                                                            //The name is then added into the NoReps List
                {
                    Console.WriteLine("[" + i + "] " + item.RecipeName);
                    EliminateRepetitions = EliminateRepetitions + " " + item.RecipeName;
                    NoReps.Add(item.RecipeName);
                    i++;
                }

            }
            Console.WriteLine("---------------------------------------------------");

            int j = 1;
            String Selectedrecipe = null;
            Console.WriteLine("Please select a valid recipe");  //NUMBER 4 IN POE PART 2 REQUIREMENTS - USER CAN SELECT A RECIPE FROM THE ALPHABETICAL ORDERED LIST
                                                                //(Number 5.a and 5.b are done in the StoreRecipe method within this class)
            int userinput = f1.CheckValidityOfIntInput();
            foreach (String item in NoReps)//to make the program more efficient, instead of looping through a list full of repetitions, it loops through a list with none
                                           //in order for the users selection to be met by the application faster
            {
                if (userinput == j)
                {
                    Selectedrecipe = item;

                }
                j++;//indexed for selection
            }

            if (Selectedrecipe == null || userinput > j || userinput < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYou have selected an invalid option");//prompts user to select a valid option and returns user to menu
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Press [Enter] to return to the menu");
                Console.ReadLine();
                Console.Clear();
                
            }
            else//If the user input is valid then the appropriate recipe is printed in a formatted manner, using composite formatting
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                concatString = "Complete Recipe: " + "\n" + "-------------------------------------------------------------------------------------------" + "\n" + "Ingredients:" + "\n";
                concatString = concatString + "-------------------------------------------------------------------------------------------\n";
                int count = 1;
               
                foreach (Recipe item in recipebook)
                {
                   
                    if (Selectedrecipe == item.RecipeName)
                    {
                        
                        //Adegeo (2022) Composite formatting,
                        //Microsoft Learn. Available at:
                        //https://learn.microsoft.com/en-us/dotnet/standard/base-types/composite-formatting (Accessed: April 20, 2023).

                        concatString = concatString + String.Format("{0,-20}", item.Ingredients) + String.Format("{0,-30}", "Quantity: " + item.Quantities + " " + item.UnitOfMeasurement) + String.Format("{0,-20}", "Calories: " + item.Calories) + String.Format("{0,-20}", "Food Group: " + item.FoodGroup) + "\n";
                                                   

                    }
                }
                concatString = concatString + "\n" + "-------------------------------------------------------------------------------------------";
                concatString = concatString + "\n" + "Steps:" + "\n";
                concatString = concatString + "-------------------------------------------------------------------------------------------\n";

                foreach (RecipeSteps p in stepsbook)
                {
                    if (Selectedrecipe == p.RecipeName)
                    {
                        concatString = concatString + "Step " + count + ": " + p.Step + "\n";
                        count++;
                    }
                }
                concatString = concatString + "-------------------------------------------------------------------------------------------\n";
                Delegate del = new Delegate();
                CalorieDelegate CD = new CalorieDelegate(del.TotalCals);

                double totalCals = CD(recipebook, Selectedrecipe);
                concatString = concatString + "This recipe contains a total of " + totalCals + " calories\n";
                Console.WriteLine(concatString);
                Console.ForegroundColor = ConsoleColor.Red;
               
                CalorieDelegate CD2 = new CalorieDelegate(del.CalorieAlert);//NUMBER 7 DONE - KEEPING TRACK AND NOTIFYING THE USER WHEN CALORIES EXCEED 300
                                                                           //THE DELEGATE INVOLVED IN THE COMPLETION OF NUMBER 7 IS IN THE Delegate class
                CD(recipebook, Selectedrecipe);

                Console.ForegroundColor = ConsoleColor.White;
                
            }
            return Selectedrecipe;
        }

        public void UpdateQuantities(String SelectedRecipe)//Updates and scales the quantity of the recipes and therefore the calories
        {
            String option = "";
            Console.WriteLine(" Would You like to scale the quantites to \n [1] 0.5 (half the original amount) \n [2] 2 (Double the original Amount) \n [3] 3 (Triple the original amount) \n Please select the corresponding number to scale your recipe, Press the [Enter] key to leave the amounts as is");
            option = Console.ReadLine();

            // Wagner, B. (2023) If and switch statements - select execution path among branches.,
            // if and switch statements - select execution path among branches. | Microsoft Learn.Available at:
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements (Accessed: April 20, 2023). 

            switch (option) // based on the option the user selects, the array containg quantities are scaled.
            {
                case "1":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nYour recipe has been scaled by a factor of 0.5");
                    foreach (Recipe item in recipebook)
                    {
                        if (SelectedRecipe == item.RecipeName)
                        {
                            item.Quantities = item.Quantities * 0.5;
                            item.Calories = item.Calories * 0.5;
                        }

                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "2":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nYour recipe has been scaled by a factor of 2");

                    foreach (Recipe item in recipebook)
                    {
                        if (SelectedRecipe == item.RecipeName)
                        {
                            item.Quantities = item.Quantities * 2;
                            item.Calories = item.Calories * 2;
                        }

                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "3":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nYour recipe has been scaled by a factor of 3");
                    foreach (Recipe item in recipebook)
                    {
                        if (SelectedRecipe == item.RecipeName)
                        {
                            item.Quantities = item.Quantities * 3;
                            item.Calories = item.Calories * 3;
                        }

                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nYou have chosen to keep the quantities as they are");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            if (option == "1" || option == "2" || option == "3")//ensures that the recipe was scaled in order to be reset
            {
               
                    Console.WriteLine("Would you like to reset the scaling of the recipe, Press [1] to reset the scaling, Press [2] to leave scaling as is");
                String choice = Console.ReadLine();
                Console.Clear();
                    switch (choice)
                    {
                        case "1":
                            switch (option) // based on the option the user selects, the list containing quantities are scaled.
                            {
                                case "1":

                                    foreach (Recipe item in recipebook)
                                    {
                                        if (SelectedRecipe == item.RecipeName)
                                        {
                                            item.Quantities = (item.Quantities / 0.5);
                                        
                                    }

                                    }
                                    break;
                                case "2":

                                    foreach (Recipe item in recipebook)
                                    {
                                        if (SelectedRecipe == item.RecipeName)
                                        {
                                            item.Quantities = (item.Quantities / 2);
                                    }

                                    }
                                    break;
                                case "3":
                                    foreach (Recipe item in recipebook)
                                    {
                                        if (SelectedRecipe == item.RecipeName)
                                        {
                                            item.Quantities = (item.Quantities / 3);
                                    }

                                    }
                                    break;
                            }
                        Console.Clear();
                        Console.WriteLine("The Recipe Scaling was Reset");
                            break;
                        case "2":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Scaling has not been reset");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                        default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input,scaling has not been reset");
                            
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
               
            }
            Console.ForegroundColor = ConsoleColor.Green;
            String concatout = "Complete Recipe: " + "\n" + "-------------------------------------------------------------------------------------------" + "\n" + "Ingredients:" + "\n";
            concatout = concatout + "-------------------------------------------------------------------------------------------\n";
            int count = 1;
            
            foreach (Recipe item in recipebook)
            {
                if (SelectedRecipe == item.RecipeName)
                {

                    //Adegeo (2022) Composite formatting,
                    //Microsoft Learn. Available at:
                    //https://learn.microsoft.com/en-us/dotnet/standard/base-types/composite-formatting (Accessed: April 20, 2023).

                    concatout = concatout + String.Format("{0,-20}", item.Ingredients) + String.Format("{0,-30}", "Quantity: " + item.Quantities + " " + item.UnitOfMeasurement) + String.Format("{0,-20}", "Calories: " + item.Calories) + String.Format("{0,-20}", "Food Group: " + item.FoodGroup) + "\n";
                    
                }
            }
            concatout = concatout + "\n" + "-------------------------------------------------------------------------------------------";
            concatout = concatout + "\n" + "Steps:" + "\n";
            concatout = concatout + "-------------------------------------------------------------------------------------------\n";

            foreach (RecipeSteps p in stepsbook)
            {
                if (SelectedRecipe == p.RecipeName)
                {
                    concatout = concatout + "Step " + count + ": " + p.Step + "\n";
                    count++;
                }
            }
            concatout = concatout + "-------------------------------------------------------------------------------------------\n";
            Delegate del = new Delegate();
            CalorieDelegate CD = new CalorieDelegate(del.TotalCals);

            double totalCals = CD(recipebook, SelectedRecipe);
            concatout = concatout + "This recipe contains a total of " + totalCals + " calories\n";
            Console.WriteLine(concatout);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press [Enter] to return to the menu");
            Console.ReadLine();
            Console.Clear();
        }

    }
}


