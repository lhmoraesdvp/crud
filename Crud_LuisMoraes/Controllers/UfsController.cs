using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Crud_LuisMoraes.Models;

namespace Crud_LuisMoraes.Controllers
{
    public class UfsController : Controller
    {
        private DB db = new DB();

        // GET: Ufs
        public ActionResult Index()
        {
            return View(db.Uf.ToList());
        }

        // GET: Ufs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uf uf = db.Uf.Find(id);
            if (uf == null)
            {
                return HttpNotFound();
            }
            return View(uf);
        }

        // GET: Ufs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ufs/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,estado,sigla")] Uf uf)
        {
            if (ModelState.IsValid)
            {
                db.Uf.Add(uf);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uf);
        }

        // GET: Ufs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uf uf = db.Uf.Find(id);
            if (uf == null)
            {
                return HttpNotFound();
            }
            return View(uf);
        }

        // POST: Ufs/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,estado,sigla")] Uf uf)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uf).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uf);
        }

        // GET: Ufs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uf uf = db.Uf.Find(id);
            if (uf == null)
            {
                return HttpNotFound();
            }
            return View(uf);
        }

        // POST: Ufs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uf uf = db.Uf.Find(id);
            db.Uf.Remove(uf);
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
