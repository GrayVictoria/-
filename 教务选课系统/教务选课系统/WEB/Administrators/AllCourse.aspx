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
        <asp:ListItem></asp:ListItem>
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
    </asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="searchvalue" TypeName="教务选课系统.BLL.B_CourseDetail"></asp:ObjectDataSource>
        &nbsp&nbsp 对应专业： <%-- 8个专业--%>
    <asp:DropDownList ID="DropDownList2" runat="server" OnDataBound="DropDownList2_DataBound" DataSourceID="ObjectDataSource3" DataTextField="mname" DataValueField="mname">
    </asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="searchmajor" TypeName="教务选课系统.BLL.B_CourseDetail"></asp:ObjectDataSource>
        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
        &nbsp&nbsp 课程编号：&nbsp
        <asp:TextBox ID="TextBox1" runat="server" Width="94px"></asp:TextBox>
        &nbsp&nbsp<asp:Button ID="Button4" runat="server" Text="确定" OnClick="Button4_Click" />
    <div>
        <div>
            <div>

                <asp:GridView ID="课程表" runat="server" Width="100%" AutoGenerateColumns="False"  DataSourceID="ObjectDataSource1">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="课程序列号" SortExpression="id" Visible="False" />
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
                        <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/WEB/Administrators/CourseDetail.aspx?id={0}" HeaderText="详情" Text="详情" />
                        <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/WEB/Administrators/StudentSheet.aspx?id={0}" HeaderText="选课名单" Text="选课名单" />
                    </Columns>
                </asp:GridView>

                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllCourseAdministrators" TypeName="教务选课系统.BLL.B_CourseDetail">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList1" Name="term" PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="DropDownList2" Name="major" PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="TextBox1" Name="cnum" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>

            </div>
        </div>
    </div>
        <div>
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            </div>
        </div>
</asp:Content>
