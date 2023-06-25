using NHCH.MOD;
using NHCH.ULT;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHCH.DAL
{
    public class NamHocDAL
    { 
        public BaseResultMOD DanhSachNamHoc(BasePagingParams p, ref int TotalRow)
        {
            var Result = new BaseResultMOD();
            List<NamHocMOD> danhSachMaNamHocHeThong = new List<NamHocMOD>();
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("Keyword",SqlDbType.NVarChar,200)
            };
            parameters[0].Value = p.Keyword != null ? p.Keyword : "";
           
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, CommandType.StoredProcedure, "QTT_NamHoc_DanhSach", parameters))
                {
                    while (dr.Read())
                    {
                        NamHocMOD item = new NamHocMOD();
                        item.id_NamHoc = Utils.ConvertToInt32(dr["id_NamHoc"], 0);
                        item.MaNamHoc = Utils.ConvertToString(dr["MaNamHoc"], string.Empty);
                        item.TenNamHoc = Utils.ConvertToString(dr["TenNamHoc"], string.Empty);
                        item.BatDau = Utils.ConvertToString(dr["BatDau"], string.Empty);
                        item.KetThuc = Utils.ConvertToString(dr["KetThuc"], string.Empty);
                        item.GhiChu = Utils.ConvertToString(dr["GhiChu"], string.Empty);
                        danhSachMaNamHocHeThong.Add(item);
                    }
                    dr.Close();
                }
                //TotalRow = Utils.ConvertToInt32(parameters[5].Value, 0);
                Result.Status = 1;
                Result.Data = danhSachMaNamHocHeThong;
            }
            catch (Exception ex)
            {
                Result.Status = -1;
                //Result.Message = Constant.API_Error_System;
                Result.Message = ex.ToString();
            }
            return Result;
        }
        public NamHocMOD? ChiTietNamHoc(int id_NamHoc)
        {
            NamHocMOD item = new NamHocMOD();
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@id_NamHoc",SqlDbType.Int)
            };
            parameters[0].Value = id_NamHoc;
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, System.Data.CommandType.StoredProcedure, "QTT_NamHoc_ChiTiet", parameters))
                {
                    while (dr.Read())
                    {
                        item = new NamHocMOD();
                        item.id_NamHoc = Utils.ConvertToInt32(dr["id_NamHoc"], 0);
                        item.MaNamHoc = Utils.ConvertToString(dr["MaNamHoc"], string.Empty);
                        item.TenNamHoc = Utils.ConvertToString(dr["TenNamHoc"], string.Empty);
                        item.BatDau = Utils.ConvertToString(dr["BatDau"], string.Empty);
                        item.KetThuc = Utils.ConvertToString(dr["KetThuc"], string.Empty);
                        item.GhiChu = Utils.ConvertToString(dr["GhiChu"], string.Empty);
                        break;
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
            }
            return item;
        }

        public BaseResultMOD ThemMoiNamHoc(ThemmoiNamHoc item)
        {
            var Result = new BaseResultMOD();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                        new SqlParameter("@MaNamHoc", SqlDbType.VarChar),
                        new SqlParameter("@TenNamHoc", SqlDbType.NVarChar),
                        new SqlParameter("@BatDau", SqlDbType.VarChar),
                        new SqlParameter("@KetThuc", SqlDbType.VarChar),
                        new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                };
                parameters[0].Value = item.MaNamHoc.Trim();
                parameters[1].Value = item.TenNamHoc.Trim();
                parameters[2].Value = item.BatDau.Trim();
                parameters[3].Value = item.KetThuc.Trim();
                parameters[4].Value = item.GhiChu.Trim();
                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            Result.Status = ULT.Utils.ConvertToInt32(SQLHelper.ExecuteScalar(trans, CommandType.StoredProcedure, "QTT_NamHoc_ThemMoi", parameters).ToString(), 0);
                            trans.Commit();
                            Result.Message = "Thêm mới năm học thành công!";
                            Result.Data = Result.Status;
                        }
                        catch (Exception ex)
                        {
                            Result.Status = -1;
                            Result.Message = Constant.ERR_INSERT;
                            trans.Rollback();
                        }
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

        public BaseResultMOD CapNhatNamHoc(CapnhatNamHoc item)
        {
            var Result = new BaseResultMOD();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                        new SqlParameter("@id_NamHoc", SqlDbType.Int),
                        new SqlParameter("@MaNamHoc", SqlDbType.VarChar),
                        new SqlParameter("@TenNamHoc", SqlDbType.NVarChar),
                        new SqlParameter("@BatDau", SqlDbType.VarChar),
                        new SqlParameter("@KetThuc", SqlDbType.VarChar),
                        new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                };
                parameters[0].Value = item.id_NamHoc;
                parameters[1].Value = item.MaNamHoc.Trim();
                parameters[2].Value = item.TenNamHoc.Trim();
                parameters[3].Value = item.BatDau.Trim();
                parameters[4].Value = item.KetThuc.Trim();
                parameters[5].Value = item.GhiChu.Trim();
                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            Result.Status = SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "QTT_NamHoc_CapNhat", parameters);
                            trans.Commit();
                            Result.Message = "Cập nhật thông tin tham số thành công!";
                            Result.Data = Result.Status;
                        }
                        catch (Exception ex)
                        {
                            Result.Status = -1;
                            Result.Message = Constant.ERR_UPDATE;
                            trans.Rollback();
                        }
                    }
                }
            }
            catch (Exception)
            {
                Result.Status = -1;
                Result.Message = Constant.ERR_UPDATE;
                throw;
            }
            return Result;
        }

                       
        public BaseResultMOD XoaMaNamHocHeThong(int id_NamHoc)
        {
            var Result = new BaseResultMOD();
            SqlParameter[] parameters = new SqlParameter[]
            {
                   new SqlParameter("id_NamHoc", SqlDbType.Int)
            };
            parameters[0].Value = id_NamHoc;
            using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        var val = SQLHelper.ExecuteNonQuery(trans, System.Data.CommandType.StoredProcedure, "QTT_NamHoc_Xoa", parameters);
                        trans.Commit();
                        if (val < 0)
                        {
                            Result.Status = 0;
                            Result.Message = "Không thể xóa tham số hệ thống!";
                            return Result;
                        }
                    }
                    catch
                    {
                        Result.Status = -1;
                        Result.Message = Constant.ERR_DELETE;
                        trans.Rollback();
                        return Result;
                        throw;
                    }
                }
            }
            Result.Status = 1;
            Result.Message = "Xóa tham số hệ thống thành công!";
            return Result;
        }

    //Kiểm tra trùng
        public int KiemTraTrung(int? id_NamHoc, string MaNamHoc)
        {
            var SoLuong = 0;
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@id_NamHoc",SqlDbType.Int),
                    new SqlParameter("@MaNamHoc",SqlDbType.VarChar)
            };
            parameters[0].Value = id_NamHoc ?? Convert.DBNull;
            parameters[1].Value = MaNamHoc;
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, System.Data.CommandType.StoredProcedure, "QTT_NamHoc_KiemTraTrung", parameters))
                {
                    while (dr.Read())
                    {
                        SoLuong = Utils.ConvertToInt32(dr["SoLuong"], 0);
                        break;
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
            }
            return SoLuong;
        }
    }
}
