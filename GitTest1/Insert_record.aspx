<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Insert_record.aspx.cs" Inherits="GitTest1.Insert_record" %>
<style>
    .margins{
        margin-left:20px;
    }
    .margins_small {
        margin-left:8px;
    }
    .center_align {
        position:relative
    }
</style>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
    
<body>
    <form id="form1" runat="server" style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif">
    <div style="margin-bottom:10px">
    </div>
        <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="panel1" runat="server"><ContentTemplate>
    <div>
    <asp:Label ID="lbl1" runat="server" Text="Account" CssClass="text-info"></asp:Label> 
        <asp:DropDownList runat="server" id="acct_list" Width="20%" CssClass="margins" onchange="Displaytext(this)">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>

        
        <asp:Button runat="server" ID="btn_show_add" Text="Add New Account >>" CssClass="margins btn btn-sm" OnClick="btn_show_add_Click"/>
        
        <asp:panel runat="server" style="display:inline;" DefaultButton="btn_add_acct" ><asp:TextBox runat="server" ID="txt_add_acct" CssClass="margins" Visible="False" Width="10%"></asp:TextBox><asp:Button runat="server" id="btn_add_acct" CssClass="margins btn btn-sm" Text="Add Account" Visible="False" OnClick="btn_add_acct_Click"/></asp:panel>
        <br /><br />
        
        <asp:Label runat="server" Text="Amounts"></asp:Label>
        <asp:TextBox ID="txt_amount" runat="server" CssClass="margins" Width="20%" TextMode="Number" step="0.01"></asp:TextBox>
        <br /><br />

        <asp:Label runat="server" Text="Category"></asp:Label>
        <asp:DropDownList runat="server" CssClass="margins" ID="cat_list" Width="20%" AutoPostBack="True" OnSelectedIndexChanged="cat_list_SelectedIndexChanged">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
        <asp:Button runat="server" ID="btn_view_add_cat" Text="Add New Category >>" CssClass="margins" OnClick="btn_view_add_cat_Click" Width="183px" />
        <asp:panel runat="server" style="display:inline" DefaultButton="btn_add_cat" ID="pnl_cat" Visible="false"><asp:TextBox runat="server" ID="txt_add_cat" CssClass="margins" Width="10%"></asp:TextBox><asp:Button runat="server" id="btn_add_cat" CssClass="margins" Text="Add Category" OnClick="btn_add_cat_Click"/></asp:panel>

        <br /><br />

        <asp:Label runat="server" Text="Sub-Category"></asp:Label>
        <asp:DropDownList runat="server" CssClass="margins" ID="subcat_list" Width="20%">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>

        <asp:Button runat="server" ID="btn_view_add_subcat" Text="Add New Sub-Category >>" CssClass="margins" OnClick="btn_view_add_subcat_Click" />
        <asp:panel runat="server" style="display:inline" DefaultButton="btn_add_subcat" ID="pnl_subcat" Visible="false">
                <asp:DropDownList runat="server" CssClass="margins" ID="drop_cat_selection" Width="10%">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
            <asp:TextBox runat="server" ID="txt_add_subcat" CssClass="margins" width="10%"></asp:TextBox>
            <asp:Button runat="server" id="btn_add_subcat" CssClass="margins" Text="Add Category" OnClick="btn_add_subcat_Click"/></asp:panel>
        
        <br /><br />

        <asp:Label runat="server" Text="Payment"></asp:Label>
        <asp:DropDownList runat="server" CssClass="margins" ID="pay_list" Width="20%">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />

        <asp:Label runat="server" Text="Payee"></asp:Label>
        <asp:DropDownList runat="server" CssClass="margins" ID="payee_list" Width="20%">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
        <br /><br />

        <asp:Label runat="server" Text="Description"></asp:Label>
        <asp:TextBox runat="server" ID="txt_desc" CssClass="margins" Width="20%"></asp:TextBox>

        <br /><br />
        <asp:LinkButton runat="server" CssClass="btn btn-success btn-sm" id="btn_reload" OnClick="btn_reload_Click" ><i class="glyphicon glyphicon-refresh" ></i>&nbsp;Reload</asp:LinkButton>
     <%--   <asp:Button runat="server" ID="reload_btn" Text="Reload" OnClick="reload_btn_Click" CssClass="margins_small"></asp:Button>         --%>
        <%--<asp:Button runat="server" ID="btn_add_record" Text="Insert" CssClass="btn btn-primary btn-sm glyphicon glyphicon-ok" OnClick="btn_add_record_Click" />--%>
        <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm margins_small" ID="btn_add_record1" OnClick="btn_add_record1_Click"><i class="glyphicon glyphicon-ok" ></i>&nbsp;Insert</asp:LinkButton>
        <asp:LinkButton runat="server" CssClass="btn btn-info btn-sm margins_small" id="btn_back1" OnClick="btn_back_Click1" ><i class="glyphicon glyphicon-circle-arrow-left" ></i>&nbsp;Back</asp:LinkButton>
        <%--<asp:Button runat="server" ID="btn_back" Text="Back" OnClick="btn_back_Click"  />--%>
    </div>
        </ContentTemplate></asp:UpdatePanel>
        
    </form>
</body>
</html>
