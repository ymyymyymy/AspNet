<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.Master" AutoEventWireup="true" CodeBehind="AlterMenu.aspx.cs" Inherits="RestaurantSystem.AlterMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:480px; height:429px; position:absolute; top:20px; left:50px; right:0px">
        <div style="width:480px;" >
        <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" 
                onrowdeleting="GridView1_RowDeleting" DataKeyNames="Menu_ID" 
                onrowcancelingedit="GridView1_RowCancelingEdit" 
                onrowdatabound="GridView1_RowDataBound" 
                onrowediting="GridView1_RowEditing" Width="500"
                onrowupdating="GridView1_RowUpdating">
                <Columns>
                <asp:TemplateField HeaderText="cheack all">
                <HeaderTemplate>
                    <input ID="allCheck" type="checkbox"  onclick="getall(this)" />check all
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
                    <asp:BoundField DataField="Menu_ID" HeaderText="ID" 
                        SortExpression="Menu_ID" Visible="False" />
                    <asp:BoundField DataField="Menu_Name" HeaderText="name" 
                        SortExpression="Menu_Name" />
                    <asp:TemplateField HeaderText="type" SortExpression="Menu_Type">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownList1" runat="server" Width="70px">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("type_Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Menu_Price" HeaderText="price" 
                        SortExpression="Menu_Price" />
                    <asp:BoundField DataField="Menu_picture" HeaderText="picture" 
                        SortExpression="Menu_picture" />
                    <asp:CommandField HeaderText="delete" ShowDeleteButton="True" 
                        DeleteText="delete" />
                    <asp:CommandField HeaderText="update" ShowEditButton="True" CancelText="cancel" 
                        EditText="update" UpdateText="update" />
                </Columns>
            </asp:GridView>
            
    </div>
    
    <br />
       <div style="float:right;width:580px; height:20px; position:absolute; top:310px; left:0px;">
       there are <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        pages,this is  
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
           /<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        &nbsp;&nbsp; page&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">first</asp:LinkButton>&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">previous</asp:LinkButton>&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click">next</asp:LinkButton>&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton4_Click">last</asp:LinkButton>
    </div>
    
     <br />
       <div style="float:right;width:580px; position:absolute; top:360px; left:0px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="Button2" runat="server" Text="delete items" 
               Width="110px" BackColor="#FFFF99" BorderColor="#CCFFFF" 
               BorderStyle="Solid" onclick="Button2_Click" style="text-align: center" />

        <asp:Button ID="Button1" runat="server" Text="add user"
          Width="110px" BackColor="#FFFF99" BorderColor="#CCFFFF" BorderStyle="Solid" 
               onclick="Button1_Click" />
       
        <asp:Button ID="Button3" runat="server" Text="exit" onclick="Button3_Click"
          Width="110px" BackColor="#FFFF99" BorderColor="#CCFFFF" BorderStyle="Solid" />
     </div>
    
    </div>
</asp:Content>
