<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" Title="Untitled Page" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <table id="Table2" border="0" cellpadding="1" cellspacing="1" width="600">
        <tr>
            <td align="left" bgcolor="#1f2b53" colspan="5" style="border-top-width: 1px; border-left-width: 1px;
                border-bottom: 1px solid; height: 25px; border-right-width: 1px" valign="middle">
                &nbsp;<span style="color: white"><strong>Login to ARS</strong></span></td>
        </tr>

        <tr>
            <td align="left" colspan="5" style="height: 17px" valign="middle">
                <div style="text-align: left">
                    <table border="0" cellpadding="1" cellspacing="1" style="width: 60%">
                        <tr>
                            <td style="width: 68px">
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 68px; height: 22px;">
                                Email ID</td>
                            <td style="width: 100px; height: 22px;">
                                <asp:TextBox ID="TxtEmailId" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtEmailId"
                                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 68px">
                                Password</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtPassword"
                                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                </div>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                &nbsp;
                <asp:Label ID="lblmsg" runat="server" CssClass="MsgLabel"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" bgcolor="#1f2b53" colspan="5" style="border-top-width: 1px; border-left-width: 1px;
                border-bottom: 1px solid; height: 25px; border-right-width: 1px" valign="middle">
                &nbsp;<span style="color: white"><strong> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Button ID="BtnLogin" runat="server" OnClick="BtnLogin_Click" Text="Login" />&nbsp;
                    <asp:Button ID="BtnRegister" runat="server" OnClick="BtnRegister_Click" Text="Register" CausesValidation="False" /></strong></span></td>
        </tr>
    </table>
    <br />
    <br />
    <br />
</asp:Content>

