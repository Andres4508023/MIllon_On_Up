using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainBD.Domain;
using DomainBD.Models;
using LibService.PropertyService;
using LibService.OwnerService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MillonAndUpFront.Controllers
{
    public class PropertyConsumeController : Controller
    {
        private readonly IPropertyService _propertyService;
        private readonly IOwnerService _ownerService;
        private readonly MillionOnUpContext _context;
        private readonly IHostingEnvironment _hostenvironment;

        public PropertyConsumeController(IPropertyService propertyService, IOwnerService ownerService, MillionOnUpContext context, IHostingEnvironment hostenvironment)
        {
            _propertyService = propertyService;
            _ownerService = ownerService;
            _context = context;
            this._hostenvironment = hostenvironment;
        }

        public async Task<IActionResult> ListProperties()
        {
            var list = await _propertyService.GetPropertiesList();
            ViewBag.List = list;
            return View(list);
        }

        public async Task<IActionResult> ListOwner()
        {
            var list = await _ownerService.GetOwnersList();
            ViewBag.ListOwnerId = list;
            return View(list);
        }

        public async Task<IActionResult> UpdateOwner(int IdOwner)
        {

            var ModelOwnerId = await _context.Owner.FindAsync(IdOwner);
        
            if (ModelOwnerId == null)
            {
                return NotFound();
            }

            return View(ModelOwnerId);
            
        }

        public IActionResult CreateOwner()
        {
            return View();
        }

        public async Task<IActionResult> DeleteProperty(int id)
        {
            var response = await _propertyService.DeleteProperty(id);

            return RedirectToAction(nameof(ListProperties));
        }

        public async Task <IActionResult> CreateProperty()
        {
            List<Owner> listOwner = await _ownerService.GetOwnersList();
            ViewBag.listOwner = new SelectList(listOwner, "IdOwner", "NamesOwner");
            PropertyModel model = new PropertyModel();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProperty(PropertyModel model)
        {
            bool response = await _propertyService.SaveProperty(model);

            return RedirectToAction("ListProperties");
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwner(Owner model)
        {
            bool response = await _ownerService.SaveOwner(model);

            return RedirectToAction("ListOwner");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOwnerPost(Owner model)
        {
            bool response = await _ownerService.UpdateOwner(model);

            return RedirectToAction("ListProperties");
        }

        public async Task<IActionResult> EditProperty(int id)
        {
            var property_ = await _context.Property.FindAsync(id);
            List<Owner> listOwner = await _ownerService.GetOwnersList();
            ViewBag.listOwner = new SelectList(listOwner, "IdOwner", "NamesOwner");

            if (property_ == null)
            {
                return NotFound();
            }
            return View(property_);
        }

        [HttpPost]
        public async Task<IActionResult> EditProperty(PropertyModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool response = await _propertyService.UpdateProperty(model);
                }
                return RedirectToAction("ListProperties");
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwnerSave(Owner model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool response = await _ownerService.SaveOwner(model);
                }
                return RedirectToAction("ListProperties");
            }
               
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
         
     }
}