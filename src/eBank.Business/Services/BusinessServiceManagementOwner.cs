using eBank.Business.Interfaces;
using eBank.Domain.Interfaces.Services;
using eBank.Business.DTO.DTO;
using eBank.Domain.Models;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;

namespace eBank.Business.Services
{
    public class BusinessServiceManagementOwner : IBusinessServiceManagementOwner
    {
        private readonly IServiceOwner _serviceOwner;
        private readonly IMapper _mapper;

        public BusinessServiceManagementOwner(IServiceOwner serviceOwner, IMapper mapper)
        {
            _serviceOwner = serviceOwner;
            _mapper = mapper;
        }

        public async Task<bool> Add(OwnerDTO obj)
        {
            var objOwner = _mapper.Map<Owner>(obj);
            return await _serviceOwner.Add(objOwner);
        }

        public async Task<IEnumerable<OwnerDTO>> GetAll()
        {
            var objOwner = await _serviceOwner.GetAll();
            return _mapper.Map<IEnumerable<OwnerDTO>>(objOwner);
        }

        public async Task<OwnerDTO> GetById(int id)
        {
            var objOwner = await _serviceOwner.GetById(id);
            return _mapper.Map<OwnerDTO>(objOwner);
        }

        public async Task<bool> Remove(int id)
        {
            return await _serviceOwner.Remove(id);
        }

        public async Task<bool> Update(int id, OwnerDTO obj)
        {
            var objOwner = _mapper.Map<Owner>(obj);
            objOwner.Id = id;
            return await _serviceOwner.Update(objOwner);
        }

        public void Dispose()
        {
            _serviceOwner.Dispose();
        }
    }
}
