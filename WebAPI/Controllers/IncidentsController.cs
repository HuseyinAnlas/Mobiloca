using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
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
            int culture = GetHeaderCulture();
            StateManager _stateService = new StateManager(culture);
            var result = _stateService.GetAll();
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
        public IActionResult Add(List<InputIncidentsDto> incident)
        {
            
            int culture = GetHeaderCulture();
            StateManager _stateService = new StateManager(culture); 
            var result = _stateService.AddRange(incident);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("getbyfilter")]
        public IActionResult GetByFilter(FilterIncidentDto incident)
        {

            int culture = GetHeaderCulture();
            StateManager _stateService = new StateManager(culture);
            var result = _stateService.GetByFilter(incident);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        private int GetHeaderCulture()
        {
            string headerCulture = HttpContext.Request.Headers["Culture"];
            int culture = 0;
            if (!string.IsNullOrEmpty(headerCulture))
                culture = Convert.ToInt32(headerCulture);
            return culture;
        }

    }
}
