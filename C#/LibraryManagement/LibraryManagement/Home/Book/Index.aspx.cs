using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Home.Book
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
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
        /// 所有图书数据绑定
        /// </summary>
        protected void Bind()
        {
            var now = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            //查询图书的sql语句
            string sql = "SELECT distinct id,name,author, (SELECT count(*) from Borrows where book_id=id and back_date > '" +
                    now + "') as status  from Books where 1=1";
            string keyword = TextBox1.Text.Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                //关键字模糊查询
                sql = sql + " and name like '%" + keyword + "%' or id like '%" + keyword + "%'";
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
    }
}