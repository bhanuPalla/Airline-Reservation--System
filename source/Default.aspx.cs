using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class _Default : System.Web.UI.Page 
{
    DatabaseLayer objdb = new DatabaseLayer();
    ValidationFunctions objfun = new ValidationFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {

        //fill drop down
        if (IsPostBack == false)
        {
            objdb.FillDropDownList(DdlFrom, "select CityCode, CityName from DestinationMaster where CityActive=1 order by CityName", "CityName", "CityCode");
            objdb.FillDropDownList(DdlTo, "select CityCode, CityName from DestinationMaster where CityActive=1 order by CityName", "CityName", "CityCode");


            //fill day of month
            objdb.FillDay(DdlDepartDay);
            objdb.FillDay(DdlReturnDay);

            //fill month and year
            objdb.FillMonthYear(DdlDepartMonthYear);
            objdb.FillMonthYear(DdlReturnMonthYear);

            //fill pasenger count
            DdlChild.Items.Add("");
            DdlInfants.Items.Add("");
            int i = 0;
            for (i = 1; i <= 5; i++)
            {
                DdlAdults.Items.Add(i.ToString());
                DdlChild.Items.Add(i.ToString());
                DdlInfants.Items.Add(i.ToString());
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //validation
        if (DdlFrom.SelectedItem.Text  == "--Select--")
        {
            lblmsg.Text = "Select from city.";
            return;
        }
        if (DdlTo.SelectedItem.Text == "--Select--")
        {
            lblmsg.Text = "Select to city.";
            return;
        }
        if (DdlFrom.SelectedItem.Text == DdlTo.SelectedItem.Text)
        {
            lblmsg.Text = "From city and to city must be different.";
            return;
        }
        int dtdif = 0;
        DateTime departdt, returndt;
        int p;
        int m;
        string[] a = new string[2];
        a=DdlDepartMonthYear.SelectedItem.Value.Split('-');

        departdt = Convert.ToDateTime(a[1] + "-" + a[0] + "-" + DdlDepartDay.SelectedItem.Value  );
        
        a=DdlReturnMonthYear.SelectedItem.Value.Split('-');
        returndt = Convert.ToDateTime(a[1] + "-" + a[0] + "-" + DdlDepartDay.SelectedItem.Value);

        //journey date must be greater than system date
        System.TimeSpan diffResult = departdt.Subtract(DateTime.Now);
        dtdif = diffResult.Days;
        if (dtdif < 0)
        {
            lblmsg.Text = "Journey date can not be less than system date.";
            return;
        }
        if (RdReturn.Checked == true)
        {
            diffResult = returndt.Subtract(departdt);
            dtdif = diffResult.Days;
            if (dtdif < 0)
            {
                lblmsg.Text = "Return date can not less than journey date.";
                return;
            }

        }
        

        //store user search critria in session for further use
        if (RdOneWay.Checked == true)
        {
            Session["journeytype"] = "One Way";
        }
        else
        {
            Session["journeytype"] = "Round Trip";
        }

        Session["from"] = DdlFrom.SelectedItem.Value;
        Session["to"] = DdlTo.SelectedItem.Value;
        Session["depart"] = departdt.ToString("dd-MMM-yyyy");
        Session["return"] = returndt.ToString("dd-MMM-yyyy");
        Session["adult"] = DdlAdults.Text;
        Session["child"] = DdlChild.Text;
        Session["infant"] = DdlInfants.Text;



        Response.Redirect("flightoptions.aspx");

    }


    protected void RdOneWay_CheckedChanged(object sender, EventArgs e)
    {
        if (RdOneWay.Checked == true)
        {
            
            DdlReturnDay.Enabled = false;
            DdlReturnMonthYear.Enabled = false;

        }
        else
        {
            DdlReturnDay.Enabled = true;
            DdlReturnMonthYear.Enabled = true;
        }
    }
}
