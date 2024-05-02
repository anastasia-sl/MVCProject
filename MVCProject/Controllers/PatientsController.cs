//using System.Configuration;
//using System.Linq;
using System.Web.Mvc;
//using MVCProject.Models;
//using System.Data.Entity;

namespace MVCProject.Controllers
{
    public class PatientsController : Controller
    {
        //private PatientContext _context = new PatientContext(ConfigurationManager.ConnectionStrings[0].ConnectionString);

        // GET: Patients
        public ActionResult View()
        {
            //var patients = _context.Patients.ToList();
            PatientsRepository repository = new PatientsRepository();
            return View(repository.GetPatients());
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
