<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="Alta Mecanico.aspx.cs" Inherits="WebApplication1.Alta_Mecanico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
        function validarRegistro() {
            if (document.getElementById("<%=txtRegistro.ClientID%>").value == "") {
                alert("El registro no puede estar vacio");
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <h1> ALTA MECANICO </h1>
   
    <asp:Label ID="lblNombre" runat="server" Text="Nombre : "></asp:Label>
    <asp:TextBox ID="txtNombre" runat="server" AutoPostBack="True"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe ingresar nombre " ControlToValidate="txtNombre" Display="Dynamic"></asp:RequiredFieldValidator>
    <br />
    <fieldset>
    <asp:Label ID="lblCalle" runat="server" Text="Calle :"></asp:Label>
    <asp:TextBox ID="txtCalle" runat="server" AutoPostBack="True" Width="120px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe ingresar una calle" ControlToValidate="txtCalle"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblNumero" runat="server" Text="Numero de Puerta :"></asp:Label>
    <asp:TextBox ID="txtNumero" runat="server" AutoPostBack="True" Width="120px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNumero" Display="Dynamic" ErrorMessage="Debe ingresar Numero"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblCiudad" runat="server" Text="Ciudad :"></asp:Label>
    
    <asp:TextBox ID="txtCiudad" runat="server" AutoPostBack="True"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCiudad" ErrorMessage="Debe Ingresar una ciudad"></asp:RequiredFieldValidator>
        </fieldset>
    <br />
    <asp:Label ID="lblTelefono" runat="server" Text="Telefono ;"></asp:Label>
    <asp:TextBox ID="txtTelefono" runat="server" AutoPostBack="True" Width="120px"></asp:TextBox>
    <br />
    <asp:Label ID="lblRegistro" runat="server" Text="Numero de Registro Mecanico :"></asp:Label>
    <asp:TextBox ID="txtRegistro" runat="server" AutoPostBack="True" Width="120px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtRegistro" ErrorMessage="Debe Ingresar Nuemero Registro"></asp:RequiredFieldValidator>
<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtRegistro" Display="Dynamic" ErrorMessage="Fuera de Rango" MaximumValue="10000" MinimumValue="0" Type="Integer"></asp:RangeValidator>
    <br />
    <asp:Label ID="lblJornal" runat="server" Text="Numero de Puerta :"></asp:Label>
    <asp:TextBox ID="txtJornal" runat="server" AutoPostBack="True" Width="120px"></asp:TextBox>
    <br />
    <asp:Label ID="lblCapaExtra" runat="server" Text="Realizo capacitacion extra ?"></asp:Label><br />
    <asp:RadioButton ID="CapacitaSi" runat="server" AutoPostBack="true" GroupName=" Capacitacion" OnCheckedChanged="CapacitaSi_CheckedChanged" Text="Si"/>
    <asp:RadioButton ID="CapacitaNO" runat="server" AutoPostBack="true" GroupName=" Capacitacion" OnCheckedChanged="CapacitaNO_CheckedChanged"  Text="No"/>

    <asp:TextBox ID="txtCapaExtra" runat="server" ReadOnly="true" Visible="false" AutoPostBack="True" ></asp:TextBox>
    <br />
    <asp:Label ID="lblFoto" runat="server" Text="Ingrese Foto :"></asp:Label>
    <br />
   
    <asp:FileUpload  ID="Foto" runat="server" Width="120px" AllowMultiple="True" EnableTheming="True" />
    <br />
    
    <asp:Button ID="btnAgregarMecanico" runat="server" Text="Ingresar" OnClick="btnAgregarMecanico_Click" Enabled="True" OnClientClick="return validarRegistro()"/>
    <br />
    <asp:Label ID="lblMensaje" runat="server" Width="400px"></asp:Label>
</asp:Content>
