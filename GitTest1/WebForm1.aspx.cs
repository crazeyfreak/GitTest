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
        //string db_con = "Provider=SQLOLEDB;Data Source=naresh\\naresh_server;Trusted_Connection=Yes;Database=test_db;";
        SqlConnection DB = new SqlConnection();
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            DB.ConnectionString = db_con;
            DB.Open();
            Label1.Text = "Name has been amedned";
        //    TableRow tnew = new TableRow();
         //   table1.Rows.Add(tnew);
            cmd = new SqlCommand("select top 3 [amount],[account] from [expense_data]",DB);
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
    }
}