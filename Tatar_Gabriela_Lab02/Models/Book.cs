using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Xml.Linq;


namespace Tatar_Gabriela_Lab02.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Display(Name = "Book Title")]

        [Required(ErrorMessage = "Completati obligatoriu!")]
        [StringLength(150, MinimumLength = 3)]
        public string Title { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500)]

        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }

        public int? PublisherID { get; set; }
        public Publisher? Publisher { get; set; } //navigation property


        public int? AuthorID { get; set; }
        public Author? Author { get; set; }

        public ICollection<BookCategory>? BookCategories { get; set; }
    }
}
