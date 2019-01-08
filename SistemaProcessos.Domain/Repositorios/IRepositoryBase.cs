using SistemaProcessos.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SistemaProcessos.Domain.Repositorios
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : EntidadeBase<TEntity>
    {
        void Adicionar(TEntity obj);
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        void Atualizar(TEntity obj);
        void Remover(Guid id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}