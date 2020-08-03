using Laboratorio1.Core;
using Laboratorio1.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio1.Data.Repositories
{
    public class AutorRepository : IRepository<Autor>
    {

        private readonly AutorLibroContext _context;
        public AutorRepository(AutorLibroContext context)
        {
            _context = context;
        }

        public Autor Add(Autor entity)
        {
            _context.Autor.Add(entity);
            return entity;
        }
        public IQueryable<Autor> All()
        {
            return _context.Autor;
        }

        public Autor GetById(long id)
        {
            return _context.Autor.FirstOrDefault(x => x.Id == id);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Autor Update(Autor entity)
        {
            throw new NotImplementedException();
        }
    }

}
