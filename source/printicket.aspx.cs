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


public partial class printicket : System.Web.UI.Page
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
                Session["ReturnUrl"] = "default.aspx";
                Response.Redirect("login.aspx");
                return;
            }
            else
            {
                //display details
                string str = "";
                str = "select ReservationMaster.*,FlightMaster.*  from ReservationMaster, FlightMaster where FlightMaster.FlightNo =ReservationMaster.ResFlightId and ResRandom='" + Request.QueryString["id"].ToString() + "'   ";
                DataSet dsRMaster = new DataSet();
                dsRMaster = objdb.GetDataset(str, "ReservationMaster");

                str = "select ResDId as [Passenger No.], ResDPassengerFirstName as [First Name], ResDPassengerMiddleName as [Middle Name], ResDPassengerLastName as [Last Name], ResDGender as [Gender], ResDAge as [Age] from ReservationDetails where ResRandom='" + Request.QueryString["id"].ToString() + "'   ";
                DataSet dsRDetails = new DataSet();
                dsRDetails = objdb.GetDataset(str, "ReservationDetails");

                sp_refno.InnerHtml = Convert.ToString(dsRMaster.Tables[0].Rows[0]["ResId"]);
                sp_flight_no.InnerHtml = Convert.ToString(dsRMaster.Tables[0].Rows[0]["FlightNo"]);
                sp_departuredate.InnerHtml = Convert.ToString(dsRMaster.Tables[0].Rows[0]["FlightDepartureTime"]);
                sp_arrivaldate.InnerHtml = Convert.ToString(dsRMaster.Tables[0].Rows[0]["FlightArivalTime"]);
                sp_origin.InnerHtml = Convert.ToString(dsRMaster.Tables[0].Rows[0]["FlightDestinationFrom"]);
                sp_destination.InnerHtml = Convert.ToString(dsRMaster.Tables[0].Rows[0]["FlightDestinationTo"]);
                sp_total_price.InnerHtml = Convert.ToString(dsRMaster.Tables[0].Rows[0]["ResTotalAmount"]);

                GridView1.DataSource = dsRDetails;
                GridView1.DataMember = "ReservationDetails";
                GridView1.DataBind();

            }

        }
        catch (Exception ex) { }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex >= 0)
        {
            int i = e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = i.ToString();
        }
    }
}
