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
    public partial class UserSignUp : System.Web.UI.Page
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                UserModel oData = new UserModel();
                oData.Name = txtName.Text;
                oData.LocationAddress = Convert.ToInt32(ddlLocation.SelectedValue);
                oData.MobileNoOrEmail = txtUsername.Text;
                oData.Password = txtPassword.Text;
                if (_oWebApiCalls.AddUser(oData))
                {
                    ShowInformationMessage(ResponseMessages.InsertSuccess, WarningType.Success);
                    ResetControllers();
                }
                else
                {
                    ShowInformationMessage("User already exists", WarningType.Warning);
                    ResetControllers();
                }
            }
            catch (Exception ex)
            {
                ShowInformationMessage(ex.Message, WarningType.Warning);
            }
        }

        #endregion Event

        #region Method

        private void PageLoad()
        {
            try
            {
                ResetControllers();
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

        private void ResetControllers()
        {
            try
            {
                txtName.Text = string.Empty;
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
                ddlLocation.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ShowInformationMessage(ex.Message, WarningType.Warning);
            }
        }

        #endregion Method
    }
}