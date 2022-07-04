using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMeterPro.Models
{
    public class SMDBContext : DbContext
    {
        public SMDBContext()
        {

        }
        public SMDBContext(DbContextOptions<SMDBContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Bills> bills { get; set; }
        public virtual DbSet<Users> users { get; set; }
        public virtual DbSet<Complaints> complaints { get; set; }
        public virtual DbSet<Vendors> vendors { get; set; }
        public virtual DbSet<UserLocations> userlocation { get; set; }
        public virtual DbSet<SmartMeter> smartmeter { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserLocations>().ToTable("UserLocations");
        }
        //public IEnumerable<Bills> PostBills(Bills bill)
        //{
        //    return bills.FromSqlRaw(bill.ConsumerEmailId).AsEnumerable();
        //}
    }
}
