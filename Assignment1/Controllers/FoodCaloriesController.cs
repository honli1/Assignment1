using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment1.Models;
using Microsoft.AspNet.Identity;

namespace Assignment1.Controllers
{
    public class FoodCaloriesController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: FoodCalories
        public ActionResult Index()
        {
            return View(db.FoodCalories.ToList());
        }

        // GET: FoodCalories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodCalorie foodCalorie = db.FoodCalories.Find(id);
            if (foodCalorie == null)
            {
                return HttpNotFound();
            }
            return View(foodCalorie);
        }

        // GET: FoodCalories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodCalories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,FoodCatergory,CalorieAmount")] FoodCalorie foodCalorie)
        {
            foodCalorie.UserId = User.Identity.GetUserId();
            ModelState.Clear();
            TryValidateModel(foodCalorie);
            if (ModelState.IsValid)
            {
                db.FoodCalories.Add(foodCalorie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(foodCalorie);
        }

        // GET: FoodCalories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodCalorie foodCalorie = db.FoodCalories.Find(id);
            if (foodCalorie == null)
            {
                return HttpNotFound();
            }
            return View(foodCalorie);
        }

        // POST: FoodCalories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FoodCatergory,CalorieAmount,UserId")] FoodCalorie foodCalorie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodCalorie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foodCalorie);
        }

        // GET: FoodCalories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodCalorie foodCalorie = db.FoodCalories.Find(id);
            if (foodCalorie == null)
            {
                return HttpNotFound();
            }
            return View(foodCalorie);
        }

        // POST: FoodCalories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FoodCalorie foodCalorie = db.FoodCalories.Find(id);
            db.FoodCalories.Remove(foodCalorie);
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
