using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    DatabaseLayer objdb = new DatabaseLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {



            if (IsPostBack == false)
            {
                if (Session["AdminLogin"] == "admin")
                {
                    sp_link.InnerHtml = "<a href='AdminChangePassword.aspx'><font color='white'>Change Password</font></a>&nbsp|&nbsp<a href='logout.aspx'><font color='white'>Logout</font></a>";

                    lblempname.Text = "Admin Login as : " + Session["CustName"].ToString().ToUpper();
                    //create menu for admin
                    CreateMenubar("2");
                }
                else
                {

                    if (Session["CustID"] == null)
                    {
                         
                        sp_link.InnerHtml = "<a href='login.aspx'><font color='white'>Login</font></a>&nbsp|&nbsp<a href='registration.aspx'><font color='white'>Rgister</font></a>";
                        lblempname.Text = "Welcome guest.";
                        //create menu for guest
                        CreateMenubar("0");
                    }
                    else
                    {
                        sp_link.InnerHtml = "<a href='ChangePassword.aspx'><font color='white'>Change Password</font></a>&nbsp|&nbsp<a href='logout.aspx'><font color='white'>Logout</font></a>";

                        lblempname.Text = "Login as : " + Session["CustName"].ToString().ToUpper();
                        //create menu for customer
                        CreateMenubar("1");
                    }
                }
               
                     
            }
        }
        catch (Exception ex) { }
    }

    private void CreateMenubar(string flag)
    {

        //create menu bar based on logged users
        string str1="";
        if (flag == "2")
        {

            str1 = str1 + "<table border='0' width='140' id='table1' cellspacing='1' cellpadding='1'>";
            str1 = str1 + "<tr>";
            str1 = str1 + "<td height='20' align='center' valign='top' background ='images/link_back.gif'><a href='adminDefault.aspx'>Home</a></td>";
            str1 = str1 + "</tr>";
            str1 = str1 + "<tr>";
            str1 = str1 + "<td height='20' align='center' valign='top' background ='images/link_back.gif'><a href='destination.aspx'>Destination Master</a></td>";
            str1 = str1 + "</tr>";
            str1 = str1 + "<tr>";
            str1 = str1 + "<td height='20' align='center' valign='top' background ='images/link_back.gif'><a href='flightmaster.aspx'>Flight Master</a></td>";
            str1 = str1 + "</tr>";
            str1 = str1 + "<tr>";
            str1 = str1 + "<td height='20' align='center' valign='top' background ='images/link_back.gif'><a href='viewtranscation.aspx'>View Transcation</a></td>";
            str1 = str1 + "</tr>";
            str1 = str1 + "</table>";
        }

    if(flag=="0")
    {

        str1=str1+ "<table border='0' width='140' id='table1' cellspacing='1' cellpadding='1'>";
        str1=str1+ "<tr>";
        str1=str1+ "<td height='20' align='center' valign='top' background ='images/link_back.gif'><a href='Default.aspx'>Home</a></td>";
        str1=str1+ "</tr>";
        str1=str1+ "<tr>";
        str1 = str1 + "<td height='20' align='center' valign='top' background ='images/link_back.gif'><a href='Default.aspx'>Search Flight</a></td>";
        str1=str1+ "</tr>";
        str1=str1+ "<tr>";
        str1 = str1 + "<td height='20' align='center' valign='top' background ='images/link_back.gif'><a href='aboutus.aspx'>About Us</a></td>";
        str1=str1+ "</tr>";
        str1=str1+ "<tr>";
        str1 = str1 + "<td height='20' align='center' valign='top' background ='images/link_back.gif'><a href='contactus.aspx'>Contact Us</a></td>";
        str1=str1+ "</tr>";
        str1 = str1 + "</table>";
    }
    if (flag == "1")
    {
        str1 = str1 + "<table border='0' width='140' id='table1' cellspacing='1' cellpadding='1'>";
        str1 = str1 + "<tr>";
        str1 = str1 + "<td height='20' align='center' valign='top' background ='images/link_back.gif'><a href='Default.aspx'>Home</a></td>";
        str1 = str1 + "</tr>";
        str1 = str1 + "<tr>";
        str1 = str1 + "<td height='20' align='center' valign='top' background ='images/link_back.gif'><a href='editprofile.aspx'>Edit Profile</a></td>";
        str1 = str1 + "</tr>";
        str1 = str1 + "<tr>";
        str1 = str1 + "<td height='20' align='center' valign='top' background ='images/link_back.gif'><a href='viewbooking.aspx'>View Booking</a></td>";
        str1 = str1 + "</tr>";
        str1 = str1 + "<tr>";
        str1 = str1 + "<td height='20' align='center' valign='top' background ='images/link_back.gif'><a href='ChangePassword.aspx'>Change Password</a></td>";
        str1 = str1 + "</tr>";
        str1 = str1 + "<tr>";
        str1 = str1 + "<td height='20' align='center' valign='top' background ='images/link_back.gif'><a href='logout.aspx'>Logout</a></td>";
        str1 = str1 + "</tr>";
        str1 = str1 + "<tr>";
        str1 = str1 + "<td height='20' align='center' valign='top' background ='images/link_back.gif'><a href='aboutus.aspx'>About Us</a></td>";
        str1 = str1 + "</tr>";
        str1 = str1 + "<tr>";
        str1 = str1 + "<td height='20' align='center' valign='top' background ='images/link_back.gif'><a href='contactus.aspx'>Contact Us</a></td>";
        str1 = str1 + "</tr>";
        str1 = str1 + "</table>";
    }

        sp_linktable.InnerHtml =str1;

        
    }

   
    
}
