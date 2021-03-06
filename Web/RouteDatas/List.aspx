﻿<%@ Page Title="T_RouteDatas" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="CSADataReport.Web.RouteDatas.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" src="/js/CheckBox.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!--Title -->

            <!--Title end -->

            <!--Add  -->

            <!--Add end -->

            <!--Search -->
            <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>
                    <td style="width: 80px" align="right" class="tdbg">
                         <b>关键字：</b>
                    </td>
                    <td class="tdbg">                       
                    <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查询"  OnClick="btnSearch_Click" >
                    </asp:Button>                    
                        
                    </td>
                    <td class="tdbg">
                    </td>
                </tr>
            </table>
            <!--Search end-->
            <br />
            <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3"  OnPageIndexChanging ="gridView_PageIndexChanging"
                    BorderWidth="1px" DataKeyNames="Id" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="false" PageSize="10"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
                    <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择"    >
                                <ItemTemplate>
                                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
		<asp:BoundField DataField="ReportWeek" HeaderText="ReportWeek" SortExpression="ReportWeek" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ReportYear" HeaderText="ReportYear" SortExpression="ReportYear" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="CompanyId" HeaderText="CompanyId" SortExpression="CompanyId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="RouteId" HeaderText="RouteId" SortExpression="RouteId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="LineId" HeaderText="LineId" SortExpression="LineId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="GP20" HeaderText="GP20" SortExpression="GP20" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="GP40" HeaderText="GP40" SortExpression="GP40" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="HQ40" HeaderText="HQ40" SortExpression="HQ40" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="HQ45" HeaderText="HQ45" SortExpression="HQ45" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="TEU" HeaderText="TEU" SortExpression="TEU" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Others" HeaderText="Others" SortExpression="Others" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="IsReported" HeaderText="IsReported" SortExpression="IsReported" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="AddTime" HeaderText="AddTime" SortExpression="AddTime" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="EditTime" HeaderText="EditTime" SortExpression="EditTime" ItemStyle-HorizontalAlign="Center"  /> 
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Show.aspx?id={0}"
                                Text="详细"  />
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Modify.aspx?id={0}"
                                Text="编辑"  />
                            <asp:TemplateField ControlStyle-Width="50" HeaderText="删除"   Visible="false"  >
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                         Text="删除"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                </asp:GridView>
               <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
                <tr>
                    <td style="width: 1px;">                        
                    </td>
                    <td align="left">
                        <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click"/>                       
                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
