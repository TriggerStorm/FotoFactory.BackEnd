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
    [Route("api/[controller]")]
    [ApiController]

    public class SummaryController : ControllerBase
    {
        private readonly ISummaryService _summaryService;

        public SummaryController(ISummaryService summaryService)
        {
            _summaryService = summaryService;
        }

        // GET api/summary
        [HttpGet]
        public ActionResult<List<Summary>> Get([FromBody] List<WorkSpace> allWorkSpaces)
        {
            List<Summary> allSummaries = _summaryService.GetSummaryList(allWorkSpaces);
            return Ok(allSummaries);
        }
    }
}