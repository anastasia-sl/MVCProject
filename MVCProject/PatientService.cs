//using MVCProject.Models;
//using System.Collections.Generic;
//using System.Linq;

//namespace MVCProject
//{
//    public class PatientService
//    {
//        private List<Patient> _patients;

//        public PatientService()
//        {
//            _patients = new List<Patient>();
//        }

//        public List<Patient> GetAllPatients()
//        {
//            return _patients;
//        }

//        public void AddPatient(Patient patient)
//        {
//            patient.Id = _patients.Any() ? _patients.Max(p => p.Id) + 1 : 1;
//            _patients.Add(patient);
//        }

//        public void UpdatePatient(Patient patient)
//        {
//            var existingPatient = _patients.FirstOrDefault(p => p.Id == patient.Id);
//            if (existingPatient != null)
//            {
//                existingPatient.Name = patient.Name;
//                // Обновите другие свойства пациента по необходимости
//            }
//        }

//        public void DeletePatient(int id)
//        {
//            var patientToRemove = _patients.FirstOrDefault(p => p.Id == id);
//            if (patientToRemove != null)
//            {
//                _patients.Remove(patientToRemove);
//            }
//        }
//    }
//}