using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendMillonUpDomain.Models
{
    public class Owner
    {
        [Key]
        public int IdOwner { get; set; }
        public string NamesOwner { get; set; }
        public string AdressOwner { get; set; }
        public int Age { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }
    }
}
