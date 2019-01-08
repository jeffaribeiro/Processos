using SistemaProcessos.Data.Context;
using SistemaProcessos.Domain.Entidades;
using SistemaProcessos.Domain.Repositorios;

namespace SistemaProcessos.Data.Repositorios
{
    public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(MyContext context) : base(context)
        {

        }
    }
}
