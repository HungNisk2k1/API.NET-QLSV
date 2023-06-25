using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHCH.MOD
{
    public class ThamSoHeThongMOD
    {
        public int? id { get; set; }
        public string ThamSo { get; set; }
        public string GiaTri { get; set; }
        public string GhiChu { get; set; }
    }
    public class ThemMoiThamSoHeThongMOD
    {
        public string ThamSo { get; set; }
        public string GiaTri { get; set; }
        public string GhiChu { get; set; }
    }

    public class CapNhatThamSoHeThongMOD
    {
    public int? id { get; set; }
    public string ThamSo { get; set; }
    public string GiaTri { get; set; }
    public string GhiChu { get; set; }
    }
}
