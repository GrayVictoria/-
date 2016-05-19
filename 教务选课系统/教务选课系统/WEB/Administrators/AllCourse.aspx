<%@ Page Title="" Language="C#" MasterPageFile="~/Administrators.Master" AutoEventWireup="true" CodeBehind="AllCourse.aspx.cs" Inherits="教务选课系统.WEB.Administrators.AllCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Web/Administrators/Setting.aspx">设置学年学期</asp:HyperLink>

    </div>
    <div>
        &nbsp&nbsp 课程学期： <%--第一学期，第二学期，第三学期--%>
    <asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList>
        &nbsp&nbsp 对应专业： <%-- 8个专业--%>
    <asp:DropDownList ID="DropDownList2" runat="server">
    </asp:DropDownList>
        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
        &nbsp&nbsp 课程编号：&nbsp
        <asp:TextBox ID="TextBox1" runat="server" Width="94px"></asp:TextBox>
        &nbsp&nbsp<asp:Button ID="Button4" runat="server" Text="确定" />
    <div>
        <div>
            <div>

                <asp:GridView ID="课程表" runat="server" Width="100%" AutoGenerateColumns="False"  DataSourceID="ObjectDataSource1">
                    <Columns>
                        <asp:BoundField DataField="cnum" HeaderText="课程编号" SortExpression="cnum" />
                        <asp:BoundField DataField="cname" HeaderText="课程名称" SortExpression="cname" />
                        <asp:BoundField DataField="cmajor.mname" HeaderText="开设学院" SortExpression="cmajor" />
                        <asp:BoundField DataField="cteacher" HeaderText="教师" SortExpression="cteacher" />
                        <asp:BoundField DataField="ccredit" HeaderText="学分" SortExpression="ccredit" />
                        

                        <%--><asp:TemplateField HeaderText="课程编号"></asp:TemplateField>
                        <asp:TemplateField HeaderText="课程名称"></asp:TemplateField>
                        <asp:TemplateField HeaderText="开设学院"></asp:TemplateField>
                        <asp:TemplateField HeaderText="教师"></asp:TemplateField>
                        <asp:TemplateField HeaderText="学分"></asp:TemplateField>--%>
                        <asp:HyperLinkField DataNavigateUrlFields="cnum" DataNavigateUrlFormatString="~/WEB/Administrators/CourseDetail.aspx?cnum={0}" HeaderText="详情" Text="详情" />
                        <asp:HyperLinkField DataNavigateUrlFields="cnum" DataNavigateUrlFormatString="~/WEB/Administrators/StudentSheet.aspx?cnum={0}" HeaderText="选课名单" Text="选课名单" />
                    </Columns>
                </asp:GridView>

                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllCourse" TypeName="教务选课系统.BLL.B_CourseDetail"></asp:ObjectDataSource>

            </div>
        </div>
    </div>
        <div>
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            </div>
        </div>
</asp:Content>
