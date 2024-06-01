<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="WebApplication2.Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Заказ представления</h2>
        <asp:Label ID="Label1" runat="server" Text="Выберите представление:"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Укажите количество билетов:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Забронировать" OnClick="Button1_Click" />
    </div>
</asp:Content>
