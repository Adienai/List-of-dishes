namespace Menu.Domain.Entities
{
    public class Dishes
    {
        public int Id { get; set; }
        public string Roast {  get; set; }
        public string Ragout { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public int RatingId { get; set; }
        public Category Category { get; set; }
        public Rating Rating { get; set; }
        public List<MenuDishes> MenuDishes { get; set; }
    }
}
