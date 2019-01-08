using System;
using System.Collections.Generic;
using SistemaProcessos.Domain.Entidades;
using SistemaProcessos.Domain.Repositorios;

namespace SistemaProcessos.Business.Interfaces.Implementacao
{
    public class EmpresaBusiness : IEmpresaBusiness
    {

        #region "Injeções de Dependência"

        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaBusiness(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        #endregion

        public void Cadastrar(Empresa empresa)
        {
            _empresaRepository.Adicionar(empresa);
        }

        public void Excluir(Guid id)
        {
            _empresaRepository.Remover(id);
        }

        public IEnumerable<Empresa> ListarTodos()
        {
            return _empresaRepository.ObterTodos();
        }

        public Empresa ObterPorId(Guid id)
        {
            return _empresaRepository.ObterPorId(id);
        }

        public void Persistir()
        {
            _empresaRepository.SaveChanges();
        }

    }
}
