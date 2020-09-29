using ESDE.Custody.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESDE.Custody.Domain.Interfaces
{
    public interface ICustodyApplication
    {
        Task<IEnumerable<CustodyForGetDto>> GetAll();
        void Process(string message);
    }
}
