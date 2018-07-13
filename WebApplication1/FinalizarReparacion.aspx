<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="FinalizarReparacion.aspx.cs" Inherits="WebApplication1.FinalizarReparacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
         function validarFechaEntrega() {
             if (document.getElementById("<%=TxtFechaFin.ClientID%>").value == "")
             {
                alert("La fecha de entrega no puede estar vacio");
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Finalizar Reparacion</h1>
        <asp:Label ID="LblEmbRepPedn" runat="server" Text="Seleccione Embarcacion"></asp:Label>
        <asp:DropDownList ID="DDLEmbRepPend" runat="server"></asp:DropDownList>
        <br />
        <asp:Button ID="BtnMostrar" runat="server" Text="Mostrar" OnClick="BtnMostrar_Click" />
        <br />

        <asp:PlaceHolder ID="PlcRepPend" runat="server">

            <asp:Label ID="LblRepPend" runat="server" Text="Reparacion pendiente de la embarcacion seleccionada"></asp:Label>
        <br />
        <asp:GridView ID="GrillaRepPend" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="NombreEmb" HeaderText="NombreEmb"></asp:BoundField>
                    <asp:BoundField DataField="FechaIngGrilla" HeaderText="FechaIng"></asp:BoundField>
                    <asp:BoundField DataField="FechaPromEntGrilla" HeaderText="FechaPromEnt"></asp:BoundField>
                </Columns>
            </asp:GridView>
            <br />
        <asp:Label ID="LblFechaFin" runat="server" Text="Seleccione una Fecha de Finalizacion"></asp:Label>
        <br />
            <asp:TextBox ID="TxtFechaFin" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:ImageButton ID="ImgBtnCalendario" runat="server" ImageUrl="~/imagenes/calendaricon_large.png" Height="24px" Width="23px" OnClick="ImgBtnCalendario_Click" />
        <br />
        <asp:Calendar ID="Calendario1" runat="server" OnSelectionChanged="Calendario1_SelectionChanged"></asp:Calendar>
        <br />
        <asp:Button ID="BtnFinalizar" runat="server" Text="Finalizar" OnClick="BtnFinalizar_Click" OnClientClick="return validarFechaEntrega()"/>

        </asp:PlaceHolder>
        <br />
        <asp:Label ID="LblMsjSalida" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
