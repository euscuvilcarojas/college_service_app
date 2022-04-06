<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentRegistrations.aspx.cs" Inherits="BITCollegeSite.StudentRegistrations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="lblStudent" runat="server" Text="[StudentName]"></asp:Label>
        <asp:GridView ID="RegistrationGridView" runat="server" AllowSorting="True" AutoGenerateColumns="False" AutoGenerateSelectButton="True" CellPadding="8" ForeColor="#333333" GridLines="None" CellSpacing="15" OnSelectedIndexChanged="DataGridView_SelectedIndexChanged" BorderStyle="Solid" BorderWidth="5px" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Course.CourseNumber" HeaderText="Course">
                <HeaderStyle BorderWidth="2px" HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle Width="100px" BorderWidth="2px" HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="Course.Title" HeaderText="Title">
                <HeaderStyle BorderWidth="2px" HorizontalAlign="Left" VerticalAlign="Middle" Width="180px" />
                <ItemStyle Width="180px" BorderWidth="2px" HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="Course.CourseType" HeaderText="Course Type">
                <HeaderStyle BorderWidth="2px" HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle Width="100px" BorderWidth="2px" HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="Course.TuitionAmount" HeaderText="Tuition" DataFormatString="{0:C}">
                <HeaderStyle BorderWidth="2px" HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle Width="80px" BorderWidth="2px" HorizontalAlign="Right" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="Grade" HeaderText="Grade" DataFormatString="{0:P}">
                <HeaderStyle BorderWidth="2px" HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle Width="80px" BorderWidth="2px" HorizontalAlign="Right" VerticalAlign="Middle" />
                </asp:BoundField>
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
    </p>
    <p>
        <asp:Label ID="lblMessage" runat="server" Text="Messages"></asp:Label>
    </p>
    <p>
        <asp:LinkButton ID="linkBtnRegister" runat="server" OnClick="linkBtnRegister_Click">Register</asp:LinkButton>
    </p>
    <p>
        <asp:Label ID="lblException" runat="server" ForeColor="#FF5050" Text="Error/Message (Visible = true only when displaying an error)" Visible="False"></asp:Label>
    </p>
</asp:Content>
