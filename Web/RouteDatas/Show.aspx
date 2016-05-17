<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="CSADataReport.Web.RouteDatas.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		Id
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ReportWeek
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblReportWeek" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ReportYear
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblReportYear" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CompanyId
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCompanyId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		RouteId
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRouteId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		LineId
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLineId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		GP20
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblGP20" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		GP40
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblGP40" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		HQ40
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblHQ40" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		HQ45
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblHQ45" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		TEU
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTEU" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Others
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblOthers" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		IsReported
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblIsReported" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		AddTime
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAddTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		EditTime
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblEditTime" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




