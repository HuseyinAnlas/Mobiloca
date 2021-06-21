using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        IIncidentService _incidentService;

        public IncidentsController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            
            var result = _incidentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _incidentService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Incident incident)
        {
            var result = _incidentService.Add(incident);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Incident incident)
        {
            var result = _incidentService.Update(incident);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Incident incident)
        {
            var result = _incidentService.Delete(incident);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
