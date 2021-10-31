using eBank.Domain.Interfaces.Repositories;
using eBank.Domain.Interfaces.Services;
using eBank.Domain.Models;

namespace eBank.Domain.Services
{
    public class ServiceAccount : ServiceBase<Account>, IServiceAccount
    {
        public readonly IRepositoryAccount _repositoryAccount;

        public ServiceAccount(IRepositoryAccount repositoryAccount)
            : base(repositoryAccount)
        {
            _repositoryAccount = repositoryAccount;
        }
    }
}
