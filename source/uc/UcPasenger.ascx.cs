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

public partial class uc_UcPasenger : System.Web.UI.UserControl
{
    private string v_passengerid;
    private string v_passengertype;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //property for First Name
    
    public string FirstName
    {

        get
        {
            return TxtFirstName.Text; 
        }
        set
        {
            TxtFirstName.Text = value; 

        }
    }
    //property for Middle Name
    public string MiddleName
    {
        get
        {
            return TxtMiddleName.Text;
        }
        set
        {
            TxtMiddleName.Text = value;

        }
    }
    //property for Last Name
    public string LastName
    {
        get
        {
            return TxtLastName.Text;
        }
        set
        {
            TxtLastName.Text = value;

        }
    }
    //property for Gender
    public string Gender
    {
        get
        {
            return ddlGender.Text;
        }
        set
        {
            ddlGender.Text = value;

        }
    }
    //property for Age
    public string Age
    {
        get
        {
            return TxtAge.Text;
        }
        set
        {
            TxtAge.Text = value;

        }
    }
    //property for Age
    public string PassengerID
    {
        get
        {
            return v_passengerid;
        }
        set
        {
            v_passengerid = value;
            if (v_passengerid == "1" && v_passengertype == "adult")
            {

                sp_passenger.InnerHtml = v_passengerid + ". Primary Passenger ";
                
            }
            else
            {
                sp_passenger.InnerHtml = v_passengerid + ". ";
                
            }
        }
    }

    //property for Age
    public string PassengerType
    {
        get
        {
            return v_passengertype;
        }
        set
        {
            v_passengertype = value;

            sp_passenger_type.InnerHtml = v_passengertype ;
            
        }
    }
}
