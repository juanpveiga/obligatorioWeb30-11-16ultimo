<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="AltaMaterialNacional.aspx.cs" Inherits="WebApplication1.altaMaterialNacional" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    

    <h1>ALTA MATERIAL NACIONAL</h1>

    <asp:Label ID="lblNomMaterial" runat="server" Text="Ingrese nombre del material "></asp:Label>
    <asp:TextBox ID="txtNomMaterial" runat="server" ></asp:TextBox>
   
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNomMaterial" ErrorMessage="Debe Ingresar Nombre"></asp:RequiredFieldValidator>
   
    <br />
    <asp:Label ID="lblPeso" runat="server" Text="Ingrese Peso :"></asp:Label>
    <asp:TextBox ID="txtPeso" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPeso" ErrorMessage="Debe Ingresar Peso"></asp:RequiredFieldValidator>
    <br />
     <asp:Label ID="lblCostoCompra" runat="server" Text="Ingrese Costo de Compra :"></asp:Label>
    <asp:TextBox ID="txtCostoCompra" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCostoCompra" ErrorMessage="Debe ingresar Costo"></asp:RequiredFieldValidator>
    <br />
     <asp:Label ID="lblNombreEmpresa" runat="server" Text="Ingrese Nombre de la Empresa :"></asp:Label>
    <asp:TextBox ID="txtNombreEmpresa" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNombreEmpresa" ErrorMessage="Debe Ingresar Nombre de la Empresa"></asp:RequiredFieldValidator>
    <br /> :
     <asp:Label ID="lblAntiguedad" runat="server" Text="Ingrese Antiguedad :"></asp:Label>
    <asp:TextBox ID="txtAntiguedad" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAntiguedad" ErrorMessage="Debe ingresar antiguedad"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtAntiguedad" ErrorMessage="Debe ingresar valores mayores a 1 " MaximumValue="1000" MinimumValue="1"></asp:RangeValidator>
    <br />
     <asp:Label ID="lblMontoFijo" runat="server" Text="Ingrese Monto Fijo :"></asp:Label>
    <asp:TextBox ID="txtMontoFijo" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMontoFijo" ErrorMessage="Debe ingresar monto"></asp:RequiredFieldValidator>
    <br />
    <asp:Button ID="btnAltaMatNacional" runat="server" Text="Button" OnClick="btnAltaMatNacional_Click" />
    <br />
    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>

</asp:Content>
