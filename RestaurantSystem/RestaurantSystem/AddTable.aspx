<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTable.aspx.cs" Inherits="RestaurantSystem.AddTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:581px;  margin-top:30px; height: 230px;" border="1"  font-family: Gisha;" 
             border="1px"  cellpadding=1px cellspacing=1px>
            <tr>
                <td  >
                    &nbsp;&nbsp; table： </td>
                <td  >
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="userName" runat="server"></asp:TextBox>
                        &nbsp;(please input&nbsp; 4 or 8)&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="userName" ErrorMessage="RequiredFieldValidator" 
                        Display="Dynamic" ForeColor="Red">name is 
                    not null</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                        runat="server" ControlToValidate="userName" 
                        ErrorMessage="RegularExpressionValidator" ValidationExpression="(4|8)" ForeColor="Red">please 
                    input 4 or 8</asp:RegularExpressionValidator>
                        </td>
            </tr>
            <tr>
                <td >
                   &nbsp;&nbsp; status：</td>
                <td >
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                        </td>
            </tr>
            <tr>
                <td colspan="2" >
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="subbtim" runat="server" Text=" submit" 
                        onclick="subbtim_Click" style="height: 26px" />
                    &nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="   exit   " 
                        ValidationGroup="1" Height="23px" Width="93px" />
                     &nbsp;&nbsp;
                    <asp:Button ID="console" runat="server" Text="  reset  " onclick="console_Click" 
                        ValidationGroup="1" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
