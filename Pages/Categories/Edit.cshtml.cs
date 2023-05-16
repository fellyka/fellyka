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
    public class Edit : PageModel
    {
        private readonly AppDbContext db;
        private readonly ILogger<Create> _logger;

        [BindProperty]
        public Category Category { get; set; }

        public Edit(AppDbContext db,ILogger<Create> logger)
        {
            this.db = db;
            _logger = logger;
        }

        public void OnGet(int id)
        {
             //Category = db.Categories.FirstOrDefault(x => x.Id == id);
            //Category = db.SingleOrDefault(x => x.Id == id);
           //Category = db.Categories.Where(x => x.Id == id).FirstOrDefault;
            Category = db.Categories.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The DispalyPrder cannot exactly match the Name.");
            }
            if(ModelState.IsValid)
            {
            db.Categories.Update(Category);
            await db.SaveChangesAsync();
            TempData["success"] = "Category updated successfully";
            return RedirectToPage("Index");
            }
            return Page();
        }
    }
}