namespace Menu.Domain.Entities
{
    public class Category
    {
        public readonly object Menu;

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Dishes> Dishes { get; set; }
    } 
}
