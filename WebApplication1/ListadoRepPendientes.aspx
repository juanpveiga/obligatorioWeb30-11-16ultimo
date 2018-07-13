<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="ListadoRepPendientes.aspx.cs" Inherits="WebApplication1.ListadoRepPendientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Listado Reparaciones Pendientes</h1>

        <asp:PlaceHolder ID="PlcRepPend" runat="server">

            <asp:GridView ID="GrillaRepPend" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="NombreEmb" HeaderText="NombreEmb"></asp:BoundField>
                    <asp:BoundField DataField="FechaIngGrilla" HeaderText="FechaIng"></asp:BoundField>
                    <asp:BoundField DataField="FechaPromEntGrilla" HeaderText="FechaPromEnt"></asp:BoundField>
                </Columns>
            </asp:GridView>

        </asp:PlaceHolder>
        <br />
        <asp:Label ID="LblMsjSalida" runat="server" Text="Label"></asp:Label>

    </div>
</asp:Content>
