using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tatar_Gabriela_Lab02.Data;
using Tatar_Gabriela_Lab02.Models;

namespace Tatar_Gabriela_Lab02.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly Tatar_Gabriela_Lab02.Data.Tatar_Gabriela_Lab02Context _context;

        public CreateModel(Tatar_Gabriela_Lab02.Data.Tatar_Gabriela_Lab02Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
    
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Category.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
