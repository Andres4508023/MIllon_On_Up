using System;
using System.Collections.Generic;

namespace BackendMillonUpEntity.Domain
{
    public partial class Usuario
    {
        public int IdUser { get; set; }
        public string Users { get; set; }
        public string Password { get; set; }
        public DateTime? DateCreation { get; set; }
        public int? IdProperty { get; set; }
    }
}
