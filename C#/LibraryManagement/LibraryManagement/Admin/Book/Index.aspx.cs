using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Admin
{
    public partial class Admin_Book : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Bind();
        }

        /// <summary>
        /// 所有图书数据绑定
        /// </summary>
        private void Bind()
        {
            var now = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            string keyword = TextBox1.Text.Trim();
            //查询图书的sql语句
            string sql = "SELECT distinct id,name,author, (SELECT count(*) from Borrows where book_id=id and back_date > '" +
                now + "') as status  from Books where 1 = 1";
            if (!string.IsNullOrEmpty(keyword))
            {
                //关键字模糊查询
                sql += " and (name like '%" + keyword + "%' or id like '%" + keyword + "%')";
            }

            DataTable dt = new DataTable();
            ConnSql con = new ConnSql();
            //执行查询
            dt = con.RunSqlReturnTable(sql);
            GridView1.DataSourceID = null;
            GridView1.DataSource = dt;
            //表格绑定
            GridView1.DataBind();
        }

        /// <summary>
        /// 图书搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void research_Click(object sender, EventArgs e)
        {
            Bind();
        }

        /// <summary>
        /// 删除图书
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            ConnSql con = new ConnSql();
            //删除图书语句
            string sql = "delete from Books where id='" + (sender as Button).CommandArgument.ToString() + "'";
            //删除该图书的借阅记录语句
            string sql1 = "delete from Borrows where book_id='" + (sender as Button).CommandArgument.ToString() + "'";
            int x = con.RunSql(sql);
            con.RunSql(sql1);
            if (x == 1)
            {
                WebMessage.Show("删除成功", "Index.aspx");
                Bind();
            }
            else
            {
                WebMessage.Show("删除失败");
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Book_edit.aspx?id="+(sender as Button).CommandArgument.ToString());
        }
    }
}