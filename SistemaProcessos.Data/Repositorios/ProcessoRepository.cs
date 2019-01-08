using SistemaProcessos.Data.Context;
using SistemaProcessos.Domain.Entidades;
using SistemaProcessos.Domain.Repositorios;

namespace SistemaProcessos.Data.Repositorios
{
    public class ProcessoRepository : RepositoryBase<Processo>, IProcessoRepository
    {
        public ProcessoRepository(MyContext context) : base(context)
        {

        }
    }
}
