using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FotoFactory.Core.AppService;
using FotoFactory.Core.AppService.Service;
using FotoFactory.Core.AppService.Validators;
using FotoFactory.CoreEntities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FotoFactory.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkSpacePosterController : ControllerBase
    {
        private readonly IWorkSpacePosterService _workSpacePosterService;

        public WorkSpacePosterController(IWorkSpacePosterService workSpacePosterService )
        {
            _workSpacePosterService = workSpacePosterService;

        }
        // GET: api/<WorkSpacePosterController>
        [HttpGet]
        public ActionResult<IEnumerable> Get()
        {
            try
            {
                return Ok(_workSpacePosterService.ReadAllWorkSpacePoster());
            }
            catch (Exception e)

            {
                return BadRequest($"cannot read all workSpacePosters");
            }
        }

        // GET api/<WorkSpacePosterController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            {
                try
                {
                    return Ok(_workSpacePosterService.ReadWorkSpacePosterById(id));
                }
                catch (Exception e)
                {
                    return StatusCode(404, e.Message);
                }
            }
        }

        // POST api/<WorkSpacePosterController>/create
        [HttpPost]
        public ActionResult Post([FromBody] JObject data) // Size id , Poster id , frame id - needs to arrive from body.
        //Then we porvide with x and y pos .
        {
            try
            {
                if ( data["XPos"] == null || Int32.Parse(data["XPos"].ToString()) <= -1)
                    return StatusCode(500, $" position of x cannot be empty or off the grid");
                if (data["YPos"] == null || Int32.Parse(data["YPos"].ToString()) <= -1)
                    return StatusCode(500, $" position of y cannot be empty or off the grid");
                if (data["sizeId"] == null || Int32.Parse(data["sizeId"].ToString()) <= 0)
                    return StatusCode(404, $" sizeId not found");
                if (data["frameId"] == null || Int32.Parse(data["frameId"].ToString()) <= 0)
                    return StatusCode(404, $"frameId not found");
                if (data["posterId"] == null || Int32.Parse(data["posterId"].ToString()) <= 0)
                    return StatusCode(404, $"posterId not found");
                return Ok(_workSpacePosterService.CreateWorkSpacePoster(Int32.Parse(data["XPos"].ToString()),
                    Int32.Parse(data["YPos"].ToString()), Int32.Parse(data["posterId"].ToString()),
                    Int32.Parse(data["frameId"].ToString()), Int32.Parse(data["sizeId"].ToString())));
            }
            catch (ArgumentOutOfRangeException e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<WorkSpacePosterController>/5/update
        [HttpPut("{id}")]
        public ActionResult Put( int id, [FromBody] JObject data)
        {
            try
            {
                if (data["XPos"] == null || Int32.Parse(data["XPos"].ToString()) <= -1)
                    return StatusCode(500, $" position of x cannot be empty or off the grid");
                if (data["YPos"] == null || Int32.Parse(data["YPos"].ToString()) <= -1)
                    return StatusCode(500, $" position of y cannot be empty or off the grid");
                return Ok(_workSpacePosterService.UpdateWorkSpacePoster(id , Int32.Parse(data["XPos"].ToString()), Int32.Parse(data["YPos"].ToString())));
            }
            catch (ArgumentNullException e)
            {
                return StatusCode(500, $"A valid id is needed to update");
            }
        }

        // DELETE api/<WorkSpacePosterController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                return Ok(_workSpacePosterService.DeleteWorkSpacePoster(id));
            }
            catch (NullReferenceException e)
            {
                return BadRequest((e.Message));
            }
        }
    }
}
