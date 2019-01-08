using System;
using Microsoft.AspNetCore.Mvc;
using SistemaProcessos.API.Base;
using SistemaProcessos.API.Inputs;
using SistemaProcessos.Domain.Entidades;
using SistemaProcessos.Domain.Persistencia;
using SistemaProcessos.Services.Interfaces;

namespace SistemaProcessos.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EmpresaController : MeuControllerBase
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IUnitOfWork unitOfWork, IEmpresaService empresaService) : base(unitOfWork)
        {
            _empresaService = empresaService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]EmpresaInput input)
        {
            try
            {
                Empresa response = _empresaService.Cadastrar(input.Cnpj, input.Nome, input.Estado);

                return ResponseSuccess(response);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }

    }
}
