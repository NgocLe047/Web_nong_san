using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NongPham_Nhom2.Models;

namespace NongPham_Nhom2.Controllers
{
    public class SanPhamController : Controller
    {
        //
        // GET: /SanPham/
        dbQuanLyNongPhamDataContext db = new dbQuanLyNongPhamDataContext();
        public ActionResult SanPhamPartial()
        {
            
            return View(db.SanPham_s.ToList());
        }
        public ActionResult Banner()
        {
            return View(db.SanPham_s.ToList());
        }
        public ActionResult ChiTietSanPham(string MaSP)
        {
            SanPham_ sp = db.SanPham_s.Single( t => t.MaSP == MaSP);
            if (sp == null)
                return HttpNotFound();
            ViewBag.TenLoai = db.LoaiSanPham_s.First(t => t.MaLoai == sp.MaLoai).TenLoai;
            return View(sp);
        }
    }
}
