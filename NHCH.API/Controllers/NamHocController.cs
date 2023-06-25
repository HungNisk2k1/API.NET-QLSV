using Microsoft.AspNetCore.Mvc;
using NHCH.BUS;
using NHCH.MOD;

namespace NHCH.API.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("api/v1/NamHoc")]
    public class NamHocController : ControllerBase
    {
        private readonly ILogger<NamHocController> _logger;
        public NamHocController(ILogger<NamHocController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("DanhSach")]
        //[CustomAuthAttribute(ChucNangEnum.HeThong_QuanLy_NamHoc, AccessLevel.Read)]
        public IActionResult DanhSach([FromQuery] BasePagingParams p)
        {
            var TotalRow = 0;
            if (p == null) return BadRequest();
            var Result = new NamHocBUS().DanhSach(p, ref TotalRow);
            Result.TotalRow = TotalRow;
            if (Result != null) return Ok(Result);
            else return NotFound();
        }


        [HttpGet]
        [Route("ChiTiet")]
        public IActionResult ChiTiet(int id_NamHoc)
        {
            if (id_NamHoc == null) return BadRequest();
            var Result = new NamHocBUS().ChiTietNamHoc(id_NamHoc);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
        //thêm mới người dùng
        [HttpPost]
        [Route("ThemMoi")]
        public IActionResult ThemMoi([FromBody] ThemmoiNamHoc item)
        {
            if (item == null) return BadRequest();
            var Result = new NamHocBUS().ThemMoiNamHoc(item);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        //cập nhật người dùng
        [HttpPut]
        [Route("CapNhat")]
        public IActionResult CapNhat([FromBody] CapnhatNamHoc item)
        {
            if (item == null) return BadRequest();
            var Result = new NamHocBUS().CapNhat(item);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
        // xóa
        [HttpDelete]
        [Route("Xoa")]
        public IActionResult Xoa(int id_NamHoc)
        {
            if (id_NamHoc == null || id_NamHoc < 1) return BadRequest();
            var Result = new NamHocBUS().Xoa(id_NamHoc);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
    }
}