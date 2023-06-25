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
    public class KhoiLopDAL
    {
        public BaseResultMOD DanhSach(BasePagingParams p, ref int TotalRow)
        {
            var Result = new BaseResultMOD();
            List<KhoiLopMOD> DanhsachKhoiLop = new List<KhoiLopMOD>();
            SqlParameter[] parameters = new SqlParameter[]
            {
         new SqlParameter("Keyword",SqlDbType.NVarChar,50),
                new SqlParameter("TotalRow",SqlDbType.Int),
            };
            parameters[0].Value = p.Keyword != null ? p.Keyword : "";
            parameters[1].Direction = ParameterDirection.Output;
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, CommandType.StoredProcedure, "DM_KhoiLop_DanhSach", parameters))
                {
                    while (dr.Read())
                    {
                        KhoiLopMOD item = new KhoiLopMOD();
                        item.id_KhoiLop = Utils.ConvertToInt32(dr["id_KhoiLop"], 0);
                        item.MaKhoiLop = Utils.ConvertToString(dr["MaKhoiLop"], string.Empty);
                        item.TenKhoiLop = Utils.ConvertToString(dr["TenKhoiLop"], string.Empty);
                        item.TenBacHoc = Utils.ConvertToString(dr["TenBacHoc"], string.Empty);
                        DanhsachKhoiLop.Add(item);
                    }
                    dr.Close();
                }
                TotalRow = Utils.ConvertToInt32(parameters[1].Value, 0);
                Result.Status = 1;
                Result.Data = DanhsachKhoiLop;
            }
            catch (Exception ex)
            {
                Result.Status = -1;
                Result.Message = Constant.API_Error_System;
                throw;
            }
            return Result;

        }
      
        public KhoiLopMOD ChiTietKhoiLop(int Id_KhoiLop)
        {
            KhoiLopMOD item = null;

            SqlParameter[] parameters = new SqlParameter[]
                   {
                    new SqlParameter("@Id_KhoiLop", SqlDbType.Int)
                   };
            parameters[0].Value = Id_KhoiLop;
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, System.Data.CommandType.StoredProcedure, "DM_KhoiLop_ChiTiet", parameters))
                {
                    while (dr.Read())
                    {
                        item = new KhoiLopMOD();

                        item.id_KhoiLop = Utils.ConvertToInt32(dr["Id_KhoiLop"], 0);
                        item.MaKhoiLop = Utils.ConvertToString(dr["MaKhoiLop"], string.Empty);
                        item.TenKhoiLop = Utils.ConvertToString(dr["TenKhoiLop"], string.Empty);
                        item.TenBacHoc = Utils.ConvertToString(dr["TenBacHoc"], string.Empty);
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
        public BaseResultMOD ThemMoi( ThemmoiKhoiLop item)
        {
            var Result = new BaseResultMOD();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
               {
                    new SqlParameter("MaKhoiLop", SqlDbType.VarChar),
                    new SqlParameter("TenKhoiLop", SqlDbType.NVarChar),

                    new SqlParameter("id_BacHoc", SqlDbType.Int)

               };
                parameters[0].Value = item.MaKhoiLop.Trim();
                parameters[1].Value = item.TenKhoiLop.Trim();

                parameters[2].Value = item.id_BacHoc;

                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            Result.Status = Utils.ConvertToInt32(SQLHelper.ExecuteScalar(trans, CommandType.StoredProcedure, "DM_KhoiLop_ThemMoi", parameters).ToString(), 0);
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
        public BaseResultMOD CapNhap(CapnhatKhoiLop item)
        {
            var Result = new BaseResultMOD();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
               {
                    new SqlParameter("id_KhoiLop", SqlDbType.Int),
                    new SqlParameter("MaKhoiLop", SqlDbType.VarChar),
                    new SqlParameter("TenKhoiLop", SqlDbType.NVarChar),
                    new SqlParameter("id_BacHoc", SqlDbType.Int),

               };
                parameters[0].Value = item.id_KhoiLop;
                parameters[1].Value = item.MaKhoiLop.Trim();
                parameters[2].Value = item.TenKhoiLop.Trim();

                parameters[3].Value = item.id_BacHoc;

                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            Result.Status = SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "DM_KhoiLop_CapNhap ", parameters);
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

        public BaseResultMOD Xoa(int id_KhoiLop)
        {
            var Result = new BaseResultMOD();
            SqlParameter[] parameters = new SqlParameter[]
            {
               new SqlParameter("id_KhoiLop", SqlDbType.Int)
            };
            parameters[0].Value = id_KhoiLop;
            using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        var qr = SQLHelper.ExecuteNonQuery(trans, System.Data.CommandType.StoredProcedure, "DM_KhoiLop_Xoa ", parameters);
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
