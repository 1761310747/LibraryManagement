<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="User_Add.aspx.cs" Inherits="Library.Admin.User.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="fluid">
             <div class="row">
                <div class="col-lg-6"><b>添加用户</b></div>
            </div>
            <hr />
            <div id="form" class="form-horizontal" style="width: 650px; padding-left: 18px">
                <div class="form-group">
                    <div class="input-group">
                        <div class="input-group-addon">用户ID</div>
                        <asp:TextBox ID="userId" runat="server" type="text" class="form-control" placeholder="请输入用户ID"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="input-group">
                        <div class="input-group-addon">密码</div>
                        <%--<input type="password" class="form-control" placeholder="请输入密码" name="password">--%>
                        <asp:TextBox ID="password" runat="server" type="password" class="form-control" placeholder="请输入密码"></asp:TextBox>

                    </div>
                </div>
                <div class="form-group">
                    <div class="input-group">
                        <div class="input-group-addon">姓名</div>
                        <%--<input type="text" class="form-control" placeholder="请输入姓名" name="name">--%>
                        <asp:TextBox ID="name" runat="server" type="text" class="form-control" placeholder="请输入姓名"></asp:TextBox>

                    </div>
                </div>
                <div class="form-group">
                    <div class="input-group">
                        <div class="input-group-addon">班级</div>
                        <%--<input type="text" class="form-control" placeholder="请输入班级" name="class">--%>
                        <asp:TextBox ID="class1" runat="server" type="text" class="form-control" placeholder="请输入班级"></asp:TextBox>

                    </div>
                </div>
                <div class="form-group">
                    <div class="input-group">
                        <div class="input-group-addon">状态</div>

                        <asp:DropDownList ID="status" runat="server" class="form-control">
                            <asp:ListItem Value="1">正常</asp:ListItem>
                            <asp:ListItem Value="0">挂失</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <div class="input-group">
                        <div class="input-group-addon">状态</div>

                        <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                            <asp:ListItem Value="0">用户</asp:ListItem>
                            <asp:ListItem Value="1">管理员</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">

                    <asp:Button ID="submit" runat="server" Text="确认" class="btn btn-primary" Style="margin-right: 10px" OnClick="submit_Click" />

                    <asp:Button ID="reset" runat="server" Text="取消" class="btn btn-danger" Style="margin-left: 10px" OnClick="reset_Click" />
                </div>
            </div>
        </div>
    </div>

    <style>
        .input-group-addon {
            width: 80px !important;
        }
    </style>
</asp:Content>
