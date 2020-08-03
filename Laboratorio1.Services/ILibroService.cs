using Laboratorio1.Core;
using Laboratorio1.Core.Models;
using Laboratorio1.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Laboratorio1.Services
{
    public interface ILibroService
    {
        ServiceResult<LibroModel> Add(LibroModel Libro);

        ServiceResult<IEnumerable<LibroModel>> GetAll();

        ServiceResult<LibroModel> GiveBack(long Id);

        ServiceResult<LibroModel> Borrow(long Id);
    }
}
