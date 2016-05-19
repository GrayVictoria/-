<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="AllCourse.aspx.cs" Inherits="教务选课系统.WEB.Student.AllCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div>

    </div>
    <div>
        &nbsp&nbsp 课程性质： <%--通识，专业选修，专业必修，体育课，第二专业--%>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="value" DataValueField="value"></asp:DropDownList>
          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UniversityManageSystemConnectionString %>" SelectCommand="SELECT [value] FROM [coursevalue]"></asp:SqlDataSource>
          &nbsp&nbsp 选课状态： <%-- 已选，未选--%>
    <asp:DropDownList ID="DropDownList2" runat="server">
    </asp:DropDownList>
        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
        &nbsp&nbsp 课程编号：&nbsp
        <asp:TextBox ID="TextBox1" runat="server" Width="94px"></asp:TextBox>
        &nbsp&nbsp<asp:Button ID="Button4" runat="server" Text="确定" />
    <div>
        <div>
            <div>

                <asp:GridView ID="课程表" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="cnum">
                    <Columns>
                        <asp:BoundField DataField="cnum" HeaderText="课程编号" SortExpression="cnum" />
                        <asp:BoundField DataField="cname" HeaderText="课程名称" SortExpression="cname" />
                        <asp:BoundField DataField="cteacher" HeaderText="教师" SortExpression="cteacher" />
                        <asp:BoundField DataField="ccredit" HeaderText="学分" SortExpression="ccredit" />
                        <asp:TemplateField HeaderText="选课退课">
                            <ItemTemplate>
                                <asp:Button ID="Button6" runat="server" Text="选课" />
                                <asp:Button ID="Button7" runat="server" Text="退课" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField DataNavigateUrlFields="cnum" DataNavigateUrlFormatString="~/WEB/Student/CourseDetail.aspx?cnum={0}" HeaderText="详情" Text="详情" />
                    </Columns>
                </asp:GridView>

                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllCourse" TypeName="教务选课系统.BLL.B_CourseDetail"></asp:ObjectDataSource>

            </div>
        </div>
    </div>
        <div>
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            <asp:Button ID="Button5" runat="server" Text="查看本学期课程表" />
        </div>
        </div>
</asp:Content>
    