<%@ Page Title="首页" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Library.Admin.Admin_Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
    <div class="center-block">
      <h3 class="text-center">
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>:你好，欢迎登录后台管理系统</h3>
      <h3 class="text-center" style="margin-top:70px;">本馆共有<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>本图书</h3>
      <h3 class="text-center">共有<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>名读者</h3>
      <h4 class="text-center" style="margin-top:70px;">上次登录时间：</h4>
      <h4 class="text-center">
                <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></h4>
    </div>
  </div>
    <style>
           body {
            background-color: #f0f2f5;
            min-height: 100vh;
            height: 100%;
            width: 100%;
            background-image: linear-gradient(rgba(0, 0, 0, 0.6), rgba(0, 0, 0, 0.6)), url(/Resources/bg1.jpg);
            background-repeat: no-repeat;
            background-size: 100% 100%;
            background-position: center center;
        }

        .center-block {
            color: #fff;
            margin-top:50px;
            width: 500px;
            min-height: 400px;
            background: rgba(255, 255, 255, 0.1);
            backdrop-filter: blur(5px);
            box-shadow: 0 25px 45px rgb(0 0 0 / 10%);
            border: 1px solid rgba(255, 255, 255, 0.5);
            border-right: 1px solid rgba(255, 255, 255, 0.2);
            border-bottom: 1px solid rgba(255, 255, 255, 0.2);
        }
    </style>
    <script type="text/javascript">
        $(".navbar-nav li").eq(0).addClass("active")
</script>
</asp:Content>
