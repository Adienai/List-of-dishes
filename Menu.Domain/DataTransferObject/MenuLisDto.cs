using Menu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Domain.DataTransferObjects
{
    internal class MenuLisDto
    {
        public int Id { get; set; }
        public string Difinition { get; set; }
        public int Total { get; set; }
        public List<MenuDishes> MenuDishes { get; set; }
    }
}
