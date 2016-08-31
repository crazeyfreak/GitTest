<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main_frm.aspx.cs" Inherits="GitTest1.WebForm1" %>
<style>
    ul {
      list-style-type:none;
      margin:0;
      padding:0;  
    }
    li {
        display:inline;
        margin-right:10px;
    }

    li:hover{
        background-color:blue;
    }
    .main_div {
        margin-top:20px;
    }
    .filter_pnl {
        margin-top:10px;
    }
</style>

<!DOCTYPE html>
<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
<html xmlns="http://www.w3.org/1999/xhtml">


<head runat="server">
    <title>My Testing</title>
</head>
<body onload="Page_Load">
    <form id="form1" runat="server">
       <div class="main_div">
           <ul>
               <li><asp:Button runat="server" Text="Insert Record" Height="26px" OnClick="Unnamed1_Click" /></li>
           </ul>
       </div>
        <div style="margin-bottom:10px">
           <asp:DropDownList ID="Select_Drop" runat="server" Width="20%" CssClass="dropdown">
            <asp:ListItem>Summery</asp:ListItem>
            <asp:ListItem>Detail</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="Btn_gen" runat="server" Text="Generate" style="margin-left:20px; width:90px" OnClick="Btn_gen_Click"  />
            <asp:Button ID="btn_export" runat="server" Text="Export" style="margin-left:20px; width:90px" OnClick="Btn_export_Click"  />
           <asp:Button ID="btn_filter" runat="server" Text="Filter" style="margin-left:20px; width:90px" OnClick="Btn_filter_Click"  />
        </div> 
        <asp:Panel runat="server" ID="pnl_filter" CssClass="filter_pnl" Visible="false">
            <asp:DropDownList runat="server" ID="drp_filter" >
                
            </asp:DropDownList>
            <asp:Button ID="filter_apply" runat="server" Text="Apply" style="margin-left:20px; width:90px" OnClick="filter_apply_Click" />
        </asp:Panel>
        <div align="center">
        <asp:table style="text-align:center" runat="server" ID="table1" GridLines="Both" Font-Names="Segoe UI" Font-Size="Small" Visible="false">
                <asp:TableRow runat="server" ID="main_row">
                <asp:TableCell runat="server"><b>Account</b></asp:TableCell>
                <asp:TableCell runat="server"><b>Total Amount</b></asp:TableCell>
            </asp:TableRow>
        </asp:table>
      </div>  
    </form>
</body>
</html>
