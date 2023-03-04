namespace Menu.Domain.Entities
{
    public class MenuDishes
    {
        public int Id { get; set; }
        public int DishesId { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public Dishes Dishes { get; set; }
    }
}
