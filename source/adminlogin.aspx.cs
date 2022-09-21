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
                //reset the session varaiable
                Session["AdminLogin"] = null;
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
            DataSet dsCust = new DataSet();
            //open data set to check admin email id
            dsCust = objDb.GetDataset("select admfirstname + ' ' + admmiddlename + ' ' + admlastname admname, *  from adminMaster where admEmailID='" + TxtEmailId.Text + "'", "admMst");
            if (dsCust != null)
            {
                if (dsCust.Tables["admMst"].Rows.Count > 0)
                {
                    //check admin password
                    if (TxtPassword.Text == dsCust.Tables["admMst"].Rows[0]["admPassword"].ToString())
                    {
                        //if email id and password is ok, store session value
                        Session["AdminLogin"] = "admin";
                        Session["CustID"] = dsCust.Tables["admMst"].Rows[0]["admID"].ToString().ToUpper();
                        Session["CustName"] = dsCust.Tables["admMst"].Rows[0]["admname"].ToString();
                        //Session["CustLastLoginDate"] = dsCust.Tables["admMst"].Rows[0]["admLastLoginDtae"].ToString();
                        Session["CustEmailID"] = dsCust.Tables["admMst"].Rows[0]["admEmailID"].ToString();

                        

                        if (Convert.ToString(Session["ReturnUrl"]) == "" )
                        {
                            Response.Redirect("adminDefault.aspx");
                            
                        }
                        else
                        {

                            Response.Redirect(Convert.ToString(Session["ReturnUrl"]));
                        }
                    }
                    else
                    {
                        //display message for wrong password
                        lblmsg.Text = "Invalid password.";
                        TxtPassword.Focus();
                    }
                }
                else
                {
                    //display message for wrong admin email id
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


}
