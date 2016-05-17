<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.Master" AutoEventWireup="true" CodeBehind="DeclareReport.aspx.cs" Inherits="CSADataReport.Web.DeclareReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>报关数据填报(周报)</title>
    <link href="Css/Default.css" rel="stylesheet" type="text/css" />
    <script src="lib/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <link href="Css/btnclass.css" rel="stylesheet" type="text/css" />
    <script type[="text/javascript">
        function DoDateChange() {
            var s = document.getElementById("txbReportDate").value;
            document.getElementById("txbReportDate").value = s;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <%--   <form id="fDeclareDatas" method="post" action="">--%>
 <h2 align="center">报关数据填报(周报)</h3>
    <br />
    
    <table id="tBody" align="center">
        <tbody>
        <tr>
            <td colspan="4" style="text-align:right">数据日期：</td><td><input id="txbReportDate" name="ReportTime" runat="server" class="Wdate" onFocus="WdatePicker({lang:'zh-cn',isShowWeek:true,maxDate:new Date(),readOnly:true,isShowClear:false})"  />
            </td>
        </tr>
            <tr>
                <td></td>
                <td>报关类型</td>
                <td>报关票数</td>
                <td>报关箱量</td>
                <td>报关收入</td>
            </tr>
            <tr>
                <td rowspan="3">班轮报关</td>
                <td>关封</td>
                <td>
                    <asp:TextBox ID="txbWaibaoGuanfengNum" style="TEXT-ALIGN: right;vertical-align:middle" runat="server" 
                         Width="148px" 
                        BackColor="#99ccff"  MaxLength="15" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txbWaibaoGuanfengContainer" style="TEXT-ALIGN: right;vertical-align:middle" 
                        runat="server"  Width="148px" BackColor="#99ccff"  MaxLength="15" 
                        TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txbWaibaoGuanfengIncome" style="TEXT-ALIGN: right" runat="server"  Width="148px" BackColor="#99ccff" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}" MaxLength="15"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>空箱</td>
                <td>
                    <asp:TextBox ID="txbZibaoGuanfengNum" style="TEXT-ALIGN: right;vertical-align:middle" runat="server"  Width="148px" BackColor="#99ccff" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txbZibaoGuanfengContainer" style="TEXT-ALIGN: right;vertical-align:middle" runat="server"  Width="148px" BackColor="#99ccff" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txbZibaoGuanfengIncome" style="TEXT-ALIGN: right;vertical-align:middle" 
                        runat="server"  Width="148px" BackColor="#99ccff" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}" MaxLength="15"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>其他</td>
                <td>
                    <asp:TextBox ID="txbQitaGuanfengNum" style="TEXT-ALIGN: right;vertical-align:middle" runat="server" Width="148px" BackColor="#99ccff" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txbQitaGuanfengContainer" style="TEXT-ALIGN: right;vertical-align:middle" runat="server"  Width="148px" BackColor="#99ccff" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txbQitaGuanfengIncome" style="TEXT-ALIGN: right;vertical-align:middle" 
                        runat="server"  Width="148px" BackColor="#99ccff" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}" MaxLength="15"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td rowspan="3">货代报关</td>
                <td>外包</td>
                <td>
                    <asp:TextBox ID="txbWaibaoQitaNum" style="TEXT-ALIGN: right;vertical-align:middle" runat="server"  Width="148px" BackColor="#99ccff" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txbWaibaoQitaContainer" style="TEXT-ALIGN: right;vertical-align:middle" runat="server"  Width="148px" BackColor="#99ccff" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txbWaibaoQitaIncome" style="TEXT-ALIGN: right;vertical-align:middle" runat="server" 
                         Width="148px" BackColor="#99ccff" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}" MaxLength="15"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>自报</td>
                <td>
                    <asp:TextBox ID="txbZibaoQitaNum" style="TEXT-ALIGN: right;vertical-align:middle" runat="server"  Width="148px" BackColor="#99ccff" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txbZibaoQitaContainer" style="TEXT-ALIGN: right;vertical-align:middle" runat="server"  Width="148px" BackColor="#99ccff" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txbZibaoQitaIncome" style="TEXT-ALIGN: right;vertical-align:middle;vertical-align:middle" runat="server" 
                         Width="148px" BackColor="#99ccff" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}" MaxLength="15"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>其他</td>
                <td>
                    <asp:TextBox ID="txbQitaNum" style="TEXT-ALIGN: right;vertical-align:middle" runat="server"  Width="148px" BackColor="#99ccff" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txbQitaContainer" style="TEXT-ALIGN: right;vertical-align:middle" runat="server"  Width="148px" BackColor="#99ccff" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txbQitaIncome" style="TEXT-ALIGN: right;vertical-align:middle" runat="server" 
                         Width="148px" BackColor="#99ccff" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))||(event.keyCode==46)) {event.returnValue=true;} else{event.returnValue=false;}" MaxLength="15"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>小计</td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lblBallotTotal" style="TEXT-ALIGN: right;vertical-align:middle" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblContainerTotal" style="TEXT-ALIGN: right;vertical-align:middle" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblIncomeTotal" style="TEXT-ALIGN: right;vertical-align:middle" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
            <td colspan="2" style="text-align:right">所属口岸：</td><td colspan="3" style="text-align:left"><%=currentUser.U_UserCompany.CompanyName %></td>
        </tr>
        </tbody>
    </table>
    <br />
    <table align="center">
    <tr>
        <td>
            <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
        </td>
    </tr>
    </table>
    <table align="center">
    <tr>
    <td></td>
    <td><asp:Button ID="btnSave" runat="server" Text="保 存" CssClass="btn"  
            onclick="btnSave_Click" /></td>
    <td width="50"></td>
    <td><asp:Button ID="btnReport" runat="server" Text="上 报" CssClass="btn" Enabled="false"
            onclick="btnReport_Click"  /></td>
    <td></td>
    </tr>   
    </table>
    </form>
</asp:Content>
