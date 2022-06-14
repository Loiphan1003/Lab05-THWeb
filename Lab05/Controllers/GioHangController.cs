using Lab05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Lab05.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        DataContext data = new DataContext();

        public List<Giohang> layGioHang()
        {
            List<Giohang> lstGioHang = Session["GioHang"] as List<Giohang>;
            if(lstGioHang == null)
            {
                lstGioHang = new List<Giohang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }

        public ActionResult ThemGioHang(int id,string strURL)
        {
            List<Giohang> lstGioHang = layGioHang();
            Giohang sanPham = lstGioHang.Find(n => n.Id == id);
            if(sanPham == null)
            {
                sanPham = new Giohang(id);
                lstGioHang.Add(sanPham);
                return Redirect(strURL);
            }
            else
            {
                sanPham.SoLuong++;
                return Redirect(strURL);
            }
        }

        private int tongSoLuong()
        {
            int tsl = 0;
            List<Giohang> lstGioHang = Session["GioHang"] as List<Giohang>;
            if(lstGioHang == null)
            {
                tsl = lstGioHang.Sum(n => n.SoLuong);
            }
            return tsl;
        }

        private int tongSoLuongSanPham()
        {
            int tsl = 0;
            List<Giohang> lstGioHang = Session["GioHang"] as List<Giohang>;
            if (lstGioHang != null)
            {
                tsl = lstGioHang.Count();
            }
            return tsl;
        }

        private double tongTien()
        {
            double tt = 0;
            List<Giohang> lstGioHang = Session["GioHang"] as List<Giohang>;
            if (lstGioHang != null)
            {
                tt = lstGioHang.Sum(n => n.ThanhTien);
            }
            return tt;
        }

        public ActionResult GioHang()
        {
            List<Giohang> lstGioHang = layGioHang();
            ViewBag.TongSoLuong = tongSoLuong();
            ViewBag.TongTien = tongTien();
            ViewBag.TongSoLuongSanPham = tongSoLuongSanPham();
            return View(lstGioHang);
        }

        public ActionResult GioHangPartial()
        {
            ViewBag.TongSoLuong = tongSoLuong();
            ViewBag.TongTien = tongTien();
            ViewBag.TongSoLuongSanPham = tongSoLuongSanPham();
            return PartialView();
        }

        public ActionResult XoaGioHang(int id)
        {
            List<Giohang> lstGioHang = layGioHang();
            Giohang sanPham = lstGioHang.SingleOrDefault(n => n.Id == id);
            if(sanPham != null)
            {
                lstGioHang.RemoveAll(n => n.Id == id);
                return RedirectToAction("GioHang");
            }
            return RedirectToAction("GioHang");
        }

        public ActionResult CapNhatGioHang(int id, FormCollection collection)
        {
            List<Giohang> lstGioHang = layGioHang();
            Giohang sanPham = lstGioHang.SingleOrDefault(n => n.Id == id);
            if(sanPham != null)
            {
                sanPham.SoLuong = int.Parse(collection["txtSoLg"].ToString());
            }
            return RedirectToAction("GioHang");
        }

        public ActionResult XoaTatCaGioHang()
        {
            List<Giohang> lstGioHang = layGioHang();
            lstGioHang.Clear();
            return RedirectToAction("GioHang");
        }


        public ActionResult DatHang()
        {
            List<Giohang> lstGioHang = layGioHang();
            double tt = tongTien();
            KhachHang userName = Session["User"] as KhachHang ;
            DataContext data = new DataContext();
            DonHang dh = new DonHang()
            {
               ngaydat = DateTime.Now,
               ngaygiao = DateTime.Now,
               makh = userName.makh
            };

            data.DonHang.Add(dh);
            data.SaveChanges();
            foreach (var item in lstGioHang)
            {
                ChiTietDonHang ct = new ChiTietDonHang()
                {
                    madon = dh.madon,
                    id = item.Id,
                    soluong = item.SoLuong,
                    gia = decimal.Parse(item.Gia.ToString())
                };

                data.ChiTietDonHang.Add(ct);
            }
            data.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}