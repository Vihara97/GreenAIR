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
    public partial class Vegetation : System.Web.UI.Page
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

        protected void gvVegitations_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvVegitations.PageIndex = e.NewPageIndex;
                LoadGrid();
            }
            catch (Exception ex)
            {
                ShowInformationMessage(ex.Message, WarningType.Warning);
            }
        }

        protected void gvVegitations_RowCommand(object sender, GridViewCommandEventArgs e)
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
                VegitationModel oData = new VegitationModel();
                oData.Name = txtName.Text;
                oData.Species = txtSpecies.Text;
                oData.HowManyPerUnit = Convert.ToInt32(txtHowManyPerUnit.Text);
                if (_oWebApiCalls.AddVegitation(oData))
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
                GridViewRow oGridViewRow = gvVegitations.Rows[Convert.ToInt32(ViewState["index"])];
                Label lblId = (Label)oGridViewRow.FindControl("lblgvId");

                VegitationModel oData = new VegitationModel();
                oData.ID = Convert.ToInt32(lblId.Text);
                oData.Name = txtName.Text;
                oData.Species = txtSpecies.Text;
                oData.HowManyPerUnit = Convert.ToInt32(txtHowManyPerUnit.Text);
                if (_oWebApiCalls.EditVegitation(oData))
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
                GridViewRow oGridViewRow = gvVegitations.Rows[Convert.ToInt32(ViewState["index"])];
                Label lblId = (Label)oGridViewRow.FindControl("lblgvId");
                if (_oWebApiCalls.DeleteVegitationById(Convert.ToInt32(lblId.Text)))
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
                List<VegitationModel> _oVegitationModels = new List<VegitationModel>();
                _oVegitationModels = _oWebApiCalls.GetAllVegitations();
                gvVegitations.DataSource = _oVegitationModels;
                gvVegitations.DataBind();
            }
            catch (Exception ex)
            {
                ShowInformationMessage(ex.Message, WarningType.Warning);
            }
        }

        private void View()
        {
            GridViewRow oGridViewRow = gvVegitations.Rows[Convert.ToInt32(ViewState["index"])];
            Label lblId = (Label)oGridViewRow.FindControl("lblgvId");
            VegitationModel oVegitationModel = _oWebApiCalls.GetVegitationById(Convert.ToInt32(lblId.Text));

            if (oVegitationModel != null)
            {
                txtID.Text = lblId.Text;
                txtName.Text = !string.IsNullOrEmpty(oVegitationModel.Name) ? oVegitationModel.Name : string.Empty;
                txtSpecies.Text = !string.IsNullOrEmpty(oVegitationModel.Species) ? oVegitationModel.Species : string.Empty;
                txtHowManyPerUnit.Text = Convert.ToString(oVegitationModel.HowManyPerUnit);
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
                        txtID.Enabled = false;
                        groupId.Visible = false;
                        txtName.Enabled = true;
                        txtSpecies.Enabled = true;
                        txtHowManyPerUnit.Enabled = true;
                        break;

                    case CommandMood.Edit:
                        txtID.Enabled = false;
                        groupId.Visible = false;
                        txtName.Enabled = true;
                        txtSpecies.Enabled = true;
                        txtHowManyPerUnit.Enabled = true;
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
                groupId.Visible = false;
                txtID.Text = string.Empty;
                txtName.Text = string.Empty;
                txtSpecies.Text = string.Empty;
                txtHowManyPerUnit.Text = string.Empty;
            }
            catch (Exception ex)
            {
                ShowInformationMessage(ex.Message, WarningType.Warning);
            }
        }

        #endregion Method
    }
}