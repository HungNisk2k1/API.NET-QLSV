using Microsoft.AspNetCore.Mvc;
using NHCH.BUS;
using NHCH.MOD;

namespace NHCH.API.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("api/v1/KhoiLop")]
    public class KhoiLopController : ControllerBase
    {
        private readonly ILogger<KhoiLopController> _logger;
        public KhoiLopController(ILogger<KhoiLopController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("DanhSach")]
        //[CustomAuthAttribute(ChucNangEnum.HeThong_QuanLy_KhoiLop, AccessLevel.Read)]
        public IActionResult DanhSach([FromQuery] BasePagingParams p)
        {
            var TotalRow = 0;
            if (p == null) return BadRequest();
            var Result = new KhoiLopBUS().DanhSach(p, ref TotalRow);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }


        [HttpGet]
        [Route("ChiTiet")]
        public IActionResult ChiTiet(int id_KhoiLop)
        {
            if (id_KhoiLop == null) return BadRequest();
            var Result = new KhoiLopBUS().ChiTietKhoiLop(id_KhoiLop);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
        //thêm mới người dùng
        [HttpPost]
        [Route("ThemMoi")]
        public IActionResult ThemMoi([FromBody] ThemmoiKhoiLop item)
        {
            if (item == null) return BadRequest();
            var Result = new KhoiLopBUS().ThemMoiKhoiLop(item);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        //cập nhật người dùng
        [HttpPut]
        [Route("CapNhat")]
        public IActionResult CapNhat([FromBody] CapnhatKhoiLop item)
        {
            if (item == null) return BadRequest();
            var Result = new KhoiLopBUS().CapNhap(item);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
        // xóa
        [HttpDelete]
        [Route("Xoa")]
        public IActionResult Xoa(int id_KhoiLop)
        {
            if (id_KhoiLop == null || id_KhoiLop < 1) return BadRequest();
            var Result = new KhoiLopBUS().Xoa(id_KhoiLop);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
    }
}