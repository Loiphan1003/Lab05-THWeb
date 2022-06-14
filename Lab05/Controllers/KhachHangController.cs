using Lab05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab05.Controllers
{
    public class KhachHangController : Controller
    {

        // GET: KhachHang
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(KhachHang khachHang)
        {
            DataContext data = new DataContext();
            data.KhachHang.Add(khachHang);
            data.SaveChanges();
            return RedirectToAction("Rubik/Index");
        }

        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(KhachHang khachHang)
        {
            DataContext data = new DataContext();
            KhachHang kh = data.KhachHang.SingleOrDefault(n => n.tendangnhap.Equals(khachHang.tendangnhap) && n.matkhau.Equals(khachHang.matkhau));

            if(kh == null)
            {
                return View();
            }
            Session["User"] = kh;
            return RedirectToAction("Index","Home");
        }


        public ActionResult KhachHangPartial()
        {
            return PartialView();
        }

        public ActionResult DangNhapPartial()
        {
            return PartialView();
        }
    }
}