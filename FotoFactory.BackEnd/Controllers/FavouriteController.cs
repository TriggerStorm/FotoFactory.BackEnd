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


        // POST api/favourite
        //[Authorize(Roles = "Administrator")]
        [HttpPost("{id}")]
        // NOT essential. Only needed if we change this methods name from "Post", and then it tells the system this is the POST method. Needed if sending parameters
        public ActionResult<Favourite> Post(int id)
        {
            /*   string error = CheckPetInput(petToPost);
               if (!(error == ""))
               {
                   return StatusCode(500, error);
               }
               Pet petToCreate = _petService.CreatePet(petToPost);
               return StatusCode(201, petToCreate); 
               */
            try
            {
                return Ok(_favouriteService.NewLoggedInUsersFavouritedPoster(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
