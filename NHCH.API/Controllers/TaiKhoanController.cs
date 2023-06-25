using Microsoft.AspNetCore.Mvc;
using NHCH.BUS;
using NHCH.MOD;

namespace NHCH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(TaiKhoanMOD login)
        {
            if (login == null) return BadRequest();
            var Result = new TaiKhoanBUS().LoginBUS(login);
            if (Result != null) return Ok(Result);
            else return BadRequest();

        }
        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] DangKiTaiKhoan item)
        {
            if (item == null) return BadRequest();
            var Result = new TaiKhoanBUS().RegisterBUS(item);
            if (Result != null) return Ok(Result);
            else return NotFound();
        }
    }

}
