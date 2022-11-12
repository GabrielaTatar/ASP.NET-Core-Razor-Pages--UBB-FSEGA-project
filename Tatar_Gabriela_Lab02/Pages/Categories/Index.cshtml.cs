﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tatar_Gabriela_Lab02.Data;
using Tatar_Gabriela_Lab02.Models;

namespace Tatar_Gabriela_Lab02.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Tatar_Gabriela_Lab02.Data.Tatar_Gabriela_Lab02Context _context;

        public IndexModel(Tatar_Gabriela_Lab02.Data.Tatar_Gabriela_Lab02Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Category != null)
            {
                Category = await _context.Category.ToListAsync();
                
            }
        }
    }
}