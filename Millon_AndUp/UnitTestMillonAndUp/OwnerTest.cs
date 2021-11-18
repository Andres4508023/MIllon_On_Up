using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using BackendMillonAndUpDataAccess.Repositories.Owners;
using BackendMillonUpDomain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace UnitTestMillonAndUp
{
    [TestClass]
   public class OwnerTest
    { 
        [TestMethod]
        public void GetOwner()
        {
            try
            {
                int IdOwner = 1;
                var owner = new SpAsyncEnumerableQueryable<Owner>(
                    new Owner
                    {
                        IdOwner = 1,
                        NamesOwner = "Andres Fierro",
                        AdressOwner = "Calle 1",
                        Age = 32,
                        Telephone = 1234567,
                        Email = "Name@hotmail.com"
                    });
                var parameterContextOptions = new DbContextOptionsBuilder<ParameterContext>()
                    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                    .Options;
                ParameterContext parameterContext = new ParameterContext(parameterContextOptions);
                parameterContext.dsOwner = parameterContext.dsOwner.MockFromSql(owner);

                OwnerD _ownerD = new OwnerD(parameterContext);
                var result = _ownerD.GetOwners();
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
