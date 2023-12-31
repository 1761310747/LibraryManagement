﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Admin.User
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void submit_Click(object sender, EventArgs e)
        {
            if (userId.Text == "")
                WebMessage.Show("请输入ID");
            else if (password.Text == "")
                WebMessage.Show("请输入密码");
            else if (name.Text == "")
                WebMessage.Show("请输入姓名");
            else if (class1.Text == "")
                WebMessage.Show("请输入班级");
            else
            {
                if (DropDownList1.SelectedValue=="0")
                {
                    //添加读者用户信息
                    //sql语句
                    string sql = "INSERT INTO Users (id,pwd,name,class,status,admin,last_login_time,times,times1) VALUES ('" + userId.Text.Trim() + "','" + password.Text.Trim() + "','" + name.Text.Trim() + "','" + class1.Text.Trim() + "','" + status.SelectedValue + "','0','"+DateTime.Now.ToString()+"','10','0')";
                    ConnSql conn = new ConnSql();
                    int s = conn.RunSql(sql); //执行sql
                    if (s > 0)
                    {
                        WebMessage.Show("添加学生成功");
                    }
                    else
                    {
                        WebMessage.Show("添加学生失败");
                    }
                }
                else if (DropDownList1.SelectedValue == "1")
                {
                    //添加管理员
                    //sql语句
                    string sql = "INSERT INTO Users (id,pwd,name,class,status,admin,last_login_time,times,times1) VALUES ('" + userId.Text.Trim() + "','" + password.Text.Trim() + "','" + name.Text.Trim() + "','" + class1.Text.Trim() + "','" + status.SelectedValue + "','2','" + DateTime.Now.ToString() + "','20','0')";
                    ConnSql conn = new ConnSql();
                    int s = conn.RunSql(sql); //执行sql
                    if (s > 0)
                    {
                        WebMessage.Show("添加管理员成功");
                    }
                    else
                    {
                        WebMessage.Show("添加管理员失败");
                    }
                }
            }
        }

        protected void reset_Click(object sender, EventArgs e)
        {

        }
    }
}