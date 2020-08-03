using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Laboratorio1.Data.Entities
{
    public class Libro
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Nombre { get; set; }

        public string Fecha { get; set; }
        
        [Required]
        public int Cantidad { get; set; }

        [ForeignKey(nameof(Autor))]
        public long AutorID { get; set; }

        public Autor Autor { get; set; }
    }
}