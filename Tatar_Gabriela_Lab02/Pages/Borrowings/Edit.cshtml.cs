﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tatar_Gabriela_Lab02.Data;
using Tatar_Gabriela_Lab02.Models;

namespace Tatar_Gabriela_Lab02.Pages.Borrowings
{
    public class EditModel : PageModel
    {
        private readonly Tatar_Gabriela_Lab02.Data.Tatar_Gabriela_Lab02Context _context;

        public EditModel(Tatar_Gabriela_Lab02.Data.Tatar_Gabriela_Lab02Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Borrowing == null)
            {
                return NotFound();
            }

            var borrowing =  await _context.Borrowing.Include(b => b.Member).Include(b => b.Book).FirstOrDefaultAsync(m => m.ID == id);
           
   

            if (borrowing == null)
            {
                return NotFound();
            }
            Borrowing = borrowing;
           ViewData["BookID"] = new SelectList(_context.Book, "ID", "Title");
           ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Borrowing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowingExists(Borrowing.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BorrowingExists(int id)
        {
          return _context.Borrowing.Any(e => e.ID == id);
        }
    }
}
