using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NongPham_Nhom2.Models;

namespace NongPham_Nhom2.Controllers
{
    public class LoaiSanPhamController : Controller
    {
        //
        // GET: /LoaiSanPham/
        dbQuanLyNongPhamDataContext db = new dbQuanLyNongPhamDataContext();

        public ActionResult LoaiSanPhamPartial()
        {
            var list = db.LoaiSanPham_s.OrderBy(n => n.TenLoai).ToList();
            return View(list);
        }
        public ActionResult SanPhamTheoLoai(string MaLoai)
        {
            string tenLoai = db.LoaiSanPham_s.First(t => t.MaLoai == MaLoai).TenLoai;
            var list = db.SanPham_s.Where(s => s.MaLoai == MaLoai).OrderBy(s => s.GiaSP).ToList();
            if (list.Count != 0)
            {
                ViewBag.SanPham_s = tenLoai;
            }

            else
            { 
                ViewBag.SanPham_s = "Không có sản phẩm thuộc loại " + tenLoai;
            }
            return View(list);
        }


    }
}
