
using My_cookbook.Utilities;

namespace My_cookbook.Services
{
    internal partial class RecipeService : IRecipeService
    {
        public void Show()
        {
            Console.Clear();
            Console.WriteLine($"{Headline.HeaderShow}\n");
            if (!_recipes.Any())
            {
                Console.WriteLine("No recipes found.");
                return;
            }

            Console.WriteLine("\n--- Recipes ---\n");
            for (int i = 0; i < _recipes.Count; i++)
            {
                Console.WriteLine($"[{i}] {_recipes[i].Name}");  // Zeigt mir alle Rezepte zur Auswahl an
            }

            Console.Write("\nSelect recipe: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < _recipes.Count)
            {
                Console.Clear();
                var recipe = _recipes[index];
                Console.WriteLine($"\n--- {recipe.Name} ---\n");
                Console.WriteLine($"Portion: {recipe.Portion}\n");
                Console.WriteLine($"Calories: {recipe.Calories}\n");
                Console.WriteLine($"Cooking Time: {recipe.CookingTime} \n");
                Console.WriteLine("Ingredients:\n");
                foreach (var ingredient in recipe.Ingredients)
                {
                    Console.WriteLine($"- {ingredient}");
                }
                Console.WriteLine($"\nPreparation:\n {recipe.Preparation} \n");
                Console.WriteLine($"Instructions: {recipe.CookingInstuctions} \n");

                Console.WriteLine("\nPress any key to return to main menu...");
                Console.ReadKey(true); // wartet auf beliebige Taste
            }
            else
            {
                Console.WriteLine("\n\n\nInvalid selection.\nreturning to main menu...");
                Thread.Sleep(2000);
            }
        }
    }
}
