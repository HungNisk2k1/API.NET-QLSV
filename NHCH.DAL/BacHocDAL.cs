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
    public class BacHocDAL
    { 
        public BaseResultMOD DanhSachBacHoc(BasePagingParams p, ref int TotalRow)
        {
            var Result = new BaseResultMOD();
            List<BacHocMOD> danhSachMaBacHocHeThong = new List<BacHocMOD>();
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("Keyword",SqlDbType.NVarChar,200)
            };
            parameters[0].Value = p.Keyword != null ? p.Keyword : "";
           
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, CommandType.StoredProcedure, "DM_BacHoc_DanhSach", parameters))
                {
                    while (dr.Read())
                    {
                        BacHocMOD item = new BacHocMOD();
                        item.id_BacHoc = Utils.ConvertToInt32(dr["id_BacHoc"], 0);
                        item.MaBacHoc = Utils.ConvertToString(dr["MaBacHoc"], string.Empty);
                        item.TenBacHoc = Utils.ConvertToString(dr["TenBacHoc"], string.Empty);
                        danhSachMaBacHocHeThong.Add(item);
                    }
                    dr.Close();
                }
                //TotalRow = Utils.ConvertToInt32(parameters[5].Value, 0);
                Result.Status = 1;
                Result.Data = danhSachMaBacHocHeThong;
            }
            catch (Exception ex)
            {
                Result.Status = -1;
                //Result.Message = Constant.API_Error_System;
                Result.Message = ex.ToString();
            }
            return Result;
        }

      
        public BacHocMOD? ChiTietBacHoc(int id_BacHoc)
        {
            BacHocMOD item = new BacHocMOD();
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@id_BacHoc",SqlDbType.Int)
            };
            parameters[0].Value = id_BacHoc;
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, System.Data.CommandType.StoredProcedure, "DM_BacHoc_ChiTiet", parameters))
                {
                    while (dr.Read())
                    {
                        item = new BacHocMOD();
                        item.id_BacHoc = Utils.ConvertToInt32(dr["id_BacHoc"], 0);
                        item.MaBacHoc = Utils.ConvertToString(dr["MaBacHoc"], string.Empty);
                        item.TenBacHoc = Utils.ConvertToString(dr["TenBacHoc"], string.Empty);
                       
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

        public BaseResultMOD ThemMoiBacHoc(ThemmoiBacHoc item)
        {
            var Result = new BaseResultMOD();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                        new SqlParameter("@MaBacHoc", SqlDbType.VarChar),
                        new SqlParameter("@TenBacHoc", SqlDbType.NVarChar)
                };
                parameters[0].Value = item.MaBacHoc.Trim();
                parameters[1].Value = item.TenBacHoc.Trim();
               
                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            Result.Status = ULT.Utils.ConvertToInt32(SQLHelper.ExecuteScalar(trans, CommandType.StoredProcedure, "DM_BacHoc_ThemMoi", parameters).ToString(), 0);
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

       
        public BaseResultMOD CapNhatBacHoc(CapnhatBacHoc item)
        {
            var Result = new BaseResultMOD();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                        new SqlParameter("@id_BacHoc", SqlDbType.Int),
                        new SqlParameter("@MaBacHoc", SqlDbType.VarChar),
                        new SqlParameter("@TenBacHoc", SqlDbType.VarChar)
                };
                parameters[0].Value = item.id_BacHoc;
                parameters[1].Value = item.MaBacHoc.Trim();
                parameters[2].Value = item.TenBacHoc.Trim();
                
                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            Result.Status = SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "DM_BacHoc_CapNhat", parameters);
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

                            
        public BaseResultMOD XoaMaBacHocHeThong(int id_BacHoc)
        {
            var Result = new BaseResultMOD();
            SqlParameter[] parameters = new SqlParameter[]
            {
                   new SqlParameter("id_BacHoc", SqlDbType.Int)
            };
            parameters[0].Value = id_BacHoc;
            using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        var val = SQLHelper.ExecuteNonQuery(trans, System.Data.CommandType.StoredProcedure, "DM_BacHoc_Xoa", parameters);
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


        public int KiemTraTrung(int? id_BacHoc, string MaBacHoc)
        {
            var SoLuong = 0;
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@id_BacHoc",SqlDbType.Int),
                    new SqlParameter("@MaBacHoc",SqlDbType.VarChar)
            };
            parameters[0].Value = id_BacHoc ?? Convert.DBNull;
            parameters[1].Value = MaBacHoc;
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, System.Data.CommandType.StoredProcedure, "DM_BacHoc_KiemTraTrung", parameters))
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
