using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendMillonUpEntity.Domain
{
    public partial class Property
    {
      //  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdProperty { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public int? Stratum { get; set; }
        public int? YearsConstruction { get; set; }
        public double? Tax { get; set; }
        public double? Price { get; set; }
        public string ImagePath { get; set; }
        public int? IdOwner { get; set; }
    }
}
