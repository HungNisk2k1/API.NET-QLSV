using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHCH.MOD
{
    public class KhoiLopMOD
    {
        public int? id_KhoiLop { get; set; }
        public string MaKhoiLop { get; set; }
        public string TenKhoiLop { get; set; }
        public string TenBacHoc { get; set; }
    }
    public class ThemmoiKhoiLop
    {
        
        public string MaKhoiLop { get; set; }
        public string TenKhoiLop { get; set; }

        public int? id_BacHoc { get; set; }



    }
        public class CapnhatKhoiLop
    {
        public int? id_KhoiLop { get; set; }
        public string MaKhoiLop { get; set; }
        public string TenKhoiLop { get; set; }

        public int? id_BacHoc { get; set; }



    }
}
