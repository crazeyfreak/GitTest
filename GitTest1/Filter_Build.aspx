<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Filter_Build.aspx.cs" Inherits="GitTest1.Filter_Build" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" >
    <asp:Panel runat="server" ID="pnl_textbox" >
<%--        <asp:DropDownList runat="server" id="ddl_method_1"></asp:DropDownList>
        <asp:DropDownList runat="server" id="ddl_con_1">
            <asp:ListItem>Like</asp:ListItem>
            <asp:ListItem>Equals</asp:ListItem>
            <asp:ListItem>Starts With</asp:ListItem>
            <asp:ListItem>End With</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox runat="server" id="txtbox_1"></asp:TextBox>--%>
    </asp:Panel>
        
    <asp:Label runat="server" Text="Filter Name : " style="font-family:'Segoe UI'; font-size:14px"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox runat="server" ID="txt_filter_name" Width="10%"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lbl_empty" ForeColor="Red" Visible="false">Please Enter filter name</asp:Label>
    <br />
    <br />
    <asp:Button runat="server" ID="gen_txt" Text="And Condion" OnClick="gen_txt_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button runat="server" ID="btn_filter_create" Text="Create Filter" OnClick="btn_filter_create_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
        
    </form>
</body>
</html>
