using eBank.Business.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eBank.Business.Interfaces
{
    public interface IBusinessServiceManagementOwner
    {
        Task<bool> Add(OwnerDTO obj);

        Task<OwnerDTO> GetById(int id);

        Task<IEnumerable<OwnerDTO>> GetAll();

        Task<bool> Update(int id, OwnerDTO obj);

        Task<bool> Remove(int id);

        void Dispose();
    }
}
