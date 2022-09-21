<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="registration.aspx.cs" Inherits="registration" Title="Untitled Page" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <table id="Table2" border="0" cellpadding="1" cellspacing="1" width="600">
        <tr>
            <td align="left" bgcolor="#1f2b53" colspan="5" style="border-top-width: 1px; border-left-width: 1px;
                border-bottom: 1px solid; height: 25px; border-right-width: 1px" valign="middle">
                &nbsp;<span style="color: white"><strong>ARS Customer Registraion</strong></span></td>
        </tr>
        <tr>

            <td align="left" colspan="5" style="height: 17px" valign="middle">
                <div style="text-align: left">
                    <table border="0" cellpadding="1" cellspacing="1" style="width: 70%">
                        <tr>
                            <td style="width: 68px">
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 68px">
                                Email ID</td>
                            <td style="width: 130px">
                                <asp:TextBox ID="TxtEmailId" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtEmailId" ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Not Valid"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="TxtEmailId"></asp:RegularExpressionValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 68px">
                                Password</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="TxtPassword" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtPassword"
                                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 120px">
                                Confirm Password</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="TxtConfirmPassword" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtConfirmPassword"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TxtPassword"
                                    ControlToValidate="TxtConfirmPassword" ErrorMessage="Not Match"></asp:CompareValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 68px">
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 68px">
                                First Name</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="TxtFirstName" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtFirstName"
                                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 100px" >
                                Middle Name</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="TxtMiddleName" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtMiddleName"
                                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 68px">
                                Last Name</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="TxtLastName" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtLastName"
                                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 68px">
                                Address</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="TxtAddress" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtZipCode"
                                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 68px">
                                City</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="TxtCity" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TxtCity"
                                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 68px">
                                Zip Code</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="TxtZipCode" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TxtZipCode"
                                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr style="color: #1f2b53">
                            <td style="width: 68px">
                                Mobile No</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="TxtMobileNo" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TxtMobileNo"
                                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
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
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Button ID="BtnSubmit" runat="server" OnClick="BtnLogin_Click" Text="Submit" />&nbsp;
                    <asp:Button ID="BtnBack" runat="server" OnClick="BtnRegister_Click" Text="Back" CausesValidation="False" /></strong></span></td>
        </tr>
    </table>
</asp:Content>

