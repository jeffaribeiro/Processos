using System;
using System.Collections.Generic;
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
    public class ProcessoController : MeuControllerBase
    {
        private readonly IProcessoService _processoService;

        public ProcessoController(IUnitOfWork unitOfWork, IProcessoService processoService) : base(unitOfWork)
        {
            _processoService = processoService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]ProcessoInput input)
        {
            try
            {
                if (input.EhValido())
                {
                    Processo response = _processoService.Cadastrar(input.NumProcesso, input.Estado, input.Valor, input.DataInicio, input.Ativo, input.IdEmpresa);

                    return ResponseSuccess(response);
                }
                return BadRequest("Dados de entrada inválidos");
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }

        [HttpGet("RetornarSomaDosProcessosAtivos")]
        public IActionResult RetornarSomaDosProcessosAtivos()
        {
            try
            {
                decimal response = _processoService.RetornarSomaDosProcessosAtivos();
                return ResponseSuccess(response);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }

        [HttpGet("RetornarMediaDosProcessosPorEmpresaEEstado")]
        public IActionResult RetornarMediaDosProcessosPorEmpresaEEstado(Guid idEmpresa, string estado)
        {
            try
            {
                decimal response = _processoService.RetornarMediaDosProcessosPorEmpresaEEstado(idEmpresa, estado);
                return ResponseSuccess(response);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }

        [HttpGet("RetornarQuantidadeProcessosAcimaDeUmValor")]
        public IActionResult RetornarQuantidadeProcessosAcimaDeUmValor(decimal valor)
        {
            try
            {
                decimal response = _processoService.RetornarQuantidadeProcessosAcimaDeUmValor(valor);
                return ResponseSuccess(response);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }

        [HttpGet("RetornarProcessosPorMesAno")]
        public IActionResult RetornarProcessosPorMesAno(int mes, int ano)
        {
            try
            {
                IEnumerable<Processo> response = _processoService.RetornarProcessosPorMesAno(mes, ano);
                return ResponseSuccess(response);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }

        [HttpGet("RetornarProcessosNoMesmoEstadoDaEmpresa")]
        public IActionResult RetornarProcessosNoMesmoEstadoDaEmpresa(string cnpj)
        {
            try
            {
                IEnumerable<Processo> response = _processoService.RetornarProcessosNoMesmoEstadoDaEmpresa(cnpj);
                return ResponseSuccess(response);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }

        [HttpGet("RetornarProcessosPorSiglaLike")]
        public IActionResult RetornarProcessosPorSiglaLike(string sigla)
        {
            try
            {
                IEnumerable<Processo> response = _processoService.RetornarProcessosPorSiglaLike(sigla);
                return ResponseSuccess(response);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }

    }
}
