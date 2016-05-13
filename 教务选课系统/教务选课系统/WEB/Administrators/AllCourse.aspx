<%@ Page Title="" Language="C#" MasterPageFile="~/Administrators.Master" AutoEventWireup="true" CodeBehind="AllCourse.aspx.cs" Inherits="教务选课系统.WEB.Administrators.AllCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

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

                <asp:GridView ID="课程表" runat="server" Width="100%" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="课程编号"></asp:TemplateField>
                        <asp:TemplateField HeaderText="课程名称"></asp:TemplateField>
                        <asp:TemplateField HeaderText="开设学院"></asp:TemplateField>
                        <asp:TemplateField HeaderText="教师"></asp:TemplateField>
                        <asp:TemplateField HeaderText="学分"></asp:TemplateField>
                        <asp:TemplateField HeaderText="课程详情">
                            <ItemTemplate>
                                <asp:Button ID="Button3" runat="server" Text="详情" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="选课名单">
                            <ItemTemplate>
                                <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="选课名单" />
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
