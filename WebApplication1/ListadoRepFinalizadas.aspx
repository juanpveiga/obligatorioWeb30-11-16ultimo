<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="ListadoRepFinalizadas.aspx.cs" Inherits="WebApplication1.ListadoRepFinalizadas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <h1>Listado Reparaciones Finalizadas</h1>

        <asp:Label ID="LblEmbRepFin" runat="server" Text="Seleccione Embarcacion"></asp:Label>
        <asp:DropDownList ID="DDLEmbarcaciones" runat="server"></asp:DropDownList>
        <br />
        <asp:Button ID="BtnMostrar" runat="server" Text="Mostrar" OnClick="BtnMostrar_Click" />
        <br />

        <asp:PlaceHolder ID="PlcRepFin" runat="server">
            <asp:Label ID="LblRepFin" runat="server" Text="Seleccione reparacion para mostrar detalles"></asp:Label>
            <br />
            <asp:ListBox ID="LstRepFin" runat="server" AutoPostBack="True" OnSelectedIndexChanged="LstRepPend_SelectedIndexChanged"></asp:ListBox>
        <br />
            <asp:PlaceHolder ID="PlcGrillas" runat="server">

                <asp:GridView ID="GrillaMecanicos" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="NumReg" HeaderText="NumReg"></asp:BoundField>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre"></asp:BoundField>
                <asp:BoundField DataField="CapExtra" HeaderText="CapExtra"></asp:BoundField>
            </Columns>
        </asp:GridView>
        <br />

        <asp:GridView ID="GrillaMatUtilizados" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="MatUtil" HeaderText="MatUtilizado"></asp:BoundField>
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad"></asp:BoundField>
            </Columns>
        </asp:GridView>


            </asp:PlaceHolder>
        
        
        </asp:PlaceHolder>

        
        

        
        <br />

        <asp:Label ID="LblMsjSalida" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
