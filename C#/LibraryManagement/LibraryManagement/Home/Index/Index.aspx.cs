using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Home.Index
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = Session["Name"].ToString();
            Label5.Text = Session["Time"].ToString();
            //查询超期未还的图书
            string sql = "SELECT count(*) from Borrows where user_id=" + Session["id"].ToString() + " and back_date < '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff")+"'";
            ConnSql conn = new ConnSql();
            string a = conn.RunSqlReturnString(sql);
            ConnSql con = new ConnSql();
            //查询已结的图书总数
            string sql1 = "SELECT COUNT(*) as s from Borrows where user_id=" + Session["id"].ToString();
            string b = con.RunSqlReturnString(sql1);
            Label4.Text = a.ToString().Trim();
            Label3.Text = b.ToString().Trim();
        }
    }
}