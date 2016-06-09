<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="CourseDetail.aspx.cs" Inherits="教务选课系统.WEB.Student.CourseDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <asp:DetailsView ID="DetailsView1" runat="server" Height="350px" Width="607px" AutoGenerateRows="False" DataKeyNames="cnum" DataSourceID="ObjectDataSource1">
                <Fields>
                    <asp:BoundField DataField="cnum" HeaderText="课程编号" SortExpression="cnum" />
                    <asp:BoundField DataField="cname" HeaderText="课程名称" SortExpression="cname" />
                    <asp:BoundField DataField="cplace" HeaderText="上课地点" SortExpression="cplace" />
                    <asp:BoundField DataField="cteacher" HeaderText="上课教师" SortExpression="cteacher" />
                    <asp:BoundField DataField="ctime" HeaderText="上课时间" SortExpression="ctime" />
                    <asp:BoundField DataField="csemaster" HeaderText="上课学期" SortExpression="csemaster" />
                    <asp:BoundField DataField="cmajor.mname" HeaderText="开课学院" SortExpression="cmajor" />
                    <asp:BoundField DataField="cvalue.value" HeaderText="课程性质" SortExpression="cvalue" />
                    <asp:BoundField DataField="ccredit" HeaderText="学分" SortExpression="ccredit" />
                    <asp:BoundField DataField="cintroduction" HeaderText="课程简介" SortExpression="cintroduction" />
                    <asp:BoundField DataField="cyear" HeaderText="开课学年" SortExpression="cyear" />
                </Fields>
            </asp:DetailsView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="search" TypeName="教务选课系统.BLL.B_CourseDetail">
                <SelectParameters>
                    <asp:QueryStringParameter Name="id" QueryStringField="id" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="返回" />
        </div>
        <%--  <div>
            <asp:Button ID="Button1" runat="server" Text="返回" />
        </div>--%>
    </div>
</asp:Content>
