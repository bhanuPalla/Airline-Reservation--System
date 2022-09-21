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

public partial class login : System.Web.UI.Page
{
    DatabaseLayer objDb = new DatabaseLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (IsPostBack == false)
            {
                //re-set session value
                Session["CustID"] = null;
                Session["CustName"] = null;
                Session["CustLastLoginDate"] = null;
                TxtEmailId.Focus();
            }
        }
        catch (Exception ex) { }
    }
    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            //check customer email id
            DataSet dsCust = new DataSet();
            dsCust = objDb.GetDataset("select custfirstname + ' ' + custmiddlename + ' ' + custlastname cname, *  from CustomerMaster where CustEmailID='" + TxtEmailId.Text + "'", "CustMst");
            if (dsCust != null)
            {
                if (dsCust.Tables["CustMst"].Rows.Count > 0)
                {
                    //check customer password
                    if (TxtPassword.Text == dsCust.Tables["CustMst"].Rows[0]["CustPassword"].ToString())
                    {
                        //if email id and password is correct store session vaue and re-direct to home page
                        Session["CustID"] = dsCust.Tables["CustMst"].Rows[0]["CustID"].ToString().ToUpper();
                        Session["CustName"] = dsCust.Tables["CustMst"].Rows[0]["cname"].ToString();
                        Session["CustLastLoginDate"] = dsCust.Tables["CustMst"].Rows[0]["CustLastLoginDtae"].ToString();
                        Session["CustEmailID"] = dsCust.Tables["CustMst"].Rows[0]["CustEmailID"].ToString();
                        Session["CustMobile"] = dsCust.Tables["CustMst"].Rows[0]["CustMobile"].ToString();

                        

                        if (Convert.ToString(Session["ReturnUrl"]) == "" )
                        {
                            Response.Redirect("Default.aspx");
                            
                        }
                        else
                        {

                            Response.Redirect(Convert.ToString(Session["ReturnUrl"]));
                        }
                    }
                    else
                    {
                        //display message if password is not correct

                        lblmsg.Text = "Invalid password.";
                        TxtPassword.Focus();
                    }
                }
                else
                {
                    //display message if email id is not correct
                    lblmsg.Text = "Invalid Email ID.";
                    TxtEmailId.Text = "";
                    TxtPassword.Focus();
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
        Response.Redirect("registration.aspx");
    }
}
