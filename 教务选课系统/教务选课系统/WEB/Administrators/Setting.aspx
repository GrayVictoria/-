<%@ Page Title="" Language="C#" MasterPageFile="~/Administrators.Master" AutoEventWireup="true" CodeBehind="Setting.aspx.cs" Inherits="教务选课系统.WEB.Administrators.Setting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <div>
                时间设置----
                &nbsp年份：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                &nbsp&nbsp
                学期：
                <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                <asp:Button ID="Button1" runat="server" Text="确定" />
            </div>
        </div>
        <div>

        </div>
    </div>
</asp:Content>
