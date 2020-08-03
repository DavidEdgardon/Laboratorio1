using Laboratorio1.Core;
using Laboratorio1.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio1.Services
{
    public interface IAutorService
    {
        ServiceResult<AutorModel> Add(AutorModel Autor);

        ServiceResult<IEnumerable<AutorModel>> GetAll();

        ServiceResult<IEnumerable<LibroModel>> GetLibrosPorAutor(long id);
    }
}
