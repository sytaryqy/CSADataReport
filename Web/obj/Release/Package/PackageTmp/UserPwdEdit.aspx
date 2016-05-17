<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPwdEdit.aspx.cs" Inherits="CSADataReport.Web.UserPwdEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>信息修改</title>
    <link href="Css/Default.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function btnC_onclick() {
            window.location = "Main.aspx";
        }

// ]]>
    </script>
</head>
<body bgcolor="#ccffff">
    <form id="fEdit" runat="server">
    <center>
    <div>
        <table class="title" >
            <tr><td>密码修改</td></tr>
        </table>
        <br /> 
        <table id="tBody" cellpadding="0px" cellspacing="0px" >
            <tr><td style="text-align:right">登&nbsp;录&nbsp;名：</td><td>
                <asp:TextBox ID="txtUname" runat="server"></asp:TextBox>
                </td><td style="text-align:left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="用户名不能为空" ControlToValidate="txtUname">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtUname" Display="Dynamic" ErrorMessage="不存在少于6位的用户名" 
                        ValidationExpression="^\w{6,}$">*</asp:RegularExpressionValidator>
                </td></tr>
            <tr><td style="text-align:right">原&nbsp;密&nbsp;码：</td><td>
                <asp:TextBox ID="txtOrgPwd" runat="server"></asp:TextBox>
                </td><td style="text-align:left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtOrgPwd" ErrorMessage="原密码不能为空">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="txtOrgPwd" Display="Dynamic" ErrorMessage="原密码不能少于6位" 
                        ValidationExpression="^\S{6,}$">*</asp:RegularExpressionValidator>
                </td></tr>
            <tr><td style="text-align:right">新&nbsp;密&nbsp;码：</td><td>
                <asp:TextBox ID="txtNewPwd" runat="server"></asp:TextBox>
                </td><td style="text-align:left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtNewPwd" Display="Dynamic" ErrorMessage="新密码不能为空">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                        ControlToValidate="txtNewPwd" Display="Dynamic" ErrorMessage="新密码不能少于6位" 
                        ValidationExpression="^\S{6,}$">*</asp:RegularExpressionValidator>
                </td></tr>
            <tr><td style="text-align:right">密码确认：</td><td>
                <asp:TextBox ID="txtPwdConfirm" runat="server"></asp:TextBox>
                </td><td style="text-align:left">
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="txtNewPwd" ControlToValidate="txtPwdConfirm" 
                        Display="Dynamic" ErrorMessage="两次输入的密码不同">*</asp:CompareValidator>
                </td></tr>
            <tr><td></td><td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    ShowMessageBox="True" ShowSummary="False" />
                <asp:Button ID="btnS" runat="server" CssClass="btn" Text="修改" 
                    onclick="btnS_Click" />
                <input type="button" id="btnC" class="btn" value="取消" onclick="return btnC_onclick()" /></td><td></td></tr>
        </table>     
    </div>
    </center>
    </form>
</body>
</html>
