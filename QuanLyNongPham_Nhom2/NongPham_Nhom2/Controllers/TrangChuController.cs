using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NongPham_Nhom2.Models;

namespace NongPham_Nhom2.Controllers
{
    public class TrangChuController : Controller
    {
        //
        // GET: /TrangChu/
        dbQuanLyNongPhamDataContext db = new dbQuanLyNongPhamDataContext();
       
        public ActionResult DangXuat()
        {
            return View();
        }
        public ActionResult DangKy()
        {
            return View();
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(User taiKhoan)
        {
            if (ModelState.IsValid)
            {
                KhachHang_ khachHang = new KhachHang_();

                // Kiểm tra mã để thêm
                string maKH = db.KhachHang_s.Max(kh => kh.MaKH).ToString();
                int max = int.Parse(maKH.TrimStart(new char[] { 'K', 'H' }));
                maKH = (max + 1).ToString();
                if (max >= 0 && max <= 8)
                    khachHang.MaKH = "KH00" + maKH;
                else if (max <= 98)
                    khachHang.MaKH = "KH0" + maKH;
                else
                    khachHang.MaKH = "KH" + maKH;
                // Thêm vào database
                try
                {
                    khachHang.TenKH = taiKhoan.HoTen;
                    khachHang.DiaChi = taiKhoan.DiaChi;
                    khachHang.SDT = taiKhoan.SDT;
                    khachHang.TenTK = taiKhoan.TenTK;
                    khachHang.MatKhau = taiKhoan.MatKhau;
                    db.KhachHang_s.InsertOnSubmit(khachHang);
                    db.SubmitChanges();
                    ViewBag.KiemTraDuLieu = true;
                    Session["User"] = taiKhoan;
                    return RedirectToAction("DangNhap", "TrangChu");

                }
                catch (Exception)
                {
                    ViewBag.KiemTraDuLieu = false;
                    return View(khachHang);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(NongPham_Nhom2.Models.User li)
        {
            NongPham_Nhom2.Models.Searchuser ss = new Models.Searchuser();
            string pass = ss.searchk(li);
            string pass2 = ss.searchnv(li);
            if (pass == li.MatKhau)
            {

                return RedirectToAction("TrangChu", "KhachHang");

            }
            else if (pass2 == li.MatKhau)
            {
                return RedirectToAction("QuanLySanPham", "NhanVien");
            }
            @ViewBag.data = "invalide user";
            return RedirectToAction("DangNhap", "TrangChu");
        }
        public ActionResult GioiThieu()
        {
            return View();
        }
        public ActionResult TuyenDung()
        {
            return View();
        }
        public ActionResult HuongDan()
        {
            return View();

        }
        public ActionResult FooterPartial()
        {
            return View(db.LoaiSanPham_s.ToList());
        }
        public ActionResult TrangChu()
        {
            return View();
        }
        public ActionResult TimKiem(string search = " ")
        {
            List<SanPham_> sp = db.SanPham_s.Where(s => s.TenSP.Contains(search)).ToList();
            return View((sp));
        }
        public ActionResult TinTucKhuyenMai()
        {
            var km = db.KhuyenMai_s.ToList();
            return View(km);
        }
        //

    }
}
