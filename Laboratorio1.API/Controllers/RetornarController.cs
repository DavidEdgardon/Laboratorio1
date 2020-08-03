using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laboratorio1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetornarController : ControllerBase
    {

        private readonly ILibroService _libroservice;
        public RetornarController(ILibroService libroservice)
        {
            _libroservice = libroservice;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult ReturnLibro(int id)
        {
            var libro = _libroservice.GiveBack(id);
            if (libro.ResponseCode != Core.ResponseCode.Success)
            {
                return BadRequest(libro.Error);
            }
            return Ok(libro.Result);
        }
    }
}
