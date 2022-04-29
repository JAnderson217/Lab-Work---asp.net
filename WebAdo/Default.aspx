<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAdo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Load Selected" OnClick="Button1_Click"/>
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </div>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Delete Record" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Update Record" />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Create Record" />
    </form>
</body>
</html>
