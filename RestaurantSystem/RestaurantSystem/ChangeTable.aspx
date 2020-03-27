<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.Master" AutoEventWireup="true" CodeBehind="ChangeTable.aspx.cs" Inherits="RestaurantSystem.ChangeOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="lbl_table" runat="server" Text="the original one"></asp:Label>
&nbsp;&nbsp;<asp:TextBox ID="txt_table" runat="server" Width="68px"></asp:TextBox>
&nbsp;
    <asp:Label ID="lbl_destination" runat="server" 
        Text="-----&gt;    the destination"></asp:Label>
&nbsp;<asp:TextBox ID="txt_destination" runat="server" Width="64px"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
    <br />
    <br />
    <asp:Label ID="lbl_person" runat="server" Text="person"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>8</asp:ListItem>
    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btn_submit" runat="server" Text="submit" 
        onclick="btn_submit_Click" />
    <br />
        <br />
        <br />
        <asp:DataList ID="DataList1" runat="server" 
    RepeatColumns="9" 
        RepeatDirection="Horizontal">
    <ItemTemplate>
        <asp:CheckBox ID="CheckBox1" runat="server" Text='<%# Bind("Table_id") %>'
                Checked='<%# Convert.ToInt32(Eval("Table_status")) ==2?true:false %>' />
        <br />
        <br />
    </ItemTemplate>
</asp:DataList>
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lbl_page" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="link_previous" runat="server" onclick="link_previous_Click">previous</asp:LinkButton>
&nbsp;&nbsp;
    <asp:LinkButton ID="link_next" runat="server" onclick="link_next_Click">next</asp:LinkButton>
    <br />

</asp:Content>
