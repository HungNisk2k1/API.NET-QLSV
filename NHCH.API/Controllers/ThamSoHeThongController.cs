using Microsoft.AspNetCore.Mvc;
using NHCH.BUS;
using NHCH.MOD;

namespace NHCH.API.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("api/v1/ThamSoHeThong")]
    public class ThamSoHeThongController : ControllerBase
    {
        private readonly ILogger<ThamSoHeThongController> _logger;
        public ThamSoHeThongController(ILogger<ThamSoHeThongController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("DanhSach")]
        //[CustomAuthAttribute(ChucNangEnum.HeThong_QuanLy_ThamSoHeThong, AccessLevel.Read)]
        public IActionResult DanhSach([FromQuery] BasePagingParams p)
        {
            var TotalRow = 0;
            if (p == null) return BadRequest();
            var Result = new ThamSoHeThongBUS().DanhSach(p, ref TotalRow);
            Result.TotalRow = TotalRow;
            if (Result != null) return Ok(Result);
            else return NotFound();
        }


        [HttpGet]
        [Route("ChiTiet")]
        public IActionResult ChiTiet(int id)
        {
            if (id == null) return BadRequest();
            var Result = new ThamSoHeThongBUS().ChiTietThamSoHeThong(id);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
        //thêm mới người dùng
        [HttpPost]
        [Route("ThemMoi")]
        public IActionResult ThemMoi([FromBody] ThemMoiThamSoHeThongMOD item)
        {
            if (item == null) return BadRequest();
            var Result = new ThamSoHeThongBUS().ThemMoi(item);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        //cập nhật người dùng
        [HttpPut]
        [Route("CapNhat")]
        public IActionResult CapNhat([FromBody] ThamSoHeThongMOD item)
        {
            if (item == null) return BadRequest();
            var Result = new ThamSoHeThongBUS().CapNhat(item);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
        // xóa
        [HttpDelete]
        [Route("Xoa")]
        public IActionResult Xoa(int id)
        {
            if (id == null || id < 1) return BadRequest();
            var Result = new ThamSoHeThongBUS().Xoa(id);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
    }
}