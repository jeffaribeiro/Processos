using SistemaProcessos.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace SistemaProcessos.Services.Interfaces
{
    public interface IEmpresaService
    {
        Empresa Cadastrar(string cnpj, string nome, string estado);
        void Excluir(Guid id);
        IEnumerable<Empresa> ListarTodos();
        Empresa ObterPorId(Guid id);
    }
}
