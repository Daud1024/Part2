using System;

namespace POE_P2_Final
{
    internal class AdditionalFunctions
    {


        public void GreetUser()//Introduces user to the Recipe application
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to the recipe application!");
            Console.WriteLine("Press any button to continue!");
            Console.ReadKey(true); //Emily (2021) C# console application - how to read key presses and user inputs,
                                   //Brainstorm Creative. Available at:
                                   //https://www.brainstormcreative.co.uk/c/console-application-c-how-to-read-key-presses-and-user-inputs/ (Accessed: March 15, 2023). 
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }
        public int CheckValidityOfIntInput()//checks if user has inserted a valid integer
        {
            int attempts = 0;
            String Input = null;
            int NumberOfIngredients = 0;
            do
            {

                if (attempts == 0)
                {
                    Input = Console.ReadLine();
                }

                //C# try-catch - javatpoint (2019)
                //www.javatpoint.com. Available at:
                //https://www.javatpoint.com/c-sharp-try-catch (Accessed: March 15, 2023). 
                try
                {
                    NumberOfIngredients = int.Parse(Input);
                    if (NumberOfIngredients <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid input, press any key to continue");
                        Console.ReadKey(true);//Emily (2021) C# console application - how to read key presses and user inputs,
                                              //Brainstorm Creative. Available at:
                                              //https://www.brainstormcreative.co.uk/c/console-application-c-how-to-read-key-presses-and-user-inputs/ (Accessed: March 15, 2023).
                        attempts = attempts + 1;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                catch (FormatException) //C# - exception handling (2020)
                                        //Tutorials Point. Available at:
                                        //https://www.tutorialspoint.com/csharp/csharp_exception_handling.htm (Accessed: March 15, 2023). 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid input, press any key to continue");
                    Console.ReadKey(true);
                    attempts = attempts + 1;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if ((attempts > 0) && (NumberOfIngredients <= 0))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease re-enter a valid number");
                    Input = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;

                }
            } while (NumberOfIngredients <= 0);
            return NumberOfIngredients;
        }
        public string CheckValidityOfStringInput(String listIngredients, String detail)//checks if a required string is null
        {
            do
            {
                listIngredients = Console.ReadLine();

                if (listIngredients == "")//checks if the ingredient is left empty by mistakes and
                                          //allows user to reinsert a valid ingredient
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid input, press any key to continue");
                    Console.ReadKey(true);//Emily (2021) C# console application - how to read key presses and user inputs,
                                          //Brainstorm Creative. Available at:
                                          //https://www.brainstormcreative.co.uk/c/console-application-c-how-to-read-key-presses-and-user-inputs/ (Accessed: March 15, 2023).
                    Console.WriteLine("Please re-enter " + detail);
                    Console.ForegroundColor = ConsoleColor.White;
                }

            } while (listIngredients == "");
            return listIngredients;
        }
        public double CheckValidityOfDoubleInput()//checks if user input is a valid double value in relation to recipes
        {
            int attempts = 0;
            String Input = null;
            double DoubleVal = 0;
            do
            {

                if (attempts == 0)
                {
                    Input = Console.ReadLine();
                }

                //C# try-catch - javatpoint (2019)
                //www.javatpoint.com. Available at:
                //https://www.javatpoint.com/c-sharp-try-catch (Accessed: March 15, 2023). 

                try
                {
                    Input = Input.Replace(".", ","); //ensures that whether a user inputs a comma or a fullstop as a decimal point, it is converted to a double
                                                     //Kumar, M. (2019) C#: Replace() method, GeeksforGeeks.
                                                     //GeeksforGeeks. Available at:
                                                     //https://www.geeksforgeeks.org/c-sharp-replace-method/ (Accessed: March 15, 2023). 

                    DoubleVal = double.Parse(Input);
                    if (DoubleVal <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid input, press any key to continue");
                        Console.ReadKey(true);//Emily (2021) C# console application - how to read key presses and user inputs,
                                              //Brainstorm Creative. Available at:
                                              //https://www.brainstormcreative.co.uk/c/console-application-c-how-to-read-key-presses-and-user-inputs/ (Accessed: March 15, 2023).
                        attempts = attempts + 1;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                catch (FormatException)//C# - exception handling (2020)
                                       //Tutorials Point. Available at:
                                       //https://www.tutorialspoint.com/csharp/csharp_exception_handling.htm (Accessed: March 15, 2023). 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid input, press any key to continue");
                    Console.ReadKey(true);
                    attempts = attempts + 1;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if ((attempts > 0) && (DoubleVal <= 0))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease re-enter a valid number");
                    Input = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;

                }
            } while (DoubleVal <= 0);
            return DoubleVal;

        }
        //Question 1.a
        public int NumberOfIngredientsPrompt()//prompts user for the number of ingredients
        {//Question 1 a.
            
            Console.WriteLine("\nPlease enter the number of ingredients for a single recipe:");

            int output = CheckValidityOfIntInput();

            return output;
        }

        public int NumberOfStepsPrompt()//prompts user for the number of steps
        {

            Console.WriteLine("\nPlease enter the number of steps for the single recipe:");

            int output = CheckValidityOfIntInput();

            return output;
        }

    }
}

