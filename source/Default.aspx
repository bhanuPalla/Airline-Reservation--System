<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" MasterPageFile="~/MasterPage.master" StylesheetTheme="SkinFile" %>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <br />
    <asp:Label ID="lblmsg" runat="server" CssClass="MsgLabel"></asp:Label><br />

<table border="0" width="600" cellspacing="1" cellpadding="1" id="table1">
	<tr>
		<td align="center" valign="middle" colspan="5" style="border-left-width: 1px; border-right-width: 1px; border-top-width: 1px; border-bottom-style: solid; border-bottom-width: 1px" bgcolor="#1F2B53" height="25">
		<p align="left">&nbsp;<span style="color: white"><strong>Book your flight</strong></span></td>
	</tr>
	<tr>
		<td align="left" valign="top" style="width: 63px">&nbsp;</td>
		<td align="left" valign="top" style="width: 108px">
            <asp:RadioButton ID="RdOneWay" runat="server" Text="One Way" GroupName="journeytype" OnCheckedChanged="RdOneWay_CheckedChanged"  /></td>
		<td align="left" valign="top" style="width: 91px">&nbsp;<asp:RadioButton ID="RdReturn" runat="server" Text="Round Trip" Checked="True" GroupName="journeytype" /></td>
		<td align="left" valign="top" style="width: 105px"></td>
		<td align="left" valign="top" width="125">&nbsp;</td>
	</tr>
	<tr>

		<td align="left" valign="top" style="width: 63px">From</td>
		<td align="left" valign="top" style="width: 108px">
            <asp:DropDownList ID="DdlFrom" runat="server" Width="90px">
            </asp:DropDownList></td>
		<td align="left" valign="top" style="width: 91px">Depart</td>
		<td align="left" valign="top" style="width: 105px"><asp:DropDownList ID="DdlDepartDay" runat="server" Width="50px">
        </asp:DropDownList>&nbsp;</td>
		<td align="left" valign="top" width="125"><asp:DropDownList ID="DdlDepartMonthYear" runat="server" Width="90px">
        </asp:DropDownList></td>
	</tr>
	<tr>
		<td align="left" valign="top" style="height: 15px; width: 63px;">To</td>
		<td align="left" valign="top" style="height: 15px; width: 108px;"><asp:DropDownList ID="DdlTo" runat="server" Width="90px">
        </asp:DropDownList></td>
		<td align="left" valign="top" style="height: 15px; width: 91px;">Return</td>
		<td align="left" valign="top" style="height: 15px; width: 105px;"><asp:DropDownList ID="DdlReturnDay" runat="server" Width="50px">
        </asp:DropDownList></td>
		<td align="left" valign="top" width="125" style="height: 15px"><asp:DropDownList ID="DdlReturnMonthYear" runat="server" Width="90px">
        </asp:DropDownList></td>
	</tr>
	<tr>
		<td align="left" valign="top" style="width: 63px">Adults</td>
		<td align="left" valign="top" style="width: 108px"><asp:DropDownList ID="DdlAdults" runat="server" Width="50px">
        </asp:DropDownList></td>
		<td align="left" valign="top" style="width: 91px">
            Child :
            <asp:DropDownList ID="DdlChild" runat="server" Width="50px">
        </asp:DropDownList></td>
		<td align="left" valign="top" style="width: 105px">&nbsp;Infants
            <asp:DropDownList ID="DdlInfants" runat="server" Width="50px">
            </asp:DropDownList></td>
		<td align="left" valign="top" width="125">
            </td>
	</tr>
	<tr>
		<td align="left" valign="top" style="width: 63px">&nbsp;</td>
		<td align="left" valign="top" style="width: 108px">&nbsp;</td>
		<td align="left" valign="top" style="width: 91px">&nbsp;</td>
		<td align="left" valign="top" style="width: 105px">&nbsp;</td>
		<td align="left" valign="top" width="125">&nbsp;</td>
	</tr>
    <tr>
        		<td align="left" valign="middle" colspan="5" style="border-left-width: 1px; border-right-width: 1px; border-top-width: 1px; border-bottom-style: solid; border-bottom-width: 1px" bgcolor="#1F2B53" height="25">
		

            <asp:Button ID="Button1" runat="server" Text="Search Flight" OnClick="Button1_Click" /></td>
    </tr>
</table>


</asp:Content>