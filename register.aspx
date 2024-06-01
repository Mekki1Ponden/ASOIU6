<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="WebApplication2.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>Регистрация</h2>
    <table>
        <tr>
            <td>Имя:</td>
            <td><asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox></td>
        </tr>
       
        <tr>
            <td>Электронная почта:</td>
            <td><asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Логин:</td>
            <td><asp:TextBox ID="TextBoxLogin" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Пароль:</td>
            <td><asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center;"><asp:Button ID="ButtonRegister" runat="server" Text="Зарегистрироваться" OnClick="ButtonRegister_Click" /></td>
        </tr>
    </table>
    <asp:Label ID="ErrorLabel" runat="server" Text="" CssClass="error-label"></asp:Label>
</asp:Content>
