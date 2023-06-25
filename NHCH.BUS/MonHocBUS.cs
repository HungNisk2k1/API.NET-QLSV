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
    public class MonHocBUS
    {
        public BaseResultMOD DanhSach(BasePagingParams p, ref int TotalRow)
        {
            var Result = new BaseResultMOD();
            try
            {
                Result = new MonHocDAL().DanhSach(p, ref TotalRow);
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
        public BaseResultMOD ChiTietMonHoc(int id_MonHoc)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (id_MonHoc == null || id_MonHoc < 1)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng chọn id khối lớp";
                    return Result;
                }
                else
                {
                    Result.Data = new MonHocDAL().ChiTietMonHoc(id_MonHoc);
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
        public BaseResultMOD ThemMoiMonHoc(ThemmoiMonHoc item)
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
                else if (item == null || item.MaMonHoc == null || string.IsNullOrEmpty(item.MaMonHoc))
                {
                    Result.Status = 0;
                    Result.Message = "Mã khối lớp  không được trống";
                    return Result;
                }
                else if (item.TenMonHoc == null || string.IsNullOrEmpty(item.TenMonHoc))
                {

                    Result.Status = 0;
                    Result.Message = "Tên khối lớp không được trống!";
                    return Result;
                }
                else
                {
                    return new MonHocDAL().ThemMoi(item);
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
        public BaseResultMOD CapNhap(CapnhatMonHoc item)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (item == null || item.MaMonHoc == null || item.MaMonHoc.Length > 100)
                {
                    Result.Status = 0;
                    Result.Message = "Mã bậc học không được trống";
                    return Result;
                }
                else if (item.TenMonHoc.Length > 200)
                {
                    Result.Status = 0;
                    Result.Message = "Độ dài của tham số không được quá 200 ký tự";
                    return Result;
                }
                else
                {
                    var crThamSoHeThong = new MonHocDAL().ChiTietMonHoc((int)item.id_MonHoc);
                    if (crThamSoHeThong == null || crThamSoHeThong.id_MonHoc < 1)
                    {
                        Result.Status = 0;
                        Result.Message = "ID không tồn tại!";
                        return Result;
                    }

                    else
                    {
                        return new MonHocDAL().CapNhap(item);
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
        public BaseResultMOD Xoa(int id_MonHoc)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (id_MonHoc == null || id_MonHoc < 1)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng chọn id trước khi xóa!";
                    return Result;
                }
                else
                {
                    var kiemTraTaiKhoan = new MonHocDAL().ChiTietMonHoc(id_MonHoc);
                    if (kiemTraTaiKhoan == null || kiemTraTaiKhoan.id_MonHoc < 1)
                    {
                        Result.Status = 0;
                        Result.Message = "id không tồn tại!";
                        return Result;
                    }
                    else
                        return new MonHocDAL().Xoa(id_MonHoc);
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
