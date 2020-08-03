using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading;

namespace Laboratorio1.Data.Entities
{
    public class Autor
    {
        public Autor()
        {
            this.Libros = new List<Libro>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Nombre { get; set; }

        public int Edad { get; set; }

        public ICollection<Libro> Libros { get; set; }
    }
}