
using System.Data;

namespace My_cookbook.Services
{
    internal class MainMenu
    {
        private bool _running = true;
        private RecipeService _recipeService;

        public MainMenu()
        {
            _recipeService = new RecipeService();
        }

        internal void RenderMenu()
        {
            bool invalidInput = false;

            while (_running)
            {
                Console.Clear();
                Console.WriteLine("\n--- My cookbook ---");
                Console.WriteLine("[1] Add recipe");
                Console.WriteLine("[2] Show recipe");
                Console.WriteLine("[3] Edit recipe");
                Console.WriteLine("[4] Delete recipe");
                Console.WriteLine("[0] Quit");
                Console.Write("Your selection: ");

                if (invalidInput) 
                {
                    Console.Write("invalid input, only numbers 0-4 are allowed.\nYour selection: ");
                }

                switch (Console.ReadLine())
                {
                    case "1":
                        _recipeService.Add();
                        break;
                    case "2":
                        _recipeService.Show();
                        break;
                    case "3":
                        _recipeService.Update();
                        break;
                    case "4":
                        _recipeService.Delete();
                        break;
                    case "0":
                        _running = false;
                        break;
                    default:
                        invalidInput = true;
                        break;
                }
            }
            Console.WriteLine("\nExiting application...");
            Thread.Sleep(2000);
        }
    }
}
