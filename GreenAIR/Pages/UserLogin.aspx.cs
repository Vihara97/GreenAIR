using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GreenAIR.Pages
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
            }
        }
    }
}