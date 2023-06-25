using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHCH.MOD
{
    public class NguoiDungMOD
    {
        public int id { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public int TrangThai { get; set; }
        public int VaiTro { get; set; }
    }
    public class ThemMoiNguoiDungMOD
    {
        public string TaiKhoan { get; set; }
        public string HoTen { get; set; }
        public int TrangThai { get; set; }
        public int VaiTro { get; set; }
    }

    public class CapNhatNguoiDungMOD
    {
        public int id { get; set; }
        public string TaiKhoan { get; set; }
        public string HoTen { get; set; }
        public int TrangThai { get; set; }
        public int VaiTro { get; set; }
    }
    public class CapNhatTaiKhoanMOD
    {
        public int id { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public int TrangThai { get; set; }
        public int VaiTro { get; set; }
    }

    public class ChiTietNguoiDungMOD
    {
        public int id { get; set; }
        public string TaiKhoan { get; set; }
        public string HoTen { get; set; }
        public int TrangThai { get; set; }
        public string TenTrangThai { get; set; }
        public int VaiTro { get; set; }
        public string TenVaiTro { get; set; }
    }
    public class ProductMOD
    {
        public int id { get; set; }
        public string title { get; set; } = "";
        public string contents { get; set; } = "";
        public int type { get; set; }
    }
}
