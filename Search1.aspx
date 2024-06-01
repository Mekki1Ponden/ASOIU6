<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Search1.aspx.cs" Inherits="WebApplication2.Search1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label2" runat="server" Text="Выберите представление"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" AppendDataBoundItems="true" DataSourceID="SqlDataSource3" DataTextField="название" DataValueField="код_представления" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1">
        <asp:ListItem Selected="True" Value="0">Не выбрано</asp:ListItem>
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:theatre %>" SelectCommand="SELECT код_представления, название FROM представления"></asp:SqlDataSource>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="код_представления" DataSourceID="SqlDataSource4" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="код_представления" HeaderText="Код представления" ReadOnly="True" SortExpression="код_представления" Visible="False" />
            <asp:BoundField DataField="название" HeaderText="название представления" SortExpression="Название" />
            <asp:BoundField DataField="цена" HeaderText="Цена представления" SortExpression="цена" />

        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
    <br />
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:theatre %>" SelectCommand="SELECT код_представления, название, цена FROM представления WHERE (код_представления = @код_представления)">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="Код_представления" SessionField="IDT" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
