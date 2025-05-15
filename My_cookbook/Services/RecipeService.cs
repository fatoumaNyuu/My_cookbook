using My_cookbook.Models;
using My_cookbook.Storage;

namespace My_cookbook.Services
{
    internal class RecipeService
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
            Console.Write("Recipe title: ");
            recipeModel.Name = Console.ReadLine();

            Console.Write("Portions: ");
            int.TryParse(Console.ReadLine(), out int portion); // keine Eingabe und Buchstaben = 0
            recipeModel.Portion = portion;

            Console.Write("Calories: ");
            int.TryParse(Console.ReadLine(), out int calories); // keine Eingabe und Buchstaben = 0
            recipeModel.Calories = calories;

            Console.Write("Cooking Time: ");
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
            recipeModel.Preparation = Console.ReadLine();

            Console.WriteLine("Instructions: ");
            recipeModel.CookingInstuctions = Console.ReadLine();

            _recipes.Add(recipeModel);
            StorageService.Save(_recipes);
            Console.WriteLine("Saved recipe!");
        }
        public void Show()
        {
            Console.Clear();
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
                Console.WriteLine($"Portion: {recipe.Portion}");
                Console.WriteLine($"Calories: {recipe.Calories}");
                Console.WriteLine($"Cooking Time: {recipe.CookingTime}");
                Console.WriteLine("Ingredients:");
                foreach (var ingredient in recipe.Ingredients)
                {
                    Console.WriteLine($"- {ingredient}");
                }
                Console.WriteLine($"Preparation: {recipe.Preparation}");
                Console.WriteLine($"Instructions: {recipe.CookingInstuctions}");

                Console.WriteLine("\nPress any key to return to main menu...");
                Console.ReadKey(true); // wartet auf beliebige Taste
            }
            else
            {
                Console.WriteLine("\n\n\nInvalid selection.\nreturning to main menu...");
                Thread.Sleep(2000);
            }
        }
        public void Update() 
        {
        
        }
        public void Delete()
        {

        }
    }
}
