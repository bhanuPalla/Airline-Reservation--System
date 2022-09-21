<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="bookflight.aspx.cs" Inherits="bookflight" Title="Untitled Page" StylesheetTheme="SkinFile" %>

<%@ Register Src="uc/UcPasenger.ascx" TagName="UcPasenger" TagPrefix="uc1" %>
<%@ Reference Control="~/uc/UcPasenger.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <table id="table1" border="0" cellpadding="1" cellspacing="1" width="600">
        <tr>
            <td align="center" bgcolor="#1f2b53" colspan="5" height="25" style="border-top-width: 1px;
                border-left-width: 1px; border-bottom: 1px solid; border-right-width: 1px" valign="middle">
                <p align="left">
                    &nbsp;<span style="color: lightgrey"><strong><span style="color: white">Flight Itinerary
                        &nbsp;&nbsp;</span> </strong>&nbsp; </span></p>
            </td>
        </tr>

        <tr>
            <td align="left" style="width: 105px" valign="top">
                Origin</td>
            <td align="left" style="width: 108px" valign="top">
                <span id="sp_journeytype" runat ="server">Destination</span></td>
            <td align="left" style="width: 91px" valign="top">
                &nbsp;Flight No</td>
            <td align="left" style="width: 105px" valign="top">
                Departure Date</td>
            <td align="left" valign="top" width="125">
                &nbsp;Arival Time</td>
        </tr>
        <tr>
            <td align="left" style="width: 105px; height: 17px;" valign="top">
                <strong><span id="sp_origin" runat ="server" ></span> </strong></td>
            <td align="left" style="width: 108px; height: 17px;" valign="top">
             <strong><span id="sp_destination" runat ="server" ></span></strong></td>
            <td align="left" style="width: 91px; height: 17px;" valign="top">
                <strong><span id="sp_flight_no" runat ="server" ></span> </strong></td>
            <td align="left" style="width: 105px; height: 17px;" valign="top">
                <strong><span id="sp_departuredate" runat ="server"></span> </strong></td>
            <td align="left" valign="top" width="125" style="height: 17px">
                <strong><span id="sp_arrivaldate" runat ="server"/></strong></td>
        </tr>
        <tr>
            <td align="left" style="width: 105px; height: 17px" valign="top">
            </td>
            <td align="left" style="width: 108px; height: 17px" valign="top">
            </td>
            <td align="left" style="width: 91px; height: 17px" valign="top">
            </td>
            <td align="left" style="width: 105px; height: 17px" valign="top">
            </td>
            <td align="left" style="height: 17px" valign="top" width="125">
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 105px; height: 17px" valign="top">
                <strong>Passengers</strong></td>
            <td align="left" style="width: 108px; height: 17px" valign="top">
                <strong>Fare per Person</strong></td>
            <td align="left" style="width: 91px; height: 17px" valign="top">
                <strong>Fuel Surchage</strong></td>
            <td align="left" style="width: 105px; height: 17px" valign="top">
                <strong>Other Charges</strong></td>
            <td align="left" style="height: 17px" valign="top" width="125">
                <strong>Sub Total</strong></td>
        </tr>
        <span id="sp_fare_details" runat ="server"></span>
        <tr>
            <td align="left" style="width: 105px; height: 17px" valign="top">
            </td>
            <td align="left" style="width: 108px; height: 17px" valign="top">
            </td>
            <td align="left" style="width: 91px; height: 17px" valign="top">
            </td>
            <td align="left" style="width: 105px; height: 17px" valign="top">
                <strong>Total Price</strong></td>
            <td align="left" style="height: 17px" valign="top" width="125">
                <strong><span id="sp_total_price" runat ="server"  ></span></strong></td>
        </tr>
        <tr>
            <td align="left" bgcolor="#1f2b53" colspan="5" style="border-top-width: 1px;
                border-left-width: 1px; border-bottom: 1px solid; border-right-width: 1px; height: 25px;" valign="middle">
                &nbsp;<span style="color: white"><strong>Contact Information</strong></span></td>
        </tr>
        <tr>
            <td align="left" colspan="5"  valign="middle" style="height: 17px">
                <div style="text-align: left">
                    <table border="0" cellpadding="1" cellspacing="1" style="width: 60%">
                        <tr>
                            <td style="width: 68px">
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 68px">
                                Mobile No</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="TxtMobile" runat="server"></asp:TextBox>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 68px">
                                Email ID</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="TxtEmailId" runat="server"></asp:TextBox></td>
                        </tr>
                    </table>
                </div>
                </td>
        </tr>
        <tr>
            <td align="left" bgcolor="#1f2b53" colspan="5" style="border-top-width: 1px;
                border-left-width: 1px; border-bottom: 1px solid; border-right-width: 1px; height: 25px;" valign="middle">
                &nbsp;<span style="color: white"><strong>Passenger Information</strong></span></td>
        </tr>
        <tr>
            <td align="left" colspan="5" valign="middle">
                
                <br />
                <asp:PlaceHolder ID="PlcPassenger" runat="server">
                
                  
                
                </asp:PlaceHolder>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="5" valign="middle">
                <asp:Button ID="BtnBack" runat="server"   Text="Back" Width="70px" />
                &nbsp;
                <asp:Button ID="BtnContinue" runat="server"   Text="Continue" Width="70px" OnClick="BtnContinue_Click" /></td>
        </tr>
        <tr>
            <td align="left" colspan="5" valign="middle">
            </td>
        </tr>
         <tr>
            <td align="left"  colspan="5" height="25"  valign="top">
                &nbsp;</td>
        </tr>

    </table>
    <br />
</asp:Content>


