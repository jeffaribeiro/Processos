using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SistemaProcessos.Domain.Entidades;
using SistemaProcessos.Domain.Repositorios;

namespace SistemaProcessos.Business.Interfaces.Implementacao
{
    public class ProcessoBusiness : IProcessoBusiness
    {

        #region "Injeções de Dependência"

        private readonly IProcessoRepository _processoRepository;

        public ProcessoBusiness(IProcessoRepository processoRepository)
        {
            _processoRepository = processoRepository;
        }

        #endregion

        public IEnumerable<Processo> BuscarAtivos()
        {
            Expression<Func<Processo, bool>> processos = p => p.Ativo;

            return _processoRepository.Buscar(processos);
        }

        public void Cadastrar(Processo processo)
        {
            _processoRepository.Adicionar(processo);
        }

        public void Excluir(Guid id)
        {
            _processoRepository.Remover(id);
        }

        public IEnumerable<Processo> ListarTodos()
        {
            return _processoRepository.ObterTodos();
        }

        public Processo ObterPorId(Guid id)
        {
            return _processoRepository.ObterPorId(id);
        }

        public IEnumerable<Processo> ObterProcessosNoMesmoEstadoDaEmpresa(string cnpj)
        {
            Expression<Func<Processo, bool>> processos = p => p.Estado == p.Empresa.Estado && p.Empresa.Cnpj == cnpj;
          
            return _processoRepository.Buscar(processos);
        }

        public IEnumerable<Processo> ObterProcessosPorEmpresaEEstado(Guid idEmpresa, string estado)
        {
            Expression<Func<Processo, bool>> processos = p => p.IdEmpresa == idEmpresa && p.Estado == estado;

            return _processoRepository.Buscar(processos);
        }

        public IEnumerable<Processo> ObterProcessosPorSiglaLike(string sigla)
        {
            Expression<Func<Processo, bool>> processos = p => p.NumProcesso.ToUpper().Contains(sigla.ToUpper());

            return _processoRepository.Buscar(processos);
        }

        public void Persistir()
        {
            _processoRepository.SaveChanges();
        }

    }
}
