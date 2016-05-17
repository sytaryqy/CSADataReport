<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="CSADataReport.Web.DeclareDatas.Show" Title="显示页" %>
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
		DeclareReportWeek
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDeclareReportWeek" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DeclareReportYear
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDeclareReportYear" runat="server"></asp:Label>
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
		GFOuterDeclareBallot
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblGFOuterDeclareBallot" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		GFSelfDeclareBallot
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblGFSelfDeclareBallot" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		GFOtherDeclareBallot
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblGFOtherDeclareBallot" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		QTOuterDeclareBallot
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblQTOuterDeclareBallot" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		QTSelfDeclareBallot
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblQTSelfDeclareBallot" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		QTOtherDeclareBallot
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblQTOtherDeclareBallot" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		GFOuterDeclareContainer
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblGFOuterDeclareContainer" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		GFSelfDeclareContainer
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblGFSelfDeclareContainer" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		GFOtherDeclareContainer
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblGFOtherDeclareContainer" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		QTOuterDeclareContainer
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblQTOuterDeclareContainer" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		QTSelfDeclareContainer
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblQTSelfDeclareContainer" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		QTOtherDeclareContainer
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblQTOtherDeclareContainer" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		GFOuterDeclareIncome
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblGFOuterDeclareIncome" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		GFSelfDeclareIncome
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblGFSelfDeclareIncome" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		GFOtherDeclareIncome
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblGFOtherDeclareIncome" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		QTOuterDeclareIncome
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblQTOuterDeclareIncome" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		QTSelfDeclareIncome
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblQTSelfDeclareIncome" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		QTOtherDeclareIncome
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblQTOtherDeclareIncome" runat="server"></asp:Label>
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
	<tr>
	<td height="25" width="30%" align="right">
		IsReported
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblIsReported" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




