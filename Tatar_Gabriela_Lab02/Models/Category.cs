namespace Tatar_Gabriela_Lab02.Models
{
    public class Category
    {
        public int ID { get; set; }

        public string CategoryName { get; set; }

        public ICollection<BookCategory> BookCategories { get; set;}
    }
}
