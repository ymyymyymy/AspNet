<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.Master" AutoEventWireup="true" CodeBehind="AlterTable.aspx.cs" Inherits="RestaurantSystem.table" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:580px; height:450px; position:absolute; top:20px; left:0px;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Table_id" onrowdeleting="GridView1_RowDeleting" 
        onrowcancelingedit="GridView1_RowCancelingEdit" 
        onrowdatabound="GridView1_RowDataBound" onrowediting="GridView1_RowEditing" 
        onrowupdating="GridView1_RowUpdating"  Width=500 OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
         <asp:TemplateField HeaderText="check all">
                <HeaderTemplate>
                    <input ID="getall" type="checkbox"  onclick="getall()" />check all
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="table_id" HeaderText="Table_id" 
                SortExpression="Table_id" ReadOnly="True" />
            <asp:TemplateField HeaderText="Status" SortExpression="Status">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="delete" ShowDeleteButton="True" 
                DeleteText="delete" />
            <asp:CommandField HeaderText="update" ShowEditButton="True" CancelText="cancel" 
                EditText="update" UpdateText="update" />
        </Columns>
    </asp:GridView>
    </div>
    
    <div style="float:right;width:580px; height:20px; position:absolute; top:310px; left:0px;">
       there are <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        pages,this is 
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        /<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        &nbsp; page&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">first</asp:LinkButton>&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">previous</asp:LinkButton>&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click">next</asp:LinkButton>&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton4_Click">last</asp:LinkButton>
    </div>
    
     <br />
       <div style="float:right;width:580px; position:absolute; top:360px; left:0px;">
         <asp:Button ID="Button2" runat="server" Text="delete items" 
               Width="110px" BackColor="#66FFCC" BorderColor="#CCFFFF" 
               BorderStyle="Solid" onclick="Button2_Click" />

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       
        <asp:Button ID="Button1" runat="server" Text="add user"
          Width="110px" BackColor="#66FFCC" BorderColor="#CCFFFF" BorderStyle="Solid" 
               onclick="Button1_Click" style="height: 26px" />
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       
        <asp:Button ID="Button3" runat="server" Text="exit" onclick="Button3_Click"
          Width="110px" BackColor="#66FFCC" BorderColor="#CCFFFF" BorderStyle="Solid" />
     </div>
</asp:Content>
