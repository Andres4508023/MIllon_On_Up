using System;
using System.Collections.Generic;
using System.Text;
using BackendMillonAndUpDataAccess.Interfaces.Owners;

namespace BackendMillonAndUpDataAccess.Interfaces
{
  public  interface IParameterUnitWork
    {
        IOwnerD OwnerD { get; }
        void Save();
        void Dispose();
    }
}
