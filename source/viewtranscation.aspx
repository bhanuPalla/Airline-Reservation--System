<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewtranscation.aspx.cs" Inherits="viewtranscation" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="table1" border="0" cellpadding="1" cellspacing="1" width="600">
        <tr>
            <td align="left" bgcolor="#1f2b53" colspan="5" height="25" style="border-top-width: 1px;
                border-left-width: 1px; border-bottom: 1px solid; border-right-width: 1px" valign="middle">
                &nbsp;<span style="color: white"><strong>View transcation&nbsp; </strong></span></td>
        </tr>
        <tr>
            <td align="left" colspan="5" height="25" valign="top">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound"
                    Width="100%">
                    <HeaderStyle BackColor="AliceBlue" />
                </asp:GridView>

            </td>
        </tr>
    </table>
</asp:Content>

