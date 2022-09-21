<%@ Page Language="C#" AutoEventWireup="true" CodeFile="printicket.aspx.cs" Inherits="printicket" StylesheetTheme="SkinFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Print eTicket</title>
    <link href="mykb.css" type ="text/css" rel="Stylesheet" />
</head>
<body style="background-color:White;">
    <form id="form1" runat="server">
    <div>
        <table id="table1" border="0" cellpadding="1" cellspacing="1" width="600"  bgcolor ="white">
            <tr>
                <td align="center" bgcolor="#1f2b53" colspan="5" height="25" style="border-top-width: 1px;
                    border-left-width: 1px; border-bottom: 1px solid; border-right-width: 1px" valign="middle">
                    <p align="left">
                        &nbsp;<span style="color: lightgrey"><strong><span style="color: white">ARS Flight Itinerary
                            &nbsp;&nbsp; Booking PRN No : <span id="sp_refno" runat ="server" ></span>  </span> </strong>&nbsp; </span>
                    </p>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 105px" valign="top">
                    Origin</td>
                <td align="left" style="width: 108px" valign="top">
                    <span id="sp_journeytype" runat="server">Destination</span></td>
                <td align="left" style="width: 91px" valign="top">
                    &nbsp;Flight No</td>
                <td align="left" style="width: 105px" valign="top">
                    Departure Date</td>
                <td align="left" valign="top" width="125">
                    &nbsp;Arival Time</td>
            </tr>
            <tr>
                <td align="left" style="width: 105px; height: 17px" valign="top">
                    <strong><span id="sp_origin" runat="server"></span></strong>
                </td>
                <td align="left" style="width: 108px; height: 17px" valign="top">
                    <strong><span id="sp_destination" runat="server"></span></strong>
                </td>
                <td align="left" style="width: 91px; height: 17px" valign="top">
                    <strong><span id="sp_flight_no" runat="server"></span></strong>
                </td>
                <td align="left" style="width: 105px; height: 17px" valign="top">
                    <strong><span id="sp_departuredate" runat="server"></span></strong>
                </td>
                <td align="left" style="height: 17px" valign="top" width="125">
                    <strong><span id="sp_arrivaldate" runat="server"></span></strong>
                </td>
            </tr>
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
                    <strong><span id="sp_total_price" runat="server"></span></strong>
                </td>
            </tr>
            <tr>
                <td align="left" bgcolor="#1f2b53" colspan="5" style="border-top-width: 1px; border-left-width: 1px;
                    border-bottom: 1px solid; height: 25px; border-right-width: 1px" valign="middle">
                    &nbsp;<span style="color: white"><strong>Passenger Information</strong></span></td>
            </tr>
            <tr>
                <td align="left" colspan="5" style="height: 17px" valign="middle">
                    <div style="text-align: left">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound"
                            Width="100%">
                            <HeaderStyle BackColor="AliceBlue" />
                        </asp:GridView>
                        &nbsp;</div>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="5" valign="middle">
                </td>
            </tr>
                        <tr>
                <td align="left" bgcolor="#1f2b53" colspan="5" style="border-top-width: 1px; border-left-width: 1px;
                    border-bottom: 1px solid; height: 25px; border-right-width: 1px" valign="middle">
                    &nbsp;<span style="color: white"><strong>Terms and Condition</strong></span></td>
            </tr>
            <tr>
                <td align="left" colspan="5" valign="middle">
                    . The card used to purchase the tickets will have to be produced at the time of
                    Check-in. . If the holder of the card is not the passenger, then the passenger should
                    posses: a. A photocopy of both sides of the card, which will have to be self attested
                    by the card holder authorising the use of the card for the purchase of the ticket.
                    For security reasons, please strike out the Card Verification Value (CVV) code on
                    the copy of your card. b. This photocopy should also contain the name of the passenger,
                    the date of journey and the sector on which the journey is made. The above document
                    MUST be produced at the time of check-in. If the passenger fails to comply with
                    these conditions, Jet Airways reserves the right to deny the passenger(s) from boarding.
                    The details mentioned above do not apply for Net Banking/ Cash Card. For International
                    travel, please ensure that the validity of your passport is as per the requirements
                    of the destination country. Due to Security reasons, liquids, aerosols and gels
                    (LAGs) in carry-on baggage are restricted to containers of 100ml each. At some airports,
                    duty-free LAGs may be purchased after screening checkpoints. At most airports, including
                    Indian airports, transit guests are not allowed to carry Duty-free LAGs purchased
                    on a previous sector in cabin baggage, these will be confiscated at the Security
                    Checkpoint. For carriage of arms, ammunition, prohibited, restricted articles, please
                    refer to our terms and conditions. Please keep your valuables in your hand baggage
                    for precaution measures.</td>
            </tr>
            <tr>
                <td align="left" colspan="5" valign="middle">
                    <asp:Button ID="BtnPrint" runat="server"   Text="Print" Width="70px" />
                    &nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" colspan="5" valign="middle">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
