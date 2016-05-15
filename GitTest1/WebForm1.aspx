<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="GitTest1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My DB Testing</title>
</head>
<body onload="Page_Load">
    <form id="form1" runat="server">
        <asp:table border="1" style="width:50%; text-align:center" runat="server" ID="table1">
                <asp:TableRow runat="server">
                <asp:TableCell runat="server">Name</asp:TableCell>
                <asp:TableCell runat="server">amount</asp:TableCell>
            </asp:TableRow>
            
        </asp:table>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
