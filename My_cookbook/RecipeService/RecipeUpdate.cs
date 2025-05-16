using My_cookbook.Storage;
using My_cookbook.Utilities;

namespace My_cookbook.Services
{
    internal partial class RecipeService : IRecipeService
    {
        public void Update()
        {
            Console.Clear();
            Console.WriteLine($"{Headline.HeaderUpdate}\n");
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

            Console.Write("\nSelect recipe for Update: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < _recipes.Count)
            {
                Console.Clear();
                var recipe = _recipes[index];
                Console.WriteLine("New name (leave empty for no changes):");
                var newName = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(newName) && recipe.Name != newName)  // name ist nicht leer oder null & nicht gleich vorheriger name = neuer name
                {
                    recipe.Name = newName;
                }

                Console.WriteLine("New Portions (leave empty for no changes):");
                if (int.TryParse(Console.ReadLine(), out int portion))
                {
                    recipe.Portion = portion;
                }

                Console.WriteLine("New Calories (leave empty for no changes):");
                if (int.TryParse(Console.ReadLine(), out int calories))
                {
                    recipe.Calories = calories;
                }

                Console.WriteLine("New Cooking Time (leave empty for no changes):");
                if (int.TryParse(Console.ReadLine(), out int cookingTime))
                {
                    recipe.CookingTime = cookingTime;
                }

                Console.WriteLine("New Ingredients (one ingredient per line, leave line empty to quit):");
                while (true)
                {
                    var ingredient = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(ingredient)) break;
                    recipe.Ingredients.Add(ingredient);
                }

                Console.WriteLine("New Preparation (leave empty for no changes):");
                while (true)
                {
                    var preparation = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(preparation)) break;
                    recipe.Preparation += $"\n{preparation}";
                }

                Console.WriteLine("New Instructions (leave empty for no changes):");
                while (true)
                {
                    var instruction = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(instruction)) break;
                    recipe.CookingInstuctions += $"\n{instruction}";
                }

                Console.WriteLine("\nUpdating...\n");
                Thread.Sleep(2000);
                StorageService.Save(_recipes);
                Console.WriteLine("\nUpdated recipe!");
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
