<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="discosCatalogoWeb.Listado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <asp:GridView ID="dgvListadoDiscos" runat="server" AutoGenerateColumns="false" CssClass="mt-3 table table-secondary">
        <Columns>
            <asp:BoundField HeaderText="Título" DataField="Titulo" />
            <asp:BoundField HeaderText="Fecha de lanzamiento" DataField="FechaDeLanzamiento" />
            <asp:BoundField HeaderText="Cantidad de canciones" DataField="CantCanciones" />
            <asp:BoundField HeaderText="Estilo" DataField="Estilo.Descripcion" />
            <asp:BoundField HeaderText="Tipo de edición" DataField="TipoEdicion.Descripcion" />
            <asp:BoundField HeaderText="Activo" DataField="Activo" />
        </Columns>
    </asp:GridView>
</asp:Content>
