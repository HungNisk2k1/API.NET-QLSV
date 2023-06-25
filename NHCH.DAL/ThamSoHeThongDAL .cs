using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHCH.MOD;
using NHCH.ULT;

namespace NHCH.DAL
{
    public class ThamSoHeThongDAL
    {

        public BaseResultMOD DanhSach(BasePagingParams p, ref int TotalRow)
        {
            var Result = new BaseResultMOD();
            List<ThamSoHeThongMOD> danhSachThamSoHeThong = new List<ThamSoHeThongMOD>();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("Keyword",SqlDbType.NVarChar,200)
                
            };
            parameters[0].Value = p.Keyword != null ? p.Keyword : "";
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, CommandType.StoredProcedure, "QTHT_DanhSachThamSo", parameters))
                {
                    while (dr.Read())
                    {
                        ThamSoHeThongMOD item = new ThamSoHeThongMOD();
                        item.id = Utils.ConvertToInt32(dr["id"], 0);
                        item.ThamSo = Utils.ConvertToString(dr["ThamSo"], string.Empty);
                        item.GiaTri = Utils.ConvertToString(dr["GiaTri"], string.Empty);
                        item.GhiChu = Utils.ConvertToString(dr["GhiChu"], string.Empty);
                        danhSachThamSoHeThong.Add(item);
                    }
                    dr.Close();
                }
                //TotalRow = Utils.ConvertToInt32(parameters[5].Value, 0);
                Result.Status = 1;
                Result.Data = danhSachThamSoHeThong;
            }
            catch (Exception ex)
            {
                Result.Status = -1;
                //Result.Message = Constant.API_Error_System;
                Result.Message = ex.ToString();
            }
            return Result;
        }

        // lấy thông tin chi tiết Tham số hệ thống
        public ThamSoHeThongMOD? ChiTietThamSoHeThong(int id)
        {
            ThamSoHeThongMOD item = new ThamSoHeThongMOD();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id",SqlDbType.Int)
            };
            parameters[0].Value = id;
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, System.Data.CommandType.StoredProcedure, "QTHT_ThamSo_ChiTiet", parameters))
                {
                    while (dr.Read())
                    {
                        item = new ThamSoHeThongMOD();
                        item.id = Utils.ConvertToInt32(dr["id"], 0);
                        item.ThamSo = Utils.ConvertToString(dr["ThamSo"], string.Empty);
                        item.GiaTri = Utils.ConvertToString(dr["GiaTri"], string.Empty);
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


        // thêm mới Tham Số hệ thống,
        // chỉ thực hiện chức năng thêm mới Tham số hệ thống vào db,
        // việc validate sẽ xử lý ở tầng bus
        public BaseResultMOD ThemMoi(ThemMoiThamSoHeThongMOD item)
        {
            var Result = new BaseResultMOD();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ThamSo", SqlDbType.VarChar),
                    new SqlParameter("@GiaTri", SqlDbType.VarChar),
                    new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                };
                parameters[0].Value = item.ThamSo.Trim();
                parameters[1].Value = item.GiaTri.Trim();
                parameters[2].Value = item.GhiChu.Trim();
                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            Result.Status = ULT.Utils.ConvertToInt32(SQLHelper.ExecuteScalar(trans, CommandType.StoredProcedure, "QTHT_ThamSo_ThemMoi", parameters).ToString(), 0);
                            trans.Commit();
                            Result.Message = "Thêm mới tham số hệ thống thành công!";
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


        // cập nhật thông tin Tham số hệ thống,
        public BaseResultMOD CapNhat(ThamSoHeThongMOD item)
        {
            var Result = new BaseResultMOD();
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", SqlDbType.Int),
                    new SqlParameter("@ThamSo", SqlDbType.VarChar),
                    new SqlParameter("@GiaTri", SqlDbType.VarChar),
                    new SqlParameter("@GhiChu", SqlDbType.NVarChar),
                };
                parameters[0].Value = item.id;
                parameters[1].Value = item.ThamSo.Trim();
                parameters[2].Value = item.GiaTri.Trim();
                parameters[3].Value = item.GhiChu.Trim();
                using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            Result.Status = SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "QTHT_ThamSo_CapNhat", parameters);
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

        // Xóa thông tin Tham số hệ thống
        public BaseResultMOD XoaThamSoHeThong(int id)
        {
            var Result = new BaseResultMOD();
            SqlParameter[] parameters = new SqlParameter[]
            {
               new SqlParameter("id", SqlDbType.Int)
            };
            parameters[0].Value = id;
            using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        var val = SQLHelper.ExecuteNonQuery(trans, System.Data.CommandType.StoredProcedure, "QTHT_ThamSo_Xoa", parameters);
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

        
        /// Kiểm tra hệ thống có bị trùng với các Tham số khác đã có hay khôn
        public int KiemTraTrung(int? id, string thamSo)
        {
            var SoLuong = 0;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id",SqlDbType.Int),
                new SqlParameter("@ThamSo",SqlDbType.VarChar)
            };
            parameters[0].Value = id ?? Convert.DBNull;
            parameters[1].Value = thamSo;
            try
            {
                using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, System.Data.CommandType.StoredProcedure, "QTHT_ThamSo_KiemTraTrung", parameters))
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
