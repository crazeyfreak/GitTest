var connection = new ActiveXObject("adodb.connection") ;

var connectionstring="Provider=SQLOLEDB;Data Source=naresh\\naresh_server;Trusted_Connection=Yes;Database=test_db;"
connection.Open(connectionstring);
var rs = new ActiveXObject("ADODB.Recordset");
var total =0
rs.Open("SELECT * FROM expense_data where category='Income'", connection);
rs.MoveFirst
while(!rs.eof)
{
	document.write("<tr>");
   document.write("<td>" + rs.fields(1) + "</td>" + "<td>" + rs.fields(2) + "</td>");
   document.write("</tr>");
   total=total+ rs.fields(2);
   rs.movenext;
}
document.write("<tr><td><b>Total Amount</b></td><td><b>" + total + "</b></td></tr>");
rs.close;
connection.close;