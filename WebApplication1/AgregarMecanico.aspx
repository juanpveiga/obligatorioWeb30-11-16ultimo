<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="AgregarMecanico.aspx.cs" Inherits="WebApplication1.AgregarMecanico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>AGREGAR MECANICO A LA REPARACION</h1>
   

     <asp:label runat="server" text="Seleccione una Embarcacion en reparacion de la siguiente Lista "></asp:label>
    <asp:dropdownlist runat="server" ID="DDLEmbEnRep" ></asp:dropdownlist><br />

     <asp:Label ID="lblMecanicos" runat="server" Text="Seleccione un Mecanico de la siguiente lista"></asp:Label><br />
    <asp:DropDownList ID="DDLMecamicoRep" runat="server"></asp:DropDownList><br />

    <asp:Button ID="btnAgregarMecanico" runat="server" Text="Agregar" OnClick="btnAgregarMecanico_Click" /><br />

    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>

</asp:Content>
