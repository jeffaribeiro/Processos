using SistemaProcessos.Data.Context;
using SistemaProcessos.Domain.Persistencia;

namespace SistemaProcessos.Data.Persistencia
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext _context;

        public UnitOfWork(MyContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
