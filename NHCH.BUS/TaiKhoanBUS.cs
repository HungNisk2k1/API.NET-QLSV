using NHCH.DAL;
using NHCH.MOD;
using NHCH.ULT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHCH.BUS
{
    public class TaiKhoanBUS
    {
        public BaseResultMOD LoginBUS(TaiKhoanMOD login)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (login.UserName == null || login.UserName == "")
                {
                    Result.Status = 0;
                    Result.Message = "UserName không được để trống";
                    return Result;
                }
                else if (login.Password == null || login.Password == "")
                {
                    Result.Status = 0;
                    Result.Message = "Mật khẩu không được để trống";
                    return Result;
                }
                else
                {
                    var userLogin = new TaiKhoanUser().LoginDAL(login.UserName, login.Password);
                    if (userLogin != null && userLogin.UserName != null)
                    {
                        Result.Status = 1;
                        Result.Message = "Đăng nhập thành công";
                        Result.Data = userLogin;
                    }
                    else
                    {
                        Result.Status = 0;
                        Result.Message = "Tài khoản hoặc mật khẩu không đúng!";
                    }
                    return Result;
                }
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_INSERT;
                throw;
            }
            return Result;
        }
        // đăng ký người dùng
        public BaseResultMOD RegisterBUS(DangKiTaiKhoan item)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (item == null || item.UserName == null || item.UserName == "")
                {
                    Result.Status = 0;
                    Result.Message = "UserName không được để trống";
                    return Result;
                }

                else if (item.Password == null || item.Password == "")
                {
                    Result.Status = 0;
                    Result.Message = "Mật khẩu không được để trống";
                    return Result;
                }


                return new TaiKhoanUser().RegisterDAL(item);

            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_INSERT;
                throw;
            }
            return Result;
        }
    }
}
