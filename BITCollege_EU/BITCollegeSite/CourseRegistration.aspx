<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CourseRegistration.aspx.cs" Inherits="BITCollegeSite.CourseRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="lblStudent" runat="server" Text="[studentName]"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblCourseSelector" runat="server" Text="Course Selector:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlCourse" runat="server" Width="150px">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="lblNotes" runat="server" Text="Registration Notes:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNotes" runat="server" Width="220px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNotes" runat="server" ControlToValidate="txtNotes" Enabled="False" ErrorMessage="Registration Notes are required." Visible="False"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:LinkButton ID="lnkBtnRegister" runat="server" OnClick="lnkBtnRegister_Click">Register</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkBtnReturn" runat="server" OnClick="lnkBtnReturn_Click">Return to Registration Listing</asp:LinkButton>
    </p>
    <p>
        <asp:Label ID="lblException" runat="server" ForeColor="Red" Text="Error/Message (Visible = true only when displaying an error)" Visible="False"></asp:Label>
    </p>
</asp:Content>
