using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendMilllonUpBusinessEntity;
using BackendMillonUpEntity.Domain;
using BackendMillonUpEntity.Model;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Millon_AndUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _PropertyService;
        private readonly IHostingEnvironment _hostingEnv;

        public PropertyController(IPropertyService propertyService, IHostingEnvironment hostingEnv)
        {
            _PropertyService = propertyService;
            _hostingEnv = hostingEnv;
        }
        

        [HttpGet]
        [Route("GePropertyList")]
        public ActionResult <IEnumerable<PropertyModel>>GePropertyList()
        {
            var result = _PropertyService.GetProperties();
            return Ok(result);
        }

        [HttpGet]
        //[Route("GetPropertyId")]
        public ActionResult<IEnumerable<Property>> GetPropertyId(int IdProperty)
        {
            var result = _PropertyService.GetPropertiesId(IdProperty);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("CreateProperty")]
        public ActionResult<bool>CreateProperty (PropertyModel model)
        {
            //var a = _hostingEnv.WebRootPath;
            //var fileName = Path.GetFileName(model.ImageFile.FileName);
            //var filePath = Path.Combine(_hostingEnv.WebRootPath, "Images\\Property", fileName);

            //using (var fileSteam = new FileStream(filePath, FileMode.Create))
            //{
            //    model.ImageFile.CopyToAsync(fileSteam);
            //}

            //Property pro = new Property();
            //pro.IdProperty = model.IdProperty;
            //pro.Name = model.Name;
            //pro.Stratum = model.Stratum;
            //pro.YearsConstruction = model.YearsConstruction;
            //pro.Tax = model.Tax;
            //pro.Price = model.Price;
            //pro.ImagePath = filePath;

            var response = _PropertyService.AddProperties(model);

            if (response)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }

        //[HttpPost]
        [HttpPut]
        [Route("UpdateProperty")]
        public ActionResult<bool> EditProperty(PropertyModel model)
        {
            var response = _PropertyService.EditProperties(model);
            if (response)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }

        [HttpDelete]
  //      [Route("DeleteProperty/{IdProperty}")]
  //    [Route("GetNomDivision/{strEmployeeId}")]
        public ActionResult<bool> DeleteProperty(int IdProperty)         	
        {
            var response = _PropertyService.DeleteProperties(IdProperty);
            if (response)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }
    }
}