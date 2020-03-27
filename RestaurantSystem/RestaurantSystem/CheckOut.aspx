<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.Master" AutoEventWireup="true" CodeBehind="CheckOut.aspx.cs" Inherits="RestaurantSystem.CheckOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="lbl_number" runat="server" Text="餐桌号："></asp:Label>
    <asp:TextBox ID="txt_number" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btn_search" runat="server" onclick="btn_search_Click" 
        Text="search" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btn_sum" runat="server" 
        onclick="btn_sum_Click" Text="total" />
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btn_submit" runat="server" Text="submit" 
        onclick="btn_submit_Click" />
    <br />
    <br />
    <br />
    <br />
                    <asp:DataList ID="DataList3" runat="server">
                        <HeaderTemplate>
                            <table style="width:100%;">
                                <tr>
                                    <td width = 150px>
                                        序号</td>
                                    <td width= 250px>
                                        菜名</td>
                                    <td width = 100px>
                                        价格</td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table style="width:100%;">
                                <tr>
                                    <td width =150px>
                                        <asp:Label ID="Label10" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                    </td>
                                    <td width=250px>
                                        <asp:Label ID="Label11" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                                    </td>
                                    <td width=100px>
                                        <asp:Label ID="Label12" runat="server" Text='<%# Eval("price") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
    <br />
    <br />
    <br />
    <asp:Label ID="lbl_total" runat="server">total</asp:Label>
    <br />
    <asp:Label ID="lbl_page" runat="server">page</asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="link_previous" runat="server" onclick="link_previous_Click">previous</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="link_next" runat="server" onclick="link_next_Click">next</asp:LinkButton>
    <br />

</asp:Content>
