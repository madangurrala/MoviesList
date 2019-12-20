using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieList.Models;

namespace MovieList
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext db;

        public CreateModel(AppDbContext Appdb)
        {
            db = Appdb;
        }
        [BindProperty]
        public Movie Movie { get; set; }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await db.Movie.AddAsync(Movie);
                await db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }

        }
        public void OnGet()
        {

        }
    }
}