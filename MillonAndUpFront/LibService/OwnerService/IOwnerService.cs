using DomainBD.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibService.OwnerService
{
    public interface IOwnerService 
    {
        Task<List<Owner>> GetOwnersList();
        Task<List<Owner>> GetOwnersListId(int IdOwner);
        Task<bool> SaveOwner(Owner model);
        Task<bool> UpdateOwner(Owner model);
        Task<bool> DeleteOwner(int IdOwner);
    }
}
