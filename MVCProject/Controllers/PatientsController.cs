using System.Collections.Generic;
using System.Web.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class PatientsController : Controller
    {
        // GET: Patients
        public ActionResult Index()
        {
            List<Patient> patients = new List<Patient>
            {
                new Patient { Id = 1, Name = "John" },
                new Patient { Id = 2, Name = "Kate" }
            };

            return View(patients);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            return RedirectToAction("Index");
        }

        // GET: Patients/Edit/1
        public ActionResult Edit(int id)
        {
            Patient patient = new Patient { Id = id, Name = "John Doe" };

            return View(patient);
        }

        // POST: Patients/Edit/1
        [HttpPost]
        public ActionResult Edit(int id, Patient patient)
        {
            return RedirectToAction("Index");
        }

        // GET: Patients/Delete/1
        public ActionResult Delete(int id)
        {
            Patient patient = new Patient { Id = id, Name = "John Doe" };

            return View(patient);
        }

        // POST: Patients/Delete/1
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            return RedirectToAction("Index");
        }
    }
}
