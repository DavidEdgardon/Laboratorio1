using System;
using Laboratorio1.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Laboratorio1.Data
{
    public class AutorLibroContext : DbContext
    {
        public DbSet<Autor> Autor { get; set; }

        public DbSet<Libro> Libro { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          => optionsBuilder.UseSqlite("Data Source= C:\\Users\\David\\Desktop\\Visual Project\\Laboratorio1\\Laboratorio1.Data\\DataBase.db");
    }
}
