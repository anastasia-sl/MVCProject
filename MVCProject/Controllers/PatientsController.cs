//using System.Linq;
//using MVCProject.Models;
//using System.Web.Mvc;

//namespace MVCProject.Controllers
//{
//    public class PatientsController : Controller
//    {
//        // GET: Patients
//        public ActionResult View()
//        {
//            PatientsRepository repository = new PatientsRepository();
//            return View(repository.GetPatients());
//        }

//        //ADD
//        public ActionResult Add()
//        {
//            return View(new Patient());
//        }

//        [HttpPost]
//        public ActionResult Add(Patient patient)
//        {
//            if (ModelState.IsValid)
//            {
//                PatientsRepository repository = new PatientsRepository();
//                repository.AddPatient(patient);
//                return RedirectToAction("View");
//            }
//            return View(patient);
//        }

//        // GET: Delete
//        public ActionResult Delete(int id)
//        {
//            PatientsRepository repository = new PatientsRepository();
//            repository.RemovePatient(id);
//            return RedirectToAction("View");
//        }

//        //Filter
//        public ActionResult Filter(string searchString)
//        {
//            PatientsRepository repository = new PatientsRepository();

//            var filteredPatients = repository.GetPatientsByName(searchString);
//            return View("View", filteredPatients);
//        }

//        // Edit
//        public ActionResult Edit(int id)
//        {
//            PatientsRepository repository = new PatientsRepository();

//            var patient = repository.GetPatientById(id);
//            if (patient == null)
//            {
//                return HttpNotFound();
//            }
//            return View(patient);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(Patient patient)
//        {
//            PatientsRepository repository = new PatientsRepository();

//            if (ModelState.IsValid)
//            {
//                repository.UpdatePatient(patient);
//                return RedirectToAction("View");
//            }
//            return View(patient);
//        }
//    }
//}

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class PatientsController : Controller
    {
        private readonly HttpClient _client;

        public PatientsController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new System.Uri("https://localhost:44362/");
        }

        public async Task<ActionResult> View(string searchString)
        {
            IEnumerable<Patient> patients = null;
            HttpResponseMessage response = await _client.GetAsync("api/patients");

            if (response.IsSuccessStatusCode)
            {
                patients = await response.Content.ReadAsAsync<IEnumerable<Patient>>();
            }
            else
            {
                patients = new List<Patient>();
                ModelState.AddModelError(string.Empty, "Server error.");
            }

            return View(patients);
        }

        // DELETE
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"api/patients/{id}");

            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Patient deleted successfully.";
            }
            else
            {
                TempData["Error"] = "Failed to delete patient.";
            }

            return RedirectToAction("View");
        }

        // Filter
        public async Task<ActionResult> Filter(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return RedirectToAction("View");
            }

            HttpResponseMessage response = await _client.GetAsync($"api/patients?name={searchString}");

            if (response.IsSuccessStatusCode)
            {
                var patients = await response.Content.ReadAsAsync<IEnumerable<Patient>>();
                return View("View", patients);
            }
            else
            {
                TempData["Error"] = "Failed to retrieve filtered patients.";
                return RedirectToAction("View");
            }
        }

        // POST: Patients/Add
        [HttpPost]
        public async Task<ActionResult> Add(Patient patient)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("api/patients", patient);

            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Patient added successfully.";
                return RedirectToAction("View");
            }
            else
            {
                TempData["Error"] = "Failed to add patient.";
                return View(patient);
            }
        }

        // GET: Patients/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"api/patients/{id}");

            if (response.IsSuccessStatusCode)
            {
                var patient = await response.Content.ReadAsAsync<Patient>();
                return View(patient);
            }
            else
            {
                TempData["Error"] = "Failed to retrieve patient.";
                return RedirectToAction("View");
            }
        }

        // POST: Patients/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Patient patient)
        {
            HttpResponseMessage response = await _client.PutAsJsonAsync($"api/patients/{id}", patient);

            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Patient updated successfully.";
                return RedirectToAction("View");
            }
            else
            {
                TempData["Error"] = "Failed to update patient.";
                return View(patient);
            }
        }

    }
}
