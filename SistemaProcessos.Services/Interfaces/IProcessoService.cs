using SistemaProcessos.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace SistemaProcessos.Services.Interfaces
{
    public interface IProcessoService
    {
        Processo Cadastrar(string numProcesso, string estado, decimal valor, DateTime dataInicio, bool ativo, Guid idEmpresa);
        decimal RetornarSomaDosProcessosAtivos();
        decimal RetornarMediaDosProcessosPorEmpresaEEstado(Guid idEmpresa, string estado);
        int RetornarQuantidadeProcessosAcimaDeUmValor(decimal valor);
        IEnumerable<Processo> RetornarProcessosPorMesAno(int mes, int ano);
        IEnumerable<Processo> RetornarProcessosNoMesmoEstadoDaEmpresa(string cnpj);
        IEnumerable<Processo> RetornarProcessosPorSiglaLike(string sigla);

    }
}
