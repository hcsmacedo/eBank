using eBank.Domain.Interfaces.Repositories;
using eBank.Domain.Interfaces.Services;
using eBank.Domain.Models;

namespace eBank.Domain.Services
{
    public class ServiceBank : ServiceBase<Bank>, IServiceBank
    {
        public readonly IRepositoryBank _repositoryBank;

        public ServiceBank(IRepositoryBank repositoryBank)
            : base(repositoryBank)
        {
            _repositoryBank = repositoryBank;
        }
    }
}
