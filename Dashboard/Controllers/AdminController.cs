using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dashboard.Models;

namespace Dashboard.Controllers
{
    public class AdminController : Controller
    {
        ISchoolEntities db = new ISchoolEntities();
        public ActionResult Index()
        {
            return View();
        }
        // GET: Admin
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            //Gan gia tri nguoi dung
            var tendn = collection["username"];
            var matkhau = collection["password"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Moi nhap ten nguoi dung";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Moi nhap mat khau";
            }
            else
            {
                //Gan gia tri cho doi tuong tao moi
                Nguoidung nd = db.Nguoidungs.SingleOrDefault(n => n.TENND == tendn && n.MATKHAU == matkhau);
                if(nd != null)
                {
                    //Thong bao dang nhap thanh cong
                    Session["TKAdmin"] = nd;
                    return RedirectToAction("Index", "Admin");
                }
                else { ViewBag.Thongbao = "Ten dang nhap|mat khau chua dung, vui long kiem tra lai"; }
            }
            return View();

        }
    }
}