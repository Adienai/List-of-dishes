using Menu.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Menu.DLL.Data
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options){ }
        public DbSet<Category> Category {  get; set; }
        public DbSet<Dishes> Dishes { get; set; }
        public DbSet<Domain.Entities.MenuList> MenuList { get; set; }
        public DbSet<MenuDishes> MenuDishes { get; set; }
        public DbSet<Rating> Rating { get; set; } 
    }
}
