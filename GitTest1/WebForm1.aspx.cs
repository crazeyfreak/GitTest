using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;

namespace GitTest1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Label1.Text = "Name has been amedned";
            TableRow tnew = new TableRow();
            table1.Rows.Add(tnew);
            for (int i = 0; i < 2; i++)
            {
                TableCell tcell = new TableCell();
                tcell.Text = "Cell " + i;
                tnew.Cells.Add(tcell);
            };
        }
    }
}