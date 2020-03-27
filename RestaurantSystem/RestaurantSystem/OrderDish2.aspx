<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDish2.aspx.cs" Inherits="RestaurantSystem.OrderDish2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        菜品<asp:TextBox ID="TextBox1"  runat="server"></asp:TextBox>
        
        <br />
        
    </div>
    <asp:DataList ID="DataList1" runat="server">
        <ItemTemplate>
            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Type_ID") %>'></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("Type_Name") %>' 
                CommandArgument='<%# Eval("Type_ID") %>' onclick="LinkButton1_Click"></asp:LinkButton>
        </ItemTemplate>
        <HeaderTemplate>
            菜品类别
        </HeaderTemplate>
    </asp:DataList>
    <asp:DataList ID="DataList2" runat="server" RepeatColumns="3" 
        RepeatDirection="Horizontal">
        <ItemTemplate>
            &nbsp;
            <table style="width:100%;">
                <tr>
                    <td class="style1" rowspan="2">
                      
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="100px" 
                            CommandArgument='<%# Eval("Menu_id") %>' ImageUrl='<%# Eval("Menu_picture","~/images/{0}") %>' 
                            Width="100px" onclick="ImageButton1_Click" />   
                    </td>
                    <td>
                        &nbsp; 菜名&nbsp;&nbsp;
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Menu_name") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp; 价格&nbsp;&nbsp;
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Menu_price") %>'></asp:Label>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    </form>
</body>
</html>
