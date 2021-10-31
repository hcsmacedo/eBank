using eBank.Domain.Interfaces.Repositories;
using eBank.Domain.Interfaces.Services;
using eBank.Domain.Models;

namespace eBank.Domain.Services
{
    public class ServiceOwner : ServiceBase<Owner>, IServiceOwner
    {
        public readonly IRepositoryOwner _repositoryOwner;

        public ServiceOwner(IRepositoryOwner repositoryOwner)
            : base(repositoryOwner)
        {
            _repositoryOwner = repositoryOwner;
        }
    }
}
