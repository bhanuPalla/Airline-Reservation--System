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

public partial class bookflight : System.Web.UI.Page
{
    DatabaseLayer objdb = new DatabaseLayer();
    ValidationFunctions objfun = new ValidationFunctions();

    //cretae control array for passenger details
    private ASP.uc_ucpasenger_ascx[] ucarray_adult;
    private ASP.uc_ucpasenger_ascx[] ucarray_child;
    private ASP.uc_ucpasenger_ascx[] ucarray_infant;


    private int totalAmt;
    protected void Page_Load(object sender, EventArgs e)
    {
        string fid = Request.QueryString["id"].ToString();
        string fmode = Request.QueryString["mode"].ToString();

        //check session and redirect user to re-login if session is expair
        if (Session["CustID"] == null)
        {
            Session["ReturnUrl"] = "bookflight.aspx?id=" + fid + "&mode=" + fmode;
            Response.Redirect("login.aspx");
            return;
        }

        TxtEmailId.Text = Convert.ToString(Session["CustEmailID"]);
        TxtMobile.Text = Convert.ToString(Session["CustMobile"]);


        //get data for selected flight
        string strqr = "select * from flightmaster where FlightNo='" + fid  + "'";
        DataSet ds = new DataSet();
        ds = objdb.GetDataset(strqr, "flight");

        //define array size for pasenger
        ucarray_adult = new ASP.uc_ucpasenger_ascx[10];
        ucarray_child = new ASP.uc_ucpasenger_ascx[5];
        ucarray_infant = new ASP.uc_ucpasenger_ascx[5];


        //get session value for no of passenger
        string d1, d2;
        string strFromCity, strToity, strJourneyType;
        int adult, child, infant;
        DateTime departdt, returndt, departtm, arivaltm;

        adult = Convert.ToInt16(Convert.ToString(Session["adult"]));
        if (Convert.ToString(Session["child"]) == "")
        {
            child = 0; 
        }
        else
        {
            child = Convert.ToInt16(Convert.ToString(Session["child"]));
        }
        if (Convert.ToString(Session["infant"]) == "")
        {
            infant = 0;
        }
        else
        {
            infant = Convert.ToInt16(Convert.ToString(Session["infant"]));
        }

        //get flight details
        strFromCity = Convert.ToString(Session["from"]);
        strToity = Convert.ToString(Session["to"]);
        strJourneyType = Convert.ToString(Session["journeytype"]);

        departdt = Convert.ToDateTime(Convert.ToString(Session["depart"]));
        returndt = Convert.ToDateTime(Convert.ToString(Session["return"]));
        departtm = Convert.ToDateTime(Convert.ToString(ds.Tables[0].Rows[0]["FlightDepartureTime"]));
        arivaltm = Convert.ToDateTime(Convert.ToString(ds.Tables[0].Rows[0]["FlightArivalTime"]));

        Session["departtm"] = departtm.ToString("hh:mm");
        Session["arivaltm"] = arivaltm.ToString("hh:mm");


        sp_origin.InnerHtml = strFromCity;
        sp_destination.InnerHtml = strToity;
        sp_departuredate.InnerHtml = departdt.ToString("dd-MMM-yy") + " " + departtm.ToString("hh:mm");
        sp_arrivaldate.InnerHtml = departdt.ToString("dd-MMM-yy") + " " + arivaltm.ToString("hh:mm");


        //display price for passenger and calculate total fare
        int  fare,f1,f2,f3,f4,t;
        fare = 0;
        f1 = 0;
        f2 = 0;
        f3 = 0;
        f4 = 0;
        t = 0;
        Session["mode"] = Request.QueryString["mode"];
        if (Request.QueryString["mode"]=="economy")
        {
            fare=Convert.ToInt32( ds.Tables[0].Rows[0]["FlightFareEconomy"]);
            Session["FlightFareEconomy"] = ds.Tables[0].Rows[0]["FlightFareEconomy"];
        }
        else
        {
            fare=Convert.ToInt32( ds.Tables[0].Rows[0]["FlightFareBusiness"]);
            Session["FlightFareBusiness"] = ds.Tables[0].Rows[0]["FlightFareBusiness"];
        }
        string strrow = "";
        int i;

        //display rows for adult passengers
        if (adult > 0)
        {
            strrow=strrow+ "<tr>";
            strrow=strrow+ "<td align='left' style='width: 105px; height: 17px' valign='top'>";
            strrow=strrow+ adult.ToString() + " Adult</td>";
            strrow=strrow+ "<td align='left' style='width: 108px; height: 17px' valign='top'>";
            f1=fare*adult;
            strrow=strrow+ f1.ToString() + "</td>";
            strrow=strrow+ "<td align='left' style='width: 91px; height: 17px' valign='top'>";
            f2=500*adult;
            strrow=strrow+ f2.ToString() + "</td>";
            strrow=strrow+ "<td align='left' style='width: 105px; height: 17px' valign='top'>";
            f3=Convert.ToInt32( fare*0.01*adult);
            strrow=strrow+ f3.ToString() + "</td>";
            f4=f1+f2+f3;
            t=t+f4;
            strrow=strrow+ "<td align='left' style='height: 17px' valign='top' width='125'>";
            strrow=strrow+ f4.ToString() + "</td>";
            strrow = strrow + "</tr>";

            for (i=0;i<=adult-1 ;i++)
            {

                ucarray_adult[i] = (ASP.uc_ucpasenger_ascx)LoadControl("~/uc/UcPasenger.ascx");
                PlcPassenger.Controls.Add(ucarray_adult[i]);
                ucarray_adult[i].PassengerType = "adult";
                
                
                ucarray_adult[i].PassengerID =Convert.ToString( i+1);
                
            }

        }
        f1 = 0;
        f2 = 0;
        f3 = 0;
        f4 = 0;

        //display rows for child passengers
        if (child > 0)
        {
            strrow = strrow + "<tr>";
            strrow = strrow + "<td align='left' style='width: 105px; height: 17px' valign='top'>";
            strrow = strrow + child.ToString() + " Child</td>";
            strrow = strrow + "<td align='left' style='width: 108px; height: 17px' valign='top'>";
            f1 = fare * child;
            strrow = strrow + f1.ToString() + "</td>";
            strrow = strrow + "<td align='left' style='width: 91px; height: 17px' valign='top'>";
            f2 = 500 * child;
            strrow = strrow + f2.ToString() + "</td>";
            strrow = strrow + "<td align='left' style='width: 105px; height: 17px' valign='top'>";
            f3 = Convert.ToInt32(fare * 0.01 * child);
            strrow = strrow + f3.ToString() + "</td>";
            f4 = f1 + f2 + f3;
            t = t + f4;
            strrow = strrow + "<td align='left' style='height: 17px' valign='top' width='125'>";
            strrow = strrow + f4.ToString() + "</td>";
            strrow = strrow + "</tr>";

            for (i = 0; i <= child-1; i++)
            {

                ucarray_child[i] = (ASP.uc_ucpasenger_ascx)LoadControl("~/uc/UcPasenger.ascx");
                PlcPassenger.Controls.Add(ucarray_child[i]);
                ucarray_child[i].PassengerID = Convert.ToString(i + 1);
                
            }

        }

        f1 = 0;
        f2 = 0;
        f3 = 0;
        f4 = 0;

        //display rows for infant passengers
        if (infant > 0)
        {
            strrow = strrow + "<tr>";
            strrow = strrow + "<td align='left' style='width: 105px; height: 17px' valign='top'>";
            strrow = strrow + infant.ToString() + " Infant</td>";
            strrow = strrow + "<td align='left' style='width: 108px; height: 17px' valign='top'>";
            f1 = fare * infant;
            strrow = strrow + f1.ToString() + "</td>";
            strrow = strrow + "<td align='left' style='width: 91px; height: 17px' valign='top'>";
            f2 = 500 * infant;
            strrow = strrow + f2.ToString() + "</td>";
            strrow = strrow + "<td align='left' style='width: 105px; height: 17px' valign='top'>";
            f3 = Convert.ToInt32(fare * 0.01 * infant);
            strrow = strrow + f3.ToString() + "</td>";
            f4 = f1 + f2 + f3;
            t = t + f4;
            strrow = strrow + "<td align='left' style='height: 17px' valign='top' width='125'>";
            strrow = strrow + f4.ToString() + "</td>";
            strrow = strrow + "</tr>";

            for (i = 0; i <= infant-1; i++)
            {

                ucarray_infant[i] = (ASP.uc_ucpasenger_ascx)LoadControl("~/uc/UcPasenger.ascx");
                PlcPassenger.Controls.Add(ucarray_infant[i]);
                ucarray_infant[i].PassengerID = Convert.ToString(i + 1);
            }

        }

        sp_fare_details.InnerHtml = strrow;

        totalAmt = t;
        sp_total_price.InnerHtml  = t.ToString();


    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        //string fn;
        //fn = ucpas1.FirstName;

        //Response.Write(ucarray[0].FirstName);
    }
    protected void BtnContinue_Click(object sender, EventArgs e)
    {
        //save data in temp table for reservation master and details

        //get temp session id
        string ranid = "";
        ranid = objdb.ExecuteScaler("select newid()");
        string str1 = "";
        str1 = "insert into TempReservationMaster values (1," + Session["CustId"] + "," + Request.QueryString["id"] + ",getdate()," + totalAmt.ToString() + ",'Confirm',null,'" + ranid + "') ";

        string strr = "";
        string str2 = "";
        strr = objdb.ExecuteInsertUpdate(str1);

        //insert details

        int adult, child, infant;
        adult = Convert.ToInt16(Convert.ToString(Session["adult"]));
        if (Convert.ToString(Session["child"]) == "")
        {
            child = 0;
        }
        else
        {
            child = Convert.ToInt16(Convert.ToString(Session["child"]));
        }
        if (Convert.ToString(Session["infant"]) == "")
        {
            infant = 0;
        }
        else
        {
            infant = Convert.ToInt16(Convert.ToString(Session["infant"]));
        }
        int i;
        if (adult > 0)
        {
            for (i = 0; i <= adult - 1; i++)
            {
                str2 = "insert into TempReservationDetails values (1,1,'" + ucarray_adult[i].FirstName + "','" + ucarray_adult[i].MiddleName + "','" + ucarray_adult[i].LastName + "','" + ucarray_adult[i].Gender + "'," + ucarray_adult[i].Age + ",'" + ranid + "') ";
                strr = objdb.ExecuteInsertUpdate(str2);
            }
        }
        if (child > 0)
        {
            for (i = 0; i <= child - 1; i++)
            {
                str2 = "insert into TempReservationDetails values (1,1,'" + ucarray_child[i].FirstName + "','" + ucarray_child[i].MiddleName + "','" + ucarray_child[i].LastName + "','" + ucarray_child[i].Gender + "'," + ucarray_child[i].Age + ",'" + ranid + "') ";
                strr = objdb.ExecuteInsertUpdate(str2);
            }
        }
        if (infant > 0)
        {
            for (i = 0; i <= infant - 1; i++)
            {
                str2 = "insert into TempReservationDetails values (1,1,'" + ucarray_infant[i].FirstName + "','" + ucarray_infant[i].MiddleName + "','" + ucarray_infant[i].LastName + "','" + ucarray_infant[i].Gender + "'," + ucarray_infant[i].Age + ",'" + ranid + "') ";
                strr = objdb.ExecuteInsertUpdate(str2);
            }
        }

        Response.Redirect("bookingconfirmation.aspx?id=" + ranid);
        


    }
}
