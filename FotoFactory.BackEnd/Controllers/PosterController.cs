using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FotoFactory.Core.AppService.Service;
using FotoFactory.CoreEntities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FotoFactory.BackEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PosterController : Controller
    {
        private readonly IPosterService _posterService;

        public PosterController(IPosterService posterService)
        {
            _posterService = posterService;
        }



        // GET api/posters/1
        //[Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Poster>> Get(int id)
        {
            if (id < 1)
            {
                return BadRequest("Request Failed - Id must be greater than zero");
            }
            IEnumerable<Poster> collectionPosters = _posterService.FindPostersByCollectionId(id);
            if (collectionPosters == null)
            {
                return StatusCode(404, "No pet with id " + id + " was found");
            }
            return StatusCode(200, collectionPosters);
        }

    }
}
