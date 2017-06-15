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
    public class SinhvienController : Controller
    {
        private ISchoolEntities db = new ISchoolEntities();

        // GET: Sinhvien
        public ActionResult Danhsachsinhvien(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 6;
            var sinhviens = db.Sinhviens.Include(s => s.Chuyennganh);
            return View(sinhviens.ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Sinhvien/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sinhvien sinhvien = db.Sinhviens.Find(id);
            if (sinhvien == null)
            {
                return HttpNotFound();
            }
            return View(sinhvien);
        }

        // GET: Sinhvien/Create
        public ActionResult Create()
        {
            ViewBag.MACN = new SelectList(db.Chuyennganhs, "MACN", "TENCN");
            return View();
        }

        // POST: Sinhvien/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MASV,HOSV,TENSV,ANHDAIDIEN,QUEQUAN,NGAYSINHSV,CMNDSV,DIEM_TBTL,SDTSV,SDT_PHUHUYNH,EMAIL,DIACHI_SV,DIACHI_THUONGTRU,GIOITINH,TRANGTHAISV,MACN")] Sinhvien sinhvien)
        {
            if (ModelState.IsValid)
            {
                db.Sinhviens.Add(sinhvien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MACN = new SelectList(db.Chuyennganhs, "MACN", "TENCN", sinhvien.MACN);
            return View(sinhvien);
        }

        // GET: Sinhvien/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sinhvien sinhvien = db.Sinhviens.Find(id);
            if (sinhvien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MACN = new SelectList(db.Chuyennganhs, "MACN", "TENCN", sinhvien.MACN);
            return View(sinhvien);
        }

        // POST: Sinhvien/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MASV,HOSV,TENSV,ANHDAIDIEN,QUEQUAN,NGAYSINHSV,CMNDSV,DIEM_TBTL,SDTSV,SDT_PHUHUYNH,EMAIL,DIACHI_SV,DIACHI_THUONGTRU,GIOITINH,TRANGTHAISV,MACN")] Sinhvien sinhvien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sinhvien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MACN = new SelectList(db.Chuyennganhs, "MACN", "TENCN", sinhvien.MACN);
            return View(sinhvien);
        }

        // GET: Sinhvien/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sinhvien sinhvien = db.Sinhviens.Find(id);
            if (sinhvien == null)
            {
                return HttpNotFound();
            }
            return View(sinhvien);
        }

        // POST: Sinhvien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Sinhvien sinhvien = db.Sinhviens.Find(id);
            db.Sinhviens.Remove(sinhvien);
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
