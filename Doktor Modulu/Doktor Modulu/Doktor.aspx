<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Doktor.aspx.cs" Inherits="Doktor_Modulu.Doktor" %>

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

    </style>

</head>
<body style="background-color:powderblue;">
    <form id="form1" runat="server">

        <table class="auto-style20">
            <tr>
                <td>

                </td>
                <td colspan="6">
                    <asp:Image ID="Image1" runat="server" Height="243px" ImageUrl="~/img/cats4.jpg" Width="940px" CssClass="auto-style14" />
                </td>
                <td class="auto-style30">

                </td>
            </tr>
            <tr>
                <td colspan="8">

                    <asp:Label ID="tb_karsılama" runat="server" Text="Hosgeldiniz."></asp:Label>

                </td>
            </tr>
            <tr>
                <td>

                    <asp:Label ID="Label10" runat="server" Text="Gün  "></asp:Label>
                    <asp:DropDownList ID="DropDownList_Gun" runat="server" Height="16px">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>26</asp:ListItem>
                        <asp:ListItem>27</asp:ListItem>
                        <asp:ListItem>28</asp:ListItem>
                        <asp:ListItem>29</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>31</asp:ListItem>
                    </asp:DropDownList>

                </td>
                <td>

                    <asp:Label ID="Label8" runat="server" Text="Ay  "></asp:Label>
                    <asp:DropDownList ID="DropDownList_Ay" runat="server" Height="16px">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>

                </td>
                <td>

                    <asp:Label ID="Label9" runat="server" Text="Yıl  "></asp:Label>
                    <asp:DropDownList ID="DropDownList_Yil" runat="server" Height="16px">
                        <asp:ListItem>2020</asp:ListItem>
                        <asp:ListItem>2019</asp:ListItem>
                        <asp:ListItem>2018</asp:ListItem>
                        <asp:ListItem>2017</asp:ListItem>
                        <asp:ListItem>2016</asp:ListItem>
                        <asp:ListItem>2015</asp:ListItem>
                        <asp:ListItem>2014</asp:ListItem>
                        <asp:ListItem>2013</asp:ListItem>
                        <asp:ListItem>2012</asp:ListItem>
                        <asp:ListItem>2011</asp:ListItem>
                        <asp:ListItem>2010</asp:ListItem>
                    </asp:DropDownList>

                </td>
                <td>

                    <asp:Button ID="btn_veri_cek" runat="server" OnClick="btn_veri_cek_Click" Text="Verileri Cek" />

                    <asp:Button ID="btn_tarih_sorgu" runat="server" Text="Tarih Sorgula" CssClass="auto-style14" Height="29px" Width="101px" OnClick="btn_tarih_sorgu_Click" Visible="False" />

                </td>
                <td>

                    <asp:ListBox ID="ListBox_Hasta_Liste" runat="server" Height="128px" Width="167px" Visible="False" OnSelectedIndexChanged="ListBox_Hasta_Liste_SelectedIndexChanged"></asp:ListBox>

                </td>
                <td>

                    <asp:CheckBoxList ID="CheckBoxList_tahlil" runat="server" Height="129px" Width="208px" Visible="False">
                    </asp:CheckBoxList>

                </td>
                <td>

                    <asp:CheckBoxList ID="CheckBoxList_hastalik" runat="server" Height="129px" Width="208px" Visible="False">
                    </asp:CheckBoxList>

                </td>
                <td>

                    <asp:DropDownList ID="DropDownList_ilac" runat="server" Height="27px" Width="119px" Visible="False">
                    </asp:DropDownList>

                    <asp:Label ID="Label11" runat="server" Text="Adet" Visible="False"></asp:Label>
                    <br />
                    <asp:TextBox ID="tb_adet" runat="server" Width="108px" Visible="False"></asp:TextBox>
                    <asp:Button ID="btn_recete_yaz" runat="server" Height="28px" Text="Reçete Yaz" Width="121px" OnClick="Button4_Click" Visible="False" />

                </td>
            </tr>
            <tr>
                <td>

                    <asp:ListBox ID="ListBox_1" runat="server" Visible="False"></asp:ListBox>

                </td>
                <td>

                    <asp:ListBox ID="ListBox_2" runat="server" Visible="False"></asp:ListBox>

                </td>
                <td>

                    <asp:ListBox ID="ListBox_3" runat="server" Visible="False"></asp:ListBox>

                </td>
                <td>

                    <asp:ListBox ID="ListBox_4" runat="server" Visible="False"></asp:ListBox>

                </td>
                <td>

                    <asp:ListBox ID="ListBox_5" runat="server" Visible="False"></asp:ListBox>
                    <asp:ListBox ID="ListBox_6" runat="server" Visible="False"></asp:ListBox>

                </td>
                <td>

                    <asp:ListBox ID="ListBox_7" runat="server" Visible="False"></asp:ListBox>
                    <asp:ListBox ID="ListBox_8" runat="server" Visible="False"></asp:ListBox>
                    <asp:ListBox ID="ListBox_9" runat="server" Visible="False"></asp:ListBox>

                </td>
                <td>

                    <asp:ListBox ID="ListBox_10" runat="server" Visible="False"></asp:ListBox>
                    <asp:ListBox ID="ListBox_11" runat="server" Visible="False"></asp:ListBox>
                    <asp:ListBox ID="ListBox_12" runat="server" Visible="False"></asp:ListBox>

                </td>
                <td>

                    <asp:ListBox ID="ListBox_13" runat="server" Visible="False"></asp:ListBox>

                </td>
            </tr>
            <tr>
                <td colspan="8">&nbsp;</td>
            </tr>
        </table>

    </form>
</body>
</html>
