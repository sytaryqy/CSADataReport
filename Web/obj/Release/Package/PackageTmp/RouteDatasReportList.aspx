<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RouteDatasReportList.aspx.cs" Inherits="CSADataReport.Web.RouteDatasReportList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<h3 align="center">航线已上报数据</h3>
    <form id="form1" runat="server">
    <center>
    <div>
    
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetModelListByCompanyId" TypeName="CSADataReport.BLL.RouteDatas">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name="strCompanyId" 
                    SessionField="MyCompany" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True"  
            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
            BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            DataSourceID="ObjectDataSource1" GridLines="Vertical">
            <AlternatingRowStyle BackColor="Gainsboro" />
            <EmptyDataTemplate>
                <asp:Label ID="Label1" runat="server" Text="没有查到任何数据"></asp:Label>
            </EmptyDataTemplate>
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" 
                    Visible="False" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="ReportWeek" HeaderText="上报周" 
                    SortExpression="ReportWeek" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="ReportYear" HeaderText="上报年" 
                    SortExpression="ReportYear" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="CompanyId" HeaderText="CompanyId" 
                    SortExpression="CompanyId" Visible="False" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="R_Routes.Name" HeaderText="航线" 
                    SortExpression="RouteId" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="R_Lines.Name" HeaderText="线路" 
                    SortExpression="LineId" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="GP20" HeaderText="GP20" SortExpression="GP20" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="GP40" HeaderText="GP40" SortExpression="GP40" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="HQ40" HeaderText="HQ40" SortExpression="HQ40" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="HQ45" HeaderText="其他（20尺以下）" SortExpression="HQ45" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Others" HeaderText="其他（40尺以上）" 
                    SortExpression="Others" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="TEU" HeaderText="TEU" SortExpression="TEU" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:CheckBoxField DataField="IsReported" HeaderText="是否上报" 
                    SortExpression="IsReported" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:CheckBoxField>
                <asp:BoundField DataField="AddTime" HeaderText="AddTime" 
                    SortExpression="AddTime" Visible="False" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="EditTime" HeaderText="EditTime" 
                    SortExpression="EditTime" Visible="False" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
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
    
    </div>
    </center>
    </form>
</body>
</html>
