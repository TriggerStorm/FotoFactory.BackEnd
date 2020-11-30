using System;
using System.Collections.Generic;
using FotoFactory.Core.AppService;
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
        public ActionResult<Poster> Get(int id)
        {
            if (id < 1)
            {
                return BadRequest("Request Failed - Id must be greater than zero");
            }
                Poster poster = _posterService.FindPosterById(id);
            if (poster == null)
            {
                return StatusCode(404, "No poster with id " + id + " was found");
            }
            return StatusCode(200, poster);
        }

    }
}
