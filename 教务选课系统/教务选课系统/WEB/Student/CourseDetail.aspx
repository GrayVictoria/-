<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="CourseDetail.aspx.cs" Inherits="教务选课系统.WEB.Student.CourseDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <asp:ListView ID="ListView1" runat="server"></asp:ListView>
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="返回" />
        </div>
    </div>
</asp:Content>
