<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.Master" AutoEventWireup="true" CodeBehind="admin_error.aspx.cs" Inherits="RestaurantSystem.admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        onrowdatabound="GridView1_RowDataBound" 
        onrowupdating="GridView1_RowUpdating" 
        onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
        onrowcancelingedit="GridView1_RowCancelingEdit"  Width="610px"
        DataKeyNames="U_account" style="margin-top: 2px">
        <Columns>
            <asp:TemplateField HeaderText="check all">
                <HeaderTemplate>
                    <input ID="allCheck" type="checkbox"  onclick="getall(this)" />check all
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="U_account" HeaderText="ID" 
                SortExpression="U_account" Visible="False" />
            <asp:BoundField DataField="U_name" HeaderText="name" SortExpression="U_name" />
            <asp:BoundField DataField="U_password" HeaderText="password" 
                SortExpression="U_password" />
            <asp:TemplateField HeaderText="sex" SortExpression="U_sex">
                <EditItemTemplate>
                    &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="RadioButton1" runat="server" 
                        Checked='<%# female(Eval("u_sex")) %>' GroupName="sex" Text="female" 
                        Width="70px" />
                    &nbsp;<br />
                    <asp:RadioButton ID="RadioButton2" runat="server" 
                        Checked='<%# male(Eval("u_sex")) %>' GroupName="sex" Text="male" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("U_sex") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="role" SortExpression="p_name">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("p_name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="delete" ShowDeleteButton="True" 
                DeleteText="delete" />
            <asp:TemplateField HeaderText="update">
                <EditItemTemplate>
                    <asp:LinkButton ID="updateuser" runat="server" CommandName="Update">update</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="consoleuser" runat="server" CommandName="Cancel">cancel</asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="edituser" runat="server" CommandName="Edit">update</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        
    </asp:GridView>
    </p>
    <p>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="Button1" runat="server" BackColor="#FFFF99" OnClick="Button1_Click" style="text-align: right" Text="delete items" />
&nbsp;
        <asp:Button ID="Button2" runat="server" BackColor="#FFFF99" OnClick="Button2_Click" Text="add user" />
&nbsp;
        <asp:Button ID="Button3" runat="server" BackColor="#FFFF99" OnClick="Button3_Click" Text="exit" />
        <p>
        <div style="float:right;width:580px; height:50px; position:absolute; top:310px; left:0px; margin-top:20px; margin-bottom: 0px;">
       there are <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
         &nbsp;pages,this is  
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
           /<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        &nbsp;&nbsp;page&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">first</asp:LinkButton>&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">previous</asp:LinkButton>&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click">next</asp:LinkButton>&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton4_Click">last</asp:LinkButton>
    </div>
    &nbsp;</p>
    <p>
        
    <p>
    </p>
</asp:Content>
