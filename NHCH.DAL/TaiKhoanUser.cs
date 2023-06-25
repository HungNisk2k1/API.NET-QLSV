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
        public class TaiKhoanUser
        {
            public TaiKhoanMOD LoginDAL(string UserName, string Password)
            {
                TaiKhoanMOD item = null;
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@UserName", SqlDbType.NVarChar),
                new SqlParameter("@Password", SqlDbType.NVarChar),
                };
                parameters[0].Value = UserName;
                parameters[1].Value = Password;
                try
                {
                    using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.appConnectionStrings, System.Data.CommandType.StoredProcedure, "SingnInUser", parameters))
                    {
                        while (dr.Read())
                        {
                            item = new TaiKhoanMOD();
                            item.UserName = Utils.ConvertToString(dr["UserName"], string.Empty);
                            item.Password = Utils.ConvertToString(dr["Password"], string.Empty);

                            break;
                        }
                        dr.Close();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                return item;
            }

            // DANG KI 
            public BaseResultMOD RegisterDAL(DangKiTaiKhoan item)
            {
                var Result = new BaseResultMOD();
                try
                {
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                    new SqlParameter("@MaSinhVien", SqlDbType.VarChar),
                    new SqlParameter("@UserName", SqlDbType.VarChar),
                    new SqlParameter("@Password", SqlDbType.VarChar),
                    };
                    parameters[0].Value = item.MaSinhVien;
                    parameters[1].Value = item.UserName;
                    parameters[2].Value = item.Password;

                    using (SqlConnection conn = new SqlConnection(SQLHelper.appConnectionStrings))
                    {
                        conn.Open();
                        using (SqlTransaction trans = conn.BeginTransaction())
                        {
                            try
                            {
                                Result.Status = SQLHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "Register", parameters);
                                trans.Commit();
                                Result.Message = "Đăng ký thành công!";
                                Result.Data = Result.Status;
                            }
                            catch (Exception)
                            {
                                Result.Status = -1;
                                Result.Message = "Đăng ký thất bại!";
                                trans.Rollback();
                                throw;
                            }
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
        }
    }

