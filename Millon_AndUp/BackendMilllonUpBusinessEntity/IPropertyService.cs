using System;
using System.Collections.Generic;
using System.Text;
using BackendMillonUpEntity.Domain;
using BackendMillonUpEntity.Model;

namespace BackendMilllonUpBusinessEntity
{
   public interface IPropertyService
    {
        IEnumerable<PropertyModel> GetProperties();
        List<Property> GetPropertiesId(int IdPropery);
        bool AddProperties(PropertyModel model);
        bool EditProperties(PropertyModel model);
        bool DeleteProperties(int IdPropery);
    }
}
