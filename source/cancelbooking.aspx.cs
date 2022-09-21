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

public partial class cancelbooking : System.Web.UI.Page
{
    DatabaseLayer objdb = new DatabaseLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        //delete the reservation
        string str1 = "";
        str1 = "delete from ReservationDetails where ResRandom='" + Request.QueryString["id"].ToString() + "'";
        objdb.ExecuteInsertUpdate(str1);

        str1 = "delete from ReservationMaster where ResRandom='" + Request.QueryString["id"].ToString() + "'";
        objdb.ExecuteInsertUpdate(str1);

        Response.Redirect("viewbooking.aspx");


    }
}
