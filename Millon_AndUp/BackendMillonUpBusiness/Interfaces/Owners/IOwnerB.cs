using System;
using System.Collections.Generic;
using System.Text;
using BackendMillonUpDomain.Models;

namespace BackendMillonUpBusiness.Interfaces.Owners
{
    public interface IOwnerB
    {
        RtaOwner InsertOwner(Owner model);
        List<Owner> GetOwners();
        List<Owner> GetOwnerId(int IdOwner);
        RtaOwner UpdateOwner(Owner model);
        RtaOwner DeleteOwner(int IdOwner);
    }
}
