<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDish.aspx.cs" Inherits="RestaurantSystem.OrderDish" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    &nbsp;&nbsp;
    
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Logout" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbl_number" runat="server" Text="table number"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt_number" runat="server"></asp:TextBox>
        <br />
    
        <table >
            <tr>
                <td  valign=top width=150px>
    
             <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1" Height="284px" Width="162px">
            <HeaderTemplate>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;品项类别
            </HeaderTemplate>
            <ItemTemplate>
                <br />
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("TYPE_ID") %>' 
                    Font-Names="Verdana"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" Font-Names="Verdana" 
                    onclick="LinkButton1_Click" Text='<%# Eval("TYPE_NAME") %>'></asp:LinkButton>
                &nbsp;&nbsp; &nbsp;
            </ItemTemplate>
        </asp:DataList>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="getAllType" TypeName="BLL.GetableBLL"></asp:ObjectDataSource>
    
                </td>
                <td  align=left class="style1" valign =top with=500px>
                    <asp:DataList ID="DataList2" runat="server" 
                        RepeatColumns="3" Width="928px" 
                        onselectedindexchanged="DataList2_SelectedIndexChanged">
                        <ItemTemplate>
                            <br />
                            <table>
                                <tr>
                                    <td >
                                        &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" Height="70px" 
                                            ImageUrl='<%# Eval("Menu_picture","~/images/{0}") %>' Width="86px" 
                                            CommandArgument='<%# Eval("Menu_name") %>' 
                                            CommandName="Eval(&quot;Menu_picture&quot;)" 
                                            onclick="ImageButton2_Click" />
                                        &nbsp;
                                    </td>
                                    <td >
                                        <asp:Label ID="Label6" runat="server" Text="菜品名称："></asp:Label>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Menu_name") %>'></asp:Label>
                                        <br />
                                        <br />
                                        <br />
                                        <asp:Label ID="Label5" runat="server" Text=" 价格："></asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Menu_price") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </ItemTemplate>
                    </asp:DataList>
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="lbl_page" runat="server" Font-Names="Verdana"></asp:Label>
                    &nbsp;
                    <asp:LinkButton ID="link_previous" runat="server" Font-Names="Verdana" 
                        onclick="link_previous_Click">previous</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="link_next" runat="server" Font-Names="Verdana" 
                        onclick="link_next_Click">next</asp:LinkButton>
                </td>
                <td valign =top >
                    <asp:DataList ID="DataList3" runat="server">
                        <HeaderTemplate>
                            <table style="width:100%;">
                                <tr>
                                    <td width = 40px>
                                        序号</td>
                                    <td width= 100px>
                                        菜名</td>
                                    <td width = 40px>
                                        价格</td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table style="width:100%;">
                                <tr>
                                    <td width =40px>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                    </td>
                                    <td width=100px>
                                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                                    </td>
                                    <td width=40px>
                                        <asp:Label ID="Label9" runat="server" Text='<%# Eval("price") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:LinkButton ID="link_up" runat="server" onclick="link_up_Click">up</asp:LinkButton>
&nbsp;&nbsp;
                    <asp:LinkButton ID="link_down" runat="server" onclick="link_down_Click">down
                    </asp:LinkButton>
                </td>
            </tr>
        </table>
        <br />
    
    </div>   </form>
</body>
</html>
