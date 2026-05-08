<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task2.aspx.cs" Inherits="Lab7.Task2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       
            <div>
    <h3>Завдання 2: Реєстрація та Авторизація</h3>
    Анкетні дані (ПІБ): <br />
    <asp:TextBox ID="txtUserData" runat="server" Width="200px"></asp:TextBox>
    <br />
    Логін: <br />
    <asp:TextBox ID="txtLogin" runat="server" Width="200px"></asp:TextBox>
    <br />
    Пароль: <br />
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
    <br /><br />
    <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Увійти та зареєструвати дані" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server" Font-Bold="True"></asp:Label>

        </div>
    </form>
</body>
</html>
