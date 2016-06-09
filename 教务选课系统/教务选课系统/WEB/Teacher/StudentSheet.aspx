<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher.Master" AutoEventWireup="true" CodeBehind="StudentSheet.aspx.cs" Inherits="教务选课系统.WEB.Teacher.StudentSheet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
    <div>
        <div>

            <div>

                <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" Height="69px" style="margin-left: 229px; margin-top: 46px" Width="411px">
                    <Columns>
                        <asp:BoundField DataField="M_Smessage.snum" HeaderText="学号" SortExpression="M_Smessage.snum" />
                        <asp:BoundField DataField="M_Smessage.sname" HeaderText="姓名" SortExpression="M_Smessage.sname" />
                        <asp:BoundField DataField="M_Smessage.sclass" HeaderText="班级" SortExpression="M_Smessage.sclass" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetChooseMessage" TypeName="教务选课系统.BLL.B_Teacher">
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="2015" Name="year" SessionField="Year" Type="Int32" />
                        <asp:SessionParameter DefaultValue="1" Name="term" SessionField="Term" Type="Int32" />
                        <asp:QueryStringParameter Name="cid" QueryStringField="id" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>

            </div>
        </div>
        <div>

            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="返回" />

        </div>
    </div>
    </div>
</asp:Content>
