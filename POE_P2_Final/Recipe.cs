
namespace POE_P2_Final
{
    public class Recipe
    {

        public string RecipeName { get; set; }
        public string Ingredients { get; set; }
        public double Quantities { get; set; }
        public string UnitOfMeasurement { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }

        public Recipe() { }

        public Recipe(string recipeName, string ingredients, double quantities, string unitofmeasurement, double calories, string foodgroup)
        {
            RecipeName = recipeName;
            Ingredients = ingredients;
            Quantities = quantities;
            UnitOfMeasurement = unitofmeasurement;
            Calories = calories;
            FoodGroup = foodgroup;
        }
    }
}
