using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Admin.User
{
    public partial class User_Manage : System.Web.UI.Page
    {
        /// <summary>
        /// 页面初始化，用户数据绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                string id = Request.QueryString["id"].ToString().Trim();
                ConnSql con = new ConnSql();
                string sqlinfo = "select * from Users where id='" + id + "'"; //查询用户信息
                DataTable info = new DataTable();
                info = con.RunSqlReturnTable(sqlinfo); //执行查询
                Id.Text = Request.QueryString["id"].ToString().Trim();

                //数据绑定
                Name.Text = info.Rows[0]["name"].ToString();
                Class1.Text = info.Rows[0]["class"].ToString();
                if (info.Rows[0]["status"].ToString() == "1")
                {
                    Label2.Text = "正常";
                    Label4.Text = "挂失";
                    Label5.Text = "挂失";
                }
                else
                {
                    Label2.Text = "挂失";
                    Label4.Text = "启用";
                    Label5.Text = "启用";
                }
                TextBox1.Text = info.Rows[0]["name"].ToString().Trim();
                TextBox2.Text = info.Rows[0]["class"].ToString().Trim();
                Label1.Text = Request.QueryString["id"].ToString().Trim();
                Label3.Text = Request.QueryString["id"].ToString().Trim();

                //查询该用户借阅记录
                string sql = "SELECT Borrows.book_id,Books.name,Borrows.borrow_date,Borrows.back_date FROM Borrows,Books WHERE  Books.id=Borrows.book_id and Borrows.user_id='" + id + "'";
                DataTable dt = new DataTable();
                dt = con.RunSqlReturnTable(sql);
                Table t = new Table();

                //借阅记录数据绑定
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TableRow r = new TableRow();
                    TableCell bookid = new TableCell();
                    TableCell name = new TableCell();
                    TableCell borrow_date = new TableCell();
                    TableCell back_date = new TableCell();
                    TableCell a = new TableCell();
                    bookid.Text = dt.Rows[i][0].ToString();
                    name.Text = dt.Rows[i][1].ToString();
                    borrow_date.Text = dt.Rows[i][2].ToString();
                    back_date.Text = dt.Rows[i][3].ToString();
                    a.Text = "<a href=\"User_Manage.aspx?Xu=1&id="+ id + "&bookid=" + dt.Rows[i][0].ToString() + "\" class=\"btn btn-info btn - xs prolong \">续借</a>&nbsp<a  href=\"User_Manage.aspx?Xu=2&id=" + id + "&bookid=" + dt.Rows[i][0].ToString() + "\" class=\"btn btn-warning btn - xs return \">还书</a>";
                    r.Cells.Add(bookid);
                    r.Cells.Add(name);
                    r.Cells.Add(borrow_date);
                    r.Cells.Add(back_date);
                    r.Cells.Add(a);
                    t.Rows.Add(r);
                }
                PlaceHolder1.Controls.Add(t);
            }
            if (Request.QueryString["Xu"].ToString().Trim() != null)
            {
                //图书续借
                string Xu = Request.QueryString["Xu"].ToString().Trim();
                string Bookid = Request.QueryString["bookid"].ToString().Trim();
                string id = Request.QueryString["id"].ToString().Trim();
                if (Xu == "1" && Bookid != "0")
                {
                    ConnSql con = new ConnSql();
                    //续借sql语句
                    string sql = "UPDATE Borrows set back_date='" + DateTime.Now.AddMonths(1).ToString().Trim() + "' where book_id=" + Bookid;
                    int x = con.RunSql(sql); //执行sql
                    if (x == 1)
                    {
                        WebMessage.Show("续借成功", "User_Manage.aspx?Xu=0&id="+ id + "&Bookid=0");
                    }
                    else
                    {
                        WebMessage.Show("续借失败", "User_Manage.aspx?Xu=0&id=" + id + "&Bookid=0");
                    }
                }
                if (Xu == "2" && Bookid != "0")
                {
                    //还书
                    ConnSql con = new ConnSql();
                    //删除借阅记录
                    string sql = "delete from Borrows where book_id=" + Bookid;
                    //更新用户借阅数据
                    string sql1 = "update Users set times = times+1 where id='" + id + "'";
                    con.RunSql(sql1);
                    int x = con.RunSql(sql);
                    if (x == 1)
                    {
                        WebMessage.Show("还书成功", "User_Manage.aspx?Xu=0&id=" + id + "&Bookid=0");
                    }
                    else
                    {
                        WebMessage.Show("还书失败", "User_Manage.aspx?Xu=0&id=" + id + "&Bookid=0");
                    }
                }
            }
        }

        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {

            ConnSql con = new ConnSql();
            //编辑用户语句sql
            string sql = "update Users set name='" + TextBox1.Text.Trim() + "',class='" + TextBox2.Text.Trim() + "' where id='" + Request.QueryString["id"].ToString().Trim()+"'";
            int x = con.RunSql(sql); //执行sql
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
        /// 用户挂失
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Label2.Text == "正常")
            {
                ConnSql con = new ConnSql();
                //挂失sql语句
                string sql = "update Users set status='0' where id='" + Request.QueryString["id"].ToString().Trim() + "'";
                int x = con.RunSql(sql); //执行sql
                if (x == 1)
                {
                    WebMessage.Show("挂失成功");
                }
                else
                {
                    WebMessage.Show("挂失失败");
                }
            }
            else {
                //取消用户挂失，启用用户
                ConnSql con = new ConnSql();
                //sql语句
                string sql = "update Users set status='1' where id='" + Request.QueryString["id"].ToString().Trim() + "'";
                int x = con.RunSql(sql);//执行sql
                if (x == 1)
                {
                    WebMessage.Show("启用成功");
                }
                else
                {
                    WebMessage.Show("启用失败");
                }
            }
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void pwdButton_Click(object sender, EventArgs e)
        {
            ConnSql con = new ConnSql();
            //修改密码sql语句
            string sql = "update Users set pwd='" + newPwd.Text.Trim() + "' where id='" + Request.QueryString["id"].ToString().Trim() + "'";
            int x = con.RunSql(sql);//执行sql
            if (x == 1)
            {
                WebMessage.Show("修改成功");
            }
            else
            {
                WebMessage.Show("修改失败");
            }
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            //删除用户
            ConnSql con = new ConnSql();
            //删除用户sql语句
            string sql = "delete from Users where id='" + Request.QueryString["id"].ToString().Trim() + "'";
            //删除该用户借阅记录
            string sql1 = "delete from Borrows where user_id='" + Request.QueryString["id"].ToString().Trim() + "'";
            int x = con.RunSql(sql);//执行sql
            con.RunSql(sql1);
            if (x == 1)
            {
                WebMessage.Show("删除成功","Index.aspx");
            }
            else
            {
                WebMessage.Show("删除失败");
            }
        }
    }
}