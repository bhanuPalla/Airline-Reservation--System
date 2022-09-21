using System;
using System.Data;
using System.Data.SqlClient ;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class flightmaster : System.Web.UI.Page
{
    DatabaseLayer objDb = new DatabaseLayer();
    ValidationFunctions objvVal = new ValidationFunctions();

    protected void Page_Load(object sender, EventArgs e)
    {
        //flight details/schedule page .thsi data is used to search and book the flght
        //this page for admin, if admin session is exapir..redirect to re-login
        if (Session["AdminLogin"] == null)
        {
            Session["admin_ret_url"] = "flightmaster.aspx";
            Response.Redirect("adminlogin.aspx");
            return;
        }
        if (Page.IsPostBack == false)
        {




            //fill city 
            DataSet ds;
            string str1="";
            int i;
            str1="select CityCode from DestinationMaster where CityActive=1  order by CityCode  ";
            ds = new DataSet();
            ds = objDb.GetDataset(str1, "city");

            DdlDestinationFrom.Items.Add("");
            DdlDestinationTo.Items.Add("");

            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                DdlDestinationFrom.Items.Add(ds.Tables[0].Rows[i]["CityCode"].ToString());
                DdlDestinationTo.Items.Add(ds.Tables[0].Rows[i]["CityCode"].ToString());
            }

            //fill plane type
            str1 = "select AirpalneType from AirplaneMaster order by AirpalneType  ";
            ds = new DataSet();
            ds = objDb.GetDataset(str1, "air");

            DdlAirplane.Items.Add("");
            
            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                DdlAirplane.Items.Add(ds.Tables[0].Rows[i]["AirpalneType"].ToString());
                
            }


            //fill existing flights in grid
            string SqlStr;
            SqlStr = "select FlightNo, FlightDestinationFrom, FlightDestinationTo, FlightDate, FlightDepartureTime, FlightArivalTime from FlightMaster order by FlightNo ";

            ds = new DataSet();
            ds = objDb.GetDataset(SqlStr, "FlightMaster");

            ViewState["v_table"] = ds;
            Dg1.DataSource = ViewState["v_table"];
            Dg1.DataBind();

            //clear control

            TxtFlightNo.Text = "";
            TxtFlightDate.Text = "";
            TxtEconomySeat.Text = "";
            TxtEconomyFare.Text = "";
            TxtDuration.Text = "";
            TxtDepartureTime.Text = "";
            TxtBusinessSeat.Text = "";
            TxtBusinessFare.Text = "";
            TxtArivalTime.Text = "";

            DdlAirplane.Text ="";
            DdlDestinationFrom.Text ="";
            DdlDestinationTo.Text ="";


            if (Request.QueryString.Count > 0)
            {
                //if query string contain flight no, display details
                string qid;
                qid = Request.QueryString["id"].ToString();

                string SqlStr1;
                SqlStr1 = "select * from FlightMaster where flightno =" + qid;

                ds = new DataSet();
                ds = objDb.GetDataset(SqlStr1, "FlightMaster");
                

                DataRow r;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    r = ds.Tables[0].Rows[0];


                    TxtFlightNo.Text = Convert.ToString(r["flightno"]);
                    TxtFlightDate.Text = Convert.ToString(r["FlightDate"]);
                    TxtEconomySeat.Text = Convert.ToString(r["FlightEconomySeat"]);
                    TxtEconomyFare.Text = Convert.ToString(r["FlightFareEconomy"]);
                    TxtDuration.Text = Convert.ToString(r["FlightDuration"]);
                    TxtDepartureTime.Text = Convert.ToString(r["FlightDepartureTime"]);
                    TxtBusinessSeat.Text = Convert.ToString(r["FlightBusinessSeat"]);
                    TxtBusinessFare.Text = Convert.ToString(r["FlightFareBusiness"]);
                    TxtArivalTime.Text = Convert.ToString(r["FlightArivalTime"]);

                    DdlAirplane.Text = objDb.ExecuteScaler("select AirpalneType from AirplaneMaster where AirplaneID = " + Convert.ToString(r["FlightAirplaneID"]));
                    DdlDestinationFrom.Text = Convert.ToString(r["FlightDestinationFrom"]);
                    DdlDestinationTo.Text = Convert.ToString(r["FlightDestinationTo"]);


                }

            }

        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        //clear the form for new filgt details
        TxtFlightNo.Text = "";
        TxtFlightDate.Text = "";
        TxtEconomySeat.Text = "";
        TxtEconomyFare.Text = "";
        TxtDuration.Text = "";
        TxtDepartureTime.Text = "";
        TxtBusinessSeat.Text = "";
        TxtBusinessFare.Text = "";
        TxtArivalTime.Text = "";

        DdlAirplane.Text = "";
        DdlDestinationFrom.Text = "";
        DdlDestinationTo.Text = "";
    }
    protected void CmdUpdate_Click(object sender, EventArgs e)
    {
        if (Page.IsValid == false)
        {
            return;
        }

        if (DdlDestinationFrom.Text == "")
        {
            objvVal.CreateMessageAlert(this, "Select destination from city.", "abc");
            return;
        }

        if (DdlDestinationTo.Text == "")
        {
            objvVal.CreateMessageAlert(this, "Select destination to city.", "abc");
            return;
        }

        if (DdlAirplane.Text == "")
        {
            objvVal.CreateMessageAlert(this, "Select air plane.", "abc");
            return;
        }



        string stract = "";
        if (ChkActive.Checked == true)
        {
            stract = "1";
        }
        else
        {
            stract = "0";
        }

        bool ch;
        string qr;
        if (TxtFlightNo.Text == "")
        {
            ch = true;
            qr = " where 1=2 ";
        }
        else
        {
            ch = false;
            qr = " where flightno = " + TxtFlightNo.Text;

        }

        //open the sql connection, get connection from web config file
        string connectionInfo = ConfigurationManager.ConnectionStrings["strConString"].ToString();
        SqlConnection cn = new SqlConnection();
        cn.ConnectionString = connectionInfo;
        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }

        //get maximum flight no
        int lastid, air_id;
        SqlCommand com = new SqlCommand("select isnull(max(flightno),1) from flightmaster ", cn);
        lastid = int.Parse(com.ExecuteScalar().ToString()) + 1;

        com = new SqlCommand("select AirplaneID from AirplaneMaster where AirpalneType='" + DdlAirplane.Text + "'", cn);
        air_id = int.Parse(com.ExecuteScalar().ToString());


        SqlDataAdapter da = new SqlDataAdapter("select * from flightmaster " + qr, cn);
        SqlCommandBuilder cb = new SqlCommandBuilder(da);
        DataTable dt = new DataTable();
        da.Fill(dt);
        DataRow r;
        if (ch == true)
        {
            r = dt.NewRow();

            r["flightno"] = lastid;
            r["FlightDate"]=TxtFlightDate.Text ;
            r["FlightEconomySeat"]=TxtEconomySeat.Text  ;
            r["FlightFareEconomy"]=TxtEconomyFare.Text  ;
            r["FlightDuration"]=TxtDuration.Text;
            r["FlightDepartureTime"]=TxtDepartureTime.Text ;
            r["FlightBusinessSeat"]=TxtBusinessSeat.Text ;
            r["FlightFareBusiness"]=TxtBusinessFare.Text;
            r["FlightArivalTime"]=TxtArivalTime.Text;
            r["FlightAirplaneID"] = air_id;
            r["FlightDestinationFrom"]=DdlDestinationFrom.Text  ;
            r["FlightDestinationTo"]=DdlDestinationTo.Text  ;
            r["FlightActive"] = stract;

            dt.Rows.Add(r);
        }
        else
        {
            r = dt.Rows[0];
            r["FlightDate"] = TxtFlightDate.Text;
            r["FlightEconomySeat"] = TxtEconomySeat.Text;
            r["FlightFareEconomy"] = TxtEconomyFare.Text;
            r["FlightDuration"] = TxtDuration.Text;
            r["FlightDepartureTime"] = TxtDepartureTime.Text;
            r["FlightBusinessSeat"] = TxtBusinessSeat.Text;
            r["FlightFareBusiness"] = TxtBusinessFare.Text;
            r["FlightArivalTime"] = TxtArivalTime.Text;
            r["FlightAirplaneID"] = air_id;
            r["FlightDestinationFrom"] = DdlDestinationFrom.Text;
            r["FlightDestinationTo"] = DdlDestinationTo.Text;
            r["FlightActive"] = stract;
        }

        da.Update(dt);

        Response.Redirect("flightmaster.aspx");


    }

    protected void Dg1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Dg1.DataSource = ViewState["v_table"];
        Dg1.PageIndex = e.NewPageIndex;
        Dg1.DataBind();
    }
    protected void Dg1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex < 0)
        {
            return;
        }
        string s1 = "";// e.Row.Cells[0].Text;
        s1 = "<a href='flightmaster.aspx?id=" + e.Row.Cells[0].Text + "'><font color='black'><u>" + e.Row.Cells[0].Text + "</u></font></a>";
        e.Row.Cells[0].Text = s1;
    }
}
