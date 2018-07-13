<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="AltaReparacion.aspx.cs" Inherits="WebApplication1.AltaReparacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>ALTA REPARACION</h1>
   
    <asp:Label ID="lblseleccioneEmb" runat="server" Text="Seleccione la Embarcacion a Reparar"></asp:Label>
    

    <asp:DropDownList runat="server" AutoPostBack="true" ID="DDLEmbarcaciones" on  ></asp:DropDownList>
    
    <br />
     <asp:Label ID="lblIdEmb" runat="server" Text="Id de la Embarcacion Seleccionada"></asp:Label>
    <asp:TextBox ID="txtIdEmb" runat="server" ReadOnly="True" ClientIDMode="AutoID" ></asp:TextBox>
    <br />
    
    <asp:Label ID="lblFechaIngreso" runat="server" Text="Fecha de Ingreso de la Reparacion XX/YY/ZZZZ : "></asp:Label>
    <asp:TextBox ID="txtFechaIngreso" runat="server" TextMode="DateTime"></asp:TextBox>
    <br />
     <asp:Label ID="lblFechaPromEnt" runat="server" Text="Fecha Prometida de Entrega de la Reparacion XX/YY/ZZZZ: "></asp:Label>
    <asp:TextBox ID="txtFechaPromEnt" runat="server" TextMode="DateTime"></asp:TextBox>
    <br />

    <asp:Button ID="btnAltaRep" runat="server" Text="Button" OnClick="btnAltaRep_Click" />
    <br />
    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>

</asp:Content>
