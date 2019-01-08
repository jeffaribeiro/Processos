using SistemaProcessos.Domain.Base;
using System;
using System.Collections.Generic;

namespace SistemaProcessos.Domain.Entidades
{
    public class Empresa : EntidadeBase<Empresa>
    {
        public string Cnpj { get; private set; }
        public string Nome { get; private set; }
        public string Estado { get; private set; }

        // Construtor para o EFCore
        protected Empresa() { }

        // EF Propriedade de Navegação
        public virtual ICollection<Processo> ProcessosEmpresa { get; set; }

        public Empresa(string _cnpj, string _nome, string _estado)
        {
            Id = Guid.NewGuid();
            Cnpj = _cnpj;
            Nome = _nome;
            Estado = _estado;
        }

    }
}
