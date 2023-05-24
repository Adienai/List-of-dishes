using Menu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Domain.DataTransferObjects
{
    internal class RatingDto
    {
        public int Id { get; set; }
        public List<Dishes> Dishes { get; set; }
        public string Feedback { get; set; }
        public int OfStars { get; set; }
    }
}
