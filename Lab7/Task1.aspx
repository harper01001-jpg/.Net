<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task1.aspx.cs" Inherits="Lab7.Task1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           
    <h3>Завдання 1 (Варіант 6)</h3>
    Прізвище: <br />
    <asp:TextBox ID="txtSurname" runat="server" Width="200px"></asp:TextBox>
    <br />
    Ім'я: <br />
    <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
    <br />
    По-батькові: <br />
    <asp:TextBox ID="txtPatronymic" runat="server" Width="200px"></asp:TextBox>
    <br />
    Email: <br />
    <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
    <br /><br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Перевірити та обробити" />
    <br /><br />
    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>
</div>
        
    </form>
</body>
</html>
