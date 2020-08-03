using Laboratorio1.Core;
using Laboratorio1.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio1.Data.Repositories
{
    public class LibroRepository : IRepository<Libro>
    {

        private readonly AutorLibroContext _context;
        public LibroRepository(AutorLibroContext context)
        {
            _context = context;
        }

        public Libro Add(Libro entity)
        {
            _context.Libro.Add(entity);
            return entity;
        }
        public IQueryable<Libro> All()
        {
            return _context.Libro;
        }

        public Libro GetById(long id)
        {
            return _context.Libro.FirstOrDefault(x => x.Id == id);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Libro Update(Libro entity)
        {
            return _context.Update(entity).Entity;
        }
    }
}
