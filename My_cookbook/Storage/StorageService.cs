using My_cookbook.Models;
using System.Text.Json;

namespace My_cookbook.Storage
{
    internal static class StorageService
    {
        private static string _storagePath = "recipe_storage.json";

        static StorageService()
        {
            if (!File.Exists(_storagePath))
            {
                File.Create(_storagePath);  // falls es keine Datei gibt, wird im Storage Path eine neue angelegt
            }
        }

        public static List<RecipeModel> Load()
        {
            var data = File.ReadAllText(_storagePath);
            return JsonSerializer.Deserialize<List<RecipeModel>>(data) ?? new List<RecipeModel>(); // Serialisierung, falls keine Liste vorhanden ist, wird neuee angelegt!
        }

        public static void Save(List<RecipeModel> recipeList)
        {
            var json = JsonSerializer.Serialize(recipeList, new JsonSerializerOptions { WriteIndented = true });  // Wandelt die Daten in Text um
            File.WriteAllText(_storagePath, json);
        }
    }
}
