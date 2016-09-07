using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using global_function;

namespace GitTest1
{
    public partial class Filter_Build : System.Web.UI.Page
    {
        SqlConnection DB = new SqlConnection();
        SqlCommand cmd;
        string built_query = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            open_connection();
            List<string> txt_keys = Request.Form.AllKeys.Where(key => key.Contains("txtbox_")).ToList();
            List<string> ddl_keys = Request.Form.AllKeys.Where(key => key.Contains("ddl")).ToList();
            int i = 1;
            foreach (string key in txt_keys)
            {
                this.Create_txt("ddl_method_" + i, "txtbox_" + i, "ddl_con_" + i);
                i++;
            }
        }

        protected void gen_txt_Click(object sender, EventArgs e)
        {
            int index_dropdown_method = pnl_textbox.Controls.OfType<DropDownList>().ToList().Count + 1;
            int Text_Box = pnl_textbox.Controls.OfType<TextBox>().ToList().Count + 1;
            
            Create_txt("ddl_method_" + index_dropdown_method, "txtbox_" + Text_Box, "ddl_con_" + Text_Box);
            


        }

        private void Create_txt(string id_ddl_method,string id_Txtbox, string ddl_condition)
        {
            //TextBox txt = new TextBox();
            //txt.ID = id;
            //pnl_textbox.Controls.Add(txt);
            
            DropDownList drp = new DropDownList();
            drp.ID = id_ddl_method;
            cmd = new SqlCommand("select col_values from methods order by col_values asc",DB);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read()) {
                drp.Items.Add(new ListItem(rdr[0].ToString()));
            }
            rdr.Close();
            cmd.Dispose();
            drp.EnableViewState = true;
            drp.AutoPostBack = true;
            pnl_textbox.Controls.Add(drp);

            Literal lit3 = new Literal();
            lit3.Text = "&nbsp;&nbsp;&nbsp;&nbsp;";
            pnl_textbox.Controls.Add(lit3);

            DropDownList drp2 = new DropDownList();
            drp2.ID = ddl_condition;
            drp2.Items.Add(new ListItem("Like"));
            drp2.Items.Add(new ListItem("Equals"));
            drp2.Items.Add(new ListItem("Starts With"));
            drp2.Items.Add(new ListItem("End With"));
            pnl_textbox.Controls.Add(drp2);
            
            Literal lit = new Literal();
            lit.Text = "&nbsp;&nbsp;&nbsp;&nbsp;";
            pnl_textbox.Controls.Add(lit);

            TextBox txt = new TextBox();
            txt.ID = id_Txtbox;
            pnl_textbox.Controls.Add(txt);

            Literal lit2 = new Literal();
            lit2.Text = "<br /><br />";
            pnl_textbox.Controls.Add(lit2);
        }

        protected void open_connection()
        {
            DB.ConnectionString = all_constants.return_con();
            DB.Open();
            //Added comment
        }

        protected void btn_filter_create_Click(object sender, EventArgs e)
        {
            int total_condition = 1;

            if (txt_filter_name.Text != string.Empty)
            {
                foreach (DropDownList drp_loop in pnl_textbox.Controls.OfType<DropDownList>())
                {
                    if (drp_loop.ID.Contains("ddl_method_"))
                    {
                        if (drp_loop.Text == "Account")
                            built_query = built_query + " and account ";

                        else if (drp_loop.Text == "Category")
                            built_query = built_query + " and category ";
                    }

                    if (drp_loop.ID.Contains("ddl_con_"))
                    {
                        if (drp_loop.Text == "Like")
                            built_query = built_query + "like ";
                    }

                    if (total_condition % 2 == 0)
                        built_query = built_query + "''%" + ((TextBox)Page.Form.FindControl("txtbox_" + (total_condition / 2))).Text + "%''";
                    //ViewState["Query"] =  built_query;
                    total_condition++;
               //     btn_filter_create.Text = built_query;

                
                    //Insert the record in DB

                    
                }
                string col_default = "\"account\",\"amount\",\"category\",\"subcategory\",\"payment_method\",\"description\",\"expensed_date\",\"payee\",\"status\"";
                cmd = new SqlCommand("exec insert_filter '" + txt_filter_name.Text + "','" + col_default + "',' from details_expense_data where 1=1 "+  built_query +" '", DB);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

        }

    }
}