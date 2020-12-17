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

    public class SummaryController : ControllerBase
    {
        private readonly ISummaryService _summaryService;
        private readonly IWorkSpaceService _workspaceService;
        private readonly IUserService _userService;

        public SummaryController(ISummaryService summaryService, 
            IWorkSpaceService workSpaceService,
            IUserService userService)
        {
            _summaryService = summaryService;
            _workspaceService = workSpaceService;
            _userService = userService;
        }
        
        [HttpGet]
        public ActionResult<List<Summary>> Get([FromQuery] int userId)
        {
            var user = _userService.FindUserById(userId);
            
            List<Summary> allSummaries = _summaryService.GetSummaryList(user.WorkSpaces);
            return Ok(allSummaries);
        }

        // GET api/summary
        [HttpPost]
        public ActionResult<List<Summary>> Post([FromBody] int[] workspaceIds)
        {
            List<WorkSpace> worksapces = new List<WorkSpace>();
            foreach (var id in workspaceIds)
            {
                worksapces.Add(_workspaceService.ReadWorkSpaceByID(id));
            }
            List<Summary> allSummaries = _summaryService.GetSummaryList(worksapces);
            return Ok(allSummaries);
        }
    }
}