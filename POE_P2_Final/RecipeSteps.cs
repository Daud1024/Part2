using System;

namespace POE_P2_Final
{
    internal class RecipeSteps
    {
        public string RecipeName { get; set; }
        public string Step { get; set; }

        public RecipeSteps() { }

        public RecipeSteps(string recipeName, String step)
        {
            RecipeName = recipeName;
            Step = step;
        }
    }
}