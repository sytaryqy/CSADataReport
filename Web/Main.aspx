<%@ Register TagPrefix="uc1" TagName="CopyRight" Src="/Controls/copyright.ascx" %>

<%@ Page Language="c#" CodeBehind="Main.aspx.cs" AutoEventWireup="True" Inherits="CSADataReport.Web.Main" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Main</title>
    <link href="Css/Default.css" rel="stylesheet" type="text/css" />
</head>
<body bgcolor="#ccffff" >
    <form id="Form1" method="post" runat="server">
<%--        <div>
            <img alt="中海船务" src="Images/CSALog.png" />
        </div>--%>
        <br>
        <table bgcolor="white" height="30" cellspacing="0" cellpadding="0" width="500" align="center" border="0">
        <tbody>
            <tr>
                <td colspan="3"><img src="Images/a_te01.gif" /></td>
            </tr>
            <tr>
                <td style="font-size:small">
                    欢迎：<asp:LinkButton ID="LinkButton1" PostBackUrl="~/UserPwdEdit.aspx"  runat="server"><%=currentUser.CnName %></asp:LinkButton>&nbsp;
                    &nbsp;<asp:LinkButton ID="LinkButton2" PostBackUrl="~/Ashx/Logout.ashx" runat="server">注销</asp:LinkButton>
                </td>
                <td style="font-size:small">
                    所属公司：<%=currentUser.U_UserCompany.CompanyName %>
                </td>
                <td style="font-size:small">
                    用户组：<%=currentUser.U_UserRoles.Name %>
                </td>
            </tr>
            <tr>
                <td colspan="3"><img src="Images/a_te03.gif" /></td>
            </tr>
            </tbody>
            </table>
            <br />
            <br />
        <table id="tBody" height="350" cellspacing="0" cellpadding="0" width="638" align="center" border="0">
        <tbody>
            <tr>
            <td width="200" valign="middle">
            </td>
            <td align="center">
                    <a style="font-size:large;" href="DeclareReport.aspx?CompanyId=<%=currentUser.U_UserCompany.Id %>" >报关数据填报(周报)</a>
            </td>
                <td width="200"  valign="middle">
                </td>
            </tr>
            <tr>
            <td valign="middle">

            </td>
            <td align="center">
                    <a style="font-size:large;" href="RouteDatasReport.aspx" >航线数据填报(周报)</a>
                </td>
                <td></td>
            </tr>

            <tr>
            <td></td>
                <td align="center">
                    <a style="font-size:large;" href="LinerReport.aspx" >班轮数据填报(周报)</a>
                </td>
                <td></td>
            </tr>
            <tr>
            <td></td>
                <td align="center">
                    <a style="font-size:large;" href="LinerIncomeDatas.aspx" >班轮收入填报(月报)</a>
                </td>
                <td></td>
            </tr>
            <tr>
            <td></td>
                <td align="center">
                    <a style="font-size:large;" href="IncomeDatasReport.aspx" >收入数据填报(月报)</a>
                </td>
                <td></td>
            </tr>
            </tbody>
        </table>
        <br />
        <br />
        <br />
        <br />
        <uc1:CopyRight ID="CopyRight1" runat="server"></uc1:CopyRight>
    </form>
</body>
</html>
