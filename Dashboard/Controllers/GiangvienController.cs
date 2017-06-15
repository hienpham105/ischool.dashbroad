using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dashboard.Models;
using PagedList;
using PagedList.Mvc;

namespace Dashboard.Controllers
{
    public class GiangvienController : Controller
    {
        private ISchoolEntities db = new ISchoolEntities();

        // GET: Giangvien
        public ActionResult Danhsachgiangvien(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 6;
            var giangviens = db.Giangviens.Include(g => g.Chucvu).Include(g => g.Chuyennganh).Include(g => g.Donvi).Include(g => g.Hocvi);
            return View(giangviens.ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Giangvien/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giangvien giangvien = db.Giangviens.Find(id);
            if (giangvien == null)
            {
                return HttpNotFound();
            }
            return View(giangvien);
        }

        // GET: Giangvien/Create
        public ActionResult Create()
        {
            ViewBag.MACV = new SelectList(db.Chucvus, "MACV", "TENCV");
            ViewBag.MACN = new SelectList(db.Chuyennganhs, "MACN", "TENCN");
            ViewBag.MADV = new SelectList(db.Donvis, "MADV", "TENDV");
            ViewBag.MAHV = new SelectList(db.Hocvis, "MAHV", "TENHV");
            return View();
        }

        // POST: Giangvien/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAGV,HOGV,TENGV,QUEQUAN,ANHDAIDIEN,NGAYSINH,CMND,EMAIL,SDT,DIACHI,GIOITINH,MOTA,TRANGTHAIGV,MADV,MACV,MAHV,MACN")] Giangvien giangvien)
        {
            if (ModelState.IsValid)
            {
                db.Giangviens.Add(giangvien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MACV = new SelectList(db.Chucvus, "MACV", "TENCV", giangvien.MACV);
            ViewBag.MACN = new SelectList(db.Chuyennganhs, "MACN", "TENCN", giangvien.MACN);
            ViewBag.MADV = new SelectList(db.Donvis, "MADV", "TENDV", giangvien.MADV);
            ViewBag.MAHV = new SelectList(db.Hocvis, "MAHV", "TENHV", giangvien.MAHV);
            return View(giangvien);
        }

        // GET: Giangvien/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giangvien giangvien = db.Giangviens.Find(id);
            if (giangvien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MACV = new SelectList(db.Chucvus, "MACV", "TENCV", giangvien.MACV);
            ViewBag.MACN = new SelectList(db.Chuyennganhs, "MACN", "TENCN", giangvien.MACN);
            ViewBag.MADV = new SelectList(db.Donvis, "MADV", "TENDV", giangvien.MADV);
            ViewBag.MAHV = new SelectList(db.Hocvis, "MAHV", "TENHV", giangvien.MAHV);
            return View(giangvien);
        }

        // POST: Giangvien/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAGV,HOGV,TENGV,QUEQUAN,ANHDAIDIEN,NGAYSINH,CMND,EMAIL,SDT,DIACHI,GIOITINH,MOTA,TRANGTHAIGV,MADV,MACV,MAHV,MACN")] Giangvien giangvien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giangvien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MACV = new SelectList(db.Chucvus, "MACV", "TENCV", giangvien.MACV);
            ViewBag.MACN = new SelectList(db.Chuyennganhs, "MACN", "TENCN", giangvien.MACN);
            ViewBag.MADV = new SelectList(db.Donvis, "MADV", "TENDV", giangvien.MADV);
            ViewBag.MAHV = new SelectList(db.Hocvis, "MAHV", "TENHV", giangvien.MAHV);
            return View(giangvien);
        }

        // GET: Giangvien/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giangvien giangvien = db.Giangviens.Find(id);
            if (giangvien == null)
            {
                return HttpNotFound();
            }
            return View(giangvien);
        }

        // POST: Giangvien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Giangvien giangvien = db.Giangviens.Find(id);
            db.Giangviens.Remove(giangvien);
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
