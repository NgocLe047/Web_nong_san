using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NongPham_Nhom2.Models;

namespace NongPham_Nhom2.Controllers
{
    public class KhachHangController : Controller
    {
        //
        // GET: /KhachHang/

        public ActionResult TrangChu()
        {
            return View();
        }
        dbQuanLyNongPhamDataContext db = new dbQuanLyNongPhamDataContext();
        public ActionResult SanPhamPartial()
        {

            return View(db.SanPham_s.ToList());
        }
        
    }
}
