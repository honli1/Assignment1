using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment1.Models;

namespace Assignment1.Controllers
{
    public class NutritionAdvicesController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: NutritionAdvices
        public ActionResult Index()
        {
            return View(db.NutritionAdvices.ToList());
        }

        // GET: NutritionAdvices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NutritionAdvice nutritionAdvice = db.NutritionAdvices.Find(id);
            if (nutritionAdvice == null)
            {
                return HttpNotFound();
            }
            return View(nutritionAdvice);
        }

        // GET: NutritionAdvices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NutritionAdvices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AdviceTitle,AdviceContent")] NutritionAdvice nutritionAdvice, HttpPostedFileBase
postedFile)
        {
            ModelState.Clear();
            var myUniqueFileName = string.Format(@"{0}", Guid.NewGuid());
            nutritionAdvice. AdviceImage= myUniqueFileName;
            TryValidateModel(nutritionAdvice);

            if (ModelState.IsValid)
            {
                string serverPath = Server.MapPath("~/Uploads/");
                string fileExtension = Path.GetExtension(postedFile.FileName);
                string filePath = nutritionAdvice.AdviceImage + fileExtension;
                nutritionAdvice.AdviceImage = filePath;
                postedFile.SaveAs(serverPath + nutritionAdvice.AdviceImage);
                db.NutritionAdvices.Add(nutritionAdvice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nutritionAdvice);
        }

        // GET: NutritionAdvices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NutritionAdvice nutritionAdvice = db.NutritionAdvices.Find(id);
            if (nutritionAdvice == null)
            {
                return HttpNotFound();
            }
            return View(nutritionAdvice);
        }

        // POST: NutritionAdvices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AdviceTitle,AdviceContent,AdviceImage")] NutritionAdvice nutritionAdvice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nutritionAdvice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nutritionAdvice);
        }

        // GET: NutritionAdvices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NutritionAdvice nutritionAdvice = db.NutritionAdvices.Find(id);
            if (nutritionAdvice == null)
            {
                return HttpNotFound();
            }
            return View(nutritionAdvice);
        }

        // POST: NutritionAdvices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NutritionAdvice nutritionAdvice = db.NutritionAdvices.Find(id);
            db.NutritionAdvices.Remove(nutritionAdvice);
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
