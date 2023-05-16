﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using fellyka.Data;
using fellyka.Model;

namespace fellyka.Pages.CategoryTemp
{
    public class IndexModel : PageModel
    {
        private readonly fellyka.Data.AppDbContext _context;

        public IndexModel(fellyka.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Categories != null)
            {
                Category = await _context.Categories.ToListAsync();
            }
        }
    }
}
