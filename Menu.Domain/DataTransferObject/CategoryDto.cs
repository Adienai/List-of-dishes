using Menu.Domain.Entities;

namespace Menu.Domain.DataTransferObjects
{
    internal class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Dishes> Dishes { get; set; }
    }
}
