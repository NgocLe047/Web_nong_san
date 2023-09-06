using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NongPham_Nhom2.Models;

namespace NongPham_Nhom2.Models
{
    public class GioHang
    {
        dbQuanLyNongPhamDataContext db = new dbQuanLyNongPhamDataContext();
        public string sMaSP { get; set; }
      
        public string sTenSP { get; set; }
        public string sAnhSP { get; set; }
        public double dDonGia {get;set;}
        public int iSoLuong { get; set; }
        
        public double dThanhTien { get { return iSoLuong * dDonGia; } }
        
        public GioHang(string masp)
        {
            sMaSP = masp;
            
            SanPham_ sp = db.SanPham_s.Single(s=>s.MaSP==sMaSP);
           
            sTenSP = sp.TenSP;
            sAnhSP = sp.AnhSP;
            dDonGia = double.Parse(sp.GiaSP.ToString());
            
            iSoLuong = 1;
        }
    }
}