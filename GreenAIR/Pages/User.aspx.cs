using GreenAIR.Common;
using GreenAIR.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenAIR.Pages
{
    public partial class User : System.Web.UI.Page
    {
        #region Declare

        private CommonMethod oCommonMethod = new CommonMethod();
        private WebApiCalls _oWebApiCalls = new WebApiCalls();

        #endregion Declare

        #region Event

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PageLoad();
            }
        }

        protected void gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvUsers.PageIndex = e.NewPageIndex;
                LoadGrid();
            }
            catch (Exception ex)
            {
                ShowInformationMessage(ex.Message, WarningType.Warning);
            }
        }

        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {

                    case "EditData":
                        ViewState["index"] = e.CommandArgument.ToString();
                        HandleButtons(CommandMood.Edit);
                        HandleControllers(CommandMood.Edit);
                        View();
                        mvParent.ActiveViewIndex = 1;
                        break;

                    case "DeleteData":
                        ViewState["index"] = e.CommandArgument.ToString();
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowDeleteConfirmation();", true);
                        break;
                }
            }
            catch (Exception ex)
            {
                ShowInformationMessage(ex.Message, WarningType.Warning);
                throw ex;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                HandleButtons(CommandMood.Edit);
                HandleControllers(CommandMood.Edit);
            }
            catch (Exception ex)
            {
                ShowInformationMessage(ex.Message, WarningType.Warning);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow oGridViewRow = gvUsers.Rows[Convert.ToInt32(ViewState["index"])];
                Label lblUserId = (Label)oGridViewRow.FindControl("lblgvUserId");

                UserModel oData = new UserModel();
                oData.UserID = Convert.ToInt32(lblUserId.Text);
                oData.Name = txtName.Text;
                oData.LocationAddress = Convert.ToInt32(ddlLocation.SelectedValue);
                oData.Status = chkOnOff.Checked ? (int)Status.Active : (int)Status.Inactive;
                if (_oWebApiCalls.EditUser(oData))
                {
                    ShowInformationMessage(ResponseMessages.UpdateSuccess, WarningType.Success);
                    ResetControllers();
                    LoadGrid();
                    mvParent.ActiveViewIndex = 0;
                }
                else
                {
                    ShowInformationMessage("Cannot duplicate values", WarningType.Warning);
                }
            }
            catch (Exception ex)
            {
                ShowInformationMessage(ex.Message, WarningType.Warning);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ResetControllers();
            }
            catch (Exception ex)
            {
                ShowInformationMessage(ex.Message, WarningType.Warning);
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                mvParent.ActiveViewIndex = 0;
                ResetControllers();
            }
            catch (Exception ex)
            {
                ShowInformationMessage(ex.Message, WarningType.Warning);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow oGridViewRow = gvUsers.Rows[Convert.ToInt32(ViewState["index"])];
                Label lblUserId = (Label)oGridViewRow.FindControl("lblgvUserId");
                if (_oWebApiCalls.DeleteUserById(Convert.ToInt32(lblUserId.Text)))
                {
                    LoadGrid();
                    ShowInformationMessage(ResponseMessages.DeleteSuccess, WarningType.Success);
                }
            }
            catch (Exception ex)
            {
                ShowInformationMessage(ex.Message, WarningType.Warning);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        #endregion Event

        #region Method

        private void PageLoad()
        {
            try
            {
                mvParent.ActiveViewIndex = 0;
                LoadGrid();
                LoadDropDown();
            }
            catch (Exception ex)
            {
                ShowInformationMessage(ex.Message, WarningType.Warning);
            }
        }

        private void LoadDropDown()
        {
            try
            {
                ddlLocation.DataSource = oCommonMethod.ComboDataBindByEnum<Locations>();
                ddlLocation.DataTextField = "Text";
                ddlLocation.DataValueField = "Value";
                ddlLocation.DataBind();

            }
            catch (Exception ex)
            {
                ShowInformationMessage(ex.Message, WarningType.Warning);
            }
        }

        private void LoadGrid()
        {
            try
            {
                List<UserModel> _oUserModels = new List<UserModel>();
                _oUserModels = _oWebApiCalls.GetAllUsers();
                gvUsers.DataSource = _oUserModels;
                gvUsers.DataBind();
            }
            catch (Exception ex)
            {
                ShowInformationMessage(ex.Message, WarningType.Warning);
            }
        }

        private void View()
        {
            GridViewRow oGridViewRow = gvUsers.Rows[Convert.ToInt32(ViewState["index"])];
            Label lblUserId = (Label)oGridViewRow.FindControl("lblgvUserId");
            UserModel oUserModel = _oWebApiCalls.GetUserById(Convert.ToInt32(lblUserId.Text));

            if (oUserModel != null)
            {
                txtUserID.Text = lblUserId.Text;
                txtName.Text = oUserModel.Name;
                ddlLocation.SelectedValue = oUserModel.LocationAddress != 0 ? Convert.ToString(oUserModel.LocationAddress) : "";
                chkOnOff.Checked = oUserModel.Status == (int)Status.Active ? true : false;
            }
        }

        protected void ShowInformationMessage(string message, WarningType type)
        {
            try
            {
                switch (type)
                {
                    case WarningType.Success:
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowMessageSuccess('" + message + "');", true);
                        break;

                    case WarningType.Danger:
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowMessageDanger('" + message + "');", true);
                        break;

                    case WarningType.Info:
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowMessageInfo('" + message + "');", true);
                        break;

                    case WarningType.Warning:
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowMessageWarning('" + message + "');", true);
                        break;
                }
            }
            catch (Exception ex)
            {
                ShowInformationMessage(ex.Message, WarningType.Warning);
            }
        }

        private void HandleButtons(CommandMood oCommandMood)
        {
            try
            {
                switch (oCommandMood)
                {

                    case CommandMood.Edit:
                        btnAdd.Visible = false;
                        btnEdit.Visible = false;
                        btnSave.Visible = true;
                        btnClear.Visible = true;
                        btnClose.Visible = true;
                        break;

                }
            }
            catch (Exception ex)
            {
                ShowInformationMessage(ex.Message, WarningType.Warning);
            }
        }

        private void HandleControllers(CommandMood oCommandMood)
        {
            try
            {
                switch (oCommandMood)
                {

                    case CommandMood.Edit:
                        txtUserID.Enabled = false;
                        groupUserId.Visible = true;
                        txtName.Enabled = true;
                        ddlLocation.Enabled = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                ShowInformationMessage(ex.Message, WarningType.Warning);
            }
        }

        private void ResetControllers()
        {
            try
            {
                groupUserId.Visible = false;
                txtUserID.Text = string.Empty;
                txtName.Text = string.Empty;
                ddlLocation.SelectedIndex = 0;
                chkOnOff.Checked = false;
            }
            catch (Exception ex)
            {
                ShowInformationMessage(ex.Message, WarningType.Warning);
            }
        }

        #endregion Method
    }
}