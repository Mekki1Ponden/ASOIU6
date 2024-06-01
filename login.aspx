<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication2.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <h2>Авторизация</h2>
    <p>
        <asp:Label ID="LoginLabel" runat="server" AssociatedControlID="LoginTextBox">Логин:</asp:Label>
        <asp:TextBox ID="LoginTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="PasswordTextBox">Пароль:</asp:Label>
        <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="LoginButton" runat="server" Text="Войти" OnClick="LoginButton_Click" />
        <asp:Button ID="RegisterButton" runat="server" Text="Зарегистрироваться" OnClick="RegisterButton_Click" />
    </p>
    <p>
        <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red"></asp:Label>
    </p>
</asp:Content>
