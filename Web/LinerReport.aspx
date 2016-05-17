<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinerReport.aspx.cs" Inherits="CSADataReport.Web.LinerReport" %>

<%@ Register src="Controls/copyright.ascx" tagname="copyright" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>班轮货量填报(周报)</title>
    <script src="lib/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <link href="Css/btnclass.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
    
<!--
//        function init() {
//            document.getElementById("txbReportDate").value = new Date();
        //        }
//        function doClick() {
//            if (confirm("确定删除吗?")) {
//                document.getElementById("btnReport").click(); 
//            }
//        }

        function DoDateChange() {
            var s = document.getElementById("txbReportDate").value;
            document.getElementById("txbReportDate").value = s;
        }

// -->
    </script>
    <style type="text/css">
        .111
        {
            padding:"0";
            margin:"0";
            }
    </style>
</head>
<body>
<%--<div class="btn">
<img src="Images/CSALog.png" />
</div>--%>
    <form id="form1" runat="server">
<div>
<h2 align="center">班轮货量数据填报(周报)</h2>
</div>
    <table id="tBody" align="center">
        <tbody>
        <tr>
            <td width="70%">
                &nbsp;</td>
            <td colspan="4" style="text-align:right">数据日期：</td><td><input id="txbReportDate" name="ReportTime" runat="server" class="Wdate" onFocus="WdatePicker({lang:'zh-cn',isShowWeek:true,maxDate:new Date(),readOnly:true,isShowClear:false})" onchange="DoDateChange()" />
            </td>
        </tr>
        <tr>
        <td></td></tr>
        </tbody>
        </table>
        <div>
    <center>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
         OnRowDataBound="GridView1_RowDataBound" OnRowCreated="GridView1_RowCreated"
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:TemplateField HeaderText="班轮公司名称">
                <ItemTemplate>
                    <asp:DropDownList ID="x1" style="text-align:center" runat="server">
                    </asp:DropDownList>
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="代理艘次">
                <ItemTemplate>
                    <asp:TextBox ID="x2" style="text-align:right" runat="server" TextMode="Number"></asp:TextBox>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="代理箱量">
                <ItemTemplate>
                    <asp:TextBox ID="x3" style="text-align:right" runat="server" TextMode="Number"></asp:TextBox>
                </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
        <asp:Label ID="lblTotal" runat="server" Text="合计:" Width="100px"></asp:Label>
        <asp:Label ID="lblShipTotal" runat="server" Text="" Width="150px"></asp:Label>
        <asp:Label ID="lblContainerTotal" runat="server" Text="" Width="150px"></asp:Label> 
    <table>
        <tr>
            <td></td>
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="添加内容" OnClick="LinkButton1_Click"></asp:LinkButton>
            </td>
            <td>&nbsp;&nbsp; &nbsp;&nbsp;</td>
            <td>
                <asp:LinkButton ID="LinkButton2" runat="server" Text="删除内容" OnClick="LinkButton2_Click"></asp:LinkButton>
            </td>
        </tr>
    </table>
            <hr style="width:500px" />
            <table>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnSave" CssClass="btn" runat="server" Text="保 存" 
                    onclick="btnSave_Click" />
            </td>
            <td>
                <asp:Button ID="btnEdit" CssClass="btn" runat="server" Text="修 改" 
                    onclick="btnEdit_Click" Visible="False" />
            </td>
            <td>
                <asp:Button ID="btnReport" CssClass="btn" runat="server" Text="上 报" 
                    onclick="btnReport_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblMsg" runat="server" Width="300px" style="text-align:center" 
                    ForeColor="#CC0000"></asp:Label>
            </td>
        </tr>
    </table>
    </div>
    </center>
    </form>
</body>
</html>
