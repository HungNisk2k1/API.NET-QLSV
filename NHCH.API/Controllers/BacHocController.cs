using Microsoft.AspNetCore.Mvc;
using NHCH.BUS;
using NHCH.MOD;

namespace NHCH.API.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("api/v1/BacHoc")]
    public class BacHocController : ControllerBase
    {
        private readonly ILogger<BacHocController> _logger;
        public BacHocController(ILogger<BacHocController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("DanhSach")]
        //[CustomAuthAttribute(ChucNangEnum.HeThong_QuanLy_BacHoc, AccessLevel.Read)]
        public IActionResult DanhSach([FromQuery] BasePagingParams p)
        {
            var TotalRow = 0;
            if (p == null) return BadRequest();
            var Result = new BacHocBUS().DanhSach(p, ref TotalRow);
            Result.TotalRow = TotalRow;
            if (Result != null) return Ok(Result);
            else return NotFound();
        }


        [HttpGet]
        [Route("ChiTiet")]
        public IActionResult ChiTiet(int id)
        {
            if (id == null) return BadRequest();
            var Result = new BacHocBUS().ChiTietBacHoc(id);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
        //thêm mới người dùng
        [HttpPost]
        [Route("ThemMoi")]
        public IActionResult ThemMoi([FromBody] ThemmoiBacHoc item)
        {
            if (item == null) return BadRequest();
            var Result = new BacHocBUS().ThemMoiBacHoc(item);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }

        //cập nhật người dùng
        [HttpPut]
        [Route("CapNhat")]
        public IActionResult CapNhat([FromBody] CapnhatBacHoc item)
        {
            if (item == null) return BadRequest();
            var Result = new BacHocBUS().CapNhat(item);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
        // xóa
        [HttpDelete]
        [Route("Xoa")]
        public IActionResult Xoa(int id)
        {
            if (id == null || id < 1) return BadRequest();
            var Result = new BacHocBUS().Xoa(id);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
    }
}