using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieList.Models;

namespace MovieList.Controllers
{
    [Route("api/Movie")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly AppDbContext db;

        public MovieController(AppDbContext appDb)
        {
            db = appDb;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await db.Movie.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var RetrivedMovie = await db.Movie.FirstOrDefaultAsync(u => u.Id == id);
            if(RetrivedMovie == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            else
            {
                db.Movie.Remove(RetrivedMovie);
                await db.SaveChangesAsync();

                return Json(new { success = true, message = "Deleted successfully" });
            }


        }
    }
}