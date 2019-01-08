using SistemaProcessos.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaProcessos.Business.Interfaces
{
    public interface IProcessoBusiness
    {
        void Cadastrar(Processo processo);
        void Excluir(Guid id);
        Processo ObterPorId(Guid id);
        IEnumerable<Processo> ListarTodos();
        IEnumerable<Processo> BuscarAtivos();
        IEnumerable<Processo> ObterProcessosPorEmpresaEEstado(Guid idEmpresa, string estado);
        IEnumerable<Processo> ObterProcessosNoMesmoEstadoDaEmpresa(string cnpj);
        IEnumerable<Processo> ObterProcessosPorSiglaLike(string sigla);
        void Persistir();
    }
}
