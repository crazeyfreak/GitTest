<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="GitTest1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My DB Testing</title>
</head>
<body onload="Page_Load">
    <form id="form1" runat="server">
        <asp:DropDownList ID="Select_Drop" runat="server" Width=20% OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem>Summery</asp:ListItem>
            <asp:ListItem>Detail</asp:ListItem>
        </asp:DropDownList>
        
        <asp:Button ID="Btn_gen" runat="server" Text="Generate" style="margin-left:20px" Width="90px" OnClick="Btn_gen_Click"/>
        <div style="margin-bottom:20px"></div>
        
        <asp:table style="width:50%; text-align:center" runat="server" ID="table1" GridLines="Both" Font-Names="Segoe UI" Font-Size="Small">
                <asp:TableRow runat="server">
                <asp:TableCell runat="server"><b>Category</b></asp:TableCell>
                <asp:TableCell runat="server"><b>Total Amount</b></asp:TableCell>
            </asp:TableRow>
            
        </asp:table>
        
        
    </form>
</body>
</html>
