<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="ActualizarImpImportacion.aspx.cs" Inherits="WebApplication1.ActualizarImpImportacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>ACTUALIZAR IMPUESTO IMPORTACION (RECRAGO)</h1>
    
    <asp:Label ID="Label1" runat="server" Text="Ingrese Nuevo Valor de Impuesto :"></asp:Label>
    <asp:TextBox ID="txtNuevoValor" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNuevoValor" ErrorMessage="Debe ingresar un valor."></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtNuevoValor" ErrorMessage="El Valor debe estar comprendido entre 0 y 1." MaximumValue="1" MinimumValue="0" Type="Double"></asp:RangeValidator>
    <br/>
    <asp:Button ID="btnActualizarIMp" runat="server" Text="Actualizar" OnClick="btnActualizarIMp_Click"/><br/>
    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>

</asp:Content>
