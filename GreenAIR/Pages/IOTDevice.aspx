<%@ Page Title="" Language="C#" MasterPageFile="~/Module.Master" AutoEventWireup="true" CodeBehind="IOTDevice.aspx.cs" Inherits="GreenAIR.Pages.IOTDevice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .switch {
            position: relative;
            display: inline-block;
            width: 50px;
            height: 24px;
        }

            .switch input {
                opacity: 0;
            }

        .slider {
            position: absolute;
            cursor: pointer;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background-color: #ccc;
            -webkit-transition: .4s;
            transition: .4s;
        }

            .slider:before {
                position: absolute;
                content: "";
                height: 16px;
                width: 16px;
                left: 4px;
                bottom: 4px;
                background-color: white;
                -webkit-transition: .4s;
                transition: .4s;
            }

        input:checked + .slider {
            background-color: #2196F3;
        }

        input:focus + .slider {
            box-shadow: 0 0 1px #2196F3;
        }

        input:checked + .slider:before {
            -webkit-transform: translateX(26px);
            -ms-transform: translateX(26px);
            transform: translateX(26px);
        }

        /* Rounded sliders */
        .slider.round {
            border-radius: 34px;
        }

            .slider.round:before {
                border-radius: 50%;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:MultiView ID="mvParent" runat="server">
        <asp:View ID="View1" runat="server">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">IOT Devices</h3>
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
                            <asp:GridView ID="gvIOTDevices" runat="server" AutoGenerateColumns="False" AllowPaging="True" ShowHeaderWhenEmpty="True"
                                Class="table table-bordered table-hover" OnPageIndexChanging="gvIOTDevices_PageIndexChanging" OnRowCommand="gvIOTDevices_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="Device ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvDeviceId" runat="server" Text='<%# Bind("DeviceID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Location">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvLocation" runat="server" Text='<%# Bind("Location") %>'></asp:Label>
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
                    <h3 class="box-title">IOT Devices</h3>
                </div>
                <div class="box-body">
                    <div class="form-horizontal">
                        <div id="groupDeviceId" runat="server" class="form-group">
                            <label class="col-sm-2 control-label">Device ID:</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtDeviceID" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
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
                            <label class="col-sm-2 control-label">Status:</label>
                            <div class="col-sm-4">
                                <label class="switch">
                                    <asp:CheckBox ID="chkOnOff" runat="server" Checked="false" />
                                    <span class="slider round"></span>
                                </label>
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
            $('#<% = txtDeviceID.ClientID %>').addClass('validate[required]');
            $('#<% = ddlLocation.ClientID %>').addClass('validate[required]');
            $('#<% = chkOnOff.ClientID %>').addClass('validate[required]');

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
