using My_cookbook.Services;

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
