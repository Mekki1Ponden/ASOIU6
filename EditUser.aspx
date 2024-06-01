<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="WebApplication2.EditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Редактировать данные пользователя</h2>
    <div>
        <asp:Label ID="NameLabel" runat="server" Text="Имя:" AssociatedControlID="NameTextBox" />
        <asp:TextBox ID="NameTextBox" runat="server" />
    </div>
    <div>
        <asp:Label ID="EmailLabel" runat="server" Text="Электронная почта:" AssociatedControlID="EmailTextBox" />
        <asp:TextBox ID="EmailTextBox" runat="server" />
    </div>
    <div>
        <asp:Button ID="SaveButton" runat="server" Text="Сохранить" OnClick="SaveButton_Click" />
    </div>
</asp:Content>
