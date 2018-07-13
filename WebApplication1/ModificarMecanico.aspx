<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="ModificarMecanico.aspx.cs" Inherits="WebApplication1.ModificarMecanico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="lblTitulo" runat="server" Text="MODIFICAR DATOS DE MECANICOS "></asp:Label><br />

   

    <asp:RadioButton ID="rbtModificarTodos" runat="server" Text="Modificar todos los datos" OnCheckedChanged="rbtModificarTodos_CheckedChanged" GroupName="seleccion" />
    <asp:RadioButton ID="rbtModDireccion" runat="server" Text="Modificar Direccion " OnCheckedChanged="rbtModDireccion_CheckedChanged" GroupName="seleccion" />
    <asp:RadioButton ID="rbtModFoto" runat="server" Text=" Actualizacion de foto " OnCheckedChanged="rbtModCapExtra_CheckedChanged" GroupName="seleccion"/><br />
    
    <asp:Label ID="lblSeleccion" runat="server" Text="Seleccione Mecanico a Modificar "></asp:Label>

    <asp:ListBox ID="LstMecanicos" runat="server" OnSelectedIndexChanged="LstMecanicos_SelectedIndexChanged"></asp:ListBox><br />
    
    <asp:Label ID="lblRegistroActual" runat="server" Text="Registro Actual :"></asp:Label>
    
    <asp:TextBox ID="txtRegistroActual" runat="server" ></asp:TextBox><br />
    <asp:PlaceHolder ID="PlhInicio" runat="server">
    <asp:Label ID="lblNombre" runat="server" Text="Nombre :"></asp:Label>
        

    <asp:TextBox ID="txtNombre" runat="server" with="120px"></asp:TextBox><br />
</asp:PlaceHolder>
    <asp:PlaceHolder ID="PlhDireccion" runat="server">

     <fieldset>
         
    <asp:Label ID="lblCalle" runat="server" Text="Calle :"></asp:Label>
    <asp:TextBox ID="txtCalle" runat="server"  Width="120px"></asp:TextBox><br />


    <asp:Label ID="lblNumero" runat="server" Text="Numero de Puerta :"></asp:Label>
    <asp:TextBox ID="txtNumero" runat="server" AutoPostBack="True" Width="120px"></asp:TextBox><br />

    <asp:Label ID="lblCiudad" runat="server" Text="Ciudad :"></asp:Label>
    
    <asp:TextBox ID="txtCiudad" runat="server" AutoPostBack="True"></asp:TextBox><br />
    </fieldset>
      </asp:PlaceHolder> 
     <asp:PlaceHolder ID="PlhCapaExtra" runat="server">
    <asp:Label ID="lblTelefono" runat="server" Text="Telefono ;"></asp:Label>
    <asp:TextBox ID="txtTelefono" runat="server" AutoPostBack="True" Width="120px"></asp:TextBox><br />

    <asp:Label ID="lblJornal" runat="server" Text="Costo Jornal :"></asp:Label>
    <asp:TextBox ID="txtJornal" runat="server" AutoPostBack="True" Width="120px"></asp:TextBox><br />
    <br />
   
    <asp:Label ID="lblCapaExtra" runat="server" Text="Realizo capacitacion extra ?"></asp:Label><br />
    <asp:RadioButton ID="CapacitaSi" runat="server" AutoPostBack="false" GroupName=" Capacitacion" OnCheckedChanged="CapacitaSi_CheckedChanged" Text="Si"/>
    <asp:RadioButton ID="CapacitaNO" runat="server" AutoPostBack="false" GroupName=" Capacitacion" OnCheckedChanged="CapacitaNO_CheckedChanged"  Text="No"/>
       
    <asp:TextBox ID="txtCapaExtra" runat="server" ReadOnly="true" Visible="false" AutoPostBack="True" ></asp:TextBox>
    <br />
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="Plhfoto" runat="server">
    <asp:Label ID="lblFoto" runat="server" Text="Ingrese Foto :"></asp:Label>
    
   
    <asp:FileUpload  ID="Foto" runat="server" Width="120px" AllowMultiple="True" EnableTheming="True" />
    <br />
  </asp:PlaceHolder>

    <asp:PlaceHolder ID="Plhboton" runat="server">

    <asp:Button ID="btnModificarMec" runat="server" Text="Aceptar" OnClick="btnModificarMec_Click" /><br />

    <asp:Label ID="lblMensaje" runat="server" Width="400px"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
             <Columns>
                <asp:BoundField DataField="NumReg" HeaderText="NumReg"></asp:BoundField>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre"></asp:BoundField>
                <asp:BoundField DataField="CapExtra" HeaderText="CapExtra"></asp:BoundField>
        
                 <asp:BoundField DataField="ValorJornal" HeaderText="Valor Jornal"></asp:BoundField>
                 <asp:ImageField DataImageUrlField="Foto" HeaderText="Foto">
                    <ControlStyle Height="35px" Width="50px"></ControlStyle>
                     </asp:ImageField>
            </Columns>
        </asp:GridView>

   </asp:PlaceHolder>

</asp:Content>
