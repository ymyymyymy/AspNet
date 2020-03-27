<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage3.Master" AutoEventWireup="true" CodeBehind="Chef.aspx.cs" Inherits="RestaurantSystem.Chef" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="Black" BorderStyle="Solid" BorderWidth="5px" CellPadding="2" CellSpacing="2" Height="131px" PageSize="5" Width="417px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Visible="False">
        <Columns>
            <asp:BoundField DataField="OrderID" HeaderText="OrderID" SortExpression="OrderID" Visible="true" />
            <asp:BoundField DataField="menu_id" HeaderText="MenuID" SortExpression="menu_id" />
            <asp:BoundField DataField="Menu_Name" HeaderText="MenuName" SortExpression="Menu_Name" />
            <asp:BoundField DataField="table_id" HeaderText="TableID" SortExpression="table_id" />
            <asp:BoundField DataField="OrderDetail_amount" HeaderText="DishAmount" SortExpression="OrderDetail_amount" />
            <asp:TemplateField HeaderText="OK or NO">
                <ItemTemplate>
                    <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" Text="Submit" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle Font-Names="新宋体" Font-Overline="True" Font-Size="Large" Font-Strikeout="False" />
    </asp:GridView>
    <asp:Button ID="btnSelect" runat="server" onclick="btnSelect_Click" 
                                            Text="Select" />
    <br />
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Timer ID="Timer1" runat="server" Interval="5000">
    </asp:Timer>
    <br />
    <asp:Label ID="lblOrderID" runat="server" Text="Order ID:"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="101px">
    </asp:DropDownList>
    <br />
    <asp:Label ID="lbl_page" runat="server"></asp:Label> &nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="link_previous" runat="server" onclick="link_previous_Click">previous</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="link_next" runat="server" onclick="link_next_Click">next</asp:LinkButton>
        
    <br />
    <br />
            
</asp:Content>
