<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewDrop.aspx.cs" Inherits="BITCollegeSite.ViewDrop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    <br />
    <asp:DetailsView ID="courseDetailView" runat="server" AllowPaging="True" AutoGenerateRows="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" Height="50px" OnPageIndexChanging="courseDetailView_PageIndexChanging">
        <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <Fields>
            <asp:BoundField DataField="RegistrationNumber" HeaderText="Registration">
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="180px" Font-Bold="True" ForeColor="#6600CC" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="250px" />
            </asp:BoundField>
            <asp:BoundField DataField="Student.FullName" HeaderText="Student">
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="180px" Font-Bold="True" ForeColor="#6600CC" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="250px" />
            </asp:BoundField>
            <asp:BoundField DataField="Course.Title" HeaderText="Course">
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="180px" Font-Bold="True" ForeColor="#6600CC" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="250px" />
            </asp:BoundField>
            <asp:BoundField DataField="RegistrationDate" HeaderText="Date" DataFormatString="{0:d/M/yyyy}">
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="180px" Font-Bold="True" ForeColor="#6600CC" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="250px" />
            </asp:BoundField>
            <asp:BoundField DataField="Grade" HeaderText="Grade" DataFormatString="{0:P}">
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="180px" Font-Bold="True" ForeColor="#6600CC" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="250px" />
            </asp:BoundField>
        </Fields>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
    </asp:DetailsView>
</p>
<p>
</p>
<p>
    <asp:LinkButton ID="linkBtnDrop" runat="server" OnClick="linkBtnDrop_Click">Drop Course</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="linkBtnReturn" runat="server" OnClick="linkBtnReturn_Click">Return to Registration Listing</asp:LinkButton>
</p>
<p>
    <asp:Label ID="lblException" runat="server" Text="Error/Message (Visible = true only when displaying an error)" ForeColor="Red" Visible="False"></asp:Label>
</p>
<p>
</p>
</asp:Content>
