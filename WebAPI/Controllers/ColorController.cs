using Business.Abstract;
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
    public class ColorController : ControllerBase
    {
        IColorService _colorservice;

        public ColorController(IColorService colorservice)
        {
            _colorservice = colorservice;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _colorservice.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getcolordetail")]
        public IActionResult GetColorDetail(int id)
        {
            var result = _colorservice.GetAllById(id);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("addcolor")]
        public IActionResult AddBrand(Color color)
        {
            var result = _colorservice.Add(color);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("updatecolor")]
        public IActionResult UpdateBrand(Color color)
        {
            var result = _colorservice.Update(color);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("deletecolor")]
        public IActionResult DeleteBrand(Color color)
        {
            var result = _colorservice.Delete(color);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
