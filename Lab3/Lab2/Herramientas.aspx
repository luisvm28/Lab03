<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Herramientas.aspx.cs" Inherits="Lab2.Herramientas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <p>Laboratorio #3: Mantenimiento de Herramientas</p>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate> 
                <div>
                    <table>
                        <tr>
                            <td><asp:Label runat="server" Text="Codigo"></asp:Label></td>
                            <td><asp:TextBox runat="server" ID="txtidCodigo"></asp:TextBox> </td>
                        </tr>
                        <tr>
                            <td><asp:Label runat="server" Text="Nombre"></asp:Label></td>
                            <td><asp:TextBox runat="server" ID="txtNombre"></asp:TextBox> </td>                   
                        </tr>
                        <tr>
                            <td><asp:Label runat="server" Text="Descripcion" /></td>
                            <td><asp:TextBox runat="server" ID="txtDescripcion"></asp:TextBox></td>                   
                        </tr>

                        <tr>
                            <td><asp:Label runat="server" Text="Tipo" /></td>
                            <td><asp:DropDownList runat="server" ID="cmbcodTipo">
                                </asp:DropDownList></td>
                        </tr>

                        <tr>
                            <td><asp:Label runat="server" Text="Marca" /></td>
                            <td><asp:DropDownList runat="server" ID="cmbcodMarca">
                                </asp:DropDownList></td>
                        </tr>

                        <tr>
                            <td><asp:Button ID="bntBuscar" Text="Buscar" runat="server" OnClick="btnBuscar_Click" /></td>
                            <td><asp:Button ID="btnRegistrar" Text="Registrar" runat="server" OnClick="btnRegistrar_Click" /></td>
                            <td><asp:Button ID="btnActualizar" Text="Actualizar" runat="server" OnClick="btnActualizar_Click" /></td>
                            <td><asp:Button ID="btnEliminar" Text="Eliminar" runat="server" OnClick="btnEliminar_Click" /></td>
                        </tr>

                    </table>
            
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>

   

</body>
</html>

