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
    public class KhoiLopBUS
    {
        public BaseResultMOD DanhSach(BasePagingParams p, ref int TotalRow)
        {
            var Result = new BaseResultMOD();
            try
            {
                Result = new KhoiLopDAL().DanhSach(p, ref TotalRow);
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.API_Error_System;
                Result.Data = null;
                throw;
            }
            return Result;
        }
        public BaseResultMOD ChiTietKhoiLop(int id_KhoiLop)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (id_KhoiLop == null || id_KhoiLop < 1)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng chọn id khối lớp";
                    return Result;
                }
                else
                {
                    Result.Data = new KhoiLopDAL().ChiTietKhoiLop(id_KhoiLop);
                    Result.Status = 1;
                    return Result;
                }
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_INSERT;
                Result.Data = null;
                throw;
            }
            return Result;
        }
        public BaseResultMOD ThemMoiKhoiLop(ThemmoiKhoiLop item)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (item == null)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng nhập thông tin học viên cần thêm!";
                    return Result;
                }
            else if (item == null||item.MaKhoiLop == null || string.IsNullOrEmpty(item.MaKhoiLop))
            {
                Result.Status = 0;
                Result.Message = "Mã khối lớp  không được trống";
                return Result;
            }
                else if (item.TenKhoiLop == null || string.IsNullOrEmpty(item.TenKhoiLop))
                {

                    Result.Status = 0;
                    Result.Message = "Tên khối lớp không được trống!";
                    return Result;
                }
                else
                {
                    return new KhoiLopDAL().ThemMoi(item);
                }
            }
            catch (Exception ex)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_INSERT;
                throw;
            }
            return Result;
        }
        public BaseResultMOD CapNhap(CapnhatKhoiLop item)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (item == null || item.MaKhoiLop == null || item.MaKhoiLop.Length > 200)
                {
                    Result.Status = 0;
                    Result.Message = "Mã bậc học không được trống";
                    return Result;
                }
                else if (item.TenKhoiLop.Length > 200)
                {
                    Result.Status = 0;
                    Result.Message = "Độ dài của tham số không được quá 200 ký tự";
                    return Result;
                }
                else
                {
                    var crThamSoHeThong = new KhoiLopDAL().ChiTietKhoiLop((int)item.id_KhoiLop);
                    if (crThamSoHeThong == null || crThamSoHeThong.id_KhoiLop < 1)
                    {
                        Result.Status = 0;
                        Result.Message = "ID không tồn tại!";
                        return Result;
                    }

                    else
                    {
                        return new KhoiLopDAL().CapNhap(item);
                    }
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
        //------------
        public BaseResultMOD Xoa(int id_KhoiLop)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (id_KhoiLop == null || id_KhoiLop < 1)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng chọn id trước khi xóa!";
                    return Result;
                }
                else
                {
                    var kiemTraTaiKhoan = new KhoiLopDAL().ChiTietKhoiLop(id_KhoiLop);
                    if (kiemTraTaiKhoan == null || kiemTraTaiKhoan.id_KhoiLop < 1)
                    {
                        Result.Status = 0;
                        Result.Message = "id không tồn tại!";
                        return Result;
                    }
                    else
                        return new KhoiLopDAL().Xoa(id_KhoiLop);
                }
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = "Xóa thành công !";

            }
            return Result;
        }
    }
}
