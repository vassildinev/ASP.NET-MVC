namespace SocializR.Web.App.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using SocializR.Data;
    using SocializR.Data.Models;

    [Authorize(Roles = "Admin")]
    public class ShoutsController : Controller
    {
        private SocializRDbContext db = new SocializRDbContext();

        // GET: Shouts
        public ActionResult Index()
        {
            var shouts = db.Shouts.Include(s => s.Author);
            return View(shouts.ToList());
        }

        // GET: Shouts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shout shout = db.Shouts.Find(id);
            if (shout == null)
            {
                return HttpNotFound();
            }
            return View(shout);
        }

        // GET: Shouts/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: Shouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Content,AuthorId")] Shout shout)
        {
            if (ModelState.IsValid)
            {
                db.Shouts.Add(shout);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FirstName", shout.AuthorId);
            return View(shout);
        }

        // GET: Shouts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shout shout = db.Shouts.Find(id);
            if (shout == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FirstName", shout.AuthorId);
            return View(shout);
        }

        // POST: Shouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Content,AuthorId")] Shout shout)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shout).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FirstName", shout.AuthorId);
            return View(shout);
        }

        // GET: Shouts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shout shout = db.Shouts.Find(id);
            if (shout == null)
            {
                return HttpNotFound();
            }
            return View(shout);
        }

        // POST: Shouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shout shout = db.Shouts.Find(id);
            db.Shouts.Remove(shout);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
