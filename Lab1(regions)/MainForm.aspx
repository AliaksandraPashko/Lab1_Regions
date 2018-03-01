<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="Lab1_regions_.MainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <table>
            <tr><td><asp:Label ID="Label1" runat="server">Choose region:</asp:Label></td></tr>
            <tr><td><asp:DropDownList ID="DDListRegions" DataTextField = "Name" DataValueField = "ID" runat="server" AutoPostBack="true" onselectedindexchanged="DDListRegions_SelectedIndexChanged"></asp:DropDownList></td></tr>
            <tr><td><asp:Label ID="Label2" runat="server">Choose district:</asp:Label></td></tr>         
            <tr><td><asp:DropDownList ID="DDListDistricts" DataTextField = "Name" DataValueField ="ID" runat="server" AutoPostBack="true" onselectedindexchanged="DDListDistricts_SelectedIndexChanged"></asp:DropDownList></td></tr>
        </table>
                
            <br />
            
        <asp:GridView ID="GridView" runat="server"  DataKeyNames="ID" AutoGenerateColumns="False" OnRowDeleting="GridView_RowDeleting" OnRowEditing="GridView_RowEditing" OnRowUpdating="GridView_RowUpdating" OnRowCancelingEdit="GridView_RowCancelingEdit">
            <columns>
                <asp:TemplateField HeaderText="Name"><ItemTemplate>
                    <%#Eval("Name")%></ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="textbox1" runat="server" Text=' <%#Eval("Name")%>'></asp:TextBox>
                    </EditItemTemplate>
                    </asp:TemplateField>
               <asp:TemplateField HeaderText="Type"><ItemTemplate>
                    <%#Eval("Type")%></ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="textbox2" runat="server" Text=' <%#Eval("Type")%>'></asp:TextBox>
                    </EditItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="Population"><ItemTemplate>
                    <%#Eval("Population")%></ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="textbox3" runat="server" Text=' <%#Eval("Population")%>'></asp:TextBox>
                    </EditItemTemplate>
                    </asp:TemplateField>
                <asp:CommandField ButtonType="Link" ShowEditButton="true" EditText="Edit" ShowDeleteButton="true" UpdateText="Update" CancelText="Cancel"
                   DeleteText="Delete"/>
            </columns>
        </asp:GridView>
            <br />
        <table>
            <tr><td> Name: </td><td> <asp:TextBox ID="txtName" runat="server" /></td></tr>
            <tr><td> Type: </td><td> <asp:TextBox ID="txtType" runat="server"/></td></tr>
            <tr><td> Population: </td><td><asp:TextBox ID="txtPopulation" runat="server"/></td></tr>
            <tr><td> <asp:Button ID="AddButton" runat="server" Text="Add" OnClick="AddButton_Click"/></td></tr>
        </table>
        </div>
    </form>
</body>
</html>
