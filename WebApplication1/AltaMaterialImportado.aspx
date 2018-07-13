<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="AltaMaterialImportado.aspx.cs" Inherits="WebApplication1.AltaMaterialImportado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>ALTA MATERIALES IMPORTADOS</h1>
   
   
    
    <asp:PlaceHolder ID="PlhIngresoMat" runat="server">
    <asp:Label ID="lblNombreMaterial" runat="server" Text="Nombre de Material :"></asp:Label>
    <asp:TextBox ID="txtNombreMat" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombreMat" ErrorMessage="Debe Ingresar Nombre de Material"></asp:RequiredFieldValidator>
    <br/>
    <asp:Label ID="lblPeso" runat="server" Text="Ingrese peso del material :"></asp:Label>
    <asp:TextBox ID="txtPeso" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPeso" ErrorMessage="Debe Ingresar Peso de Material"></asp:RequiredFieldValidator>
    <br/>
    <asp:Label ID="lblCostoCompra" runat="server" Text="Ingrese costo de compra"></asp:Label>
    <asp:TextBox ID="txtCostoCompra" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCostoCompra" ErrorMessage="Debe Ingresar Costo Compra"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtCostoCompra" ErrorMessage="Costo debe ser mayor a 10 menor a 100000" MaximumValue="100000" MinimumValue="10" Type="Double"></asp:RangeValidator>
    <br/>
    <asp:Label ID="lblEmpresa" runat="server" Text="Ingrese nombre de la empresa"></asp:Label>
    <asp:TextBox ID="txtEmpresa" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmpresa" ErrorMessage="Debe Ingresar Nombre de la Empresa"></asp:RequiredFieldValidator>
    <br/>
    <asp:Label ID="lblPaisOrigen" runat="server" Text="Pais de Origen"></asp:Label>
    <asp:TextBox ID="txtPaisOrigen" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPaisOrigen" ErrorMessage="Debe Ingresar Pais de Origen"></asp:RequiredFieldValidator>
    <br/><br/>
     <asp:Button ID="btnIngresoMatImp" runat="server" Text="Agregar Material" OnClick="btnIngresoMatImp_Click"/><br />
     </asp:PlaceHolder>
    
    <asp:Label ID="lblMensaje" runat="server" ></asp:Label>

</asp:Content>
