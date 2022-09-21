<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword"
    MasterPageFile="~/MasterPage.master" StylesheetTheme="SkinFile" %>

<asp:Content ID="c3" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <center>
        <div id="div1" runat="server">
            &nbsp;<div>
                &nbsp;</div>
            <div>
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
                                    <tr style="color: #1f2b53">
                                        <td style="width: 68px">
                                            Old Password</td>
                                        <td style="width: 100px">
                                            <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtPassword" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr style="color: #1f2b53">
                                        <td style="width: 68px">
                                            New Password</td>
                                        <td style="width: 100px">
                                            <asp:TextBox ID="TxtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtNewPassword"
                                                ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr style="color: #1f2b53">
                                        <td style="width: 68px">
                                            Confirm Password</td>
                                        <td style="width: 100px">
                                            <asp:TextBox ID="TxtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtConfirmPassword"
                                                ErrorMessage="*"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TxtConfirmPassword"
                                                ControlToValidate="TxtNewPassword" ErrorMessage="Not Match"></asp:CompareValidator></td>
                                    </tr>
                                </table>
                            </div>
                            <strong><span style="color: #ffffff">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; </span></strong>
                            <asp:Label ID="lblmsg" runat="server" CssClass="MsgLabel"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" bgcolor="#1f2b53" colspan="5" style="border-top-width: 1px; border-left-width: 1px;
                            border-bottom: 1px solid; height: 25px; border-right-width: 1px" valign="middle">
                            &nbsp;<span style="color: white"><strong> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                <asp:Button ID="BtnSubmit" runat="server" OnClick="BtnLogin_Click" Text="Submit" />&nbsp;
                                <asp:Button ID="BtnBack" runat="server" CausesValidation="False" OnClick="BtnRegister_Click"
                                    Text="Back" /></strong></span></td>
                    </tr>
                </table>
            </div>

    </div> </center>
</asp:Content>
