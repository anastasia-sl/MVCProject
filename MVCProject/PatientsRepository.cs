using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MVCProject.Models;

namespace MVCProject
{
    public class PatientsRepository
    {
        private PatientContext context;

        public PatientsRepository()
        {
            context = new PatientContext(ConfigurationManager.ConnectionStrings[0].ConnectionString);
        }

        public IEnumerable<Patient> GetPatients()
        {
            return context.Patients;
        }

        public Patient GetPatientById(int id)
        {
            return context.Patients.FirstOrDefault(p => p.Id == id);
        }
    }
}