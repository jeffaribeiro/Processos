using SistemaProcessos.Business.Interfaces;
using SistemaProcessos.Domain.Entidades;
using SistemaProcessos.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaProcessos.Services.Implementacao
{
    public class ProcessoService : IProcessoService
    {
        #region "Injeções de Dependência"

        private readonly IProcessoBusiness _processoBusiness;

        public ProcessoService(IProcessoBusiness processoBusiness)
        {
            _processoBusiness = processoBusiness;
        }

        #endregion

        public Processo Cadastrar(string numProcesso, string estado, decimal valor, DateTime dataInicio, bool ativo, Guid idEmpresa)
        {
            Processo processo = new Processo(numProcesso, estado, valor, dataInicio, ativo, idEmpresa);
            _processoBusiness.Cadastrar(processo);
            _processoBusiness.Persistir();
            return _processoBusiness.ObterPorId(processo.Id);
        }

        public IEnumerable<Processo> RetornarProcessosNoMesmoEstadoDaEmpresa(string cnpj)
        {
            return _processoBusiness.ObterProcessosNoMesmoEstadoDaEmpresa(cnpj);
        }

        public decimal RetornarMediaDosProcessosPorEmpresaEEstado(Guid idEmpresa, string estado)
        {
            return _processoBusiness.ObterProcessosPorEmpresaEEstado(idEmpresa, estado).Select(p => p.Valor).Average();
        }

        public IEnumerable<Processo> RetornarProcessosPorMesAno(int mes, int ano)
        {
            return _processoBusiness.ListarTodos().Where(p => p.DataInicio.Month == mes && p.DataInicio.Year == ano);
        }

        public int RetornarQuantidadeProcessosAcimaDeUmValor(decimal valor)
        {
            return _processoBusiness.ListarTodos().Where(p => p.Valor > valor).Count();
        }

        public decimal RetornarSomaDosProcessosAtivos()
        {
            return _processoBusiness.BuscarAtivos().Select(p => p.Valor).Sum();
        }

        public IEnumerable<Processo> RetornarProcessosPorSiglaLike(string sigla)
        {
            return _processoBusiness.ObterProcessosPorSiglaLike(sigla);
        }
    }
}
