using FMT.Areas.Identity.Data;
using FMT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FMT.Controllers
{
    public class MailTrackerController : Controller
    {
        private readonly AppDbContext _db;

        public MailTrackerController(AppDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            var output = _db.MailTrackers.Include(X => X.Documents).ToList();
            return View(output);
        }

        public IActionResult Create()
        {
            ViewBag.Documents = new SelectList(_db.Documents, "Id", "DocumentType");
            return View();

        }


        [HttpPost]
        public IActionResult Create(MailTracker mail)
        {
            if (string.IsNullOrEmpty(mail.ReferenceNo))
            {
                TempData["error"] = "Name field is required";
                ViewBag.Documents = new SelectList(_db.Documents, "Id", "DocumentType", mail.DocumentId);
                return View(mail);
            }
            _db.MailTrackers.Add(mail);
            _db.SaveChanges();
            TempData["success"] = "Mail Register Created Succesfully";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var mail = _db.MailTrackers.Find(id);
            if (mail == null)
            {
                return NotFound();

            }

            ViewBag.Documents = new SelectList(_db.Documents, "Id", "DocumentType", mail.DocumentId);
            return View(mail);
        }

        [HttpPost]
        public IActionResult Edit(MailTracker mail, int id)
        {
            if (id != mail.Id)
            {
                return NotFound();
            }
            if (string.IsNullOrEmpty(mail.ReferenceNo))
            {
                _db.MailTrackers.Update(mail);
                _db.SaveChanges();
                TempData["success"] = "Mail Register Updated Succesfully";
                ViewBag.Documents = new SelectList(_db.Documents, "Id", "DocumentType", mail.DocumentId);
                return RedirectToAction(nameof(Index));
            }
            _db.MailTrackers.Update(mail);
            _db.SaveChanges();
            TempData["success"] = " Updated Succesfully";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mail = _db.MailTrackers.Include(x => x.Documents).FirstOrDefault(X => X.Id == id);
            if (mail == null)
            {
                return NotFound();
            }
            ViewBag.Documents = new SelectList(_db.Documents, "Id", "DocumentType", mail.DocumentId);

            return View(mail);
        }

        public IActionResult Delete(int Id)
        {
            if (Id == null)
            {
                return NotFound();

            }

            var mail = _db.MailTrackers.FirstOrDefault(X => X.Id == Id);
            if (mail == null)
            {
                return NotFound();
            }
            return View(mail);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int Id)
        {
            var mail = _db.MailTrackers.Find(Id);
            _db.MailTrackers.Remove(mail);
            _db.SaveChanges();
            TempData["success"] = "Mail Register Deleted Succesfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
