using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Web.Security;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NongPham_Nhom2.Models
{
    public class User
    {

        [Key]
        public string maKH { get; set; }
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [Display(Name = "Username")]
        public string TenTK { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được bỏ trống")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string MatKhau { get; set; }

        [Required(ErrorMessage = "Họ và tên không được để trống")]
        [Display(Name = "HoTen")]
        public string HoTen { get; set; }




        [DataType(DataType.Password)]
        [Display(Name = "RetypePassword")]
        [Compare("MatKhau", ErrorMessage = "Mật khẩu không khớp!")]
        public string RetypePassword { get; set; }

        public string Email { get; set; }
        public bool Check1 { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
    }
    public class Searchuser
    {

        public string searchk(User li)
        {

            dbQuanLyNongPhamDataContext db = new dbQuanLyNongPhamDataContext();
            KhachHang_ rs = new KhachHang_();

            string passout = "";
            // var pass = from m in db.registers where m.emailid == li.Emailid select m.userpassword;  
            var pass = from m in db.KhachHang_s where m.TenTK == li.TenTK select m.MatKhau;

            foreach (string query in pass)
            {
                passout = query;

            }

            return passout;

        }
        public string searchnv(User li)
        {

            dbQuanLyNongPhamDataContext db = new dbQuanLyNongPhamDataContext();

            NhanVien_ nv = new NhanVien_();
            string passout = "";
            // var pass = from m in db.registers where m.emailid == li.Emailid select m.userpassword;  

            var pass2 = from m in db.NhanVien_s where m.TenTK == li.TenTK select m.MatKhau;

            foreach (string query2 in pass2)
            {
                passout = query2;

            }
            return passout;

        }

    }

}