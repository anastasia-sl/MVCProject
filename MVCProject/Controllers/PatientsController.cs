//using System.Configuration;
using System.Linq;
using MVCProject.Models;
using System.Web.Mvc;
//using MVCProject.Models;
//using System.Data.Entity;

namespace MVCProject.Controllers
{
    public class PatientsController : Controller
    {
        // GET: Patients
        public ActionResult View()
        {
            PatientsRepository repository = new PatientsRepository();
            return View(repository.GetPatients());
        }

        //ADD
        public ActionResult Add()
        {
            return View(new Patient());
        }

        [HttpPost]
        public ActionResult Add(Patient patient)
        {
            if (ModelState.IsValid)
            {
                PatientsRepository repository = new PatientsRepository();
                repository.AddPatient(patient);
                return RedirectToAction("View");
            }
            return View(patient);
        }

        // GET: Delete
        public ActionResult Delete(int id)
        {
            PatientsRepository repository = new PatientsRepository();
            repository.RemovePatient(id);
            return RedirectToAction("View");
        }

        //Filter
        public ActionResult Filter(string searchString)
        {
            PatientsRepository repository = new PatientsRepository();

            var filteredPatients = repository.GetPatientsByName(searchString);
            return View("View", filteredPatients);
        }

        // Edit
        public ActionResult Edit(int id)
        {
            PatientsRepository repository = new PatientsRepository();

            var patient = repository.GetPatientById(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Patient patient)
        {
            PatientsRepository repository = new PatientsRepository();

            if (ModelState.IsValid)
            {
                repository.UpdatePatient(patient);
                return RedirectToAction("View");
            }
            return View(patient);
        }



        //        // Добавление пациента
        //        [HttpGet]
        //        public ActionResult Create()
        //        {
        //            return View();
        //        }

        //        [HttpPost]
        //        public ActionResult Create(Patient patient)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                _context.Patients.Add(patient);
        //                _context.SaveChanges();
        //                return RedirectToAction("Index");
        //            }
        //            return View(patient);
        //        }

        //        // Редактирование пациента
        //        [HttpGet]
        //        public ActionResult Edit(int id)
        //        {
        //            var patient = _context.Patients.Find(id);
        //            if (patient == null)
        //                return HttpNotFound();
        //            return View(patient);
        //        }

        //        [HttpPost]
        //        public ActionResult Edit(Patient patient)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                _context.Entry(patient).State = EntityState.Modified;
        //                _context.SaveChanges();
        //                return RedirectToAction("Index");
        //            }
        //            return View(patient);
        //        }

        //        // Удаление пациента
        //        public ActionResult Delete(int id)
        //        {
        //            var patient = _context.Patients.Find(id);
        //            if (patient == null)
        //                return HttpNotFound();
        //            _context.Patients.Remove(patient);
        //            _context.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //        [HttpPost]
        //        public ActionResult Filter(string searchString)
        //        {
        //            var filteredPatients = _context.Patients.Where(p => p.Name.Contains(searchString)).ToList();
        //            return View("Index", filteredPatients);
        //        }

        //        protected override void Dispose(bool disposing)
        //        {
        //            if (disposing)
        //            {
        //                _context.Dispose();
        //            }
        //            base.Dispose(disposing);
        //        }
    }
}
