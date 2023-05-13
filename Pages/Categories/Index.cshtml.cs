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
    public class Index : PageModel
    {
        private readonly AppDbContext db;
        private readonly ILogger<Index> _logger;
        public IEnumerable<Category> Categories{get;set;}
        

        public Index(AppDbContext db, ILogger<Index> logger)
        {
            this.db = db;
            _logger = logger;            
        }

        public void OnGet()
        {
            Categories = db.Categories;
        }
    }
}