using eBank.Business.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eBank.Business.Interfaces
{
    public interface IBusinessServiceManagementAccount
    {
        Task<bool> Add(AccountDTO obj);

        Task<AccountDTO> GetById(int id);

        Task<IEnumerable<AccountDTO>> GetAll();

        Task<bool> Update(int id, AccountDTO obj);

        Task<bool> Remove(int id);

        void Dispose();
    }
}
