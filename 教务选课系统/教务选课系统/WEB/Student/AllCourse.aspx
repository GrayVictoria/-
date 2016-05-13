<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="AllCourse.aspx.cs" Inherits="教务选课系统.WEB.Student.AllCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

    </div>
    <div>
        &nbsp&nbsp 课程性质： <%--通识，专业选修，专业必修，体育课，第二专业--%>
    <asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList>
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

                <asp:GridView ID="课程表" runat="server" Width="100%" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="课程编号"></asp:TemplateField>
                        <asp:TemplateField HeaderText="课程名称"></asp:TemplateField>
                        <asp:TemplateField HeaderText="教师"></asp:TemplateField>
                        <asp:TemplateField HeaderText="学分"></asp:TemplateField>
                        <asp:TemplateField HeaderText="选/退课程">
                            <ItemTemplate>
                                <asp:Button ID="Button1" runat="server" Text="选课" />
                                <asp:Button ID="Button2" runat="server" Text="退课" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="课程详情">
                            <ItemTemplate>
                                <asp:Button ID="Button3" runat="server" Text="详情" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

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
    