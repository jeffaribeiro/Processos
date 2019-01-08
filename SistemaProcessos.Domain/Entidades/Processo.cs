using SistemaProcessos.Domain.Base;
using System;

namespace SistemaProcessos.Domain.Entidades
{
    public class Processo : EntidadeBase<Processo>
    {
        public string NumProcesso { get; private set; }
        public string Estado { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataInicio { get; private set; }
        public bool Ativo { get; set; }
        public Guid IdEmpresa { get; private set; }

        // EF Propriedade de Navegação
        public Empresa Empresa { get; private set; }

        // Construtor para o EFCore
        protected Processo() { }

        public Processo(string _numProcesso, string _estado, decimal _valor, DateTime _dataInicio, bool _ativo, Guid _idEmpresa)
        {
            Id = Guid.NewGuid();
            NumProcesso = _numProcesso;
            Estado = _estado;
            Valor = _valor;
            DataInicio = _dataInicio;
            Ativo = _ativo;
            IdEmpresa = _idEmpresa;
        }
    }
}
