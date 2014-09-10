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
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ScheduleElement> ScheduleElements { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ScheduleElement>().HasRequired(s => s.Activity).WithOptional();
            modelBuilder.Entity<Household>().HasMany(s => s.ScheduleElements).WithRequired();
        }
    }
}