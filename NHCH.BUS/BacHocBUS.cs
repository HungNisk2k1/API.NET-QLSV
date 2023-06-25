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
    public class BacHocBUS
    {
        public BaseResultMOD DanhSach(BasePagingParams p , ref int TotalRow)
        {
            var Result = new BaseResultMOD();
            try
            {
                Result = new BacHocDAL().DanhSachBacHoc(p , ref TotalRow);
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

        public BaseResultMOD ChiTietBacHoc(int id_BacHoc)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (id_BacHoc == null || id_BacHoc < 1)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng chọn id_BacHoc ";
                    return Result;
                }
                else
                {
                    Result.Data = new BacHocDAL().ChiTietBacHoc(id_BacHoc);
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
        // thêm mới học viên 
        public BaseResultMOD ThemMoiBacHoc(ThemmoiBacHoc item)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (item == null)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng nhập thông tin bậc học cần thêm!";
                    return Result;
                }
                else if (item == null || item.MaBacHoc == null || item.MaBacHoc == "")
                {

                    Result.Status = 0;
                    Result.Message = "Mã học viên không được trống!";
                    return Result;
                }

                else if (item == null || item.TenBacHoc == null || item.TenBacHoc == "")
                {
                    Result.Status = 0;
                    Result.Message = "Tên hoc vien không được trống";
                    return Result;
                }
                else
                {
                    var kiemTraTaiKhoan = new BacHocDAL().KiemTraTrung(null, item.MaBacHoc);
                    if (kiemTraTaiKhoan > 0)
                    {
                        Result.Status = 0;
                        Result.Message = "Mã bậc học đã tồn tại!";
                        return Result;
                    }

                    else
                    
                        return new BacHocDAL().ThemMoiBacHoc(item);
                    
                }
            }
            catch(Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_INSERT;
                //throw;
            }
            return Result;
        }

        // cap nhat 
        public BaseResultMOD CapNhat(CapnhatBacHoc item)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (item == null || item.MaBacHoc == null || item.MaBacHoc == "")
                {
                    Result.Status = 0;
                    Result.Message = "Mã bậc học không được trống";
                    return Result;
                }
                else if (item == null || item.TenBacHoc == null || item.TenBacHoc == "")
                {
                    Result.Status = 0;
                    Result.Message = "Độ dài của tham số không được quá 200 ký tự";
                    return Result;
                }
                else
                {
                    var crThamSoHeThong = new BacHocDAL().ChiTietBacHoc((int)item.id_BacHoc);
                    if (crThamSoHeThong == null || crThamSoHeThong.id_BacHoc < 1)
                    {
                        Result.Status = 0;
                        Result.Message = "ID không tồn tại!";
                        return Result;
                    }
                    else
                    {
                        var kiemTraThamSoHeThong = new BacHocDAL().KiemTraTrung(item.id_BacHoc, item.MaBacHoc);
                        if (kiemTraThamSoHeThong > 0)
                        {
                            Result.Status = 0;
                            Result.Message = "Tham số đã được sử dụng";
                            return Result;
                        }
                        else
                        
                            return new BacHocDAL().CapNhatBacHoc(item);

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

        // xoa 
        public BaseResultMOD Xoa(int id_BacHoc)
        {
            var Result = new BaseResultMOD();
            try
            {
                if (id_BacHoc == null || id_BacHoc < 1)
                {
                    Result.Status = 0;
                    Result.Message = "Vui lòng chọn id_BacHoc trước khi xóa!";
                    return Result;
                }
                else
                {
                    var kiemTraTaiKhoan = new BacHocDAL().ChiTietBacHoc(id_BacHoc);
                    if (kiemTraTaiKhoan == null || kiemTraTaiKhoan.id_BacHoc < 1)
                    {
                        Result.Status = 0;
                        Result.Message = "id_BacHoc không tồn tại!";
                        return Result;
                    }
                    else
                        return new BacHocDAL().XoaMaBacHocHeThong(id_BacHoc);
                }
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_INSERT;
                Result.Message = "Xóa thành công !";

            }
            return Result;
        }
    }
}