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
    public partial class MonitoringCenter : System.Web.UI.Page
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

        protected void gvMonitoringCenters_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvMonitoringCenters.PageIndex = e.NewPageIndex;
                LoadGrid();
            }
            catch (Exception ex)
            {
                ShowInformationMessage(ex.Message, WarningType.Warning);
            }
        }

        protected void gvMonitoringCenters_RowCommand(object sender, GridViewCommandEventArgs e)
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
            try
            {
                MonitoringCenterModel oData = new MonitoringCenterModel();
                oData.Name = txtName.Text;
                oData.Location = Convert.ToInt32(ddlLocation.SelectedValue);
                oData.Status = chkOnOff.Checked ? (int)Status.Active : (int)Status.Inactive;
                if (_oWebApiCalls.AddMonitoringCenter(oData))
                {
                    ShowInformationMessage(ResponseMessages.InsertSuccess, WarningType.Success);
                    LoadGrid();
                    mvParent.ActiveViewIndex = 0;
                    ResetControllers();
                    HandleControllers(CommandMood.Add);
                }
                else
                {
                    ShowInformationMessage("Cannot duplicate values", WarningType.Warning);
                    ResetControllers();
                }
            }
            catch (Exception ex)
            {
                ShowInformationMessage(ex.Message, WarningType.Warning);
            }
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
                GridViewRow oGridViewRow = gvMonitoringCenters.Rows[Convert.ToInt32(ViewState["index"])];
                Label lblCenterId = (Label)oGridViewRow.FindControl("lblgvCenterId");

                MonitoringCenterModel oData = new MonitoringCenterModel();
                oData.CenterID = Convert.ToInt32(lblCenterId.Text);
                oData.Name = txtName.Text;
                oData.Location = Convert.ToInt32(ddlLocation.SelectedValue);
                oData.Status = chkOnOff.Checked ? (int)Status.Active : (int)Status.Inactive;
                if (_oWebApiCalls.EditMonitoringCenter(oData))
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
                GridViewRow oGridViewRow = gvMonitoringCenters.Rows[Convert.ToInt32(ViewState["index"])];
                Label lblCenterId = (Label)oGridViewRow.FindControl("lblgvCenterId");
                if (_oWebApiCalls.DeleteMonitoringCenterById(Convert.ToInt32(lblCenterId.Text)))
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

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    mvParent.ActiveViewIndex = 1;
                    HandleButtons(CommandMood.Add);
                    HandleControllers(CommandMood.Add);
                }
                catch (Exception ex)
                {
                    ShowInformationMessage(ex.Message, WarningType.Warning);
                }
            }
            catch (Exception ex)
            {

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
                List<MonitoringCenterModel> _oMonitoringCenterModels = new List<MonitoringCenterModel>();
                _oMonitoringCenterModels = _oWebApiCalls.GetAllMonitoringCenters();
                gvMonitoringCenters.DataSource = _oMonitoringCenterModels;
                gvMonitoringCenters.DataBind();
            }
            catch (Exception ex)
            {
                ShowInformationMessage(ex.Message, WarningType.Warning);
            }
        }

        private void View()
        {
            GridViewRow oGridViewRow = gvMonitoringCenters.Rows[Convert.ToInt32(ViewState["index"])];
            Label lblCenterId = (Label)oGridViewRow.FindControl("lblgvCenterId");
            MonitoringCenterModel oMonitoringCenterModel = _oWebApiCalls.GetMonitoringCenterById(Convert.ToInt32(lblCenterId.Text));

            if (oMonitoringCenterModel != null)
            {
                txtCenterID.Text = lblCenterId.Text;
                txtName.Text = oMonitoringCenterModel.Name;
                ddlLocation.SelectedValue = oMonitoringCenterModel.Location != 0 ? Convert.ToString(oMonitoringCenterModel.Location) : "";
                chkOnOff.Checked = oMonitoringCenterModel.Status == (int)Status.Active ? true : false;
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
                    case CommandMood.Add:
                        btnAdd.Visible = true;
                        btnEdit.Visible = false;
                        btnSave.Visible = false;
                        btnClear.Visible = true;
                        btnClose.Visible = true;
                        break;

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
                    case CommandMood.Add:
                        txtCenterID.Enabled = false;
                        groupCenterId.Visible = false;
                        txtName.Enabled = true;
                        ddlLocation.Enabled = true;
                        break;

                    case CommandMood.Edit:
                        txtCenterID.Enabled = false;
                        groupCenterId.Visible = false;
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
                groupCenterId.Visible = false;
                txtCenterID.Text = string.Empty;
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