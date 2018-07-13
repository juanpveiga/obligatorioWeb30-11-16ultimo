<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="AltaEmbarcacion.aspx.cs" Inherits="WebApplication1.AltaEmbarcacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function validarNombre() {
            if (document.getElementById("<%=txtNombre.ClientID%>").value == "") {
                alert("El Nombre no puede estar vacio");
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>ALTA EMBARCACION</h1>
    
    <asp:Label ID="lblNombre" runat="server" Text="Ingrese Nombre de la Embarcacion:"></asp:Label>
    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" ErrorMessage="Debe ingresar un nombre " SetFocusOnError="True"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblFecha" runat="server" Text="Ingrese la Fecha de Construccion de la Embarcacion XX/YY/ZZZZ "></asp:Label>
    <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFecha" ErrorMessage="Debe Ingresar una Fecha"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Elija Tipo de Motor "></asp:Label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTipoMotor" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
    <br />
     <asp:RadioButton ID="rbnIntegrado" runat="server" AutoPostBack="True" GroupName="TipoDeMotor" OnCheckedChanged="rbnIntegrado_CheckedChanged" Value="1" Text="Motor Integrado" /><br />
     <asp:RadioButton ID="rbnFueraDeBorda" runat="server" AutoPostBack="True" GroupName="TipoDeMotor" OnCheckedChanged="rbnFueraDeBorda_CheckedChanged" Value="2" Text="Motor Fuera de Borda" /><br />
     <asp:RadioButton ID="rbnOtros" runat="server" AutoPostBack="True" GroupName="TipoDeMotor" OnCheckedChanged="rbnOtros_CheckedChanged" Value="3" Text="Otros" /><br />
     <asp:TextBox ID="txtTipoMotor" runat="server" ReadOnly="true" Visible="false"></asp:TextBox>
     <br />

    <asp:Button ID="btnAgregarEmb" runat="server" Text="Button" OnClick="btnAgregarEmb_Click" OnClientClick="return validarNombre()"/>
    <br />

    <asp:Label ID="lblMensaje" runat="server" ></asp:Label>

</asp:Content>
