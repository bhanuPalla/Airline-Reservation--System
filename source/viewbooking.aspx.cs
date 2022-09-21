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

public partial class viewbooking : System.Web.UI.Page
{
    DatabaseLayer objdb = new DatabaseLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        try

        {
            if (Page.IsPostBack == true)
            {
                return;
            }

            if (Session["CustID"] == null)
            {
                Session["ReturnUrl"] = "viewbooking.aspx";
                Response.Redirect("login.aspx");
                return;
            }
            else
            {
                //display booking details for current logged customer
                string str = "";
                str = "select ResId as [Booking ID], ResFlightId as [Flight No], FlightDestinationFrom as [Origin], FlightDestinationTo as [Destination], FlightDate as [Flight Date], ResRandom as [ ] from ReservationMaster, FlightMaster where FlightMaster.FlightNo =ReservationMaster.ResFlightId and ResCustId=" + Session["CustID"].ToString() + " order by ResId ";
                DataSet ds = new DataSet();
                ds = objdb.GetDataset(str, "booking");

                GridView1.DataSource = ds;
                GridView1.DataMember = "booking";
                GridView1.DataBind();
            }

        }
        catch (Exception ex) { }

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex >= 0)
        {
            string ranid = e.Row.Cells[5].Text;
            e.Row.Cells[5].Text = "<a href='printicket.aspx?id=" + ranid + "' target='_blank'>Print Ticket</a>&nbsp;&nbsp;<a href=javascript:cancelflight('" + ranid + "')>Cancel</a>";
        }
    }
}
