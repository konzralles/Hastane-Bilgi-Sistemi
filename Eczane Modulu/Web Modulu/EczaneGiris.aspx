<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EczaneGiris.aspx.cs" Inherits="Web_Modulu.EczaneGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 450px;
        }
        .auto-style2 {
            width: 100%;
            height: 445px;
        }
        .auto-style4 {
            width: 100%;
            height: 112px;
        }
        .auto-style5 {
            height: 123px;
        }
        .auto-style6 {
            width: 416px;
        }
        .auto-style7 {
            height: 23px;
            width: 416px;
        }
        .auto-style9 {
            height: 123px;
            width: 278px;
        }
        .auto-style11 {
            width: 278px;
        }
        .auto-style12 {
            width: 810px;
        }
        .auto-style13 {
            height: 23px;
            width: 810px;
        }
    </style>
</head>
<body style="height: 450px; width: 900px">
    <form id="form1" runat="server" class="auto-style1">
        <table class="auto-style2">
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style11">
                    <asp:Image ID="Image1" runat="server" Height="236px" ImageUrl="~/img/images.jpg" Width="272px" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5"></td>
                <td class="auto-style9">
                    <table class="auto-style4">
                        <tr>
                            <td class="auto-style12">
                                <asp:Label ID="Label2" runat="server" Text="Kullanıcı Adı"></asp:Label>
                            </td>
                            <td class="auto-style6">
                                <asp:TextBox ID="tb_kullaniciadi" runat="server" Width="99px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style13">
                                <asp:Label ID="Label1" runat="server" Text="Sifre"></asp:Label>
                            </td>
                            <td class="auto-style7">
                                <asp:TextBox ID="tb_sifre" runat="server" TextMode="Password" Width="99px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                <asp:Label ID="giriskontrol" runat="server"></asp:Label>
                            </td>
                            <td class="auto-style6">
                                <asp:Button ID="login" runat="server" Text="Giris Yap" Width="100px" OnClick="login_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style11"></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
