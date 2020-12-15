using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FotoFactory.Core.AppService;
using FotoFactory.CoreEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FotoFactory.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkSpaceController : ControllerBase
    {
        private readonly IWorkSpaceService _workSpaceService;
        //private readonly IWorkSpaceValidator _workSpaceValidator;

        public WorkSpaceController(IWorkSpaceService workSpaceService)
        {
            _workSpaceService = workSpaceService ?? throw new NullReferenceException("Service cannot be null"); ;
            //_workSpaceValidator = workSpaceValidator ?? throw new NullReferenceException("Validator cannot be null"); ;
        }
        // GET: api/<WorkSpaceController>
        // https://localhost:44387/api/WorkSpace?userID=1&workspaceID=1
        [HttpGet]
        public ActionResult Get([FromQuery] int userID, [FromQuery] int workspaceID)
        {
            try
            {

                //int userId = loggedUser.Id;
                if (userID > 0)
                {
                    return Ok(_workSpaceService.ReadAllWorkSpace(userID));
                } 
                
                if (workspaceID > 0)
                {
                    return Ok(_workSpaceService.ReadWorkSpaceByID(workspaceID));
                }
                return BadRequest();
                
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        //each space will have a user. a guest will not have a workspace. so read all works with userid.
        // GET api/<WorkSpaceController>/5
        //[HttpGet("{id}")]
        //public ActionResult <WorkSpace> Get(int id)
        //{
        //    try
        //    {
        //        return Ok(_workSpaceService.ReadAllWorkSpace(id));
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(404, e.Message);
        //    }
        //}

        // POST api/<WorkSpaceController>
        [HttpPost]
        public ActionResult Post([FromBody] JObject data) //JObject is generalising the date input (Can be any input)
        // data["VARIABLE NAME"].ToString() - To get specific variable from JObject
        {
            try
            {
                if ((String.IsNullOrEmpty(data["name"].ToString())) || (String.IsNullOrEmpty(data["backGroundColour"].ToString())))
                {
                    return StatusCode(500, $" name and background colour need a valid input");
                }

                if (data["user"] == null)
                {
                    return StatusCode(500, $" User needed");
                }

                return Ok(_workSpaceService.CreateWorkSpace(data["name"].ToString(), data["backGroundColour"].ToString(), (int)data["user"]));
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/pets/5 - UPDATE
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] JObject data)// id will always match workspace id
        {
            try
            {
                WorkSpace workSpace = new WorkSpace()
                {
                    Name = data["name"].ToString(),
                    BackGroundColour = data["background"].ToString()
                };

                // _workSpaceService.UpdateWorkSpace(id ,workSpace);
                return Ok(StatusCode(200, _workSpaceService.UpdateWorkSpace(id, workSpace)));
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<WorkSpaceController>/5
        //[Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                //_workSpaceService.DeleteWorkSpace(id );
                return Ok(_workSpaceService.DeleteWorkSpace(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
