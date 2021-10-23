<%@ Page Title="" Language="C#" MasterPageFile="~/Module.Master" AutoEventWireup="true" CodeBehind="UserSignUp.aspx.cs" Inherits="GreenAIR.Pages.UserSignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="box box-primary">
        <div class="box-header with-border">
            <h3 class="box-title">Sign Up</h3>
        </div>
        <div class="box-body">
            <div class="form-horizontal">
                <div class="form-group">
                    <label class="col-sm-2 control-label">Name:</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">Location:</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlLocation" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">Mobile number or Email address:</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">New Password:</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" MaxLength="50"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="box-footer">
            <asp:Button ID="btnAdd" runat="server" Text="Sign Up" CssClass="btn btn-success" OnClick="btnAdd_Click" OnClientClick="return AttachValidation();" />
            <br />
            Already have an account? <a href='<%=ResolveClientUrl("~/Pages/UserLogin.aspx")%>'><span>Sign In</span></a>
        </div>
    </div>
    <script type="text/javascript">
        function AttachValidation() {
            $('#<% = txtName.ClientID %>').addClass('validate[required]');
            $('#<% = ddlLocation.ClientID %>').addClass('validate[required]');
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
