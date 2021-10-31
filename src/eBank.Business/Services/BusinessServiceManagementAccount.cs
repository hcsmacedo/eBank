using AutoMapper;
using eBank.Business.DTO.DTO;
using eBank.Business.Interfaces;
using eBank.Domain.Interfaces.Services;
using eBank.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eBank.Business.Services
{
    public class BusinessServiceManagementAccount : IBusinessServiceManagementAccount
    {
        private readonly IServiceAccount _serviceAccount;
        private readonly IMapper _mapper;

        public BusinessServiceManagementAccount(IServiceAccount serviceAccount, IMapper mapper)
        {
            _serviceAccount = serviceAccount;
            _mapper = mapper;
        }

        public async Task<bool> Add(AccountDTO obj)
        {
            var objAccount = _mapper.Map<Account>(obj);
            return await _serviceAccount.Add(objAccount);
        }

        public async Task<IEnumerable<AccountDTO>> GetAll()
        {
            var objAccount = await _serviceAccount.GetAll();
            return _mapper.Map<IEnumerable<AccountDTO>>(objAccount);
        }

        public async Task<AccountDTO> GetById(int id)
        {
            var objAccount = await _serviceAccount.GetById(id);
            return _mapper.Map<AccountDTO>(objAccount);
        }

        public async Task<bool> Remove(int id)
        {
            return await _serviceAccount.Remove(id);
        }

        public async Task<bool> Update(int id, AccountDTO obj)
        {
            var objAccount = _mapper.Map<Account>(obj);
            objAccount.Id = id;
            return await _serviceAccount.Update(objAccount);
        }

        public void Dispose()
        {
            _serviceAccount.Dispose();
        }
    }
}
