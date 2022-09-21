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

public partial class flightoptions : System.Web.UI.Page
{
    DatabaseLayer objdb = new DatabaseLayer();
    ValidationFunctions objfun = new ValidationFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {


        //display journey details
        sp_journeytype.InnerHtml = "<b>" + Convert.ToString(Session["journeytype"]) + "</b>";
        sp_fromcity.InnerHtml = "<b>" + Convert.ToString(Session["from"]) + "</b>";
        sp_tocity.InnerHtml = "<b>" + Convert.ToString(Session["to"]) + "</b>";
        sp_departuredate.InnerHtml = "<b>" + Convert.ToString(Session["depart"]) + "</b>";
        if (Convert.ToString(Session["journeytype"]) == "Round Trip")
        {
            sp_returndate.InnerHtml = "<b>" + Convert.ToString(Session["return"]) + "</b>";
        }
        sp_adults.InnerHtml = "<b>" + Convert.ToString(Session["adult"]) + "</b>";
        sp_child.InnerHtml = "<b>" + Convert.ToString(Session["child"]) + "</b>";
        sp_infants.InnerHtml = "<b>" + Convert.ToString(Session["infant"]) + "</b>";
        //load dataset
        //redirect flight options
        //fill dataset baed on search store view state for multiplae page

        DateTime departdt, returndt;
        departdt = Convert.ToDateTime(Convert.ToString(Session["depart"]));
        returndt = Convert.ToDateTime(Convert.ToString(Session["return"]));

        string d1, d2;
        d1 = departdt.ToString("yyyy-MM-dd 00:00");
        d2 = departdt.ToString("yyyy-MM-dd 23:59");

        string strFromCity, strToity, strJourneyType;
        strFromCity = Convert.ToString(Session["from"]);
        strToity = Convert.ToString(Session["to"]);
        strJourneyType = Convert.ToString(Session["journeytype"]);

        string strqr_d = "";
        strqr_d = "select FlightNo  as [Flight No], FlightDate as [Date], FlightDestinationFrom as [Origin], FlightDestinationTo as [Destination], FlightDepartureTime as [Departure], FlightArivalTime as [Arrival], FlightFareEconomy as Economy, FlightFareBusiness as Business  from flightmaster where FlightDestinationFrom='" + strFromCity + "' and FlightDestinationTo ='" + strToity + "' " +
            " and FlightDate between '" + d1 + "' and  '" + d2 + "' order by FlightDepartureTime ";

        DataSet ds_d = new DataSet();
        ds_d = objdb.GetDataset(strqr_d, "departure");

        ViewState["ds_d"] = ds_d;


        if (Convert.ToString(Session["journeytype"]) == "Round Trip")
        {
            d1 = returndt.ToString("yyyy-MM-dd 00:00");
            d2 = returndt.ToString("yyyy-MM-dd 23:59");


            string strqr_r = "";
            strqr_r = "select FlightNo  as [Flight No], FlightDate as [Date], FlightDestinationFrom as [Origin], FlightDestinationTo as [Destination], FlightDepartureTime as [Departure], FlightArivalTime as [Arrival], FlightFareEconomy as Economy, FlightFareBusiness as Business from flightmaster where FlightDestinationFrom='" + strToity + "' and FlightDestinationTo ='" + strFromCity + "' " +
                " and FlightDate between '" + d1 + "' and  '" + d2 + "' order by FlightDepartureTime ";

            DataSet ds_r = new DataSet();
            ds_r = objdb.GetDataset(strqr_r, "return");

            ViewState["ds_r"] = ds_r;


        }




        //check the dataset value

        GridView1.DataSource = ds_d;
        GridView1.DataMember = "departure";
        GridView1.DataBind();

    }
    protected void DdlAdults_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //go back to search 
        Response.Redirect("default.aspx");
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //format grid view display flight data
        if (e.Row.RowIndex >= 0)
        {
            DateTime strDate = Convert.ToDateTime(e.Row.Cells[1].Text);
            e.Row.Cells[1].Text = strDate.ToString("dd-MMM-yy");

            strDate = Convert.ToDateTime(e.Row.Cells[4].Text);
            e.Row.Cells[4].Text = strDate.ToString("hh:mm");

            strDate = Convert.ToDateTime(e.Row.Cells[5].Text);
            e.Row.Cells[5].Text = strDate.ToString("hh:mm");

            e.Row.Cells[6].Text = "<a href='bookflight.aspx?id=" + e.Row.Cells[0].Text + "&mode=economy'><u><font color='red'>" + e.Row.Cells[6].Text + "</font></u></a>";
            e.Row.Cells[7].Text = "<a href='bookflight.aspx?id=" + e.Row.Cells[0].Text + "&mode=business'><u><font color='red'>" + e.Row.Cells[7].Text + "</font></u></a>";
        }
    }
}
