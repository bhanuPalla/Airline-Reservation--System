using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class ChangePassword : System.Web.UI.Page
{
    DatabaseLayer objdb = new DatabaseLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["CustID"] == null)
            {
                Session["ReturnUrl"] = "ChangePassword.aspx";
                Response.Redirect("login.aspx");
                return;

            }

        }
        catch (Exception ex) { }
    }


    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid == false)
            {
                return;
            }


            //validate old and confirm password
            if (TxtPassword.Text.Trim() == "")
            {
                lblmsg.Text = "Please enter old password.";  return;
            }
            if (TxtNewPassword.Text.Trim() == "")
            {
                lblmsg.Text = "Password should not be blank.";  return;
            }
            if (TxtNewPassword.Text != TxtConfirmPassword.Text)
            {
                lblmsg.Text = "New password and confirm password must be same.";  return;
            }


            //update new password
            string strUpdate = "Update CustomerMaster set CustPassword='" + TxtNewPassword.Text.Replace("'", "''") + "' where CustID=" + Session["CustID"] + " ";

            strUpdate = objdb.ExecuteInsertUpdate(strUpdate);
            if (strUpdate == "" || strUpdate == null || strUpdate == "0")
            {
                lblmsg.Text = "Error : " + objdb.returnMsg; return;
            }
            lblmsg.Text = "Password changes successfully, please relogin.";
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Error : " + ex.Message.ToString();
        }
    }
    protected void BtnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("default.aspx");
    }
}
