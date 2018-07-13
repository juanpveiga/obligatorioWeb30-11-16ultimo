<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="ListadoEmbarcaciones.aspx.cs" Inherits="WebApplication1.ListadoEmbarcaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
     <h1>Listado de Embarcaciones</h1>

    <asp:GridView ID="GrillaEmbarcaciones" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="IdEmb" HeaderText="IdEmb" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="FechaConstGrilla" HeaderText="FechaConst" />
            <asp:BoundField DataField="TipoMotor" HeaderText="TipoMotor" />
        </Columns>
</asp:GridView>
</asp:Content>
