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
    public class AutorService : IAutorService
    {
        private readonly IRepository<Autor> _autorRepository;

        public AutorService(IRepository<Autor> autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public ServiceResult<AutorModel> Add(AutorModel autor)
        {
            var autorEntity = new Autor
            {
                Nombre = autor.Nombre,
                Edad = autor.Edad
            };

            _autorRepository.Add(autorEntity);
            _autorRepository.SaveChanges();
            autor.Id = autorEntity.Id;

            return ServiceResult<AutorModel>.SuccessResult(autor);
        }

        public ServiceResult<IEnumerable<AutorModel>> GetAll()
        {
            var autores = _autorRepository.All()
                .Select(x => new AutorModel
                {
                    Nombre = x.Nombre,
                    Id = x.Id,
                    Edad = x.Edad
                });
            
            return ServiceResult<IEnumerable<AutorModel>>.SuccessResult(autores);
        }
        public ServiceResult<IEnumerable<LibroModel>> GetLibrosPorAutor(long autorId)
        {
            var autor = _autorRepository.All()
                .Include(x => x.Libros)
                .FirstOrDefault(x => x.Id == autorId);

            if (autor == null)
            {
                return ServiceResult<IEnumerable<LibroModel>>.ErrorResult($"No se encontró una Autor con el id {autorId}");
            }

            var result = autor.Libros.Select(x => new LibroModel
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Cantidad = x.Cantidad,
                Fecha = x.Fecha,
                NombreAutor = x.Autor.Nombre,
                AutorId = x.AutorID

            });

            return ServiceResult<IEnumerable<LibroModel>>.SuccessResult(result);
        }
    }
}
