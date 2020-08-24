using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModel;
using System.Web.Http;
using System.Web.Security;

namespace WebApplication1.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            if (User.IsInRole("CanManageMovies"))
                return View("List");
            //var movies = _context.Movies.Include(m => m.Genre).ToList();
            
            return View("ReadOnlyList");
        }
        [System.Web.Http.Authorize(Roles = RoleName.CanManageMovies)]
        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("NewMovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("NewMovieForm", viewModel);
        }

        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }
            _context.SaveChanges();
            return RedirectToAction("index", "Movies");

        }


        public ActionResult Details(int? id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }


        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "shrek" };

            var customers = new List<Customer>
            {
                new Customer  { Name ="Nourhan" },
                new Customer  { Name ="Mohssen" },
                new Customer  { Name ="Louli" }

            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie ,
                
                Customers = customers 


            };
            return View(viewModel);
        }
        


        //public ActionResult Edit(int movieId)
        //{
        //    return Content("id=" + movieId);
        //}

        //public ActionResult Index(int? pageIndex , string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (string.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";
        //    return Content(string.Format("pageIndex{0}&sortBy{1}", pageIndex, sortBy));
        //}
        //[Route("movies/released/{year}/{month:regex(\\d{4}):range(1 , 12)}")]
        //public ActionResult ByReleaseYear(int? year , int? month)
        //{
        //    return Content(year + "/" + month);
        //}
    }
}