using eBank.Domain.Interfaces.Repositories;
using eBank.Domain.Models;
using eBank.Infra.Data;

namespace eBank.Infra.Repository
{
    public class RepositoryOwner : RepositoryBase<Owner>, IRepositoryOwner
    {
        private readonly DatabaseContext _context;
        public RepositoryOwner(DatabaseContext Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
