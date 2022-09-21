<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcPasenger.ascx.cs" Inherits="uc_UcPasenger" %>
<table border="0" cellpadding="1" cellspacing="1" style="width: 500px">
    <tr>
        <td style="width: 90px">
            <strong><span id="sp_passenger_type" runat ="server" ></span> &nbsp;Passenger </strong>
        </td>
        <td style="width: 350px">
            <strong><span id="sp_passenger" runat ="server" ></span></strong></td>
    </tr>
    <tr>
        <td >
            First Name</td>
        <td style="width: 350px">
            <asp:TextBox ID="TxtFirstName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtFirstName"
                ErrorMessage="Enter first name."></asp:RequiredFieldValidator></td>

    </tr>
    <tr>
        <td >
            Middle Name</td>
        <td style="width: 350px; ">
            <asp:TextBox ID="TxtMiddleName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtMiddleName"
                ErrorMessage="Enter middle name."></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td >
            Last Name</td>
        <td style="width: 350px">
            <asp:TextBox ID="TxtLastName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtLastName"
                ErrorMessage="Enter last  name."></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td >
            Gender</td>
        <td style="width: 350px">
            <asp:DropDownList ID="ddlGender" runat="server">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td >
            Age</td>
        <td style="width: 350px">
            <asp:TextBox ID="TxtAge" runat="server" Width="66px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtAge"
                ErrorMessage="Enter age"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td >
            &nbsp;</td>
        <td style="width: 350px">
            &nbsp;
        </td>
    </tr>
</table>
