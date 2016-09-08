using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using global_function;
using System.Data.SqlClient;
using System.Data;

namespace GitTest1
{
    public partial class Insert_record : System.Web.UI.Page
    {
        SqlConnection DB = new SqlConnection();
        SqlCommand cmd;
        //int s = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            DB.ConnectionString = all_constants.return_con();
            DB.Open();
            if (!IsPostBack)
            {
                populate_acct_combo();
                populate_other_combo();
            }
        }

        private void populate_acct_combo()
        {
            acct_list.Items.Clear();
            cmd = new SqlCommand("select distinct account_name from test_db.dbo.ref_account;", DB);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                acct_list.Items.Add(new ListItem(rdr[0].ToString()));
            }
            rdr.Close();
            cmd.Dispose();
        }

        private void populate_other_combo()
        {
            
            cat_list.Items.Clear();
            subcat_list.Items.Clear();
            payee_list.Items.Clear();
            pay_list.Items.Clear();
            {
                cmd = new SqlCommand("select category_text from ref_category", DB);
                SqlDataReader rdr = cmd.ExecuteReader();
            //    if (!IsPostBack) {
                while (rdr.Read())
                {
                        cat_list.Items.Add(new ListItem(rdr[0].ToString()));
                }
            //}
                rdr.Close();
                cmd.Dispose();
            }

            {
                cmd = new SqlCommand("select description from [test_db].[dbo].[ref_pay_method]", DB);
                SqlDataReader rdr = cmd.ExecuteReader();
              //  if (!IsPostBack)
                //{
                    while (rdr.Read())
                    {
                        pay_list.Items.Add(new ListItem(rdr[0].ToString()));
                    }
                //}
                rdr.Close();
                cmd.Dispose();
            }

            {
                cmd = new SqlCommand("select payee from show_payee", DB);
                SqlDataReader rdr =cmd.ExecuteReader();
                while(rdr.Read()) 
                {
                    payee_list.Items.Add(new ListItem(rdr[0].ToString()));
                }
                rdr.Close();
                cmd.Dispose();
            }
//            {
                
////                string i = "";
//                cmd = new SqlCommand("select * from ref_category", DB);
//                SqlDataReader rdr1 = cmd.ExecuteReader();
                           
//                while (rdr1.Read())
//                    {
                       
//                        subcat_list.Items.Add(new ListItem(rdr1[1].ToString()));
//                       // cmd.CommandText = "select * from ref_subcat where category_id in (" + rdr1[0].ToString() + ")";
//                        SqlCommand cmd1;    
//                        cmd1 = new SqlCommand("select * from ref_subcat where category_id in (" + rdr1[0].ToString() + ")", DB);
//                        //
                        
//                        SqlDataReader rdr = cmd1.ExecuteReader();
//                        while (rdr.Read())
//                        {
//                               subcat_list.Items.Add(new ListItem("-----" + rdr[0].ToString()));
//                        }
//                        rdr.Close();
                        
                        

//                    }
//                    //i = rdr1[0].ToString();
//                rdr1.Close();    
//                cmd.Dispose();
                
//                //int temp_int = Convert.ToInt32(i);
//                //for (int k=1;k<=temp_int;k++){
//                //    subcat_list.Items.Add(new ListItem(k.ToString()));
//                //}

//                //cmd = new SqlCommand("select * from ref_subcat", DB);
//                    //where category_id in (select category_id from ref_category where category_text like '%" + cat_list.Text.ToString() +"')", DB);
//                //SqlDataReader rdr = cmd.ExecuteReader();
//                //while (rdr.Read())
//                //{
//                //    subcat_list.Items.Add(new ListItem(rdr[0].ToString()));
//                //}
//                //rdr.Close();
//                //cmd.Dispose();
//            }
                
        }
     

        protected void btn_show_add_Click(object sender, EventArgs e)
        {
            if (txt_add_acct.Visible)
            {
                txt_add_acct.Visible = false;
                btn_add_acct.Visible = false;
                btn_show_add.Text = "Add New Account >>";
            }
            else
            {
                txt_add_acct.Visible = true;
                btn_add_acct.Visible = true;
                btn_show_add.Text = "Add New Account <<";
            }

            
        }

        protected void btn_add_acct_Click(object sender, EventArgs e)
        {
            txt_add_acct.Visible = false;
            btn_add_acct.Visible = false;
            btn_show_add.Text = "Add New Account >>";
            cmd = new SqlCommand("exec insert_account '" + txt_add_acct.Text + "'", DB);
            cmd.ExecuteNonQuery();
            populate_acct_combo();
            txt_add_acct.Text = null;
            txt_desc.Text = null;
        }


        protected void cat_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            subcat_list.Items.Clear();
            cmd = new SqlCommand("select subcategory from ref_subcat where category_id in (select category_id from ref_category where category_text like '%" + cat_list.Text.ToString() + "%')", DB);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                subcat_list.Items.Add(new ListItem(rdr[0].ToString()));
            }
            rdr.Close();
            cmd.Dispose();
        }

        protected void reload_btn_Click(object sender, EventArgs e)
        {
    
        }

    
        protected void btn_view_add_cat_Click(object sender, EventArgs e)
        {
            if (pnl_cat.Visible)
            {
                pnl_cat.Visible = false;
                btn_view_add_cat.Text = "Add New Category >>";
            }
            else
            {
                pnl_cat.Visible = true;
                btn_view_add_cat.Text = "Add New Category <<";
            }
        }

        protected void btn_add_cat_Click(object sender, EventArgs e)
        {
            pnl_cat.Visible = false;
            btn_show_add.Text = "Add New Category >>";
            cmd = new SqlCommand("exec insert_category '" + txt_add_cat.Text + "'", DB);
            cmd.ExecuteNonQuery();
            populate_acct_combo();
            populate_other_combo();
            pnl_cat.Visible = false;
            btn_view_add_cat.Text = "Add New Category >>";
            txt_add_cat.Text = null;
            txt_desc.Text = null;
        }

        protected void btn_view_add_subcat_Click(object sender, EventArgs e)
        {
            if (pnl_subcat.Visible)
            {
                pnl_subcat.Visible = false;
                btn_view_add_subcat.Text = "Add New Sub-Category >>";
            }
            else
            {
                pnl_subcat.Visible = true;
                btn_view_add_subcat.Text = "Add New Sub-Category <<";
                drop_cat_selection.Items.Clear();
                cmd = new SqlCommand("select category_text from ref_category", DB);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    drop_cat_selection.Items.Add(new ListItem(rdr[0].ToString()));
                }
                
                rdr.Close();
                cmd.Dispose();
            }
        }

        protected void btn_add_subcat_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("exec Insert_sub_cat '" + txt_add_subcat.Text + "','" + drop_cat_selection.Text + "'", DB);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            populate_acct_combo();
            populate_other_combo();
            pnl_subcat.Visible = false;
            btn_view_add_subcat.Text = "Add New Sub-Category >>";
            txt_add_subcat.Text = null;
            txt_desc.Text = null;
        }

        protected void btn_reload_Click(object sender, EventArgs e)
        {
            populate_acct_combo();
            populate_other_combo();

        }

        protected void btn_back_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Main_frm.aspx");
        }

        protected void btn_add_record1_Click(object sender, EventArgs e)
        {
            //    cmd = new SqlCommand("insert into expense_data(account,amount) values ('" + acct_list.Text + "','" + txt_amount.Text +"')", DB);
            //cmd = new SqlCommand("insert into expense_data(acct_id,amount,category_id,subcategory,payment_id,expensed_date,payee,status) values ((select acct_id from ref_account where account_name = '" +    +"')," + txt_amount.Text +
            //    ",(select category_id from ref_category where category_text='" + cat_list.Text + "'),replace('" + subcat_list.Text + "','-',''),(select payment_id from ref_pay_method where description='" + pay_list.Text + "'),GETDATE(),'Not_Implemented','Cleared')", DB);

            cmd = new SqlCommand("exec Insert_Expense_data '" + acct_list.Text + "','" + txt_amount.Text + "','" + cat_list.Text + "','" + subcat_list.Text + "','" + pay_list.Text + "','" + payee_list.Text + "','1','" + txt_desc.Text + "'", DB);
            cmd.ExecuteNonQuery();
            populate_acct_combo();
            populate_other_combo();
            txt_add_acct.Text = null;
            txt_amount.Text = null;
            txt_desc.Text = null;
        }



     

    }
}