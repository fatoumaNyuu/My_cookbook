using My_cookbook.Models;
using My_cookbook.Storage;
using My_cookbook.Utilities;

namespace My_cookbook.Services
{
    internal partial class RecipeService : IRecipeService
    {
        private List<RecipeModel> _recipes;

        public RecipeService()
        {                                       // Läd mein Storage her
            _recipes = StorageService.Load();  // speichert mein Rezept ab
        }

        public void Add()
        {
            var recipeModel = new RecipeModel(); // verbindet mein RecipeModel (Models) mit dem hier

            Console.Clear();
            Console.WriteLine($"{Headline.HeaderAdd}\n");
            Console.Write("Recipe title: ");
            var recipeName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(recipeName) && recipeModel.Name != recipeName)  // name ist nicht leer oder null & nicht gleich vorheriger name = neuer name
            {
                recipeModel.Name = recipeName;
            }

            Console.Write("Portions: ");
            int.TryParse(Console.ReadLine(), out int portion); // keine Eingabe und Buchstaben = 0
            recipeModel.Portion = portion;

            Console.Write("Calories: ");
            int.TryParse(Console.ReadLine(), out int calories); // keine Eingabe und Buchstaben = 0
            recipeModel.Calories = calories;

            Console.Write("Cooking Time in minutes: ");
            int.TryParse(Console.ReadLine(), out int cookingTime); // keine Eingabe und Buchstaben = 0
            recipeModel.CookingTime = cookingTime;

            Console.WriteLine("Ingredients (one ingredient per line, leave line empty to quit):");
            while (true)
            {
                var ingredient = Console.ReadLine();  // liest zutat
                if (string.IsNullOrWhiteSpace(ingredient)) break;  // wenn nichts drin steht dann stoppt es
                recipeModel.Ingredients.Add(ingredient); // fügt meine Zutaten in die liste hinzu
            }

            Console.WriteLine("Preparation: ");
            while (true)
            {
                var preparation = Console.ReadLine();  // liest zutat
                if (string.IsNullOrWhiteSpace(preparation)) break;  // wenn nichts drin steht dann stoppt es
                recipeModel.Preparation += $"\n{preparation}"; // fügt meine Zutaten in die liste hinzu
            }

            Console.WriteLine("Instructions: ");
            while (true)
            {
                var instruction = Console.ReadLine();  // liest zutat
                if (string.IsNullOrWhiteSpace(instruction)) break;  // wenn nichts drin steht dann stoppt es
                recipeModel.CookingInstuctions += $"\n{instruction}"; // fügt meine Zutaten in die liste hinzu
            }

            _recipes.Add(recipeModel);
            StorageService.Save(_recipes);
            Console.WriteLine("Saved recipe!");
        }
    }
}
