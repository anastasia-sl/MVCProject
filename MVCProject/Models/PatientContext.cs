using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCProject.Models
{
    public class PatientContext : DbContext
    {
        public PatientContext(string connectionString)
        {
            Database.Connection.ConnectionString = connectionString;
        }
        //public PatientContext() : base("PatientsDatabase")
        //{
        //}

        public DbSet<Patient> Patients { get; set; }
    }
}