namespace SistemaProcessos.Domain.Persistencia
{

    public interface IUnitOfWork
    {
        void Commit();
    }
}

