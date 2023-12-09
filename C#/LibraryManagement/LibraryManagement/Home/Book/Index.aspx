<%@ Page Title="图书查询" Language="C#" MasterPageFile="~/Home/Home.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Library.Home.Book.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="fluid" hidden>
            <div class="row">
                <div class="col-lg-6"><b>图书管理</b></div>
                <hr />
            </div>
            <div class="row" style="margin-bottom: 40px;">
                <div class="col-lg-6">
                    <div class="input-group">
                        <asp:TextBox ID="TextBox1" CssClass="form-control col-sm-6" runat="server"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button runat="server" ID="Button4" CssClass="btn btn-primary" Text="搜索" OnClick="research_Click"></asp:Button>
                        </span>
                    </div>
                </div>
            </div>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Width="1069px">
                <AlternatingRowStyle ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="图书ID" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="name" HeaderText="书名" SortExpression="name" />
                    <asp:BoundField DataField="author" HeaderText="作者" SortExpression="author" />
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <%# Eval("status").ToString()=="1"?"已借出":"在馆" %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
    </div>

    <script type="text/javascript">
        $(".navbar-nav li").eq(1).addClass("active")
        $("table").eq(0).addClass("grid")
        $("table").attr("data-pagination", 'true');
        $("table").attr("data-side-pagination", 'client');
        $("table").attr("data-page-size", '10');
        $("table").bootstrapTable({
            columns: [{
                field: '图书ID',
                title: '图书ID'
            }, {
                field: '书名',
                title: '书名'
            }, {
                field: '作者',
                title: '作者'
            }, {
                field: '状态',
                title: '状态'
            }]
        });

        $(".fluid").show();
    </script>
</asp:Content>
