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

public partial class editprofile : System.Web.UI.Page
{
    DatabaseLayer objDb = new DatabaseLayer();
    ValidationFunctions objVl = new ValidationFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (Page.IsPostBack == true)
            {
                return;
            }


            //check session for customer, if expair redirect to login
            if (Session["CustID"] == null)
            {
                Session["ReturnUrl"] = "editprofile.aspx";
                Response.Redirect("login.aspx");
                return;
            }
            else
            {
                //display customer details
                string str = "";
                str = "select * from CustomerMaster where CustID=" + Session["CustID"].ToString();
                DataSet ds = new DataSet();
                ds=objDb.GetDataset (str,"cust");
                if (ds.Tables[0].Rows.Count >0)
                {
                    DataRow r;
                    r = ds.Tables[0].Rows[0];
                    TxtFirstName.Text = Convert.ToString(r["CustFirstName"]);
                    TxtMiddleName.Text = Convert.ToString(r["CustMiddleName"]);
                    TxtLastName.Text = Convert.ToString(r["CustLastName"]);
                    TxtAddress.Text = Convert.ToString(r["CustAddress"]);
                    TxtCity.Text = Convert.ToString(r["CustCity"]);
                    TxtZipCode.Text = Convert.ToString(r["CustZip"]);
                    TxtMobileNo.Text = Convert.ToString(r["CustMobile"]);
                }
            }

        }
        catch (Exception ex) { }


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



                string strInsert = "";

                str = "update CustomerMaster set CustFirstName='" + TxtFirstName.Text + "', CustMiddleName='" + TxtMiddleName.Text + "',CustLastName='" + TxtLastName.Text + "', "
                + "CustAddress='" + TxtAddress.Text + "', CustCity='" + TxtCity.Text + "', CustZip='" + TxtZipCode.Text + "', CustMobile ='" + TxtMobileNo.Text + "' where CustID=" + Session["CustID"].ToString();
                
                //update the deatils
                strInsert = objDb.ExecuteInsertUpdate(str);

                if (strInsert == "" || strInsert == null || strInsert == "0")
                {

                    lblmsg.Text = "Unable to update.";
                    return;
                }
                else
                {

                    objVl.CreateMessageAlert(this, "Details updated successful", "123");
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
        Response.Redirect("default.aspx");
    }
}
