using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieList.Models;

namespace MovieList
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext db;

        public IndexModel(AppDbContext Appdb)
        {
            db = Appdb;
        }
        public IEnumerable<Movie> Movies { get; set; }
        public async Task OnGet()
        {
            Movies = await db.Movie.ToListAsync();

        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var movieRetrived = await db.Movie.FindAsync(id);
            if(movieRetrived == null)
            {
                return NotFound();
            }
            else
            {
                db.Movie.Remove(movieRetrived);
                await db.SaveChangesAsync();

                return RedirectToPage("Index");
            }

        }

    }
}