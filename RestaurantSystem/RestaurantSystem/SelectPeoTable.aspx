<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectPeoTable.aspx.cs" Inherits="RestaurantSystem.SelectPeoTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        几人桌<asp:DropDownList ID="DropDownList1" runat="server" Width="99px" Height="22px" 
            AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem Value="8"></asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 几人<asp:TextBox ID="txt_person" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="提交" onclick="Button1_Click" />
        <br />
        <br />
    
        <asp:DataList ID="DataList1" runat="server" 
            RepeatDirection="Horizontal" RepeatColumns="9">
            <ItemTemplate>
                <asp:CheckBox ID="CheckBox1" runat="server" Text='<%# Eval("Table_id") %>' />
            </ItemTemplate>
        </asp:DataList>
    
  
    
        <br />
        <br />
    
  
    
    </div>
    <div>
    
    </div>
    </form>
</body>
</html>
