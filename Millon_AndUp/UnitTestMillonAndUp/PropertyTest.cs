using Microsoft.VisualStudio.TestTools.UnitTesting;
using BackendMilllonUpBusinessEntity;
using BackendMillonUpEntity;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using BackendMillonUpEntity.Domain;

namespace UnitTestMillonAndUp
{
    [TestClass]
    public class PropertyTest
    {
        [TestMethod]
        public void GetProperty()
        {
            try
            {
                int IdProperty = 1;
                var Property = new SpAsyncEnumerableQueryable<Property>(
                    new Property
                    {
                        IdProperty = 1,
                        Name = "Andres Fierro",
                        Adress = "Calle 1",
                        Stratum = 32,
                        YearsConstruction = 1234567,
                        Tax = 2000,
                        Price = 100000,
                        ImagePath = "TestIamge",
                        IdOwner = 2
                    });
                var parameterContextOptions = new DbContextOptionsBuilder<MillionOnUpContext>()
                    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                    .Options;
                MillionOnUpContext parameterContext = new MillionOnUpContext(parameterContextOptions);
                parameterContext.Property = parameterContext.Property.MockFromSql(Property);

                PropertyService _PropertyService = new PropertyService(parameterContext);
                var result = _PropertyService.GetProperties();
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
