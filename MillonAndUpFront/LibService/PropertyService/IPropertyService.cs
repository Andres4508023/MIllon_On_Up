using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DomainBD.Domain;
using DomainBD.Models;

namespace LibService.PropertyService
{
   public interface IPropertyService
    {
        Task<List<PropertyModel>> GetPropertiesList();
        Task<List<Property>> GetPropertiesId(int IdPropery);
        Task<bool> SaveProperty(PropertyModel model);
        Task<bool> UpdateProperty(PropertyModel model);
        Task<bool> DeleteProperty(int IdProperty);
    }
}
