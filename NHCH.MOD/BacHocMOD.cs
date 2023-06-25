using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHCH.MOD
{
    public class BacHocMOD
    {
        public int? id_BacHoc { get; set; }
        
        public string MaBacHoc { get; set; }
        
        public string TenBacHoc { get; set; }
        
    }
    public class ThemmoiBacHoc
    {
    
        public string MaBacHoc { get; set; }
        public string TenBacHoc { get; set; }

    }

    public class CapnhatBacHoc
    {
        public int? id_BacHoc { get; set; }
        public string MaBacHoc { get; set; }
        public string TenBacHoc { get; set; }

    }
}
