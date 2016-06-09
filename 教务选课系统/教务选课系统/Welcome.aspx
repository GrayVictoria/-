<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="教务选课系统.Welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <div>

            登陆用户名：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

        </div>
        <div>

            登陆密码： <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

        </div>
        <div>

            <asp:Button ID="Button1" runat="server" Text="确定" OnClick="Button1_Click" Height="26px" />
            &nbsp&nbsp&nbsp&nbsp
            <asp:Button ID="Button2" runat="server" Text="取消" Height="26px" />

        </div>
    </div>
    </form>
</body>
</html>
