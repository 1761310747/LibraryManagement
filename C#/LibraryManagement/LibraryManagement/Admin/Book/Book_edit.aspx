<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Book_edit.aspx.cs" Inherits="Library.Admin.Book.Book_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="fluid">
            <div class="row">
                <div class="col-lg-6"><b>编辑图书</b></div>
            </div>
        </div>
        <div class="fluid">
            <div id="form" class="form-horizontal" style="width: 500px; padding-left: 18px">
                <div class="form-group">
                    <div class="input-group">
                        <div class="input-group-addon">书名</div>
                        <asp:TextBox ID="name" runat="server" class="form-control" placeholder="请输入图书名"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="input-group">
                        <div class="input-group-addon">书号</div>
                        <asp:TextBox ID="ISBN" runat="server" class="form-control" placeholder="请输入书号"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="input-group">
                        <div class="input-group-addon">作者</div>
                        <asp:TextBox ID="author" runat="server" class="form-control" placeholder="请输入作者"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="input-group">
                        <div class="input-group-addon">价格</div>
                        <asp:TextBox ID="price" runat="server" class="form-control" placeholder="请输入价格"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="input-group">
                        <div class="input-group-addon">出版社</div>
                        <asp:TextBox ID="press" runat="server" class="form-control" placeholder="请输入出版社"></asp:TextBox>

                    </div>
                </div>
                <div class="form-group">
                    <div class="input-group">
                        <div class="input-group-addon">出版时间</div>
                        <asp:TextBox ID="pressTime" runat="server" class="form-control" placeholder="请输入出版时间"></asp:TextBox>

                    </div>
                </div>
                <div class="form-group">
                    <label class="text-left" style="width: 100%">简介：</label>
                    <asp:TextBox ID="desc" runat="server" class="form-control" placeholder="请输入作品简介" Style="resize: none;" TextMode="MultiLine" Height="116px" Width="501px"></asp:TextBox>
                </div>
                <div class="form-group">

                    <asp:Button ID="submit" runat="server" Text="确&nbsp;认" class="btn btn-primary" Style="margin-right: 20px" OnClick="submit_Click" />
                    <asp:Button ID="reset" runat="server" Text="取&nbsp;消" class="btn btn-danger" Style="margin-left: 20px" OnClick="reset_Click" />

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
