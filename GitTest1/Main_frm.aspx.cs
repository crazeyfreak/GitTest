using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls; //For Datagrid
using System.Data.SqlClient; //For SQL Connection
using System.Data; //For DB
//using Microsoft.Office.Interop.Excel;
using global_function;
namespace GitTest1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
      //  string  db_con = "Server=NARESH\\NARESH_SERVER;Database=test_db;Trusted_Connection=True;Integrated Security=SSPI;";
       
        SqlConnection DB = new SqlConnection();
        SqlCommand cmd;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            DB.ConnectionString = all_constants.return_con();
            DB.Open();
            table1.Visible = false;
            
        }

        protected void Btn_gen_Click(object sender, EventArgs e)
        {
            table1.Visible = true;
            if (Select_Drop.Text == "Summery")
            {
                string columns = "\"account\",\"Total amount\"";
                //string query = "select format(total_amount,'##,##0.00'),account_name from account_info";
                string query = "select account,Total_amount from account_info;";
                show_table(columns, query);
                table1.Width = Unit.Percentage(50);
                //cmd = new SqlCommand("select format(total_amount,'##,##0.00'),account_name from account_info", DB);
                //SqlDataReader rdr = cmd.ExecuteReader();
                
                //while (rdr.Read())
                //{
                //    TableRow tnew = new TableRow();
                //    table1.Rows.Add(tnew);
                //    TableCell tcell = new TableCell();
                //    tcell.Text = rdr[1].ToString();
                //    tnew.Cells.Add(tcell);
                //    TableCell tcell2 = new TableCell();
                //    tcell2.Text = rdr[0].ToString();
                //    tnew.Cells.Add(tcell2);
                    
                    
                //};
            }
            else if (Select_Drop.Text == "Detail")
            {
                string columns = "\"account\",\"amount\",\"category\",\"sub-category\",\"payment_method\",\"description\",\"Date\",\"payee\",\"status\"";
                string query = "select * from details_expense_data";
                show_table(columns,query);
                //table1.Width = Unit.Percentage(90);
            
                //    {
                //        TableCell tnew_cell = new TableCell();
                //        tnew_cell.Text = "Category";
                //        tnew_cell.Font.Bold = true;
                //        main_row.Cells.Add(tnew_cell);
                //    }
                //    {
                //        TableCell tnew_cell = new TableCell();
                //        tnew_cell.Text = "Sub-Category";
                //        tnew_cell.Font.Bold = true;
                //        main_row.Cells.Add(tnew_cell);
                //    }

                //    {
                //        TableCell tnew_cell = new TableCell();
                //        tnew_cell.Text = "Payment Method";
                //        tnew_cell.Font.Bold = true;
                //        main_row.Cells.Add(tnew_cell);
                //    }
                //    {
                //        TableCell tnew_cell = new TableCell();
                //        tnew_cell.Text = "Description";
                //        tnew_cell.Font.Bold = true;
                //        main_row.Cells.Add(tnew_cell);
                //    }
                //    {
                //        TableCell tnew_cell = new TableCell();
                //        tnew_cell.Text = "Date";
                //        tnew_cell.Font.Bold = true;
                //        main_row.Cells.Add(tnew_cell);
                //    }
                //    {
                //        TableCell tnew_cell = new TableCell();
                //        tnew_cell.Text = "Payee";
                //        tnew_cell.Font.Bold = true;
                //        main_row.Cells.Add(tnew_cell);
                //    }
                //    {
                //        TableCell tnew_cell = new TableCell();
                //        tnew_cell.Text = "Status";
                //        tnew_cell.Font.Bold = true;
                //        main_row.Cells.Add(tnew_cell);
                //    }
                //    cmd = new SqlCommand("select * from details_expense_data", DB);
                //    SqlDataReader rdr = cmd.ExecuteReader();

                //    while (rdr.Read())
                //    {
                //        TableRow tnew = new TableRow();
                //        table1.Rows.Add(tnew);
                //        for (int i = 0; i <= 8; i++) { 
                //        TableCell tcell = new TableCell();
                //        tcell.Text = rdr[i].ToString();
                //        tnew.Cells.Add(tcell);
                //        }
                //        //TableCell tcell2 = new TableCell();
                //       // tcell2.Text = rdr[0].ToString();
                //       // tnew.Cells.Add(tcell2);


                //    };
                //    rdr.Close();
            }
        }


        private void show_table(string col_default,string sql_query)
        {
            table1.Visible = true;
            table1.Width = Unit.Percentage(90);
            int total_col = 0;

            total_col = (Create_table(col_default)/2);

            cmd = new SqlCommand(sql_query, DB);
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                TableRow tnew = new TableRow();
                table1.Rows.Add(tnew);
                for (int i = 0; i < total_col; i++) { 
                TableCell tcell = new TableCell();
                tcell.Text = rdr[i].ToString();
                tnew.Cells.Add(tcell);
                }
                //TableCell tcell2 = new TableCell();
                // tcell2.Text = rdr[0].ToString();
                // tnew.Cells.Add(tcell2);


            };
            rdr.Close();
        }
        

        protected void Btn_export_Click(object sender, EventArgs e)
        {
            string export_sql_command = string.Empty;
 
              if (Select_Drop.Text == "Summery") {
                  export_sql_command = "select total_amount as Amount,account from account_info";
              }
              else if (Select_Drop.Text == "Detail")
              {
                  export_sql_command = "select * from details_expense_data";
              }
              export_to_excel(export_sql_command);
        }

        public void export_to_excel(string sql_cmd)
        {   
            cmd = new SqlCommand(sql_cmd, DB);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;

            DataTable dt = new DataTable();
            sda.Fill(dt);

            //Assign data to datagrid
            DataGrid dg = new DataGrid();
            dg.DataSource = dt;
            dg.DataBind();

            //Excel File
            string sfilename = "Export_data.xls";

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=" + sfilename);
            Response.ContentType = "application/vnd.ms-excel";
            EnableViewState = false;

            System.IO.StringWriter objSW = new System.IO.StringWriter();

            HtmlTextWriter objHTW = new HtmlTextWriter(objSW);

            dg.HeaderStyle.Font.Bold = true;
            dg.RenderControl(objHTW);

            Response.Write(objSW.ToString());

            Response.End();
            dg = null;
        }

        protected void Btn_filter_Click(object sender, EventArgs e)
        {
            if (pnl_filter.Visible)
            {
                pnl_filter.Visible = false;
            }
            else
            {
                refresh_filter_combo();
            }
        }

        private void refresh_filter_combo()
        {
            drp_filter.Items.Clear();
            pnl_filter.Visible = true;
            cmd = new SqlCommand("select filter_name from filter_queries (nolock) order by filter_id asc", DB);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                drp_filter.Items.Add(new ListItem(rdr[0].ToString()));
            }
            cmd.Dispose();
            rdr.Close();
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Insert_record.aspx");
        }

        protected void filter_apply_Click(object sender, EventArgs e)
        {
            // show_table("subcategory");
            string columns = string.Empty;
            string where_clause = string.Empty;
            string where_for_sum = string.Empty;
            cmd = new SqlCommand("build_filter_query '" + drp_filter.Text + "'", DB);
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            {
                columns = rdr[0].ToString();
                where_clause = rdr[1].ToString();
                where_for_sum = "select Format(sum(-1*without_fmt),'##,###.00')  " + rdr[2].ToString();
            }

            // create_table is used to create the table main title columns
            int count = (Create_table(columns) / 2);
            rdr.Close();


            // to insert the record in the table.
            cmd = new SqlCommand(where_clause, DB);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                TableRow tnew = new TableRow();
                table1.Rows.Add(tnew);
                for (int i = 0; i < count; i++)
                {
                    TableCell tnew_cell = new TableCell();
                    tnew_cell.Text = rdr[i].ToString();
                    tnew.Cells.Add(tnew_cell);
                }
            }
            rdr.Close();

            //For adding the total Cell at the End of report.
            TableRow t_total = new TableRow();
            table1.Rows.Add(t_total);
            {
                TableCell t_cell = new TableCell();
                t_cell.Text = "Total";
                t_cell.Font.Size = 10;
                t_cell.Font.Bold = true;        
                t_total.Cells.Add(t_cell);
            }
            
            {
                try
                {
                    cmd = new SqlCommand(where_for_sum, DB);
                    rdr = cmd.ExecuteReader();
                    rdr.Read();
                    TableCell t_cell = new TableCell();
                    t_cell.Text = rdr[0].ToString();
                    t_cell.Font.Size = 10;
                    t_cell.Font.Bold = true;
                    t_total.Cells.Add(t_cell);
                    rdr.Close();
                }
                catch (Exception)
                {

                }
                
            }

        }


        protected int Create_table(string cmd)
        {
            int num = 0;
            string built_col = string.Empty;
          //  main_row.Cells.RemoveAt(0);
         //   main_row.Cells.RemoveAt(0);
            for (int i = 0; i < cmd.Length; i++)
            {
                if (cmd[i] == '\"')
                {
                    num++;
                    if (num % 2 == 0)
                    {
                        // To insert the new cell in table
                        //main_row.Cells.RemoveAt(1);
                        table1.Visible = true;
                        table1.Width = Unit.Percentage(90);

                        {
                            TableCell tnew_cell = new TableCell();
                            tnew_cell.Text = built_col.ToString().ToUpper().Replace('_',' ');
                            tnew_cell.Font.Size = 9;
                            tnew_cell.Font.Bold = true;
                            main_row.Cells.Add(tnew_cell);
                        }
                        built_col = string.Empty;
                    }
                }
                else
                {
                    // to olny include title after double quotes
                    if (cmd[i] != ',' && num%2 !=0) {
                    built_col = built_col + cmd[i].ToString(); }
                }
            }
                
            
            return num;
        }

        protected void btn_filter_create_Click(object sender, EventArgs e)
        {
            Response.Redirect("Filter_build.aspx");
        }

        protected void btn_export_filter_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("build_filter_query '" + drp_filter.Text + "'", DB);
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            export_to_excel(rdr[1].ToString());
            rdr.Close();
            cmd.Dispose();
        }

        protected void btn_filter_view_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select filter_name,where_clause,column_selected from filter_queries where filter_name='" + drp_filter.Text + "'",DB);
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            lbl_filter_name.Text = rdr[0].ToString();
            txt_filter_view.Text = rdr[1].ToString();
            txt_filter_col.Text = rdr[2].ToString();
            pnl_filter_view.Visible = true;
            rdr.Close();
            
        }
        
        protected void btn_filter_save_Click(object sender, EventArgs e)
        {
            string sql_cmd_where = txt_filter_view.Text;
            sql_cmd_where = sql_cmd_where.Replace("'", "''");

            string sql_cmd_col = txt_filter_col.Text;
            sql_cmd_col = sql_cmd_col.Replace('"', '\"');

            sql_cmd_where = "UPDATE filter_queries set where_clause='" + sql_cmd_where + "', column_selected ='"+ sql_cmd_col +"' where filter_name='" + lbl_filter_name.Text + "'";
            
            cmd = new SqlCommand(sql_cmd_where, DB);
            cmd.ExecuteNonQuery();
            txt_filter_view.Text = string.Empty;
            txt_filter_col.Text = string.Empty;
            pnl_filter_view.Visible = false;
        }

        protected void btl_filter_cancel_Click(object sender, EventArgs e)
        {
            txt_filter_view.Text = string.Empty;
            txt_filter_col.Text = string.Empty;
            pnl_filter_view.Visible = false;
        }

        protected void btn_filter_delete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("DELETE from Filter_queries where filter_name = '"+ lbl_filter_name.Text +"'",DB);
            cmd.ExecuteNonQuery();
            refresh_filter_combo();
            txt_filter_view.Text = string.Empty;
            txt_filter_col.Text = string.Empty;
            pnl_filter_view.Visible = false;
        }
    }
       
}


namespace global_function
{
    public class all_constants
    {
        private all_constants() { }
        static string db_con = "Server=NARESH\\NARESH_SERVER;Database=test_db;Trusted_Connection=True;Integrated Security=SSPI;MultipleActiveResultSets=True";

        public static  string return_con()
        {
            return db_con;
        }
    }
}