<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher.Master" AutoEventWireup="true" CodeBehind="AllCourse.aspx.cs" Inherits="教务选课系统.WEB.Teacher.AllCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

    </div>
    <div>
        &nbsp&nbsp 课程学期： <%--第一学期，第二学期，第三学期--%>
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem></asp:ListItem>
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
    </asp:DropDownList>
        &nbsp&nbsp 课程性质： <%-- 8个专业--%>
    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="ObjectDataSource2" DataTextField="value" DataValueField="value" OnDataBound="DropDownList2_DataBound">
    </asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="searchvalue" TypeName="教务选课系统.BLL.B_CourseDetail"></asp:ObjectDataSource>
        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
        &nbsp&nbsp 课程编号：&nbsp
        <asp:TextBox ID="TextBox1" runat="server" Width="94px"></asp:TextBox>
        &nbsp&nbsp<asp:Button ID="Button4" runat="server" Text="确定" OnClick="Button4_Click" />
    <div>
        <div>
            <div>

                <asp:GridView ID="课程表" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
                    <Columns>
                        

                        <%-- <asp:TemplateField HeaderText="课程编号"></asp:TemplateField>
                        <asp:TemplateField HeaderText="课程名称"></asp:TemplateField>
                        <asp:TemplateField HeaderText="开设学院"></asp:TemplateField>
                        <asp:TemplateField HeaderText="教师"></asp:TemplateField>
                        <asp:TemplateField HeaderText="学分"></asp:TemplateField> --%>
                        <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" Visible="False" />
                        <asp:BoundField DataField="cnum" HeaderText="课程编号" SortExpression="cnum" />
                        <asp:BoundField DataField="cname" HeaderText="课程名称" SortExpression="cname" />
                        <asp:BoundField DataField="cmajor.mname" HeaderText="开设学院" SortExpression="cmajor" />
                        <asp:BoundField DataField="cteacher" HeaderText="教师" SortExpression="cteacher" />
                        <asp:BoundField DataField="ccredit" HeaderText="学分" SortExpression="ccredit" />
                        

                        <asp:BoundField DataField="cmajor.mname" HeaderText="开课专业" SortExpression="cmajor" />
                        <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/WEB/Teacher/CourseDetail.aspx?id={0}" HeaderText="详情" Text="详情" />
                        <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/WEB/Teacher/StudentSheet.aspx?id={0}" HeaderText="选课名单" Text="选课名单" />
                    </Columns>
                </asp:GridView>

                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllCourseTeacher" TypeName="教务选课系统.BLL.B_CourseDetail">
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="2015" Name="year" SessionField="Year" Type="Int32" />
                        <asp:ControlParameter ControlID="DropDownList1" Name="term" PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="DropDownList2" DefaultValue="" Name="value" PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="TextBox1" DefaultValue="" Name="cnum" PropertyName="Text" Type="String" />
                        <asp:SessionParameter DefaultValue="1853" Name="tnum" SessionField="UserName" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>

            </div>
        </div>
    </div>
        <div>
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            <asp:Button ID="Button5" runat="server" Text="查看本学期课程表" OnClick="Button5_Click" />
        </div>
        </div>
</asp:Content>
