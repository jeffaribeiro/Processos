using Microsoft.AspNetCore.Mvc;
using SistemaProcessos.Domain.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaProcessos.API.Base
{
    public class MeuControllerBase : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MeuControllerBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [NonAction]
        public IActionResult ResponseSuccess(object result)
        {
            try
            {
                _unitOfWork.Commit();

                var x = Ok(result);

                return x;
            }
            catch (Exception ex)
            {

                return BadRequest($"Ocorreu um problema na operação no servidor: {ex.Message}");
            }

        }

        [NonAction]
        public IActionResult ResponseException(Exception ex)
        {
            return BadRequest(new { errors = ex.Message, exception = ex.ToString() });
        }

    }
}
