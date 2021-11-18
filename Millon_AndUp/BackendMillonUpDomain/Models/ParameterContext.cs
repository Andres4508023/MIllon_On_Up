using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using BackendMillonUpDomain.Models;

namespace BackendMillonUpDomain.Models
{
    public  class ParameterContext : DbContext
    {
        public ParameterContext(DbContextOptions<ParameterContext> options) : base(options)
        {
        }

        //public DbSet<Property> dsProperty { get; set; }
        public DbSet<Owner> dsOwner { get; set; }
        public DbSet<RtaOwner> dsRtaOwner { get; set; }

    }
}
