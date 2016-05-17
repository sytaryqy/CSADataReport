<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatasManageMain.aspx.cs" Inherits="CSADataReport.Web.Admin.DatasManageMain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>业务数据管理</title>
    <link href="../Css/Default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    &nbsp;
    <h1 align="center">业务数据管理</h1>
    &nbsp;
        <table id="tBody" height="350" cellspacing="0" cellpadding="0" width="638" align="center" border="0">
        <tbody>
            <tr >
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="center">
                    <asp:HyperLink ID="HyperLink1"  runat="server" NavigateUrl="~/Admin/DeclareDatasManage.aspx" >报关数据管理</asp:HyperLink>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="center">
                    <asp:HyperLink runat="server" NavigateUrl="~/Admin/RouteDatasManage.aspx" >航线数据管理</asp:HyperLink>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="center">
                    <asp:HyperLink runat="server" NavigateUrl="~/Admin/IncomeDatasManage.aspx" >收入数据管理</asp:HyperLink>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="center">
                    <asp:HyperLink runat="server" NavigateUrl="~/Admin/LinerDatasManage.aspx">班轮货量数据管理</asp:HyperLink>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="center">
                    <asp:HyperLink runat="server" NavigateUrl="~/Admin/LinerIncomeManage.aspx">班轮收入数据管理</asp:HyperLink>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </tbody>
        </table>
    </div>
    </form>
</body>
</html>
