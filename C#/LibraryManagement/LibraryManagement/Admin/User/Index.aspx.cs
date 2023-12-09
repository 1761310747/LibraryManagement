using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;


namespace Library.Admin
{
    public partial class Admin_User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!IsPostBack)
            {
                Bind();
            }
        }

        /// <summary>
        /// 用户搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Research_Click(object sender, EventArgs e)
        {
            Bind();
        }
        
        /// <summary>
        /// 用户数据绑定
        /// </summary>
        private void Bind()
        {
            string keyword = TextBox1.Text.Trim();
            //查询用户语句
            string sql = "SELECT [id],[name],[class],[last_login_time], case Users.status when '1' then '正常' else '挂失' end FROM [Users] where admin!='1' ";

            if (!string.IsNullOrEmpty(keyword))
            {
                //关键字模糊查询
                sql = sql + " and (id like '%" + keyword + "%' or name like '%" + keyword + "%')";
            }

            DataTable dt = new DataTable();
            ConnSql con = new ConnSql();
            dt = con.RunSqlReturnTable(sql);
            Table t = new Table();
            //用户数据绑定
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TableRow r = new TableRow();
                TableCell id = new TableCell();
                TableCell name = new TableCell();
                TableCell class1 = new TableCell();
                TableCell time = new TableCell();
                TableCell c = new TableCell();
                TableCell b = new TableCell();
                id.Text = dt.Rows[i][0].ToString();
                name.Text = dt.Rows[i][1].ToString();
                class1.Text = dt.Rows[i][2].ToString();
                time.Text = dt.Rows[i][3].ToString();
                c.Text = dt.Rows[i][4].ToString();
                b.Text = "<a href=\"User_Manage.aspx?Xu=0&Bookid=0&id=" + dt.Rows[i][0].ToString() + "\" class=\"btn btn-default btn - xs\">详情</a>";
                r.Cells.Add(id);
                r.Cells.Add(name);
                r.Cells.Add(class1);
                r.Cells.Add(time);
                r.Cells.Add(c);
                r.Cells.Add(b);
                t.Rows.Add(r);
            }
            PlaceHolder1.Controls.Add(t);       
        }
    }
}