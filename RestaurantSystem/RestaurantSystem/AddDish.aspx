<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDish.aspx.cs" Inherits="RestaurantSystem.AddDish" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" Text="Logout" OnClick="Button1_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="table name"></asp:Label>
        :<asp:TextBox ID="txt_number" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="check" />
        <br />
        <br />
        <br />
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
        <asp:DataList ID="DataList2" runat="server" RepeatDirection="Horizontal">
            <ItemTemplate>
                <asp:ImageButton ID="ImageButton1" runat="server" Height="55px" ImageUrl='<%# Eval("Menu_picture","~/images/{0}") %>' Width="62px" OnClick="ImageButton1_Click" />
                &nbsp;<br />菜品名称：<asp:Label ID="Label2" runat="server" Text='<%# Eval("Menu_name") %>'></asp:Label>
                <br />
                价格&nbsp; ：<asp:Label ID="Label3" runat="server" Text='<%# Eval("Menu_price") %>'></asp:Label>
            </ItemTemplate>
        </asp:DataList>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="getAllType" TypeName="BLL.GetableBLL"></asp:ObjectDataSource>
    </div>
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
                                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("Menu_ID") %>'></asp:Label>
                                    </td>
                                    <td width=100px>
                                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("Menu_Name") %>'></asp:Label>
                                    </td>
                                    <td width=40px>
                                        <asp:Label ID="Label9" runat="server" Text='<%# Eval("Menu_Price") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
        <br />
        <asp:LinkButton ID="link_up" runat="server" onclick="link_up_Click">up</asp:LinkButton>
&nbsp;&nbsp;
                    <asp:LinkButton ID="link_down" runat="server" onclick="link_down_Click">down
                    </asp:LinkButton>
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
        <br />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
    </form>
</body>
</body>
</html>
