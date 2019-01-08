using SistemaProcessos.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace SistemaProcessos.Business.Interfaces
{
    public interface IEmpresaBusiness
    {
        void Cadastrar(Empresa empresa);
        void Excluir(Guid id);
        Empresa ObterPorId(Guid id);
        IEnumerable<Empresa> ListarTodos();
        void Persistir();
    }
}
