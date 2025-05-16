using My_cookbook.Utilities;

namespace My_cookbook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mainMenuService = new MainMenu();
            mainMenuService.RenderMenu();
        }
    }
}
