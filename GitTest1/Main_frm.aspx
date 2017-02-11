<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main_frm.aspx.cs" Inherits="GitTest1.WebForm1" %>
<style>
    .button {
        border-radius:4px;
        background-color:#f4511e;
        border:none;
        color:#ffffff;
        text-align:center;
        font-size:10px;
        padding:8px;
        transition : all 0.5s;
        cursor : pointer;
        margin:3px;
        width:100px; 
        box-shadow: 2px 2px 1px black;
    }

    @keyframes test1 {
        from {background-color:red}
        to {background-color:yellow}
    }

    .button:hover {
        background-color:black;
        font:bold;
    }

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
    .table_align{
        margin-left:auto;
        margin-right:auto;
        margin-top:10px;
    }

    .btn_filter_margin {
        margin-left:20px;
    }
</style>

<!DOCTYPE html>
<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
<html xmlns="http://www.w3.org/1999/xhtml">


<head runat="server">
    <title>Expense Tracker</title>
    <script src="jquery.min.js"></script>

    <script>
        $(document).ready(function () {
            $("#Btn_gen").hover(function () {
                $(this).append('>>');
            });

            $("#Btn_gen").mouseleave(function () {
                $(this).text($(this).text().replace(">>", ""));
            });
        });
    </script>
</head>
<body onload="Page_Load" style="background-color:lightgrey">
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
            <asp:Button ID="Btn_gen" runat="server"  Text="Generate" OnClick="Btn_gen_Click" CssClass="button" />
            <asp:Button ID="btn_export" runat="server" Text="Export" OnClick="Btn_export_Click"  CssClass="button" />
           <asp:Button ID="btn_filter" runat="server" Text="Filter" OnClick="Btn_filter_Click"  CssClass="button"/>
        </div> 
        <asp:Panel runat="server" ID="pnl_filter" CssClass="filter_pnl" Visible="false">
            <asp:DropDownList runat="server" ID="drp_filter" >
                
            </asp:DropDownList>
			
            <asp:Button ID="filter_apply" runat="server" Text="Apply" style="margin-left:20px; width:90px" OnClick="filter_apply_Click" CssClass="btn btn-sm"/>
            <asp:Button ID="btn_export_filter" runat="server" Text="Export Copy" style="margin-left:20px; width:90px" OnClick="btn_export_filter_Click" CssClass="btn btn-sm"/>
            <asp:Button ID="btn_filter_create" runat="server" Text="Create Filter" style="margin-left:20px; width:90px" OnClick="btn_filter_create_Click" CssClass="btn btn-sm"/>
            <asp:Button ID="btn_filter_view" runat="server" Text="View Filter" style="margin-left:20px; width:90px" OnClick="btn_filter_view_Click" CssClass="btn btn-sm"/>
        </asp:Panel>
		
        <div align="center" class="table_align">
		
        <asp:table style="text-align:center" runat="server" ID="table1" GridLines="Both" Font-Names="Segoe UI" Font-Size="Small" Visible="false" CssClass="table-striped">
                <asp:TableRow runat="server" ID="main_row">
            </asp:TableRow>
        </asp:table>
		
      </div>
        <asp:Panel runat="server" ID="pnl_filter_view" Visible="false" BorderColor="Black" BorderWidth="2" HorizontalAlign="Center">
            <asp:Label runat="server" ID="lbl_filter_name" Text="Fil_Name"></asp:Label>
            <br />
            <asp:TextBox runat="server" ID="txt_filter_view" Height="100px" Width="300px" TextMode="MultiLine"></asp:TextBox>
            <br />
            <asp:TextBox ID="txt_filter_col" runat="server" Width="300px"></asp:TextBox> <asp:label runat="server" Text="?" ToolTip="Limited Columns only else it'll throw error" ></asp:label>
            <br />
            <asp:Button runat="server" ID="btn_filter_save" Text="Save" CssClass="btn_filter_margin btn btn-sm" OnClick="btn_filter_save_Click" />
            <asp:Button runat="server" ID="btn_filter_delete" Text="Delete" CssClass="btn_filter_margin btn btn-sm" OnClick="btn_filter_delete_Click"/>
            <asp:Button runat="server" ID="btl_filter_cancel" Text="Cancel" CssClass="btn_filter_margin btn btn-sm" OnClick="btl_filter_cancel_Click"/>

        </asp:Panel>
    </form>
</body>
</html>
