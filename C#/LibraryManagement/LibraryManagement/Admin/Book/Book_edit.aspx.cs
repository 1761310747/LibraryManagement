using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Admin.Book
{
    public partial class Book_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //图书详细数据查询与绑定
                string id = Request.QueryString["id"].ToString().Trim();
                string sql = "SELECT *  from Books where id='" + id + "'";
                DataTable dt = new DataTable();
                ConnSql con = new ConnSql();
                dt = con.RunSqlReturnTable(sql);
                name.Text = dt.Rows[0]["name"].ToString().Trim();
                author.Text = dt.Rows[0]["author"].ToString().Trim();
                press.Text = dt.Rows[0]["press"].ToString().Trim();
                pressTime.Text = dt.Rows[0]["press_time"].ToString().Trim();
                price.Text = dt.Rows[0]["price"].ToString().Trim();
                ISBN.Text = dt.Rows[0]["ISBN"].ToString().Trim();
                desc.Text = dt.Rows[0]["descs"].ToString().Trim();
            }
        }

        /// <summary>
        /// 编辑图书
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void submit_Click(object sender, EventArgs e)
        {
            ConnSql con = new ConnSql();
            //编辑图书语句
            string sql = "update Books set name='" + name.Text + "',author='" + author.Text + "',press='" + press.Text + "',press_time='" + pressTime.Text + "',price='" + price.Text + "',ISBN='" + ISBN.Text + "',descs='" + desc.Text + "' where id='" + Request.QueryString["id"].ToString().Trim() + "'";
            int x = con.RunSql(sql);
            if (x == 1)
            {
                WebMessage.Show("修改成功");
            }
            else
            {
                WebMessage.Show("修改失败");
            }
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void reset_Click(object sender, EventArgs e)
        {
            sss();
        }

        public void sss()
        {
                string id = Request.QueryString["id"].ToString().Trim();
                string sql = "SELECT *  from Books where id='" + id + "'";
                DataTable dt = new DataTable();
                ConnSql con = new ConnSql();
                dt = con.RunSqlReturnTable(sql);
                name.Text = dt.Rows[0]["name"].ToString().Trim();
                author.Text = dt.Rows[0]["author"].ToString().Trim();
                press.Text = dt.Rows[0]["press"].ToString().Trim();
                pressTime.Text = dt.Rows[0]["press_time"].ToString().Trim();
                price.Text = dt.Rows[0]["price"].ToString().Trim();
                ISBN.Text = dt.Rows[0]["ISBN"].ToString().Trim();
                desc.Text = dt.Rows[0]["descs"].ToString().Trim();
        }
    }
}