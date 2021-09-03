using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineOrder;
using OnlineOrder.Models;
using PagedList;

namespace OnlineOrder.Areas.Admin.Controllers
{
    public class AdvertisementsController : Controller
    {
        private OnlineOrdersEntities db = new OnlineOrdersEntities();

        // GET: Admin/Advertisements
        public ActionResult Index(int? page, string searchString)
        {
            // 1. Tham số int? dùng để thể hiện null và kiểu int
            // page có thể có giá trị là null và kiểu int.
            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;
            // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy theo ID mới có thể phân trang.
            var links = (from l in db.Advertisements select l).OrderBy(x => x.Id);
            // 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            int pageSize = 2;
            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);
            if (searchString != null)
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    ///tạo truy vấn theo trường Key có chứa chuỗi searchString 
                    links = (IOrderedQueryable<Advertisement>)links.Where(s => s.Key.Contains(searchString));
                }
                return View(links.ToPagedList(pageNumber,pageSize));
            }
            else
            {
                return View(links.ToPagedList(pageNumber, pageSize));
            }
        }

        // GET: Admin/Advertisements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisement advertisement = db.Advertisements.Find(id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            return View(advertisement);
        }

        // GET: Admin/Advertisements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Advertisements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Key,Description")] Advertisement advertisement, HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                string fileName = System.IO.Path.GetFileName(image.FileName);
                //stored image
                string urlImage = Server.MapPath("~/ImageStored/Advertisements/" + fileName);
                image.SaveAs(urlImage);
                //url
                advertisement.Image = "~/ImageStored/Advertisements/" + fileName;
            }
            if (ModelState.IsValid)
            {
                db.Advertisements.Add(advertisement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(advertisement);
        }

        // GET: Admin/Advertisements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisement advertisement = db.Advertisements.Find(id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            return View(advertisement);
        }

        // POST: Admin/Advertisements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Key,Description")] Advertisement advertisement,HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null && image.ContentLength > 0)
                {
                    string fileName = System.IO.Path.GetFileName(image.FileName);
                    //stored image
                    string urlImage = Server.MapPath("~/ImageStored/Advertisements/" + fileName);
                    image.SaveAs(urlImage);
                    //url
                    advertisement.Image = "~/ImageStored/Advertisements/" + fileName;
                }
                db.Entry(advertisement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(advertisement);
        }

        // GET: Admin/Advertisements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisement advertisement = db.Advertisements.Find(id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            return View(advertisement);
        }

        // POST: Admin/Advertisements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Advertisement advertisement = db.Advertisements.Find(id);
            db.Advertisements.Remove(advertisement);
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
