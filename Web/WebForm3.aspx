<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="CSADataReport.Web.WebForm3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound"
    OnRowCreated="GridView1_RowCreated">
    <Columns>
      <asp:TemplateField HeaderText="选择1">
        <ItemTemplate>
          <asp:DropDownList ID="x1" runat="server">
          </asp:DropDownList>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="选择2">
        <ItemTemplate>
          <asp:DropDownList ID="x2" runat="server">
          </asp:DropDownList>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="输入文字">
        <ItemTemplate>
          <asp:TextBox ID="x3" runat="server"></asp:TextBox>
        </ItemTemplate>
      </asp:TemplateField>
    </Columns>
  </asp:GridView>
  <asp:LinkButton ID="LinkButton1" runat="server" Text="添加内容" OnClick="LinkButton1_Click"></asp:LinkButton>
  <asp:LinkButton ID="LinkButton2" runat="server" Text="删除内容" OnClick="LinkButton2_Click"></asp:LinkButton>
    </div>
    </form>
</body>
</html>
