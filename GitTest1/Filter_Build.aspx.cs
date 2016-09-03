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
                this.Create_txt("ddl_method_" + i, "txtbox_" + i);
                i++;
            }
        }

        protected void gen_txt_Click(object sender, EventArgs e)
        {
            int index_dropdown_method = pnl_textbox.Controls.OfType<DropDownList>().ToList().Count + 1;
            int Text_Box = pnl_textbox.Controls.OfType<TextBox>().ToList().Count + 1;
            Create_txt("ddl_method_" + index_dropdown_method,"txtbox_" + Text_Box);

        }

        private void Create_txt(string id_ddl_method,string id_Txtbox)
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
            pnl_textbox.Controls.Add(drp);

            Literal lit = new Literal();
            lit.Text = "&nbsp;&nbsp;";
            pnl_textbox.Controls.Add(lit);

            TextBox txt = new TextBox();
            txt.ID = id_Txtbox;
            pnl_textbox.Controls.Add(txt);

            
            lit.Text = "<br /><br />";
            pnl_textbox.Controls.Add(lit);
        }

        protected void open_connection()
        {
            DB.ConnectionString = all_constants.return_con();
            DB.Open();
        }

    }
}