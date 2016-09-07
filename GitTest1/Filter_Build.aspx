<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Filter_Build.aspx.cs" Inherits="GitTest1.Filter_Build" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel runat="server" ID="pnl_textbox" >
        

    </asp:Panel>
        <asp:Button runat="server" ID="gen_txt" Text="And Condion" OnClick="gen_txt_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button runat="server" ID="btn_filter_create" Text="Create Filter" OnClick="btn_filter_create_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox runat="server" ID="txt_filter_name"></asp:TextBox>
    </form>
</body>
</html>
