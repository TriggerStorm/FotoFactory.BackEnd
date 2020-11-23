﻿using System;
using System.Collections.Generic;
using FotoFactory.Core.AppService.Service;
using FotoFactory.CoreEntities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FotoFactory.BackEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : Controller
    {
        private readonly ICollectionService _collectionService;

        public CollectionController(ICollectionService collectionService)
        {
            _collectionService = collectionService;
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
            IEnumerable<Poster> collectionPosters = _collectionService.FindPostersByCollectionId(id);
            if (collectionPosters == null)  //|| collectionPosters == [])
            {
                return StatusCode(404, "No posters in collection with id " + id + " were found");
            }
            return StatusCode(200, collectionPosters);
        }
    }
}