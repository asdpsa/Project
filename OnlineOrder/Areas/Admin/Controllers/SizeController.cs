using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Net;
using OnlineOrder.Models;

namespace OnlineOrder.Areas.Admin.Controllers
{
    public class SizeController : Controller
    {
        OnlineOrdersEntities db = new OnlineOrdersEntities();
        // GET: Admin/Size
        public ActionResult Index(int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(db.Sizes.ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Size/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Size sz = db.Sizes.Find(id);
            if (sz == null)
            {
                return HttpNotFound();
            }
            return View(sz);
        }

        // GET: Admin/Size/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Size/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Size sz)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.Sizes.Add(sz);
                    db.SaveChanges();
                    ViewBag.succcess = "Successfully deleted information !";
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(sz);
            }
        }

        // GET: Admin/Size/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Size/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Size model)
        {
            // TODO: Add update logic here
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sz = db.Sizes.Find(id);
            if (TryUpdateModel(sz,"", new string[] {"Size1","Price"}))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Update failed, please try again !");
                }
            }
                return View();
        }

        // GET: Admin/Size/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed, please try again !";
            }
            Size sz = db.Sizes.Find(id);
            if (sz == null)
            {
                return HttpNotFound();
            }
            return View(sz);
        }

        // POST: Admin/Size/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Size sz = db.Sizes.Find(id);
                db.Sizes.Remove(sz);
                db.SaveChanges();

                ViewBag.Succcess = "Successfully deleted information !";
            }
            catch
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
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
