using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Admin
{
    public partial class Admin_Borrow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 借阅与还书事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userId.Text.Trim()))
            {
                WebMessage.Show("请输入用户Id");
                return;
            }
            if (string.IsNullOrEmpty(bookId.Text.Trim()))
            {
                WebMessage.Show("请输入图书Id");
                return;
            }

            //借阅
            if (borrow.Checked)
            {
                //查询用户是否还可以借书
                ConnSql con = new ConnSql();
                string a = "select times from Users where id = '" + userId.Text.Trim() + "'";
                string b = con.RunSqlReturnString(a);
                string c = "select admin from Users where id = '"+ userId.Text.Trim() + "'";
                string d = con.RunSqlReturnString(c);
                if (b == "0" && d == "0")
                {
                    WebMessage.Show("最多借阅10本书");
                }
                else if (b == "0" && d == "2")
                {
                    WebMessage.Show("最多借阅20本书");
                }
                else {
                    //插入借阅记录
                    string sql = "INSERT INTO Borrows ([book_id], [user_id], [borrow_date], [back_date]) VALUES ('" + bookId.Text.Trim() + "', '" + userId.Text.Trim() + "', '" + DateTime.Now.ToString() + "', '" + DateTime.Now.AddMonths(2).ToString() + "');";
                    //更新图书与用户借阅状态
                    string sql1 = "UPDATE Books SET times1 = times1+1 where id='" + bookId.Text.Trim() + "'";
                    string sql2 = "UPDATE Users SET times1 = times1+1,times = times-1 where id='" + userId.Text.Trim() + "'";
                    int x = con.RunSql(sql);
                    con.RunSql(sql1);
                    con.RunSql(sql2);
                    if (x == 1)
                    {
                        WebMessage.Show("借阅成功", "Index.aspx");
                    }
                    else
                    {
                        WebMessage.Show("借阅失败");
                    }
                }
                
            }
            //还书
            else
            {
                ConnSql con = new ConnSql();
                //删除借阅记录
                string sql = "delete from Borrows where book_id="+bookId.Text.Trim();
                int x = con.RunSql(sql);
                if (x == 1)
                {
                    WebMessage.Show("还书成功", "Index.aspx");
                }
                else
                {
                    WebMessage.Show("还书失败");
                }
            }
           
        }
    }
}