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
    public class EstabelecimentosController : Controller
    {
        private DB db = new DB();

        // GET: Estabelecimentos
        public ActionResult Index()
        {
            var estabelecimentos = db.Estabelecimentos.Include(e => e.Categorias).Include(e => e.Uf);
            return View(estabelecimentos.ToList());
        }

        // GET: Estabelecimentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estabelecimentos estabelecimentos = db.Estabelecimentos.Find(id);
            if (estabelecimentos == null)
            {
                return HttpNotFound();
            }
            return View(estabelecimentos);
        }

        // GET: Estabelecimentos/Create
        public ActionResult Create()
        {
            ViewBag.categoriaId = new SelectList(db.Categorias, "id", "categoria");
            ViewBag.ufId = new SelectList(db.Uf, "id", "estado");
            return View();
        }

        // POST: Estabelecimentos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cnpj,razaoSocial,nomeFantasia,categoriaId,status,dataCadastro,ufId,cidade,bairro,cep,logradouro,numero,email,telefone")] Estabelecimentos estabelecimentos)
        {
            estabelecimentos.dataCadastro = DateTime.Now.Date;
            if (ModelState.IsValid)
            {
                db.Estabelecimentos.Add(estabelecimentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoriaId = new SelectList(db.Categorias, "id", "categoria", estabelecimentos.categoriaId);
            ViewBag.ufId = new SelectList(db.Uf, "id", "estado", estabelecimentos.ufId);
            return View(estabelecimentos);
        }

        // GET: Estabelecimentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estabelecimentos estabelecimentos = db.Estabelecimentos.Find(id);
            if (estabelecimentos == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoriaId = new SelectList(db.Categorias, "id", "categoria", estabelecimentos.categoriaId);
            ViewBag.ufId = new SelectList(db.Uf, "id", "estado", estabelecimentos.ufId);
            return View(estabelecimentos);
        }

        // POST: Estabelecimentos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cnpj,razaoSocial,nomeFantasia,categoriaId,status,dataCadastro,ufId,cidade,bairro,cep,logradouro,numero,email,telefone")] Estabelecimentos estabelecimentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estabelecimentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoriaId = new SelectList(db.Categorias, "id", "categoria", estabelecimentos.categoriaId);
            ViewBag.ufId = new SelectList(db.Uf, "id", "estado", estabelecimentos.ufId);
            return View(estabelecimentos);
        }

        // GET: Estabelecimentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estabelecimentos estabelecimentos = db.Estabelecimentos.Find(id);
            if (estabelecimentos == null)
            {
                return HttpNotFound();
            }
            return View(estabelecimentos);
        }

        // POST: Estabelecimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estabelecimentos estabelecimentos = db.Estabelecimentos.Find(id);
            db.Estabelecimentos.Remove(estabelecimentos);
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
