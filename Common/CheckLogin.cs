using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CSADataReport.Common
{
    public class CheckLogin
    {

        /// <summary>
        /// current user object
        /// </summary>
        public static CSADataReport.Model.Users SetUserObj
        {
            get 
            {
                return (CSADataReport.Model.Users)HttpContext.Current.Session["UserInfo"];
            }
            set 
            {
                HttpContext.Current.Session["UserInfo"] = value;
            }
        }


        /// <summary>
        /// user login state
        /// </summary>
        public static bool IsLogined
        {
            get
            {
                if (SetUserObj == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// show the login page and then redirect to the original page
        /// </summary>
        public static void ShowLoginPageAndReturn()
        {
            ////判断用户是否登录
            //if (!IsLogined)
            //{
                HttpContext.Current.Session["returnPage"] = HttpContext.Current.Request.Url.PathAndQuery;
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Write("<script language=javascript>window.alert('您当前没有登录！\\n请登录或与管理员联系！');window.location='/UserLogin.aspx';</script>");
                HttpContext.Current.Response.End();
            //}
        }

        /// <summary>
        /// Redirct to the login page if current user has no rights to visit the page
        /// </summary>
        public static void ShowLoginPage()
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write("<script language=javascript>window.alert('您没有权限访问当前页面！\\n请重新登录或与管理员联系！');window.location='/UserLogin.aspx';</script>");
            HttpContext.Current.Response.End();
            //}
        }

        /// <summary>
        /// Show the alert message to the user who is not allowed to access this page.
        /// </summary>
        public static void ShowAlertMessage()
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write("<script language=javascript>window.alert('您没有权限访问当前页面！\\n请注销重新重新登录或与管理员联系！');</script>");
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// Compare the strUserRole with user's U_UserRoles.Name,if not equal show the alarm message and redirct to the login page
        /// </summary>
        /// <param name="strUserRole">the allowed user's UserRole Name</param>
        public static void CheckUserRoleAllowed(string strUserRole) 
        {
            //判断用户是否登录
            if (!IsLogined)
            {
                ShowLoginPageAndReturn();
            }

            //if (SetUserObj == null)
            //{
            //    HttpContext.Current.Session["returnPage"] = HttpContext.Current.Request.Url.PathAndQuery;
            //    HttpContext.Current.Response.Clear();
            //    HttpContext.Current.Response.Write("<script language=javascript>window.alert('您当前没有登录！\\n请登录或与管理员联系！');window.location='/UserLogin.aspx';</script>");
            //    HttpContext.Current.Response.End();
            //}
            else
            {
                if (SetUserObj.U_UserRoles.Name != strUserRole)
                {
                    ShowLoginPage();
                }
            }
        }


        /// <summary>
        /// Compare the strNotAllowedUserRole with user's U_UserRoles.Name,if equal show the alarm message and redirct to the login page
        /// </summary>
        /// <param name="strUserRole">the not allowed user's UserRole Name</param>
        public static void CheckUserRoleNotAllowed(string strNotAllowedUserRole)
        {
            //判断用户是否登录
            if (!IsLogined)
            {
                ShowLoginPageAndReturn();
            }
            else
            {
                if (SetUserObj.U_UserRoles.Name == strNotAllowedUserRole)
                {
                    ShowAlertMessage();
                }
            }
        }
    }
}
