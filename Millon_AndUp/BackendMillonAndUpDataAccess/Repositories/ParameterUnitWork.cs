using System;
using System.Collections.Generic;
using System.Text;
using BackendMillonAndUpDataAccess.Repositories.Owners;
using BackendMillonAndUpDataAccess.Interfaces;
using BackendMillonAndUpDataAccess.Interfaces.Owners;
using BackendMillonUpDomain.Models;

namespace BackendMillonAndUpDataAccess.Repositories
{
    public class ParameterUnitWork : IDisposable, IParameterUnitWork
    {
        private readonly ParameterContext _ParameterContext;
        private bool _disposed;

        private IOwnerD _OwnerD;

        public ParameterUnitWork(ParameterContext parameterContext)
        {
            _ParameterContext = parameterContext;
        }

        public IOwnerD OwnerD
        {
            get { return _OwnerD = _OwnerD ?? new OwnerD(_ParameterContext); }
        }

        public void Save()
        {
            _ParameterContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _ParameterContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}

