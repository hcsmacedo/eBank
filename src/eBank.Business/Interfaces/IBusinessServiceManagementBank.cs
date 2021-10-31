using eBank.Business.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eBank.Business.Interfaces
{
    public interface IBusinessServiceManagementBank
    {
        Task<bool> Add(BankDTO obj);

        Task<BankDTO> GetById(int id);

        Task<IEnumerable<BankDTO>> GetAll();

        Task<bool> Update(int id, BankDTO obj);

        Task<bool> Remove(int id);

        void Dispose();
    }
}
