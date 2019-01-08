using SistemaProcessos.Business.Interfaces;
using SistemaProcessos.Domain.Entidades;
using SistemaProcessos.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace SistemaProcessos.Services.Implementacao
{
    public class EmpresaService : IEmpresaService
    {

        #region "Injeções de Dependência"

        private readonly IEmpresaBusiness _empresaBusiness;

        public EmpresaService(IEmpresaBusiness empresaBusiness)
        {
            _empresaBusiness = empresaBusiness;
        }

        #endregion

        public Empresa Cadastrar(string cnpj, string nome, string estado)
        {
            Empresa empresa = new Empresa(cnpj, nome, estado);
            _empresaBusiness.Cadastrar(empresa);
            _empresaBusiness.Persistir();
            return _empresaBusiness.ObterPorId(empresa.Id);
        }

        public void Excluir(Guid id)
        {
            _empresaBusiness.Excluir(id);
        }

        public IEnumerable<Empresa> ListarTodos()
        {
            return _empresaBusiness.ListarTodos();
        }

        public Empresa ObterPorId(Guid id)
        {
            return _empresaBusiness.ObterPorId(id);
        }
    }
}
