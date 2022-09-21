using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class registration : System.Web.UI.Page
{
    DatabaseLayer objDb = new DatabaseLayer();
    ValidationFunctions objVl = new ValidationFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {


    }
    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid == true)
            {
                    //check for duplicate email id
                    string str = "";
                    string strR = "";
                    str = "select count(*) from customermaster where CustEmailID='" + TxtEmailId.Text + "'";
                    strR = objDb.ExecuteScaler(str);
                    if (Convert.ToInt16(strR) > 0)
                    {
                        lblmsg.Text = "Duplicate email id.";
                        return;
                    }

                    //create customer insert query
                    string strInsert = "";

                    str = "insert into customermaster (CustFirstName, CustMiddleName, CustLastName, CustAddress, CustCity, CustZip, CustMobile, CustEmailID, CustPassword, CustActive) values "
                    + "('" + TxtFirstName.Text + "','" + TxtMiddleName.Text + "','" + TxtLastName.Text + "','" + TxtAddress.Text + "','" + TxtCity.Text + "','" + TxtZipCode.Text + "','" + TxtMobileNo.Text + "','" + TxtEmailId.Text + "','" + TxtPassword.Text + "',1)";

                    strInsert = objDb.ExecuteInsertUpdate(str);

                    if (strInsert == "" || strInsert == null || strInsert == "0")
                    {

                        lblmsg.Text = "Unable to register.";
                        return;
                    }
                    else
                    {

                        objVl.CreateMessageAlert(this, "Registration successful", "123");
                        Response.Redirect("login.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg.Text = "Error : " + ex.Message.ToString();
            }
        
    }
    protected void BtnRegister_Click(object sender, EventArgs e)
    {
        //back to home page

        Response.Redirect("default.aspx");
    }
}
