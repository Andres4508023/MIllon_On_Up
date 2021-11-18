using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackendMillonUpDomain.Models;
using BackendMillonUpBusiness.Interfaces.Owners;

namespace Millon_AndUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerB _OwnerB;

        public OwnerController(IOwnerB OwnerB)
        {
            _OwnerB = OwnerB;
        }

        
        [HttpGet]
        [Route("GetOwner")]
        public List <Owner> GetOwners()
        {
            List<Owner> ownersList = new List<Owner>();
            ownersList = _OwnerB.GetOwners();
            return ownersList;
        }

        [HttpGet]
        [Route("GetOwnerId")]
        public List<Owner> GetOwners(int IdOwner)
        {
            List<Owner> ownersListId = new List<Owner>();
            ownersListId = _OwnerB.GetOwnerId(IdOwner);
            return ownersListId;
        }


        [HttpPost]
        [Route("AddOwner")]
        public int AddOwner(Owner model)
        {
            int Answer = 0;
            var Rta = _OwnerB.InsertOwner(model);
            Answer = Rta.IdOwner;
            return Answer;
        }

        [HttpPut]
        [Route("UpdateOwner")]
        public int UpdateOwner(Owner model)
        {
            int Answer = 0;
            var Rta = _OwnerB.UpdateOwner(model);
            Answer = Rta.IdOwner;
            return Answer;
        }

        [HttpDelete]
        public int DeleteOwner(int IdOwner)
        {
            int Answer = 0;
            var Rta = _OwnerB.DeleteOwner(IdOwner);
            Answer = Rta.IdOwner;
            return Answer;
        }

    }
}