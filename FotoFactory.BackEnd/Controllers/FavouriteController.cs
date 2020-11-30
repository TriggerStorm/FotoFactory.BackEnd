using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FotoFactory.Core.AppService;
using FotoFactory.CoreEntities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FotoFactory.BackEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class FavouriteController : Controller
    {
        private readonly IFavouriteService _favouriteService;

        public FavouriteController(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }


        // GET: api/favourite/
        [HttpGet]
        public ActionResult<List<Poster>> Get()
        {
            List<Poster> favouritedPosters = (List<Poster>)_favouriteService.FindLoggedInUsersFavouritedPosters();
            return StatusCode(200, favouritedPosters);
        }


        // POST api/favourite/(id)
        //[Authorize(Roles = "Administrator")]
        [HttpPost("{id}")]
        public ActionResult<Favourite> Post(int id)
        {
            try
            {
                return Ok(_favouriteService.NewLoggedInUsersFavouritedPoster(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // DELETE api/favourite/{id}
        //[Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<Favourite> Delete(int id)
        {
            try
            {
                return Ok(_favouriteService.RemoveALoggedInUsersFavouritedPoster(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
