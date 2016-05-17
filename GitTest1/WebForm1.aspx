<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="GitTest1.WebForm1" %>

<!DOCTYPE html>
<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>My Testing</title>
</head>
<body onload="Page_Load">
    <form id="form1" runat="server">
       <div style="">
           <asp:DropDownList ID="Select_Drop" runat="server" Width="20%" CssClass="dropdown">
            <asp:ListItem>Summery</asp:ListItem>
            <asp:ListItem>Detail</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="Btn_gen" runat="server" Text="Generate" style="margin-left:20px; width:90px" OnClick="Btn_gen_Click"  />
            <asp:Button ID="btn_export" runat="server" Text="Export" style="margin-left:20px; width:90px" OnClick="Btn_export_Click"  />
        </div> 

        <div style="margin-bottom:20px" id="Div_1" ></div>
        <asp:table style="text-align:center" runat="server" ID="table1" GridLines="Both" Font-Names="Segoe UI" Font-Size="Small" Width="50%">
                <asp:TableRow runat="server" ID="main_row">
                <asp:TableCell runat="server"><b>Account</b></asp:TableCell>
                <asp:TableCell runat="server"><b>Total Amount</b></asp:TableCell>
            </asp:TableRow>
        </asp:table>
    </form>
</body>
</html>
