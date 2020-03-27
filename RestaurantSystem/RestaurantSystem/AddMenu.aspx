<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMenu.aspx.cs" Inherits="RestaurantSystem.AddMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <div style="margin-top:80px; margin-left:300px">
  
    
         <table style="width:500px;  margin-top:30px; height: 280px; font-family: Gisha;" 
             border="1px"  cellpadding=1px cellspacing=1px>
            <tr>
                <td  >
                     &nbsp; &nbsp;name： </td>
                <td  >
                    &nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="userName" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="userName" ErrorMessage="RequiredFieldValidator" ForeColor="Red">name is 
                    not null</asp:RequiredFieldValidator>
                        </td>
            </tr>
            <tr>
                <td  >
                     &nbsp; &nbsp;Price：</td>
                <td  >
                         &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="menuPrice" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ErrorMessage="RequiredFieldValidator" ControlToValidate="menuPrice" ForeColor="#FF3300">price is not null</asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
            </tr>
            <tr>
                <td >
                     &nbsp; &nbsp;type：</td>
                <td >
                              &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="80px">
                    </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
            </tr>
            <tr>
                <td colspan="2" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="subbtim" runat="server" Text=" submit" 
                        onclick="subbtim_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="console" runat="server" Text="  reset  " onclick="console_Click" 
                        ValidationGroup="1" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="   exit   " 
                        ValidationGroup="1" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
        </table>
        

       
  
    </div>
    
    </div>
    </form>
</body>
</html>
