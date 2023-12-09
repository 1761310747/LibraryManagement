<%@ Page Title="用户管理" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Library.Admin.Admin_User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="fluid">
             <div class="row">
                <div class="col-lg-6"><b>用户管理</b></div>
                <hr />
            </div>
            <div class="row" style="margin-bottom: 30px;">
                <div class="col-lg-6">
                    <div class="input-group">
                        <asp:TextBox ID="TextBox1" CssClass="form-control col-sm-6" runat="server"
                            placeholder="请输入用户ID或姓名"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button runat="server" ID="research" CssClass="btn btn-default" Text="搜索" OnClick="Research_Click"></asp:Button>
                        </span>
                    </div>
                </div>
                <div class="col-lg-6">
                    <a class="btn btn-warning pull-right" href="User_Add.aspx" style="margin-left: 20px">添加用户</a>
                </div>
            </div>


            <div id="table-box" hidden>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </div>

        </div>
    </div>

    <script type="text/javascript">

        $(".navbar-nav li").eq(2).addClass("active");
        window.onload = function () {

            $("#table-box table").eq(0).addClass("grid table text-center")
            var ftr = "<thead><tr class=\"active\"><th class=\"text-center\">用户ID</th><th class=\"text-center\">姓名</th><th class=\"text-center\">班级</th><th class=\"text-center\">最后登陆时间</th><th class=\"text-center\">状态</th><th class=\"text-center\"style=\"width:70px;\">操作</th></tr></thead>";
            $("#table-box table").eq(0).append(ftr);
            $("#table-box").show();
        }
    </script>


</asp:Content>
