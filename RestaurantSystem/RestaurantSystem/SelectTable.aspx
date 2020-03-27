<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.Master" AutoEventWireup="true" CodeBehind="SelectTable.aspx.cs" Inherits="RestaurantSystem.SelectTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="please choose type:"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>8</asp:ListItem>
    </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label2" runat="server" Text="person:"></asp:Label>
    <asp:TextBox ID="txt_account" runat="server"></asp:TextBox>
    <br />
    <asp:DataList ID="DataList1" runat="server" RepeatColumns="9" RepeatDirection="Horizontal">
        <ItemTemplate>
            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Convert.ToInt32(Eval("Table_status")) ==2?true:false %>' Text='<%# Bind("Table_id") %>' />
        </ItemTemplate>
    </asp:DataList>
    <br />
    <asp:Label ID="label_Page" runat="server" Text="Page:"></asp:Label>
    <asp:LinkButton ID="link_previous" runat="server" OnClick="link_previous_Click">previous</asp:LinkButton>
&nbsp;&nbsp;
    <asp:LinkButton ID="link_next" runat="server" OnClick="link_next_Click">next</asp:LinkButton>
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="order table" />
&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Logout" />
    <br />
    <br />
</asp:Content>
