using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Vaskelista.Models
{
    public class VaskelistaContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Household> Households { get; set; }
    }
}