using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fellyka.Data;
using fellyka.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace fellyka.Pages.Categories
{
    public class Create : PageModel
    {
        private readonly AppDbContext db;
        private readonly ILogger<Create> _logger;

        [BindProperty]
        public Category Category { get; set; }

        public Create(AppDbContext db,ILogger<Create> logger)
        {
            this.db = db;
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            await db.Categories.AddAsync(Category);
            await db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}