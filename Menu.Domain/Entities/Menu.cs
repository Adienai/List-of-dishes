namespace Menu.Domain.Entities
{
    public class Menu
    {
       public int Id { get; set; }
       public string Difinition { get; set; }
       public int Total { get; set; }
       public List <MenuDishes> MenuDishes { get; set; }

    }
}
