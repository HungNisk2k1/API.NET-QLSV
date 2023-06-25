using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHCH.MOD
{
    public class NamHocMOD
    {
        public int? id_NamHoc { get; set; }
        public string MaNamHoc { get; set; }
        public string TenNamHoc { get; set; }
        public string BatDau { get; set; }
        public string KetThuc { get; set; }
        public string GhiChu { get; set; }
    }
    public class ThemmoiNamHoc
    {
        
        public string MaNamHoc { get; set; }
        public string TenNamHoc { get; set; }
        public string BatDau { get; set; }
        public string KetThuc { get; set; }
        public string GhiChu { get; set; }
    }

    public class CapnhatNamHoc
    {
        public int? id_NamHoc { get; set; }
        public string MaNamHoc { get; set; }
        public string TenNamHoc { get; set; }
        public string BatDau { get; set; }
        public string KetThuc { get; set; }
        public string GhiChu { get; set; }
    }
}
