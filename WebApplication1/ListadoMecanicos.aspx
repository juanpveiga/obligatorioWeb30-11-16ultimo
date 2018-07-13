<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="ListadoMecanicos.aspx.cs" Inherits="WebApplication1.ListadoMecanicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:GridView ID="GrillaMecanicosSinCap" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:ImageField DataImageUrlField="Foto" HeaderText="Foto">
                    <ControlStyle Height="35px" Width="50px"></ControlStyle>

                </asp:ImageField>
                <asp:BoundField DataField="NumReg" HeaderText="NumReg" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="ValorJornal" HeaderText="ValorJornal" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
