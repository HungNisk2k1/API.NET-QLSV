using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHCH.MOD
{
    public class MonHocMOD
    {
        public int? id_MonHoc { get; set; }
        public string MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public string TenKhoiLop { get; set; }
    }
    public class ThemmoiMonHoc
    {

        public string MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }

        public int? id_KhoiLop { get; set; }



    }
    public class CapnhatMonHoc
    {
        public int? id_MonHoc { get; set; }
        public string MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }

        public int? id_KhoiLop { get; set; }



    }
}
