<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Eczane.aspx.cs" Inherits="Web_Modulu.Eczane" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body
        {
            margin-bottom:5%;
            margin-top:5%;
            margin-left:10%;
            margin-right:10%;
        }
        .auto-style3 {
            height: 30px;
            width: 87px;
        }
        .auto-style4 {
            height: 23px;
            width: 87px;
        }
        .auto-style5 {
            height: 30px;
            width: 176px;
        }
        .auto-style6 {
            height: 23px;
            width: 176px;
        }
        .auto-style7 {
            height: 30px;
            width: 71px;
        }
        .auto-style8 {
            height: 23px;
            width: 71px;
        }
        .auto-style9 {
            width: 86px;
        }
        .auto-style10 {
            width: 117px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">

        <table style="width:100%;">
            <tr>
                <td colspan="6">
                    <asp:Image ID="Image1" runat="server" Height="243px" ImageUrl="~/img/cats.jpg" Width="820px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label1" runat="server" Text="Hasta T.C. Kimlik No"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="TextBox1" runat="server" Width="130px"></asp:TextBox>
                </td>
                <td class="auto-style3">
                    <asp:Button ID="Button1" runat="server" Text="T.C. NO SORGULA" Width="131px" />
                </td>
                <td class="auto-style9">

                    &nbsp;</td>
                <td class="auto-style10">

                    &nbsp;</td>
                <td>

                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="Label3" runat="server" Text="Gün"></asp:Label>
                    <asp:DropDownList ID="DropDownList_Gun" runat="server">
                        <asp:ListItem>Gün</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style8">
                    <asp:Label ID="Label2" runat="server" Text="Ay"></asp:Label>
                    <asp:DropDownList ID="DropDownList_Ay" runat="server">
                        <asp:ListItem>Ay</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style4">
                    <asp:Label ID="Label4" runat="server" Text="Yıl"></asp:Label>
                    <asp:DropDownList ID="DropDownList_Yıl" runat="server">
                        <asp:ListItem>Yıl</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style9">

                    <asp:Label ID="Label5" runat="server" Text="Saat"></asp:Label>
                    <asp:DropDownList ID="DropDownList_Saat" runat="server">
                        <asp:ListItem>Saat</asp:ListItem>
                    </asp:DropDownList>

                </td>
                <td class="auto-style10">

                    <asp:Label ID="Label6" runat="server" Text="Dakika"></asp:Label>
                    <asp:DropDownList ID="DropDownList_Dakika" runat="server">
                        <asp:ListItem>Dakika</asp:ListItem>
                    </asp:DropDownList>

                </td>
                <td>

                    <asp:Button ID="Button2" runat="server" Text="Tarih Sorgula" />

                </td>
            </tr>
            <tr>
                <td colspan="6">&nbsp;</td>
            </tr>
        </table>

    </form>
</body>
</html>
