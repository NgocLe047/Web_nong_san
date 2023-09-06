using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NongPham_Nhom2.Models;

namespace NongPham_Nhom2.Controllers
{
    public class GioHangController : Controller
    {
        //
        // GET: /GioHang/

        dbQuanLyNongPhamDataContext db = new dbQuanLyNongPhamDataContext();
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lst = Session["GioHang"] as List<GioHang>;
            if(lst==null)
            {
                lst = new List<GioHang>();
                Session["GioHang"] = lst;
            }
            return lst;
        }

        public ActionResult ThemGioHang(string maSP,string strURL)
        {
            List<GioHang> lst = LayGioHang();
            GioHang sanPham = lst.Find(sp=>sp.sMaSP==maSP);
            if(sanPham==null)
            {
                sanPham = new GioHang(maSP);
                lst.Add(sanPham);
            }
            else
            {
                sanPham.iSoLuong++;
            }
            return Redirect(strURL);
        }
        int TongSoLuong()
        {
            List<GioHang> lst=Session["GioHang"] as List<GioHang>;
            if (lst != null)
                return lst.Sum(sp => sp.iSoLuong);
            return 0;
        }
        double TongThanhTien()
        {
            List<GioHang> lst = Session["GioHang"] as List<GioHang>;
            if (lst != null)
                return lst.Sum(sp => sp.dThanhTien);
            return 0;
        }
        public ActionResult GioHang()
        {
            if(Session["GioHang"]==null)
            {
                return RedirectToAction("TrangChu","TrangChu");
            }
            List<GioHang> lst = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();
            return View(lst);
        }
        public ActionResult GioHangPartial()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();
            return View();
        }

        public ActionResult XoaGioHang(string maSP)
        {
            List<GioHang> lst = LayGioHang();
            GioHang sp=lst.Single(s=>s.sMaSP==maSP);

            if (sp != null)
            {
                lst.RemoveAll(s => s.sMaSP == maSP);
                return RedirectToAction("GioHang");

            }
            if (lst.Count == 0)
                return RedirectToAction("TrangChu","TrangChu");
            return RedirectToAction("GioHang");
        }

    }
}
