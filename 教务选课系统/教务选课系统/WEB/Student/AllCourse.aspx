<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="AllCourse.aspx.cs" Inherits="教务选课系统.WEB.Student.AllCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div>

    </div>
    <div>
        &nbsp&nbsp 课程性质： <%--通识，专业选修，专业必修，体育课，第二专业--%>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ObjectDataSource2" DataTextField="value" DataValueField="value" OnDataBound="DropDownList1_DataBound"></asp:DropDownList>
          <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="searchvalue" TypeName="教务选课系统.BLL.B_CourseDetail"></asp:ObjectDataSource>
          &nbsp;&nbsp;&nbsp; <%-- 已选，未选--%>
        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
        &nbsp&nbsp 课程编号：&nbsp
        <asp:TextBox ID="TextBox1" runat="server" Width="94px"></asp:TextBox>
        &nbsp&nbsp<asp:Button ID="Button4" runat="server" Text="确定" OnClick="Button4_Click1" />
    <div>
        <div>
            <div>

                <asp:GridView ID="课程表" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" OnRowDeleting="课程表_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="课程编号" SortExpression="id" />
                        <asp:BoundField DataField="cname" HeaderText="课程名称" SortExpression="cname" />
                        <asp:BoundField DataField="cteacher" HeaderText="教师" SortExpression="cteacher" />
                        <asp:BoundField DataField="ccredit" HeaderText="学分" SortExpression="ccredit" />
                        <asp:TemplateField HeaderText="选课退课">
                            <ItemTemplate>
                                <asp:Button ID="Button6" runat="server" Text="选课" CommandName="Delete" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/WEB/Student/CourseDetail.aspx?id={0}" HeaderText="详情" Text="详情" />
                    </Columns>
                </asp:GridView>

                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllCourseStudent" TypeName="教务选课系统.BLL.B_CourseDetail" DeleteMethod="DoNothing">
                    <DeleteParameters>
                        <asp:Parameter Name="id" Type="String" />
                    </DeleteParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList1" Name="cvalue" PropertyName="SelectedValue" Type="String" />
                        <asp:Parameter DefaultValue="未选" Name="status" Type="String" />
                        <asp:ControlParameter ControlID="TextBox1" Name="cnum" PropertyName="Text" Type="String" />
                        <asp:SessionParameter DefaultValue="1000" Name="year" SessionField="Year" Type="Int32" />
                        <asp:SessionParameter DefaultValue="0" Name="term" SessionField="Term" Type="Int32" />
                        <asp:SessionParameter DefaultValue="2013014100" Name="snum" SessionField="UserName" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>

            </div>
            
        </div>
        <div>
             &nbsp&nbsp 课程性质： <%--通识，专业选修，专业必修，体育课，第二专业--%>
        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="ObjectDataSource4" DataTextField="value" DataValueField="value" OnDataBound="DropDownList2_DataBound"></asp:DropDownList>
          <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="searchvalue" TypeName="教务选课系统.BLL.B_CourseDetail"></asp:ObjectDataSource>
          &nbsp;&nbsp;&nbsp; <%-- 已选，未选--%>
        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
        &nbsp&nbsp 课程编号：&nbsp
        <asp:TextBox ID="TextBox2" runat="server" Width="94px"></asp:TextBox>
        &nbsp&nbsp<asp:Button ID="Button1" runat="server" Text="确定" OnClick="Button4_Click1" />
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="ObjectDataSource3" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="课程编号" SortExpression="id" />
                    <asp:BoundField DataField="cname" HeaderText="课程名称" SortExpression="cname" />
                    <asp:BoundField DataField="cteacher" HeaderText="教师" SortExpression="cteacher" />
                    <asp:BoundField DataField="ccredit" HeaderText="学分" SortExpression="ccredit" />
                    <asp:TemplateField HeaderText="退课" ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandName="Delete" Text="退课" OnClick="Page_Load" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="CourseDetail.aspx?id={0}" HeaderText="详情" Text="详情" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetAllCourseStudent" TypeName="教务选课系统.BLL.B_CourseDetail" DeleteMethod="DoNothing">
                <DeleteParameters>
                    <asp:Parameter Name="id" Type="String" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList2" Name="cvalue" PropertyName="SelectedValue" Type="String" />
                    <asp:Parameter DefaultValue="已选" Name="status" Type="String" />
                    <asp:ControlParameter ControlID="TextBox2" DefaultValue="" Name="cnum" PropertyName="Text" Type="String" />
                    <asp:SessionParameter Name="year" SessionField="Year" Type="Int32" />
                    <asp:SessionParameter Name="term" SessionField="Term" Type="Int32" />
                    <asp:SessionParameter Name="snum" SessionField="Username" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
        <div>
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            <asp:Button ID="Button5" runat="server" Text="查看本学期课程表" OnClick="Button5_Click1" />
        </div>
        </div>
</asp:Content>
    