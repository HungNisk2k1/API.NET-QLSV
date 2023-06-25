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
    public class NamHocBUS
    {
        public BaseResultMOD DanhSach(BasePagingParams p,ref int TotalRow)
        {
            var Result = new BaseResultMOD();
            try
            {
                Result = new NamHocDAL().DanhSachNamHoc(p, ref  TotalRow);
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

        public BaseResultMOD ChiTietNamHoc(int id_NamHoc)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (id_NamHoc == null || id_NamHoc < 1)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng chọn id_NamHoc học viên";
                    return Result;
                }
                else
                {
                    Result.Data = new NamHocDAL().ChiTietNamHoc(id_NamHoc);
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
        // thêm mới năm học 
        public BaseResultMOD ThemMoiNamHoc(ThemmoiNamHoc item)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (item == null)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng nhập thông tin năm học  cần thêm!";
                    return Result;
                }
                else if (item == null || item.MaNamHoc == null || string.IsNullOrEmpty(item.MaNamHoc))
                {

                    Result.Status = 0;
                    Result.Message = "Mã năm học  không được trống!";
                    return Result;
                }

                else if (item.TenNamHoc == null || string.IsNullOrEmpty(item.TenNamHoc))
                {
                    Result.Status = 0;
                    Result.Message = "Tên năm học  không được trống";
                    return Result;
                }
                else if (item.BatDau == null || string.IsNullOrEmpty(item.BatDau))
                {
                    Result.Status = 0;
                    Result.Message = "Năm bắt đầu  không được trống";
                    return Result;
                }
                else if (item.KetThuc == null || string.IsNullOrEmpty(item.KetThuc))
                {
                    Result.Status = 0;
                    Result.Message = "Năm kết thúc  không được trống";
                    return Result;
                }

                else if (item.GhiChu == null || string.IsNullOrEmpty(item.GhiChu))
                {
                    Result.Status = 0;
                    Result.Message = "Ghi chú  không được trống";
                    return Result;
                }
                else
                {
                    return new NamHocDAL().ThemMoiNamHoc(item);
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

        // cap nhat 
        public BaseResultMOD CapNhat(CapnhatNamHoc item)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (item.MaNamHoc == null || item.MaNamHoc.Length < 1 || item.MaNamHoc.Trim().Length > 200)
                {
                    Result.Status = 0;
                    Result.Message = "Mã năm học  không được trống và độ dài không được quá 200 ký tự";
                    return Result;
                }
                else if (item.TenNamHoc == null || item.TenNamHoc.Length < 1 || item.TenNamHoc.Trim().Length > 200)
                {
                    Result.Status = 0;
                    Result.Message = "Tên năm học  không được trống và độ dài không được quá 200 ký tự";
                    return Result;
                }
                if (item.BatDau == null || item.BatDau.Length < 1 || item.BatDau.Trim().Length > 200)
                {
                    Result.Status = 0;
                    Result.Message = "Năm bắt đầu  không được trống và độ dài không được quá 200 ký tự";
                    return Result;
                }
                else if (item.KetThuc == null || item.KetThuc.Length < 1 || item.KetThuc.Trim().Length > 200)
                {
                    Result.Status = 0;
                    Result.Message = "Năm kết thúc  không được trống và độ dài không được quá 200 ký tự";
                    return Result;
                }
                else if (item.GhiChu == null || item.GhiChu.Length < 1 || item.GhiChu.Trim().Length > 200)
                {
                    Result.Status = 0;
                    Result.Message = "Ghi chú  không được trống và độ dài không được quá 200 ký tự";
                    return Result;
                }

                else
                {
                    return new NamHocDAL().CapNhatNamHoc(item);

                }

            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_INSERT;
            }
            return Result;
        }

        // xoa 
        public BaseResultMOD Xoa(int id_NamHoc)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (id_NamHoc == null || id_NamHoc < 1)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng chọn id_NamHoc trước khi xóa!";
                    return Result;
                }
                else
                {
                    var kiemTraTaiKhoan = new NamHocDAL().ChiTietNamHoc(id_NamHoc);
                    if (kiemTraTaiKhoan == null || kiemTraTaiKhoan.id_NamHoc < 1)
                    {
                        Result.Status = 0;
                        Result.Message = "id_NamHoc không tồn tại!";
                        return Result;
                    }
                    else
                        return new NamHocDAL().XoaMaNamHocHeThong(id_NamHoc);
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