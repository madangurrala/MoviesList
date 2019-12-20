using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieList.Models;

namespace MovieList
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext db;

        public EditModel(AppDbContext appDb)
        {
            db = appDb;
        }

        [BindProperty]
        public Movie Movie { get; set; }
        public async Task OnGet(int id)
        {
            Movie = await db.Movie.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var MovieFromDb = await db.Movie.FindAsync(Movie.Id);
                MovieFromDb.Name = Movie.Name;
                MovieFromDb.Director = Movie.Director;
                MovieFromDb.Production = Movie.Production;

               await db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}