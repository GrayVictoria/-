<%@ Page Title="" Language="C#" MasterPageFile="~/Administrators.Master" AutoEventWireup="true" CodeBehind="Setting.aspx.cs" Inherits="教务选课系统.WEB.Administrators.Setting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <div>
                设置新学期----
                &nbsp年份：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                &nbsp&nbsp
                学期：
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="termmessage" DataTextField="termname" DataValueField="termname"></asp:DropDownList>
                <asp:SqlDataSource ID="termmessage" runat="server" ConnectionString="<%$ ConnectionStrings:UniversityManageSystemConnectionString %>" SelectCommand="SELECT [termname] FROM [termmessage]"></asp:SqlDataSource>
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                <asp:Button ID="Button1" runat="server" Text="确定" OnClick="Button1_Click" />
            </div>
        </div>
        <div>

            <asp:Button ID="Button2" runat="server" Text="返回" OnClick="Button2_Click" />

        </div>
    </div>
</asp:Content>
