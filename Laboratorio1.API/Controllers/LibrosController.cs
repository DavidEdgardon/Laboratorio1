using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Laboratorio1.Core.Models;
using Laboratorio1.Data.Entities;
using Laboratorio1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly ILibroService _libroservice;
        public LibrosController(ILibroService libroservice)
        {
            _libroservice = libroservice;
         }

        [HttpGet]
        public IActionResult Get()
        {
            var libro = _libroservice.GetAll();
            if(libro.ResponseCode != Core.ResponseCode.Success)
            {
                return BadRequest(libro.Error);
            }
            return Ok(libro.Result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] LibroModel libro)
        {
            var libroresult = _libroservice.Add(libro);
            if (libroresult.ResponseCode != Core.ResponseCode.Success)
            {
                return BadRequest(libroresult.Error);
            }
            return Ok(libroresult.Result);
        }
        
    }
}
