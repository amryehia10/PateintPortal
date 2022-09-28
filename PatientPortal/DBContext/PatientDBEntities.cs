using PatientPortal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace PatientPortal.DBContext
{
    public  class PatientDBEntities : DbContext
    {
        //public PatientDBEntities()
        //    : base("name=PatientDBEntities")
        //{
        //}
        public PatientDBEntities() : base(GetOptions())
        {
        }

        private static string GetOptions()
        {
            string con = "Data Source=VOLT\\SQLEXPRESS;Initial Catalog=PatientDB;Integrated Security=True;MultipleActiveResultSets=False";
            return con;
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    throw new UnintentionalCodeFirstException();
        //}

        public DbSet<Country> Countries { get; set; }
        public DbSet<Patientvm> Patients { get; set; }
        public DbSet<Users> User { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}