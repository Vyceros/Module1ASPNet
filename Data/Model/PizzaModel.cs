namespace ITStepRazorApp.Data.Model
{
    public class PizzaModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; } = 10;
        public bool IsLarge { get; set; }
        public bool IsSmall { get; set; }
        public bool Ham {  get; set; }
        public bool Pepperoni {  get; set; }
        public bool Pineapple {  get; set; }
        public bool Mushroom { get; set; }
        public bool Chicken {  get; set; }
        public bool ExtraSauce {  get; set; }
        public bool ExtraCheese {  get; set; }
        
    }
}
