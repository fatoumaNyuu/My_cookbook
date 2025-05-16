using My_cookbook.Utilities;
using My_cookbook.Storage;

namespace My_cookbook.Services
{
    internal partial class RecipeService : IRecipeService
    {
        public void Delete()
        {
            Console.Clear();
            Console.WriteLine($"{Headline.HeaderDelete}\n");
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

            Console.Write("\nSelect recipe for deletion: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < _recipes.Count)
            {
                Console.Clear();
                var recipe = _recipes[index];

                Console.WriteLine($"\n--- {recipe.Name} ---\n");
                Console.WriteLine($"are you sure to delete \"{recipe.Name}\"?\t(y/n):\n");
                if (Console.ReadKey(true).Key == ConsoleKey.Y) // wenn y gedrückt wird
                {
                    Console.WriteLine("\nDeleting...\n");
                    Thread.Sleep(2000);
                    _recipes.RemoveAt(index); // löscht das Rezept
                    StorageService.Save(_recipes); // speichert die Rezepte ab
                    Console.WriteLine($"\n\"{recipe.Name}\" deleted!"); // gibt mir aus, dass es gelöscht wurde
                }
                else
                {
                    Console.WriteLine("\nDeletion cancelled.\n");
                }

                Console.WriteLine("\nPress any key to return to main menu...");
                Console.ReadKey(true);
            }
            else
            {
                Console.WriteLine("\n\n\nInvalid selection.\nreturning to main menu...");
                Thread.Sleep(2000);
            }
        }
    }
}
