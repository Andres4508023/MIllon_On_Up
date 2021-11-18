using System;
using System.Collections.Generic;

namespace DomainBD.Domain
{
    public partial class Owner
    {
        public int IdOwner { get; set; }
        public string NamesOwner { get; set; }
        public string AdressOwner { get; set; }
        public int? Age { get; set; }
        public int? Telephone { get; set; }
        public string Email { get; set; }
    }
}
