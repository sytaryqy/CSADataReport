using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CSADataReport.DBUtility;

namespace CSADataReport.DAL
{
    public partial class Users
    {
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateEx(CSADataReport.Model.Users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Users set ");
            strSql.Append("CnName=@CnName,");
            strSql.Append("LoginPwd=@LoginPwd,");
            strSql.Append("CompanyId=@CompanyId,");
            strSql.Append("UserRoleId=@UserRoleId,");
            strSql.Append("UserStateId=@UserStateId");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@CnName", SqlDbType.NVarChar,50),
					new SqlParameter("@LoginPwd", SqlDbType.NVarChar,50),
					new SqlParameter("@CompanyId", SqlDbType.Int,4),
					new SqlParameter("@UserRoleId", SqlDbType.Int,4),
					new SqlParameter("@UserStateId", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.CnName;
            parameters[1].Value = model.LoginPwd;
            parameters[2].Value = model.CompanyId;
            parameters[3].Value = model.UserRoleId;
            parameters[4].Value = model.UserStateId;
            parameters[5].Value = model.Id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新用户模型指定用户名的密码
        /// </summary>
        public bool UpdatePwd(CSADataReport.Model.Users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Users set ");
            strSql.Append("LoginPwd=@LoginPwd");
            strSql.Append(" where LoginName=@LoginName");
            SqlParameter[] parameters = {
					new SqlParameter("@LoginPwd", SqlDbType.NVarChar,50),
					new SqlParameter("@LoginName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.LoginPwd;
            parameters[1].Value = model.LoginName;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体及其关联对象
        /// </summary>
        public CSADataReport.Model.Users GetModelEx(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,CnName,LoginName,LoginPwd,CompanyId,UserRoleId,UserStateId,AddTime,IsDel from T_Users ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;
            CSADataReport.Model.Users model = new CSADataReport.Model.Users();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model = DataRowToModel(ds.Tables[0].Rows[0]);
                model.U_UserCompany = new DAL.Companies().GetModel(model.CompanyId);
                model.U_UserRoles = new DAL.UserRoles().GetModel(model.UserRoleId);
                model.U_UserStates = new DAL.UserStates().GetModel(model.UserStateId);
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CSADataReport.Model.Users DataRowToModelEx(DataRow row)
        {
            CSADataReport.Model.Users model = new CSADataReport.Model.Users();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["CnName"] != null)
                {
                    model.CnName = row["CnName"].ToString();
                }
                if (row["LoginName"] != null)
                {
                    model.LoginName = row["LoginName"].ToString();
                }
                if (row["LoginPwd"] != null)
                {
                    model.LoginPwd = row["LoginPwd"].ToString();
                }
                if (row["CompanyId"] != null && row["CompanyId"].ToString() != "")
                {
                    model.CompanyId = int.Parse(row["CompanyId"].ToString());
                    model.U_UserCompany = new DAL.Companies().GetModel(model.CompanyId);
                }
                if (row["UserRoleId"] != null && row["UserRoleId"].ToString() != "")
                {
                    model.UserRoleId = int.Parse(row["UserRoleId"].ToString());
                    model.U_UserRoles = new DAL.UserRoles().GetModel(model.UserRoleId);
                }
                if (row["UserStateId"] != null && row["UserStateId"].ToString() != "")
                {
                    model.UserStateId = int.Parse(row["UserStateId"].ToString());
                    model.U_UserStates = new DAL.UserStates().GetModel(model.UserStateId);
                }
                if (row["AddTime"] != null && row["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(row["AddTime"].ToString());
                }
                if (row["IsDel"] != null && row["IsDel"].ToString() != "")
                {
                    if ((row["IsDel"].ToString() == "1") || (row["IsDel"].ToString().ToLower() == "true"))
                    {
                        model.IsDel = true;
                    }
                    else
                    {
                        model.IsDel = false;
                    }
                }
            }
            return model;
        }

    }
}
