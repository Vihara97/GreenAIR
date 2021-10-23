<%@ Page Title="" Language="C#" MasterPageFile="~/Module.Master" AutoEventWireup="true" CodeBehind="Vegetation.aspx.cs" Inherits="GreenAIR.Pages.Vegetation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:MultiView ID="mvParent" runat="server">
        <asp:View ID="View1" runat="server">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Vegitation</h3>
                </div>
                <div class="box-body">
                    <div class="row">
                        <div class="col-sm-8">
                            <asp:Button ID="btnAddNew" runat="server" Text="Add New" CssClass="btn btn-success" OnClick="btnAddNew_Click" />
                        </div>
                        <div class="col-sm-4">
                            <div class="input-group input-group-sm">
                                <asp:TextBox ID="txtSearch" runat="server" placeholder="Search.." CssClass="form-control"></asp:TextBox>
                                <span class="input-group-btn">
                                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success btn-flat" Text="Search" OnClick="btnSearch_Click" />
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <asp:GridView ID="gvVegitations" runat="server" AutoGenerateColumns="False" AllowPaging="True" ShowHeaderWhenEmpty="True"
                                Class="table table-bordered table-hover" OnPageIndexChanging="gvVegitations_PageIndexChanging" OnRowCommand="gvVegitations_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvId" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Species">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvSpecies" runat="server" Text='<%# Bind("Species") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="How many per unit?">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvHowManyPerUnit" runat="server" Text='<%# Bind("HowManyPerUnit") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/dist/img/ic_edit.png"
                                                CommandName="EditData" CommandArgument="<%# Container.DisplayIndex %>" />
                                        </ItemTemplate>
                                        <ItemStyle Width="1%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/dist/img/ic_delete.png"
                                                CommandName="DeleteData" CommandArgument="<%# Container.DisplayIndex %>" />
                                        </ItemTemplate>
                                        <ItemStyle Width="1%" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                <PagerStyle CssClass="cpb-pagination" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Vegitation</h3>
                </div>
                <div class="box-body">
                    <div class="form-horizontal">
                        <div id="groupId" runat="server" class="form-group">
                            <label class="col-sm-2 control-label">ID:</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtID" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Name:</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Species:</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtSpecies" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">How Many Per Unit:</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtHowManyPerUnit" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="box-footer">
                    <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-success" OnClick="btnAdd_Click" OnClientClick="return AttachValidation();" />
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-success" OnClick="btnEdit_Click" OnClientClick="return DetachValidation();" />
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click" OnClientClick="return AttachValidation();" />
                    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-secondary" OnClick="btnClear_Click" OnClientClick="return DetachValidation();" />
                    <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-secondary" OnClientClick="return DetachValidation();" OnClick="btnClose_Click" />
                </div>
            </div>
        </asp:View>
    </asp:MultiView>
    <div class="modal fade" id="Delete-Confirmation" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Delete Confirmation</h4>
                </div>
                <div class="modal-body">
                    <p>Are you sure you want to delete this item?</p>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="Button2" runat="server" Text="Close" class="btn btn-default" OnClientClick="return HideDeleteConfirmation();" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn btn-danger" OnClick="btnDelete_Click" />
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function ShowDeleteConfirmation() {

            $('#Delete-Confirmation').modal('show');
            return false;
        };
        function HideDeleteConfirmation() {

            $('#Delete-Confirmation').modal('hide');
            return false;
        };
    </script>
    <script type="text/javascript">
        function AttachValidation() {
            $('#<% = txtID.ClientID %>').addClass('validate[required]');
            $('#<% = txtName.ClientID %>').addClass('validate[required]');
            $('#<% = txtSpecies.ClientID %>').addClass('validate[required]');
            $('#<% = txtHowManyPerUnit.ClientID %>').addClass('validate[required,onlyNumberSp]');

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
