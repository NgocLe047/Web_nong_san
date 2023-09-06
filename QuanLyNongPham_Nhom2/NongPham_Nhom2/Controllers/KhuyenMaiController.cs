using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NongPham_Nhom2.Models;

namespace NongPham_Nhom2.Controllers
{
    public class KhuyenMaiController : Controller
    {
        //
        // GET: /KhuyenMai/
        dbQuanLyNongPhamDataContext db = new dbQuanLyNongPhamDataContext();
        public ActionResult KhuyenMaiPartial()
        {
            var km = db.KhuyenMai_s.ToList();
            return View(km);
        }
        public ActionResult ChiTietKhuyenMai(string MaKM)
        {
            var km = db.KhuyenMai_s.Single(ct => ct.MaKM == MaKM);
            if (km == null)
                return HttpNotFound();
            return View(km);
        }
    
    }
}
