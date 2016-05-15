var connection = new ActiveXObject("adodb.connection") ;

var connectionstring="Provider=SQLOLEDB;Data Source=naresh\\naresh_server;Trusted_Connection=Yes;Database=test_db;"
connection.Open(connectionstring);
var rs = new ActiveXObject("ADODB.Recordset");

rs.Open("SELECT * FROM expense_data where category='Income'", connection);
rs.MoveFirst
while(!rs.eof)
{
	document.write("<tr>");
   document.write("<td>" + rs.fields(2) + "</td>");
   document.write("</tr>");
   rs.movenext;
}

rs.close;
connection.close;