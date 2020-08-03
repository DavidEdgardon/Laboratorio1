using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laboratorio1.Core.Models;
using Laboratorio1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly IAutorService _autorservice;
        public AutoresController(IAutorService autorservice)
        {
            _autorservice = autorservice;
        }
       
        [HttpGet]
        public IActionResult Get()
        {
            var autor = _autorservice.GetAll();
            if (autor.ResponseCode != Core.ResponseCode.Success)
            {
                return BadRequest(autor.Error);
            }
            return Ok(autor.Result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AutorModel autor)
        {
            var autorresult = _autorservice.Add(autor);
            if (autorresult.ResponseCode != Core.ResponseCode.Success)
            {
                return BadRequest(autorresult.Error);
            }
            return Ok(autorresult.Result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetLibrosPorAutor(long id)
        {
            var autor = _autorservice.GetLibrosPorAutor(id);
            if (autor.ResponseCode != Core.ResponseCode.Success)
            {
                return BadRequest(autor.Error);
            }
            return Ok(autor.Result);
        }
    }
}
