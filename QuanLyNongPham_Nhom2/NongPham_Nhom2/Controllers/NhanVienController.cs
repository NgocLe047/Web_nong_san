using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NongPham_Nhom2.Models;

namespace NongPham_Nhom2.Controllers
{
    public class NhanVienController : Controller
    {
        //
        // GET: /NhanVien/

        dbQuanLyNongPhamDataContext db = new dbQuanLyNongPhamDataContext();
        public ActionResult LienHeZalo()
        {
            return View();
        }
        public ActionResult QuanLySanPham()
        {
            return View(db.SanPham_s.ToList());

        }
        
        public ActionResult ThemSanPham()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemSanPham(SanPham_ collect)
        {
            db.SanPham_s.InsertOnSubmit(collect);
            db.SubmitChanges();
            return RedirectToAction("QuanLySanPham", "NhanVien");
        }
        public ActionResult XoaSanPham(string id)
        {
            var sp = db.SanPham_s.Single(row => row.MaSP == id);
            return View(sp);
        }
        [HttpPost]
        public ActionResult XoaSanPham(string id, SanPham_ collect)
        {
            var data = db.SanPham_s.Single(row => row.MaSP == id);
            db.SanPham_s.DeleteOnSubmit(data);
            db.SubmitChanges();
            return RedirectToAction("QuanLySanPham", "NhanVien");

        }
        public ActionResult SuaSanPham(string id)
        {
            var sp = db.SanPham_s.Single(row => row.MaSP == id);
            return View(sp);
        }
        [HttpPost]
        public ActionResult SuaSanPham(string id, SanPham_ collect)
        {
            SanPham_ sp = db.SanPham_s.Single(row => row.MaSP == id);
            sp.MaSP = collect.MaSP;
            sp.TenSP = collect.TenSP;
            sp.GiaSP = collect.GiaSP;
            sp.MaLoai = collect.MaLoai;
            sp.AnhSP = collect.AnhSP;
            sp.SoLuong = collect.SoLuong;
            sp.MaNCC = collect.MaNCC;
            db.SubmitChanges();
            return RedirectToAction("QuanLySanPham", "NhanVien");
        }
    }
}
