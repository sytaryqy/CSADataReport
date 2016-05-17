<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="CSADataReport.Web.DeclareDatas.Modify" Title="修改页" %>
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
		<asp:label id="lblId" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DeclareReportWeek
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDeclareReportWeek" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DeclareReportYear
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDeclareReportYear" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CompanyId
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCompanyId" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		GFOuterDeclareBallot
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtGFOuterDeclareBallot" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		GFSelfDeclareBallot
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtGFSelfDeclareBallot" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		GFOtherDeclareBallot
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtGFOtherDeclareBallot" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		QTOuterDeclareBallot
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtQTOuterDeclareBallot" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		QTSelfDeclareBallot
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtQTSelfDeclareBallot" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		QTOtherDeclareBallot
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtQTOtherDeclareBallot" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		GFOuterDeclareContainer
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtGFOuterDeclareContainer" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		GFSelfDeclareContainer
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtGFSelfDeclareContainer" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		GFOtherDeclareContainer
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtGFOtherDeclareContainer" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		QTOuterDeclareContainer
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtQTOuterDeclareContainer" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		QTSelfDeclareContainer
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtQTSelfDeclareContainer" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		QTOtherDeclareContainer
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtQTOtherDeclareContainer" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		GFOuterDeclareIncome
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtGFOuterDeclareIncome" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		GFSelfDeclareIncome
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtGFSelfDeclareIncome" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		GFOtherDeclareIncome
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtGFOtherDeclareIncome" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		QTOuterDeclareIncome
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtQTOuterDeclareIncome" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		QTSelfDeclareIncome
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtQTSelfDeclareIncome" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		QTOtherDeclareIncome
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtQTOtherDeclareIncome" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		AddTime
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtAddTime" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		EditTime
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtEditTime" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		IsReported
	：</td>
	<td height="25" width="*" align="left">
		<asp:CheckBox ID="chkIsReported" Text="IsReported" runat="server" Checked="False" />
	</td></tr>
</table>
<script src="/js/calendar1.js" type="text/javascript"></script>

            </td>
        </tr>
        <tr>
            <td class="tdbg" align="center" valign="bottom">
                <asp:Button ID="btnSave" runat="server" Text="保存"
                    OnClick="btnSave_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
                <asp:Button ID="btnCancle" runat="server" Text="取消"
                    OnClick="btnCancle_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>

