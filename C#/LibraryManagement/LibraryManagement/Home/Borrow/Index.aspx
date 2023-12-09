<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Home.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Library.Home.Borrow.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="fluid">
                        <div class="row">
                <div class="col-lg-6"><b>借书与还书</b></div>
            </div>
            <hr />

            <div id="form" style="width: 350px">
                <div class="form-group">
                    <div class="input-group">
                        <div class="input-group-addon">读者ID</div>
                        <asp:TextBox ID="userId" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="input-group">
                        <div class="input-group-addon">图书号</div>
                        <asp:TextBox ID="bookId" runat="server" class="form-control" placeholder="请输入图书ID"></asp:TextBox>
                    </div>
                </div>
                <div class="from-control text-center" style="margin-top: 25px;">
                    <b>操作：&nbsp;&nbsp;</b>
                    <asp:RadioButton ID="borrow" runat="server" Text="借 书" GroupName="borrow" />
                    <asp:RadioButton ID="return" runat="server" Text="还 书" GroupName="borrow" />

                </div>
                <div class="text-center" style="margin-top: 20px;">
                    <asp:Button ID="submit" runat="server" Text="确认" class="btn btn-primary" OnClick="submit_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                   
                    <asp:Button ID="reset" runat="server" Text="取消" class="btn btn-danger" />

                </div>
            </div>
        </div>
    </div>
     <script type="text/javascript">
        $(".navbar-nav li").eq(3).addClass("active")
</script>
</asp:Content>
