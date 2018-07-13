<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="AgregarMaterial.aspx.cs" Inherits="WebApplication1.AgregarMaterial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>AGREGAR MATERIAL A REPARACION</h1>
   

    <asp:label runat="server" text="Seleccione una Embarcacion en reparacion de la siguiente Lista "></asp:label>
    <asp:dropdownlist runat="server" ID="DDLEmbEnRep" ></asp:dropdownlist><br />

    

     <asp:Label ID="lblListaMat" runat="server" Text="Seleccione Material de la siguiente lista"></asp:Label><br />
     <asp:dropdownlist runat="server" ID="DDLMateriales"></asp:dropdownlist><br />

     <asp:Label ID="lblCantidadKilos" runat="server" Text="Ingrese cantidad en kilogramos :"></asp:Label>
    <asp:TextBox ID="txtCantidadKilos" runat="server"></asp:TextBox><br /><br />

    <asp:button runat="server" text="Button" ID="btnAgregarMat" OnClick="btnAgregarMat_Click" /><br />

    <asp:label runat="server" text="" ID="lblMensaje"></asp:label>

</asp:Content>
