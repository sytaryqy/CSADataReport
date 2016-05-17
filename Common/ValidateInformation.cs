using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Maticsoft.DBUtility;

namespace Maticsoft.Common
{
    public class ValidateInformation
    {
        /// <summary>
        /// 验证用户帐号密码
        /// </summary>
        /// <param name="userName">帐号</param>
        /// <param name="userPassword">密码</param>
        /// <returns>对应的帐号Id</returns>
        public static int ValidateLogin(string userName, string userPassword)
        {
            MD5Helper helper = new MD5Helper();
            //string key = userPassword.Substring(0, 2); 
            string key = "cs";
            string encPassword=key+ helper.GetMD5(userPassword + key);
            SqlParameter[] array = new SqlParameter[]
	{
		new SqlParameter("@UserName", SqlDbType.VarChar, 50),
		new SqlParameter("@EncryptedPassword", SqlDbType.VarChar, 50)
	};
            array[0].Value = userName;
            array[1].Value = encPassword;
            int num;
            return DBUtility.DbHelperSQL.RunProcedure("sp_Accounts_ValidateLogin", array, out num);
        }

        /// <summary>
        /// 验证用户帐号
        /// </summary>
        /// <param name="userName">帐号</param>
        /// <param name="userPassword">密码</param>
        /// <returns>对应的AccountsPrincipal用户</returns>
        public static CSADataReport.Model.Users ValidateLoginUser(string userName, string userPassword)
        {
            int userID;
            if ((userID = ValidateLogin(userName, userPassword)) > 0)
            {

                return new Common.ValidateInformation().GetUserModel(userID);
            }
            return null;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CSADataReport.Model.Users GetUserModel(int Id)
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
                model = UserDataRowToModel(ds.Tables[0].Rows[0]);
                model.U_UserCompany = GetCompanyModel(model.CompanyId);
                model.U_UserRoles = GetUserRoleModel(model.UserRoleId);
                model.U_UserStates = GetUserStateModel(model.UserStateId);
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个Companies对象实体
        /// </summary>
        public CSADataReport.Model.Companies GetCompanyModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,CompanyName,CompanyCode,CompanyNum,AreaId,CompanyTypeId,ParentCompanyId,AddTime,IsDel from T_Companies ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)			};
            parameters[0].Value = Id;

            CSADataReport.Model.Companies model = new CSADataReport.Model.Companies();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return CompanyDataRowToModel
(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个Users对象实体
        /// </summary>
        public CSADataReport.Model.Users UserDataRowToModel(DataRow row)
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
                }
                if (row["UserRoleId"] != null && row["UserRoleId"].ToString() != "")
                {
                    model.UserRoleId = int.Parse(row["UserRoleId"].ToString());
                }
                if (row["UserStateId"] != null && row["UserStateId"].ToString() != "")
                {
                    model.UserStateId = int.Parse(row["UserStateId"].ToString());
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

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CSADataReport.Model.Companies CompanyDataRowToModel(DataRow row)
        {
            CSADataReport.Model.Companies model = new CSADataReport.Model.Companies();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["CompanyName"] != null)
                {
                    model.CompanyName = row["CompanyName"].ToString();
                }
                if (row["CompanyCode"] != null)
                {
                    model.CompanyCode = row["CompanyCode"].ToString();
                }
                if (row["CompanyNum"] != null)
                {
                    model.CompanyNum = row["CompanyNum"].ToString();
                }
                if (row["AreaId"] != null && row["AreaId"].ToString() != "")
                {
                    model.AreaId = int.Parse(row["AreaId"].ToString());
                }
                if (row["CompanyTypeId"] != null && row["CompanyTypeId"].ToString() != "")
                {
                    model.CompanyTypeId = int.Parse(row["CompanyTypeId"].ToString());
                }
                if (row["ParentCompanyId"] != null && row["ParentCompanyId"].ToString() != "")
                {
                    model.ParentCompanyId = int.Parse(row["ParentCompanyId"].ToString());
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

        /// <summary>
        /// 得到一个UserRole对象实体
        /// </summary>
        public CSADataReport.Model.UserRoles GetUserRoleModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Name from T_UserRoles ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            CSADataReport.Model.UserRoles model = new CSADataReport.Model.UserRoles();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return UserRoleDataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个UserRole对象实体
        /// </summary>
        public CSADataReport.Model.UserRoles UserRoleDataRowToModel(DataRow row)
        {
            CSADataReport.Model.UserRoles model = new CSADataReport.Model.UserRoles();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CSADataReport.Model.UserStates GetUserStateModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Name from T_UserStates ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            CSADataReport.Model.UserStates model = new CSADataReport.Model.UserStates();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return UserStateDataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个UserState对象实体
        /// </summary>
        public CSADataReport.Model.UserStates UserStateDataRowToModel(DataRow row)
        {
            CSADataReport.Model.UserStates model = new CSADataReport.Model.UserStates();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
            }
            return model;
        }
    }
}