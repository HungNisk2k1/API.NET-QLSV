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
    public class ThamSoHeThongBUS
    {

        public BaseResultMOD DanhSach(BasePagingParams p, ref int TotalRow)
        {
            var Result = new BaseResultMOD();
            try
            {
                Result = new ThamSoHeThongDAL().DanhSach(p, ref TotalRow);
            }
            catch (Exception)
            {
                Result.Status = -1;
                //Result.Message = Constant.API_Error_System;
                Result.Message = "Lỗi ở Bus";
                Result.Data = null;
            }
            return Result;
        }
        public BaseResultMOD ChiTietThamSoHeThong(int id)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (id == null || id < 1)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng chọn tham số";
                    return Result;
                }
                else
                {
                    Result.Data = new ThamSoHeThongDAL().ChiTietThamSoHeThong(id);
                    Result.Status = 1;
                    return Result;
                }
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_INSERT;
                Result.Data = null;
            }
            return Result;
        }

        //thêm mới tham số
        public BaseResultMOD ThemMoi(ThemMoiThamSoHeThongMOD item)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (item == null || item.ThamSo == null || item.ThamSo == "")
                {
                    Result.Status = 0;
                    Result.Message = "tham số không được trống";
                    return Result;
                }
                else if (item.GiaTri.Length > 100 || item.GiaTri.Length < 1)
                {
                    Result.Status = 0;
                    Result.Message = "Độ dài của tham số trong khoảng từ 1 - 100 ký tự";
                    return Result;
                }
                else
                {
                    var kiemTraTaiKhoan = new ThamSoHeThongDAL().KiemTraTrung(null, item.ThamSo.Trim());
                    if (kiemTraTaiKhoan > 0)
                    {
                        Result.Status = 0;
                        Result.Message = "tham số đã tồn tại!";
                        return Result;
                    }
                    else
                        return new ThamSoHeThongDAL().ThemMoi(item);
                }
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_INSERT;
            }
            return Result;
        }


        //cập nhật người dùng
        public BaseResultMOD CapNhat(ThamSoHeThongMOD item)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (item == null || item.ThamSo == null)
                {
                    Result.Status = 0;
                    Result.Message = "tham số không được trống";
                    return Result;
                }
                else if (item.GiaTri.Length > 100)
                {
                    Result.Status = 0;
                    Result.Message = "Độ dài của tham số không được quá 200 ký tự";
                    return Result;
                }
                else
                {
                    var crThamSoHeThong = new ThamSoHeThongDAL().ChiTietThamSoHeThong((int)item.id);
                    if (crThamSoHeThong == null || crThamSoHeThong.id < 1)
                    {
                        Result.Status = 0;
                        Result.Message = "Tham số không tồn tại!";
                        return Result;
                    }
                    else
                    {
                        var kiemTraThamSoHeThong = new ThamSoHeThongDAL().KiemTraTrung(item.id, item.ThamSo);
                        if (kiemTraThamSoHeThong > 0)
                        {
                            Result.Status = 0;
                            Result.Message = "Tham số đã được sử dụng";
                            return Result;
                        }
                        else
                            return new ThamSoHeThongDAL().CapNhat(item);

                    }
                }
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_INSERT;
            }
            return Result;
        }
        public BaseResultMOD Xoa(int id)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (id == null || id < 1)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng chọn tham số trước khi xóa!";
                    return Result;
                }
                else
                {
                    var kiemTraTaiKhoan = new ThamSoHeThongDAL().ChiTietThamSoHeThong(id);
                    if (kiemTraTaiKhoan == null || kiemTraTaiKhoan.id < 1)
                    {
                        Result.Status = 0;
                        Result.Message = "Tham số không tồn tại!";
                        return Result;
                    }
                    else
                        return new ThamSoHeThongDAL().XoaThamSoHeThong(id);
                }
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_INSERT;
            }
            return Result;
        }


    }
}
