using System;

namespace SistemaProcessos.Domain.Base
{
    public class EntidadeBase<T>
    {
        public EntidadeBase()
        {
            Id = Guid.NewGuid();
        }

        public virtual Guid Id { get; protected set; }
    }
}
