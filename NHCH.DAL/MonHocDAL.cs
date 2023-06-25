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
    public class MonHocDAL
    {
        public BaseResultMOD DanhSach(BasePagingParams p, ref int TotalRow)
        {
            var Result = new BaseResultMOD();
            List<MonHocMOD> DanhsachMonHoc = new List<MonHocMOD>();
            SqlParameter[] parameters = new SqlParameter[]
            {
         new SqlParameter("Keyword",SqlDbType.NVarChar,50),
                new SqlParameter("TotalRow",SqlDbType.Int),
            };
            parameters[0].Value = p.Keyword != null ? p.Keyword : "";
            parameters[1].Direction = ParameterDirection.Output;
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, CommandType.StoredProcedure, "DM_MonHoc_DanhSach", parameters))
                {
                    while (dr.Read())
                    {
                        MonHocMOD item = new MonHocMOD();
                        item.id_MonHoc = Utils.ConvertToInt32(dr["id_MonHoc"], 0);
                        item.MaMonHoc = Utils.ConvertToString(dr["MaMonHoc"], string.Empty);
                        item.TenMonHoc = Utils.ConvertToString(dr["TenMonHoc"], string.Empty);
                        item.TenKhoiLop = Utils.ConvertToString(dr["TenKhoiLop"], string.Empty);
                        DanhsachMonHoc.Add(item);
                    }
                    dr.Close();
                }
                TotalRow = Utils.ConvertToInt32(parameters[1].Value, 0);
                Result.Status = 1;
                Result.Data = DanhsachMonHoc;
            }
            catch (Exception ex)
            {
                Result.Status = -1;
                Result.Message = Constant.API_Error_System;
                throw;
            }
            return Result;

        }
       
        public MonHocMOD ChiTietMonHoc(int Id_MonHoc)
        {
            MonHocMOD item = null;

            SqlParameter[] parameters = new SqlParameter[]
                   {
                    new SqlParameter("@Id_MonHoc", SqlDbType.Int)
                   };
            parameters[0].Value = Id_MonHoc;
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, System.Data.CommandType.StoredProcedure, "DM_MonHoc_ChiTiet", parameters))
                {
                    while (dr.Read())
                    {
                        item = new MonHocMOD();

                        item.id_MonHoc = Utils.ConvertToInt32(dr["Id_MonHoc"], 0);
                        item.MaMonHoc = Utils.ConvertToString(dr["MaMonHoc"], string.Empty);
                        item.TenMonHoc = Utils.ConvertToString(dr["TenMonHoc"], string.Empty);
                        item.TenKhoiLop = Utils.ConvertToString(dr["TenKhoiLop"], string.Empty);
                        break;
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return item;
        }
        public BaseResultMOD ThemMoi(ThemmoiMonHoc item)
        {
            var Result = new BaseResultMOD();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
               {
                    new SqlParameter("MaMonHoc", SqlDbType.VarChar),
                    new SqlParameter("TenMonHoc", SqlDbType.NVarChar),

                    new SqlParameter("id_KhoiLop", SqlDbType.Int)

               };
                parameters[0].Value = item.MaMonHoc.Trim();
                parameters[1].Value = item.TenMonHoc.Trim();

                parameters[2].Value = item.id_KhoiLop;

                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            Result.Status = Utils.ConvertToInt32(SQLHelper.ExecuteScalar(trans, CommandType.StoredProcedure, "DM_MonHoc_ThemMoi", parameters).ToString(), 0);
                            trans.Commit();
                            Result.Message = "Thêm mới thành công!";
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
        //-------------------
        public BaseResultMOD CapNhap(CapnhatMonHoc item)
        {
            var Result = new BaseResultMOD();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
               {
                   new SqlParameter("id_MonHoc", SqlDbType.Int),
                    new SqlParameter("MaMonHoc", SqlDbType.VarChar),
                    new SqlParameter("TenMonHoc", SqlDbType.NVarChar),

                    new SqlParameter("id_KhoiLop", SqlDbType.Int),
               };

                parameters[0].Value = item.id_MonHoc;
                parameters[1].Value = item.MaMonHoc.Trim();
                parameters[2].Value = item.TenMonHoc.Trim();

                parameters[3].Value = item.id_KhoiLop;

                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            Result.Status = SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "DM_MonHoc_CapNhap ", parameters);
                            trans.Commit();
                            Result.Message = "Cập nhật thành công!";
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
            }
            return Result;
        }

        public BaseResultMOD Xoa(int id_MonHoc)
        {
            var Result = new BaseResultMOD();
            SqlParameter[] parameters = new SqlParameter[]
            {
               new SqlParameter("id_MonHoc", SqlDbType.Int)
            };
            parameters[0].Value = id_MonHoc;
            using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        var qr = SQLHelper.ExecuteNonQuery(trans, System.Data.CommandType.StoredProcedure, "DM_MonHoc_Xoa ", parameters);
                        trans.Commit();
                        if (qr < 0)
                        {
                            Result.Status = 0;
                            Result.Message = "Không thể xóa câu hỏi!";
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
            Result.Message = "Xóa thành công!";
            return Result;
        }
    }
}
