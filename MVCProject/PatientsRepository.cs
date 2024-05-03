using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MVCProject.Models;
using System.Data.Entity;

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

        public void AddPatient(Patient patient)
        {
            context.Patients.Add(patient);
            context.SaveChanges();
        }

        public void RemovePatient(int id)
        {
            var patientToRemove = context.Patients.FirstOrDefault(p => p.Id == id);
            if (patientToRemove != null)
            {
                context.Patients.Remove(patientToRemove);
                context.SaveChanges();
            }
        }

        public IEnumerable<Patient> GetPatientsByName(string name)
        {
            return context.Patients.Where(p => p.Name.Contains(name)).ToList();
        }

        public void UpdatePatient(Patient patient)
        {
            context.Entry(patient).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}