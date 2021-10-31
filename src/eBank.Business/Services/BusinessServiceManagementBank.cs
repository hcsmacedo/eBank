using eBank.Business.Interfaces;
using eBank.Domain.Interfaces.Services;
using eBank.Business.DTO.DTO;
using eBank.Domain.Models;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;

namespace eBank.Business.Services
{
    public class BusinessServiceManagementBank: IBusinessServiceManagementBank
    {
        private readonly IServiceBank _serviceBank;
        private readonly IMapper _mapper;

        public BusinessServiceManagementBank(IServiceBank serviceBank, IMapper mapper)
        {
            _serviceBank = serviceBank;
            _mapper = mapper;
        }

        public async Task<bool> Add(BankDTO obj)
        {
            var objBank = _mapper.Map<Bank>(obj);
            return await _serviceBank.Add(objBank);
        }

        public async Task<IEnumerable<BankDTO>> GetAll()
        {
            var objBank = await _serviceBank.GetAll();
            return _mapper.Map<IEnumerable<BankDTO>>(objBank);
        }

        public async Task<BankDTO> GetById(int id)
        {
            var objBank = await _serviceBank.GetById(id);
            return _mapper.Map<BankDTO>(objBank);
        }

        public async Task<bool> Remove(int id)
        {
            return await _serviceBank.Remove(id);
        }

        public async Task<bool> Update(int id, BankDTO obj)
        {
            var objBank = _mapper.Map<Bank>(obj);
            objBank.Id = id;
            return await _serviceBank.Update(objBank);
        }

        public void Dispose()
        {
            _serviceBank.Dispose();
        }
    }
}
