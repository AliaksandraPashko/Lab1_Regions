<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="Lab1_regions_.MainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td><asp:Label ID="Label1" runat="server"><p style="text-align:center">Choose region:</p></asp:Label></td>
                <td><asp:Label ID="Label2" runat="server"><p style="text-align:center">Choose district:</p></asp:Label></td>
            </tr>
            
            <tr>
                <td><asp:DropDownList ID="DDListRegions" DataTextField = "Name" DataValueField = "ID" runat="server" AutoPostBack="true" onselectedindexchanged="DDListRegions_SelectedIndexChanged"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DDListDistricts" DataTextField = "Name" DataValueField ="ID" runat="server"></asp:DropDownList></td>
            </tr>
            
        </table>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
