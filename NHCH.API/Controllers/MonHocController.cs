using Microsoft.AspNetCore.Mvc;
using NHCH.BUS;
using NHCH.MOD;

namespace NHCH.API.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("api/v1/MonHoc")]
    public class MonHocController : ControllerBase
    {
        private readonly ILogger<MonHocController> _logger;
        public MonHocController(ILogger<MonHocController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("DanhSach")]
        //[CustomAuthAttribute(ChucNangEnum.HeThong_QuanLy_MonHoc, AccessLevel.Read)]
        public IActionResult DanhSach([FromQuery] BasePagingParams p)
        {
            var TotalRow = 0;
            if (p == null) return BadRequest();
            var Result = new MonHocBUS().DanhSach(p, ref TotalRow);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }


        [HttpGet]
        [Route("ChiTiet")]
        public IActionResult ChiTiet(int id_MonHoc)
        {
            if (id_MonHoc == null) return BadRequest();
            var Result = new MonHocBUS().ChiTietMonHoc(id_MonHoc);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
        //thêm mới người dùng
        [HttpPost]
        [Route("ThemMoi")]
        public IActionResult ThemMoi([FromBody] ThemmoiMonHoc item)
        {
            if (item == null) return BadRequest();
            var Result = new MonHocBUS().ThemMoiMonHoc(item);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        //cập nhật người dùng
        [HttpPut]
        [Route("CapNhat")]
        public IActionResult CapNhat([FromBody] CapnhatMonHoc item)
        {
            if (item == null) return BadRequest();
            var Result = new MonHocBUS().CapNhap(item);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
        // xóa
        [HttpDelete]
        [Route("Xoa")]
        public IActionResult Xoa(int id_MonHoc)
        {
            if (id_MonHoc == null || id_MonHoc < 1) return BadRequest();
            var Result = new MonHocBUS().Xoa(id_MonHoc);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
    }
}