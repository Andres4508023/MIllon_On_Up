using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using BackendMillonUpEntity.Domain;
using BackendMillonUpEntity.Model;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace BackendMilllonUpBusinessEntity
{
    public class PropertyService : IPropertyService
    {
        private readonly MillionOnUpContext _context;

        public PropertyService(MillionOnUpContext context)
        {
            _context = context;
        }

        public IEnumerable<PropertyModel> GetProperties()
        {
            var propertyList = (from p in _context.Property
                                select new PropertyModel
                                {
                                    IdProperty = p.IdProperty,
                                    Name = p.Name,
                                    Adress = p.Adress,
                                    Stratum = p.Stratum,
                                    YearsConstruction = p.YearsConstruction,
                                    Tax = p.Tax,
                                    Price = p.Price,
                                    ImagePath = p.ImagePath,
                                    IdOwner = p.IdOwner
                                }).ToList();
            return propertyList;
        }


        public bool AddProperties(PropertyModel model)
        {
            using (var transcation = _context.Database.BeginTransaction())
              {
                try
                {
                    var property_ = new Property
                    {
                      //  IdProperty = model.IdProperty,
                        Name = model.Name,
                        Adress = model.Adress,
                        Stratum = model.Stratum,
                        YearsConstruction = model.YearsConstruction,
                        Tax = model.Tax,
                        Price = model.Price,
                        ImagePath = model.ImagePath,
                        IdOwner = model.IdOwner
                    };
                    _context.Property.Add(property_);
                    _context.SaveChanges();
                    transcation.Commit();
      
                    return true;
                }
                catch (Exception ex)
                {

                    transcation.Rollback();
                    return false;
                }
            }
        }
        public bool EditProperties(PropertyModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                
                    var data = _context.Property.FirstOrDefault(a => a.IdProperty == model.IdProperty);
                    if (data != null)
                    {
                        data.IdProperty = model.IdProperty;
                        data.Name = model.Name;
                        data.Adress = model.Adress;
                        data.Stratum = model.Stratum;
                        data.YearsConstruction = model.YearsConstruction;
                        data.Tax = model.Tax;
                        data.Price = model.Price;
                        data.ImagePath = model.ImagePath;
                        data.IdOwner = model.IdOwner;

                        _context.Property.Update(data);
                        _context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }

                    return false;
                }
            
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                   
                }
            }
        }

        public bool DeleteProperties(int IdPropery)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var data = _context.Property.FirstOrDefault(a => a.IdProperty == IdPropery);
                    if (data != null)
                    {
                        _context.Property.Remove(data);
                        _context.SaveChanges();
                        transaction.Commit();

                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public List<Property> GetPropertiesId(int IdPropery)
        {
           
                 var GetPropertiesIdList = (from p in _context.Property
                                            where p.IdProperty == IdPropery
                                            select p);
             
                 return GetPropertiesIdList.ToList();
        
        }
        
    }
}
