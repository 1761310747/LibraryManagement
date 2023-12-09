using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

namespace Library.Home.List
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //查询用户借阅统计
            string sql = "SELECT top 10 name, times1 from Users WHERE admin!=1 ORDER BY times1 DESC ";
            DataTable dt = new DataTable();
            ConnSql con = new ConnSql();
            dt = con.RunSqlReturnTable(sql);
            Table t = new Table();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TableRow r = new TableRow();
                TableCell name = new TableCell();
                TableCell times = new TableCell();
                name.Text = dt.Rows[i][0].ToString();
                times.Text = dt.Rows[i][1].ToString();
                r.Cells.Add(name);
                r.Cells.Add(times);
                t.Rows.Add(r);
            }
            PlaceHolder1.Controls.Add(t);
            //查询用户借阅排行
            string sql1 = "select  top 10 name,times1 from Books ORDER BY times1 desc";
            DataTable dt1 = new DataTable();
            dt1 = con.RunSqlReturnTable(sql1);
            Table a = new Table();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                TableRow q = new TableRow();
                TableCell name = new TableCell();
                TableCell times = new TableCell();
                name.Text = dt1.Rows[i][0].ToString();
                times.Text = dt1.Rows[i][1].ToString();
                q.Cells.Add(name);
                q.Cells.Add(times);
                a.Rows.Add(q);
            }
            PlaceHolder2.Controls.Add(a);
        }
    }
}