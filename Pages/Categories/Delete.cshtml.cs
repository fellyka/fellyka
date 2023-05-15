
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
    public class Delete : PageModel
    {
        private readonly AppDbContext db;
        private readonly ILogger<Create> _logger;

        [BindProperty]
        public Category Category { get; set; }

        public Delete(AppDbContext db,ILogger<Create> logger)
        {
            this.db = db;
            _logger = logger;
        }

        public void OnGet(int id )
        {
            Category = db.Categories.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
                var foundCategory = db.Categories.Find(Category.Id);
                if(foundCategory != null)
                 {
                     db.Categories.Remove(foundCategory);
                     await db.SaveChangesAsync();
                       return RedirectToPage("Index");
                 }   
            return Page();
        }
    }
}