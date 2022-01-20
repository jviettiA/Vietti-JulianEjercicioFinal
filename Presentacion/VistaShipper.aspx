<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaShipper.aspx.cs" Inherits="Presentacion.VistaShipper" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
        .auto-style2 {
            height: 22px;
        }
        .auto-style3 {
            height: 21px;
        }
        .auto-style4 {
            height: 20px;
        }
        .auto-style5 {
            height: 19px;
        }
        .auto-style6 {
            height: 18px;
        }
        .auto-style7 {
            height: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblCompname" runat="server" Text="CompanyName"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtCompaName" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style4">
                        &nbsp;</td>
                    <td class="auto-style5">
                        <asp:Button ID="btnInsertar" runat="server" Text="Insertar" OnClick="btnInsertar_Click" />
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblPhone" runat="server" Text="Phone"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style4">
                        &nbsp;</td>
                    <td class="auto-style5">
                        <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style4">
                        &nbsp;</td>
                    <td class="auto-style5">
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblShipid" runat="server" Text="ShipperID"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtShipid" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style4">
                        <asp:Label ID="lblFiltrarPorName" runat="server" Text="Filtrar por Company name"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:DropDownList ID="cbCompany" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cbState_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                                        <td class="auto-style2">
                                            &nbsp;</td>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style2">
                        
                    </td>
                    <td class="auto-style3">
                    </td>
                    <td class="auto-style4">
                        &nbsp;</td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td class="auto-style6">
                        &nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>


                <tr>
                    <td colspan="6">
                        <asp:GridView ID="gridShippers" runat="server" OnSelectedIndexChanged="gridShippers_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField SelectText="Select" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="gridOrders" runat="server">
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
