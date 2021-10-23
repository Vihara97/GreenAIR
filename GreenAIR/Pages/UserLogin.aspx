<%@ Page Title="" Language="C#" MasterPageFile="~/Module.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="GreenAIR.Pages.UserLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="box box-primary">
        <div class="box-header with-border">
            <h3 class="box-title">Sign In</h3>
        </div>
        <div class="box-body">
            <div class="form-horizontal">
                <div class="form-group">
                    <label class="col-sm-2 control-label">Email Address:</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">Password:</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" MaxLength="50"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="box-footer">
            <asp:Button ID="btnLogin" runat="server" Text="Sign In" CssClass="btn btn-success" OnClick="btnLogin_Click" OnClientClick="return AttachValidation();" />
            <br />
            Don't have an account? <a href='<%=ResolveClientUrl("~/Pages/UserSignUp.aspx")%>'><span>Sign Up</span></a>
        </div>
    </div>
    <script type="text/javascript">
        function AttachValidation() {
            $('#<% = txtUsername.ClientID %>').addClass('validate[required]');
            $('#<% = txtPassword.ClientID %>').addClass('validate[required]');
            $("#form1").validationEngine('attach', { promptPosition: "centerRight", scroll: false });
            var valid = $("#form1").validationEngine('validate');
            var vars = $("#form1").serialize();
            if (valid == true) {
                $("#form1").validationEngine('detach');
            } else {
                $("#form1").validationEngine('attach', { promptPosition: "centerRight", scroll: false });
                return false;
            }
        }
        function DetachValidation() {
            $("#form1").validationEngine('detach');
        };
    </script>
</asp:Content>
