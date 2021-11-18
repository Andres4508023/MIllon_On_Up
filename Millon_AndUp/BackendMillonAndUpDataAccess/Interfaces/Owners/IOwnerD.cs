using System;
using System.Collections.Generic;
using System.Text;
using BackendMillonUpDomain.Models;

namespace BackendMillonAndUpDataAccess.Interfaces.Owners
{
   public interface IOwnerD
    {
        RtaOwner InsertOwner(Owner model);

        List<Owner> GetOwners();

        List<Owner> GetOwnerId(int IdOwner);

        RtaOwner UpdateOwner(Owner model);

        RtaOwner DeleteOwner(int IdOwner);
    }
}
