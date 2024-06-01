<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="WebApplication2.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Личный кабинет</h2>
    <p>Имя: <asp:Label ID="NameLabel" runat="server" /></p>
    <p>Электронная почта: <asp:Label ID="EmailLabel" runat="server" /></p>
    <h3>Мои заказы</h3>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="название" HeaderText="Название представления" />
            <asp:BoundField DataField="количество" HeaderText="Количество билетов" />
            <asp:BoundField DataField="дата" HeaderText="Дата заказа" DataFormatString="{0:dd.MM.yyyy}" />
        </Columns>
    </asp:GridView>
</asp:Content>
