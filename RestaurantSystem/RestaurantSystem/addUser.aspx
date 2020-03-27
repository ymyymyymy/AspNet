<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addUser.aspx.cs" Inherits="RestaurantSystem.addUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 625px;
        }
        .auto-style2 {
            width: 142px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:581px;  margin-top:30px; height: 230px;" border="1"  font-family: Gisha;" 
             border="1px"  cellpadding=1px cellspacing=1px>
            <tr>
                <td class="auto-style2" >
                   &nbsp;&nbsp; name： </td>
                <td class="auto-style1" >&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="userName" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="userName" ErrorMessage="RequiredFieldValidator" ForeColor="Red">name is 
                    not null</asp:RequiredFieldValidator>
                        </td>
            </tr>
            <tr>
                <td class="auto-style2" >
                   &nbsp;&nbsp; password：</td>
                <td class="auto-style1" >&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="userPwd" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="userPwd" ErrorMessage="RequiredFieldValidator" ForeColor="Red">possword is 
                        not null</asp:RequiredFieldValidator>
                        </td>
            </tr>
            <tr>
                <td class="auto-style2" >
                    &nbsp;&nbsp; Confirm&nbsp;<br />
&nbsp;&nbsp; Password：</td>
                <td class="auto-style1" >&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="userpwtwo" runat="server" TextMode="Password"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                        runat="server" ControlToValidate="userpwtwo" Display="Dynamic" 
                        ErrorMessage="RequiredFieldValidator" ForeColor="Red">possword is not null</asp:RequiredFieldValidator>
                    &nbsp;
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="userPwd" ControlToValidate="userpwtwo" 
                        ErrorMessage="CompareValidator" ForeColor="Red">wrong password </asp:CompareValidator>
                        </td>
            </tr>
            <tr>
                <td class="auto-style2" >
                   &nbsp;&nbsp; sex：</td>
                <td class="auto-style1" >&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="female" runat="server" Text="girl" Checked="True" 
                        GroupName="sex" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="male" runat="server" Text="boy" GroupName="sex" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td class="auto-style2" >
                   &nbsp;&nbsp; privilege：</td>
                <td class="auto-style1">&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server" 
                        Height="21px" Width="127px">
                    </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="console" runat="server" Text="  reset  " onclick="console_Click" 
                        ValidationGroup="1" style="height: 26px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="subbtim" runat="server" Text="submit" 
                        onclick="subbtim_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="   exit   " 
                        ValidationGroup="1" Width="92px" />
                &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
