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

public partial class bookingconfirmation : System.Web.UI.Page
{
    DatabaseLayer objdb = new DatabaseLayer();
    ValidationFunctions objfun = new ValidationFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        //check session
        if (Session["CustID"] == null)
        {
            Session["ReturnUrl"] = "default.aspx";
            Response.Redirect("login.aspx");
            return;
        }



        if (Page.IsPostBack == true)
        {
            return;
        }
        //
        DataSet ds = new DataSet();


        //get session value

        

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


        strFromCity = Convert.ToString(Session["from"]);
        strToity = Convert.ToString(Session["to"]);
        strJourneyType = Convert.ToString(Session["journeytype"]);

        departdt = Convert.ToDateTime(Convert.ToString(Session["depart"]));
        returndt = Convert.ToDateTime(Convert.ToString(Session["return"]));
        departtm = Convert.ToDateTime(Convert.ToString(Session["departtm"]));
        arivaltm = Convert.ToDateTime(Convert.ToString(Session["arivaltm"]));



        sp_origin.InnerHtml = strFromCity;
        sp_destination.InnerHtml = strToity;
        sp_departuredate.InnerHtml = departdt.ToString("dd-MMM-yy") + " " + departtm.ToString("hh:mm");
        sp_arrivaldate.InnerHtml = departdt.ToString("dd-MMM-yy") + " " + arivaltm.ToString("hh:mm");


        //display price for passenger and calulate total fare
        int fare, f1, f2, f3, f4, t;
        fare = 0;
        f1 = 0;
        f2 = 0;
        f3 = 0;
        f4 = 0;
        t = 0;

        if (Convert.ToString(Session["mode"]) == "economy")
        {
            fare = Convert.ToInt32(Convert.ToString(Session["FlightFareEconomy"]));
        }
        else
        {
            fare = Convert.ToInt32(Convert.ToString(Session["FlightFareBusiness"]));
        }
        string strrow = "";
        int i;
        if (adult > 0)
        {
            strrow = strrow + "<tr>";
            strrow = strrow + "<td align='left' style='width: 105px; height: 17px' valign='top'>";
            strrow = strrow + adult.ToString() + " Adult</td>";
            strrow = strrow + "<td align='left' style='width: 108px; height: 17px' valign='top'>";
            f1 = fare * adult;
            strrow = strrow + f1.ToString() + "</td>";
            strrow = strrow + "<td align='left' style='width: 91px; height: 17px' valign='top'>";
            f2 = 500 * adult;
            strrow = strrow + f2.ToString() + "</td>";
            strrow = strrow + "<td align='left' style='width: 105px; height: 17px' valign='top'>";
            f3 = Convert.ToInt32(fare * 0.01 * adult);
            strrow = strrow + f3.ToString() + "</td>";
            f4 = f1 + f2 + f3;
            t = t + f4;
            strrow = strrow + "<td align='left' style='height: 17px' valign='top' width='125'>";
            strrow = strrow + f4.ToString() + "</td>";
            strrow = strrow + "</tr>";

            //for (i = 0; i <= adult - 1; i++)
            //{

            //    ucarray_adult[i] = (ASP.uc_ucpasenger_ascx)LoadControl("~/uc/UcPasenger.ascx");
            //    PlcPassenger.Controls.Add(ucarray_adult[i]);
            //    ucarray_adult[i].PassengerType = "adult";


            //    ucarray_adult[i].PassengerID = Convert.ToString(i + 1);

            //}

        }
        f1 = 0;
        f2 = 0;
        f3 = 0;
        f4 = 0;

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

            //for (i = 0; i <= child - 1; i++)
            //{

            //    ucarray_child[i] = (ASP.uc_ucpasenger_ascx)LoadControl("~/uc/UcPasenger.ascx");
            //    PlcPassenger.Controls.Add(ucarray_child[i]);

            //}

        }

        f1 = 0;
        f2 = 0;
        f3 = 0;
        f4 = 0;

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

            //for (i = 0; i <= infant - 1; i++)
            //{

            //    ucarray_infant[i] = (ASP.uc_ucpasenger_ascx)LoadControl("~/uc/UcPasenger.ascx");
            //    PlcPassenger.Controls.Add(ucarray_infant[i]);
            //}

        }

        sp_fare_details.InnerHtml = strrow;

        //totalAmt = t;
        sp_total_price.InnerHtml = t.ToString();

        TxtPayAmount.Text = t.ToString();

        //fill payment frop down
        DdlExpairyMonth.Items.Add("Jan");
        DdlExpairyMonth.Items.Add("Feb");
        DdlExpairyMonth.Items.Add("Mar");
        DdlExpairyMonth.Items.Add("Apr");
        DdlExpairyMonth.Items.Add("May");
        DdlExpairyMonth.Items.Add("Jun");
        DdlExpairyMonth.Items.Add("Jul");
        DdlExpairyMonth.Items.Add("Aug");
        DdlExpairyMonth.Items.Add("Sep");
        DdlExpairyMonth.Items.Add("Oct");
        DdlExpairyMonth.Items.Add("Nov");
        DdlExpairyMonth.Items.Add("Dec");


        int y;
        for (y = 2020; y <= 2030; y++)
        {
            DdlExpairyYear.Items.Add(y.ToString());
        }

    }
    protected void BtnContinue_Click(object sender, EventArgs e)
    {
        //validate the data
        if (TxtCardNo.Text.Length !=16)
        {
            objfun.CreateMessageAlert(this, "Invalid card no. card no must be 16 characters long", "123");
            return;
        }
        if (objfun.IsNumeric(TxtCardNo.Text) == false)
        {
            objfun.CreateMessageAlert(this, "Invalid card no. card no must be 16 digit numeric", "123");
            return;
        }
        if (TxtCVC.Text.Length != 3)
        {
            objfun.CreateMessageAlert(this, "Invalid CVC. CVC no must be 3 characters long", "123");
            return;
        }
        if (objfun.IsNumeric(TxtCVC.Text) == false)
        {
            objfun.CreateMessageAlert(this, "Invalid CVC no. it must be 3 digit numeric only", "123");
            return;
        }

        //update refrence no
        //insert into temp to main
        string str1 = "";
        string strrm,strrd = "";
        string strRef = "";
        str1 = "select isnull(max(payemntrtefno),0)+1 from reservationmaster";
        str1=objdb.ExecuteScaler (str1);
        strRef = str1;

        //insert main from temp
        str1 = "insert into reservationmaster (ResCustId,ResFlightId,ResDate,ResTotalAmount,ResStatus,ResRandom)  select ResCustId,ResFlightId,ResDate,ResTotalAmount,ResStatus,ResRandom  from tempreservationmaster where ResRandom='" + Request.QueryString["id"] + "'";
        strrm = objdb.ExecuteInsertUpdate(str1);

        string strrResID = objdb.ExecuteScaler("select ResId from reservationmaster where ResRandom='" + Request.QueryString["id"] + "'");

        //insert details table from temp
        str1 = "insert into reservationdetails (ResMasterId, ResDPassengerFirstName, ResDPassengerMiddleName, ResDPassengerLastName, ResDGender, ResDAge,ResRandom)  select " + strrResID + ", ResDPassengerFirstName, ResDPassengerMiddleName, ResDPassengerLastName, ResDGender, ResDAge, ResRandom  from tempreservationdetails where ResRandom='" + Request.QueryString["id"] + "'";
        strrd = objdb.ExecuteInsertUpdate(str1);

        //delete temp if success
        if ((strrm != "" || strrm != null) && ((strrd != "" || strrd != null)))
        {
            str1 = "delete from tempreservationmater where ResRandom=" + Request.QueryString["id"] + "'";
            strrm = objdb.ExecuteInsertUpdate(str1);

            str1 = "delete from tempreservationdetails where ResRandom=" + Request.QueryString["id"] + "'";
            strrm = objdb.ExecuteInsertUpdate(str1);

            objfun.CreateMessageAlert(this, "Booking is completed your booking ref no is " + strrResID, "123");
        }
        else
        {

        }

        


    }
    protected void BtnBack_Click(object sender, EventArgs e)
    {

    }
}
