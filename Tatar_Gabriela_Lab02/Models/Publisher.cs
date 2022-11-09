namespace Tatar_Gabriela_Lab02.Models
{
    public class Publisher
    {
        public int ID { get; set; }

        public string PublisherName { get; set; }

        public ICollection<Book>? Books { get; set; } //navigation property
    }
}
