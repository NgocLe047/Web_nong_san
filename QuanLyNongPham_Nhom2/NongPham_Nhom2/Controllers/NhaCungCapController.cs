using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NongPham_Nhom2.Models;
namespace NongPham_Nhom2.Controllers
{
    public class NhaCungCapController : Controller
    {
        //
        // GET: /NhaCungCap/
        dbQuanLyNongPhamDataContext db = new dbQuanLyNongPhamDataContext();
        public ActionResult NhaCungCapPartial()
        {
            var list = db.NhaCungCap_s.OrderBy(n => n.TenNCC).ToList();
            return View(list);
        }
        public ActionResult SanPhamTheoNhaCungCap(string MaNCC)
        {
            string tenNCC = db.NhaCungCap_s.First(t => t.MaNCC == MaNCC).TenNCC;
            var list = db.SanPham_s.Where(s => s.MaNCC == MaNCC).OrderBy(s => s.GiaSP).ToList();
            if (list.Count != 0)
            {
                ViewBag.SanPham_s = tenNCC;
            }

            else
            {
                ViewBag.SanPham_s = "Không có sản phẩm thuộc " + tenNCC;
            }
            return View(list);
        }

    }
}
