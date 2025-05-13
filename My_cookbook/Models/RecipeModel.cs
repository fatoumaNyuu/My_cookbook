namespace My_cookbook.Models
{
    internal class RecipeModel
    {
        public Guid Id { get; } = new Guid();
        public string Name { get; set; }
        public int Portion { get; set; }
        public float Calories { get; set; }
        public int CookingTime{ get; set; }
        public List<string> Ingredients { get; set; }
        public string Preparation { get; set; }
        public string CookingInstuctions {  get; set; }
        
    }
}
