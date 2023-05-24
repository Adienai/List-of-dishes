using Menu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Domain.DataTransferObjects
{
    internal class MenuDishesDto
    {
        public int Id { get; set; }
        public int DishesId { get; set; }
        public int MenuId { get; set; }
        public MenuList Menu { get; set; }
        public Dishes Dishes { get; set; }
    }
}
