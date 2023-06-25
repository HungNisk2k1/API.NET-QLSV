//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHCH.MOD
{
    public class BasePagingParams
    {
        public string Keyword { get; set; } = "";
        public string OrderByOption { get; set; } = "";
        public string OrderByName { get; set; } = "";
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
        public int Offset { get { return (PageSize == 0 ? 10 : PageSize) * ((PageNumber == 0 ? 1 : PageNumber) - 1); } }
        public int Limit { get { return (PageSize == 0 ? 10 : PageSize); } }
        public int VaiTro { get; set; }
        public int? TrangThai { get; set; }


    }
}
