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

            Console.Write("Recipe title: ");
            recipeModel.Name = Console.ReadLine();

            Console.Write("Portions: ");
            recipeModel.Portion = int.Parse(Console.ReadLine() ?? "0"); // DAU-Sicher machen / Absturzsicher

            Console.Write("Calories: ");
            recipeModel.Calories = int.Parse(Console.ReadLine() ?? "0"); // DAU-Sicher machen / Absturzsicher

            Console.Write("Cooking Time: ");
            recipeModel.CookingTime = int.Parse(Console.ReadLine() ?? "0"); // DAU-Sicher machen / Absturzsicher

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

        }
        public void Update() 
        {
        
        }
        public void Delete()
        {

        }
    }
}
