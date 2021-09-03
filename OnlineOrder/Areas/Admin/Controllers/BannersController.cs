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
    public class BannersController : Controller
    {
        private OnlineOrdersEntities db = new OnlineOrdersEntities();

        // GET: Admin/Banners
        public ActionResult Index(int? page, string searchString)
        {
            // 1. Tham số int? dùng để thể hiện null và kiểu int
            // page có thể có giá trị là null và kiểu int.
            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;
            // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy theo ID mới có thể phân trang.
            var links = (from l in db.Banners select l).OrderBy(x => x.Id);
            // 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            int pageSize = 2;
            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);
            if (searchString != null)
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    ///tạo truy vấn theo trường Description có chứa chuỗi searchString 
                    links = (IOrderedQueryable<Banner>)links.Where(s => s.Description.Contains(searchString));
                }
                return View(links.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return View(links.ToPagedList(pageNumber, pageSize));
            }
        }

        // GET: Admin/Banners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banner banner = db.Banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        // GET: Admin/Banners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Banners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Sort,Description")] Banner banner, HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                string fileName = System.IO.Path.GetFileName(image.FileName);
                //stored image
                string urlImage = Server.MapPath("~/ImageStored/Banners/" + fileName);
                image.SaveAs(urlImage);
                //url
                banner.Image = "~/ImageStored/Banners/" + fileName;
            }
            if (ModelState.IsValid)
            {
                db.Banners.Add(banner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(banner);
        }

        // GET: Admin/Banners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banner banner = db.Banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        // POST: Admin/Banners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Sort,Description")] Banner banner, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null && image.ContentLength > 0)
                {
                    string fileName = System.IO.Path.GetFileName(image.FileName);
                    //stored image
                    string urlImage = Server.MapPath("~/ImageStored/Banners/" + fileName);
                    image.SaveAs(urlImage);
                    //url
                    banner.Image = "~/ImageStored/Banners/" + fileName;
                }
                db.Entry(banner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(banner);
        }

        // GET: Admin/Banners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banner banner = db.Banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        // POST: Admin/Banners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Banner banner = db.Banners.Find(id);
            db.Banners.Remove(banner);
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
