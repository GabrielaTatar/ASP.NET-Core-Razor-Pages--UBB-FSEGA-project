using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tatar_Gabriela_Lab02.Data;
using Tatar_Gabriela_Lab02.Models;

namespace Tatar_Gabriela_Lab02.Pages.Books
{
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Tatar_Gabriela_Lab02.Data.Tatar_Gabriela_Lab02Context _context;

        public CreateModel(Tatar_Gabriela_Lab02.Data.Tatar_Gabriela_Lab02Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID", "FirstName");

            var book = new Book();
            book.BookCategories = new List<BookCategory>();
            PopulateAssignedCategoryData(_context, Book);

            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newBook = new Book();
            if (selectedCategories != null)
            {
                newBook.BookCategories = new List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBook.BookCategories.Add(catToAdd);
                }
            }

            //if (await TryUpdateModelAsync<Book>(
            //    newBook,
            //    "Book",
            //     i => i.Title, i => i.Author,
            //     i => i.Price, i => i.PublishingDate, i => i.PublisherID))
            //{
                _context.Book.Add(newBook);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            //}
            PopulateAssignedCategoryData(_context, newBook);
            return Page();
        }
    }
}
