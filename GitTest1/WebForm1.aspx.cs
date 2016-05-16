using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace GitTest1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string  db_con = "Server=NARESH\\NARESH_SERVER;Database=test_db;Trusted_Connection=True;Integrated Security=SSPI;";
       
        SqlConnection DB = new SqlConnection();
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            DB.ConnectionString = db_con;
            DB.Open();
        }

        protected void Btn_gen_Click(object sender, EventArgs e)
        {
            if (Select_Drop.Text == "Summery")
            {
                table1.Width = Unit.Percentage(50);
                cmd = new SqlCommand("select case when sum(amount) < 0 then SUM(amount)*(-1) when sum(amount) >= 0 then SUM(amount) end , category from [expense_data] group by category order by 1 desc ", DB);
                SqlDataReader rdr = cmd.ExecuteReader();
                
                while (rdr.Read())
                {
                    TableRow tnew = new TableRow();
                    table1.Rows.Add(tnew);
                    TableCell tcell = new TableCell();
                    tcell.Text = rdr[1].ToString();
                    tnew.Cells.Add(tcell);
                    TableCell tcell2 = new TableCell();
                    tcell2.Text = rdr[0].ToString();
                    tnew.Cells.Add(tcell2);
                    
                    
                };
            }
            else if (Select_Drop.Text == "Detail")
            {
                table1.Width = Unit.Percentage(90);
                
                    {
                        TableCell tnew_cell = new TableCell();
                        tnew_cell.Text = "Category";
                        tnew_cell.Font.Bold = true;
                        main_row.Cells.Add(tnew_cell);
                    }
                    {
                        TableCell tnew_cell = new TableCell();
                        tnew_cell.Text = "Sub-Category";
                        tnew_cell.Font.Bold = true;
                        main_row.Cells.Add(tnew_cell);
                    }

                    {
                        TableCell tnew_cell = new TableCell();
                        tnew_cell.Text = "Payment Method";
                        tnew_cell.Font.Bold = true;
                        main_row.Cells.Add(tnew_cell);
                    }
                    {
                        TableCell tnew_cell = new TableCell();
                        tnew_cell.Text = "Description";
                        tnew_cell.Font.Bold = true;
                        main_row.Cells.Add(tnew_cell);
                    }
                    {
                        TableCell tnew_cell = new TableCell();
                        tnew_cell.Text = "Date";
                        tnew_cell.Font.Bold = true;
                        main_row.Cells.Add(tnew_cell);
                    }
                    {
                        TableCell tnew_cell = new TableCell();
                        tnew_cell.Text = "Payee";
                        tnew_cell.Font.Bold = true;
                        main_row.Cells.Add(tnew_cell);
                    }
                    cmd = new SqlCommand("select * from details_expense_data", DB);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TableRow tnew = new TableRow();
                        table1.Rows.Add(tnew);
                        for (int i = 0; i <= 7; i++) { 
                        TableCell tcell = new TableCell();
                        tcell.Text = rdr[i].ToString();
                        tnew.Cells.Add(tcell);
                        }
                        //TableCell tcell2 = new TableCell();
                       // tcell2.Text = rdr[0].ToString();
                       // tnew.Cells.Add(tcell2);


                    };

            }
        }
    }
       
}