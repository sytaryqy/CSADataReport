<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="DeclareReportedList.aspx.cs" Inherits="CSADataReport.Web.DeclareReportedList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>报关数据填报</title>
    <link href="Css/Default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center>
<h3 align="center">报关历史数据</h3>
<%--    <form id="form1" runat="server">--%>
  <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetModelListByCompanyId" 
            TypeName="CSADataReport.BLL.DeclareDatas">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name="strCompanyId" 
                    SessionField="MyCompany" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
<div>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
        BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        DataSourceID="ObjectDataSource1" GridLines="Vertical">
        <EmptyDataTemplate>
                <asp:Label ID="Label1" runat="server" Text="没有查到任何数据"></asp:Label>
        </EmptyDataTemplate>
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" 
                Visible="False" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="DeclareReportYear" HeaderText="上报年" 
                SortExpression="DeclareReportYear" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="DeclareReportWeek" HeaderText="上报周" 
                SortExpression="DeclareReportWeek" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="D_UserCompany.CompanyName" HeaderText="口岸名称" 
                SortExpression="CompanyId" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="GFOuterDeclareBallot" 
                HeaderText="班轮关封票数" SortExpression="GFOuterDeclareBallot" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="GFOuterDeclareContainer" HeaderText="班轮关封箱量" 
                SortExpression="GFOuterDeclareContainer" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="GFOuterDeclareIncome" HeaderText="班轮关封收入" 
                SortExpression="GFOuterDeclareIncome" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="GFSelfDeclareBallot" HeaderText="班轮空箱票数" 
                SortExpression="GFSelfDeclareBallot" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="GFSelfDeclareContainer" HeaderText="班轮空箱箱量" 
                SortExpression="GFSelfDeclareContainer" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="GFSelfDeclareIncome" HeaderText="班轮空箱收入" 
                SortExpression="GFSelfDeclareIncome" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="GFOtherDeclareBallot" HeaderText="班轮其它票数" 
                SortExpression="GFOtherDeclareBallot" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="GFOtherDeclareContainer" HeaderText="班轮其它箱量" 
                SortExpression="GFOtherDeclareContainer" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="GFOtherDeclareIncome" HeaderText="班轮其它收入" 
                SortExpression="GFOtherDeclareIncome" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="QTOuterDeclareBallot" HeaderText="货代外包票数" 
                SortExpression="QTOuterDeclareBallot" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="QTOuterDeclareContainer" HeaderText="货代外包箱量" 
                SortExpression="QTOuterDeclareContainer" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="QTOuterDeclareIncome" HeaderText="货代外包收入" 
                SortExpression="QTOuterDeclareIncome" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="QTSelfDeclareBallot" HeaderText="货代自报票数" 
                SortExpression="QTSelfDeclareBallot" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="QTSelfDeclareContainer" HeaderText="货代自报箱量" 
                SortExpression="QTSelfDeclareContainer" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="QTSelfDeclareIncome" HeaderText="货代自报收入" 
                SortExpression="QTSelfDeclareIncome" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="QTOtherDeclareBallot" HeaderText="货代其它票数" 
                SortExpression="QTOtherDeclareBallot" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="QTOtherDeclareContainer" HeaderText="货代其它箱量" 
                SortExpression="QTOtherDeclareContainer" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="QTOtherDeclareIncome" HeaderText="货代其它收入" 
                SortExpression="QTOtherDeclareIncome" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="AddTime" HeaderText="添加时间" 
                SortExpression="AddTime" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="EditTime" HeaderText="上报时间" 
                SortExpression="EditTime" Visible="False" />
            <asp:CheckBoxField DataField="IsReported" HeaderText="是否上报" 
                SortExpression="IsReported" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:CheckBoxField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="Gray" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />

<SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

<SortedAscendingHeaderStyle BackColor="#0000A9"></SortedAscendingHeaderStyle>

<SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

<SortedDescendingHeaderStyle BackColor="#000065"></SortedDescendingHeaderStyle>
    </asp:GridView>
    </div>
    </form>
    </center>
</asp:Content>
