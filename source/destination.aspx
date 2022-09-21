<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="destination.aspx.cs" Inherits="destination" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="table1" border="0" cellpadding="2" cellspacing="2" style="width: 614px">
        <tr>
            <td align="left" colspan="3">
                <strong>Admin : Destination/ City &nbsp;Master</strong></td>
        </tr>
        <tr>
            <td align="left" colspan="3" style="height: 15px">
                <asp:GridView ID="Dg1" runat="server" AllowPaging="True" OnPageIndexChanging="Dg1_PageIndexChanging"
                    OnRowDataBound="Dg1_RowDataBound" PageSize="5" Width="586px">
                </asp:GridView>
                <br />
            </td>
        </tr>
        <tr>

            <td align="left" style="width: 161px; height: 15px">
                City Code:</td>
            <td align="left" style="width: 371px; height: 15px">
                &nbsp;<asp:TextBox ID="TxtCityCode" runat="server" BackColor="White" BorderStyle="Solid"
                    BorderWidth="1px" Font-Names="Verdana" Font-Size="XX-Small" MaxLength="50" Width="178px"></asp:TextBox></td>
            <td style="height: 15px" width="89">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" style="width: 161px">
                City Name:</td>
            <td align="left" style="width: 371px">
                &nbsp;<asp:TextBox ID="TxtCityName" runat="server" BackColor="White" BorderStyle="Solid"
                    BorderWidth="1px" Font-Names="Verdana" Font-Size="XX-Small" MaxLength="50" Width="178px"></asp:TextBox></td>
            <td width="89">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" style="width: 161px">
                Active</td>
            <td align="left" style="width: 371px">
                &nbsp;<asp:CheckBox ID="ChkActive" runat="server" /></td>
            <td width="89">
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 161px">
            </td>
            <td align="left" style="width: 371px">
            </td>
            <td width="89">
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 161px; height: 17px">
                &nbsp;</td>
            <td align="left" style="width: 371px; height: 17px">
                &nbsp;<asp:Button ID="CmdAddNew" runat="server" BackColor="#C0C0FF" BorderColor="#434367"
                    BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
                    ForeColor="White" OnClick="Button1_Click" Text="Add New" Width="91px" />&nbsp;
                <asp:Button ID="CmdUpdate" runat="server" BackColor="#C0C0FF" BorderColor="#434367"
                    BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
                    ForeColor="White" OnClick="CmdUpdate_Click" Text="Submit" Width="91px" /></td>
            <td style="height: 17px" width="89">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

