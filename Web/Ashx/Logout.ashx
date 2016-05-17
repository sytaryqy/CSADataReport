<%@ WebHandler Language="C#" Class="Logout" %>

using System;
using System.Web;
using System.Web.SessionState;

public class Logout : IHttpHandler, IRequiresSessionState
{
    
    public void ProcessRequest(HttpContext context)
    {
        if (context.Session["UserInfo"] != null)
        {
            context.Session.Abandon();
            context.Response.Redirect("/Main.aspx");
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}