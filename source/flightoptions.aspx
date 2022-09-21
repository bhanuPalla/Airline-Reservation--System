<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="flightoptions.aspx.cs" Inherits="flightoptions" Title="Untitled Page" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <table id="table1" border="0" cellpadding="1" cellspacing="1" width="600">
        <tr>
            <td align="center" bgcolor="#1f2b53" colspan="5" height="25" style="border-top-width: 1px;
                border-left-width: 1px; border-bottom: 1px solid; border-right-width: 1px" valign="middle">
                <p align="left">
                    &nbsp;<span style="color: lightgrey"><strong><span style="color: white">Search Critaria</span>
                        &nbsp;
                <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="Modify Search" /></strong></span></p>
            </td>
        </tr>

        <tr>
            <td align="left" style="width: 105px" valign="top">
                Journey Type :</td>
            <td align="left" style="width: 108px" valign="top">
                <span id="sp_journeytype" runat ="server"></span>  </td>
            <td align="left" style="width: 91px" valign="top">
                &nbsp;</td>
            <td align="left" style="width: 105px" valign="top">
            </td>
            <td align="left" valign="top" width="125">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" style="width: 105px" valign="top">
                From :</td>
            <td align="left" style="width: 108px" valign="top">
                <span id="sp_fromcity" runat ="server" ></span> </td>
            <td align="left" style="width: 91px" valign="top">
                Depart :</td>
            <td align="left" style="width: 105px" valign="top">
                <span id="sp_departuredate" runat ="server" ></span> </td>
            <td align="left" valign="top" width="125">
                </td>
        </tr>
        <tr>
            <td align="left" style="width: 105px; height: 15px" valign="top">
                To :</td>
            <td align="left" style="width: 108px; height: 15px" valign="top">
                <span id="sp_tocity" runat ="server" ></span> </td>
            <td align="left" style="width: 91px; height: 15px" valign="top">
                Return :</td>
            <td align="left" style="width: 105px; height: 15px" valign="top">
                <span id="sp_returndate" runat ="server" ></span> </td>
            <td align="left" style="height: 15px" valign="top" width="125">
                </td>
        </tr>
        <tr>
            <td align="left" style="width: 105px" valign="top">
                Adults :</td>
            <td align="left" style="width: 108px" valign="top">
                <span id="sp_adults" runat ="server" ></span> </td>
            <td align="left" style="width: 91px" valign="top">
                Child : <span id="sp_child" runat ="server" ></span></td>
            <td align="left" style="width: 105px" valign="top">
                &nbsp;Infants : <span id="sp_infants" runat ="server" ></span></td>
            <td align="left" valign="top" width="125">
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 105px" valign="top">
                &nbsp;</td>
            <td align="left" style="width: 108px" valign="top">
                &nbsp;</td>
            <td align="left" style="width: 91px" valign="top">
                &nbsp;</td>
            <td align="left" style="width: 105px" valign="top">
                &nbsp;</td>
            <td align="left" valign="top" width="125">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" bgcolor="#1f2b53" colspan="5" height="25" style="border-top-width: 1px;
                border-left-width: 1px; border-bottom: 1px solid; border-right-width: 1px" valign="middle">
                &nbsp;<span style="color: white"><strong>Select Flight</strong></span></td>
        </tr>
         <tr>
            <td align="left"  colspan="5" height="25"  valign="top">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" Width="100%">
                    <HeaderStyle BackColor="AliceBlue" />
                </asp:GridView>
                </td>
        </tr>

    </table>
    <br />
</asp:Content>

