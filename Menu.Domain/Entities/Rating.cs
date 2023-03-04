namespace Menu.Domain.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public List <Dishes> Dishes { get; set; }
        public string Feedback {  get; set; }
        public int OfStars { get; set; }
    }
}
