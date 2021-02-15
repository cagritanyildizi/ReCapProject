using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
    public class ReCapsController : ControllerBase
    {
        IReCapService _recapService;

        public ReCapsController(IReCapService recapService)
        {
            _recapService = recapService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _recapService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _recapService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(ReCap rental)
        {
            var result = _recapService.Add(rental);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(ReCap rental)
        {
            var result = _recapService.Update(rental);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(ReCap rental)
        {
            var result = _recapService.Delete(rental);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}