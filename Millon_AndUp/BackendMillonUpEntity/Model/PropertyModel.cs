using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BackendMillonUpEntity.Model
{
    public class PropertyModel
    {
        [Key]
        public int IdProperty { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public int? Stratum { get; set; }
        public int? YearsConstruction { get; set; }
        public double? Tax { get; set; }
        public double? Price { get; set; }
        public string ImagePath { get; set; }
        public int? IdOwner { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile  { get; set; }
    }
}
