using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio1.Core.Models
{
    public class LibroModel
    {
        public long Id { get; set; }

        public String Nombre { get; set; }

        public int Cantidad { get; set; }

        public string Fecha { get; set; }

        public string NombreAutor { get; set; }
        
        public long AutorId { get; set; }
    }
}
