using Laboratorio1.Core;
using Laboratorio1.Core.Models;
using Laboratorio1.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio1.Services
{
    public class LibroService : ILibroService
    {
        private readonly IRepository<Libro> _rep;
        
        public LibroService(IRepository<Libro> rep)
        {
            _rep = rep;  
        }

        public ServiceResult<LibroModel> Add(LibroModel libro)
        {
            var libroentity = new Libro
            {
                Nombre = libro.Nombre,
                Fecha = libro.Fecha,
                Cantidad = libro.Cantidad,
                AutorID = libro.AutorId
            };

            _rep.Add(libroentity);
            _rep.SaveChanges();
            libro.Id = libroentity.Id;
            //libro.NombreAutor = libroentity.Autor.Nombre;
            return ServiceResult<LibroModel>.SuccessResult(libro);
        }

        public ServiceResult<IEnumerable<LibroModel>> GetAll()
        {
            var libros = _rep.All().Select(x => new LibroModel 
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Fecha = x.Fecha,
                Cantidad = x.Cantidad,
                NombreAutor = x.Autor.Nombre,
                AutorId = x.AutorID                
            });
            return ServiceResult<IEnumerable<LibroModel>>.SuccessResult(libros);
        }

        public ServiceResult<LibroModel> GiveBack(long Id)
        {
            var libro = _rep.GetById(Id);

            if (libro == null)
            {
                return ServiceResult<LibroModel>.ErrorResult($"No se encontró un Libro con el id {Id}");
            }

            libro.Cantidad = libro.Cantidad + 1;

            var result = new LibroModel
            {
                Id = libro.Id,
                Nombre = libro.Nombre,
                Cantidad = libro.Cantidad,
                Fecha = libro.Fecha,
                //NombreAutor= libro.Autor.Nombre,
                AutorId = libro.AutorID

            };
            _rep.Update(libro);
            _rep.SaveChanges();

            return ServiceResult<LibroModel>.SuccessResult(result);
           
        }
        public ServiceResult<LibroModel> Borrow(long Id)
        {
            var libro = _rep.GetById(Id);

            if (libro == null)
            {
                return ServiceResult<LibroModel>.ErrorResult($"No se encontró un Libro con el id {Id}");
            }
            
            var result = new LibroModel
            {
                Id = libro.Id,
                Nombre = libro.Nombre,
                Cantidad = libro.Cantidad,
                Fecha = libro.Fecha,
                //NombreAutor= libro.Autor.Nombre,
                AutorId = libro.AutorID

            };
            if (libro.Cantidad <= 3)
            {
                return ServiceResult<LibroModel>.NotFoundResult($"No hay suficientes Libros de {Id}" , result);
            }
            libro.Cantidad = libro.Cantidad - 1;
                       
            _rep.Update(libro);
            _rep.SaveChanges();
            result.Cantidad = libro.Cantidad;
            return ServiceResult<LibroModel>.SuccessResult(result);
        }

    }
}
