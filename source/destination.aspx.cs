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

public partial class destination : System.Web.UI.Page
{
    DatabaseLayer objDb = new DatabaseLayer();
    ValidationFunctions objvVal = new ValidationFunctions();

    protected void Page_Load(object sender, EventArgs e)
    {
        //this page for adminsitrator
        //check admin login, if user is not admin or session is expair, redirect to admin login page
        if (Session["AdminLogin"] == null)
        {
            Session["admin_ret_url"] = "destination.aspx";
            Response.Redirect("adminlogin.aspx");
            return;
        }
        if (Page.IsPostBack == false)
        {

            //fill destination details in grid

            string SqlStr;
            SqlStr = "select * from DestinationMaster order by CityCode ";

            DataSet ds = new DataSet();
            ds=objDb.GetDataset(SqlStr,"dest");


            ViewState["v_table"] = ds;
            Dg1.DataSource = ViewState["v_table"];
            Dg1.DataBind();

            TxtCityCode.Text = "";
            TxtCityName.Text = "";
            ChkActive.Checked = false;


            if (Request.QueryString.Count > 0)
            {
                string qid;
                qid = Request.QueryString["id"].ToString();

                string SqlStr1;
                SqlStr1 = "select * from DestinationMaster where CityCode ='" + qid + "'";

 

                ds = new DataSet();
                ds = objDb.GetDataset(SqlStr, "dest");
                
                DataRow r;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // dispaly current destination
                    r = ds.Tables[0].Rows[0];

                    TxtCityCode.Text = Convert.ToString(r["citycode"]);
                    TxtCityName.Text = Convert.ToString(r["CityName"]);
                    if (Convert.ToString(r["CityActive"]) == "1")
                    {
                        ChkActive.Checked = true;
                    }
                    else
                    {
                        ChkActive.Checked = false;
                    }


                }

            }

        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        //clera the form for new destination
        TxtCityCode.Text = "";
        TxtCityName.Text = "";
        ChkActive.Checked = false;
    }
    protected void CmdUpdate_Click(object sender, EventArgs e)
    {

        //validate the data
        if (TxtCityCode.Text == "")
        {
            objvVal.CreateMessageAlert(this, "Enter city code.", "abc");
            return;
        }

        if (TxtCityName.Text == "")
        {
            objvVal.CreateMessageAlert(this, "Enter city name.", "abc");
            return;
        }


        //check city name already exists
        string str1 = "";
        str1 = "select isnull(count(*),0) from destinationmaster where citycode='" + TxtCityCode.Text + "'";
        string strr = objDb.ExecuteScaler(str1);

        string stract="0";
        if (ChkActive.Checked ==true )
        {
            stract="1";
        }

        //create insert and update query

        bool ch;
        string qr;
        if (strr == "0")
        {
            ch = true;
            qr = "insert into destinationmaster values('" + TxtCityCode.Text + "','" + TxtCityName.Text + "'," + stract + ") ";
        }
        else
        {
            ch = false;
            qr = "update destinationmaster set cityname='" + TxtCityName.Text + "', CityActive=" + stract + " where citycode = '" + TxtCityCode.Text + "'";

        }

        //execute the query to update / insert record
        strr = objDb.ExecuteInsertUpdate(qr);

        Response.Redirect("destination.aspx");


    }

    protected void Dg1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Dg1.DataSource = ViewState["v_table"];
        Dg1.PageIndex = e.NewPageIndex;
        Dg1.DataBind();
    }
    protected void Dg1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //create hyper link for display and edit record

        if (e.Row.RowIndex < 0)
        {
            return;
        }
        string s1 = "";// e.Row.Cells[0].Text;
        s1 = "<a href='destination.aspx?id=" + e.Row.Cells[0].Text + "'><font color='black'><u>" + e.Row.Cells[0].Text + "</u></font></a>";
        e.Row.Cells[0].Text = s1;
    }
}
