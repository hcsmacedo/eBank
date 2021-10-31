using eBank.Domain.Interfaces.Repositories;
using eBank.Domain.Models;
using eBank.Infra.Data;

namespace eBank.Infra.Repository
{
    public class RepositoryBank : RepositoryBase<Bank>, IRepositoryBank
    {
        private readonly DatabaseContext _context;
        public RepositoryBank(DatabaseContext Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
