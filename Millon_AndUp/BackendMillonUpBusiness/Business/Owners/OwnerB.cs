using System;

using BackendMillonUpDomain.Models;

using System.Collections.Generic;
using System.Text;
using BackendMillonUpBusiness.Interfaces.Owners;
using BackendMillonAndUpDataAccess.Interfaces;

namespace BackendMillonUpBusiness.Business.Owners
{
    public class OwnerB : IOwnerB
    {

        private readonly IParameterUnitWork _parameterUnitWork;
        public OwnerB(IParameterUnitWork parameterUnitWork)
        {
            _parameterUnitWork = parameterUnitWork;
        }

        public RtaOwner DeleteOwner(int IdOwner)
        {
            try
            {
                var result = _parameterUnitWork.OwnerD.DeleteOwner(IdOwner);
                _parameterUnitWork.Dispose();
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Owner> GetOwnerId(int IdOwner)
        {
            try
            {
                var result = _parameterUnitWork.OwnerD.GetOwnerId(IdOwner);
                _parameterUnitWork.Dispose();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Owner> GetOwners()
        {
            try
            {
                var result = _parameterUnitWork.OwnerD.GetOwners();
                _parameterUnitWork.Dispose();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public RtaOwner InsertOwner(Owner model)
        {
            try
            {
                var result = _parameterUnitWork.OwnerD.InsertOwner(model);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public RtaOwner UpdateOwner(Owner model)
        {
            try
            {
                var result = _parameterUnitWork.OwnerD.UpdateOwner(model);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
