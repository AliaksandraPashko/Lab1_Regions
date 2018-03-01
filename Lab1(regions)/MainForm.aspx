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
            
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="false">
            <columns>
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Type" HeaderText="Type" />
                <asp:BoundField DataField="Population" HeaderText="Population" />
            </columns>
        </asp:GridView>
            <br />
            <asp:Button ID="EditButton" runat="server" OnClick="EditButton_Click" Text="Edit" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="DeleteButton" runat="server" Text="Delete" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="UpdateButton" runat="server" Text="Update" />
        </div>
    </form>
</body>
</html>
