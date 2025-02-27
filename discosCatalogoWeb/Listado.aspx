<%@ Page Title="Listado" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="discosCatalogoWeb.Listado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div class="d-flex justify-content-center mt-3">
        <a class="btn btn-success" href="AltaDisco.aspx">Agregar Nuevo</a>
    </div>
    <div class="container-fluid px-2">
        <%-- definicion y configuracion del gridView --%>
        <asp:GridView 
            ID="dgvListadoDiscos" 
            runat="server" 
            AutoGenerateColumns="false" 
            CssClass="mt-3 table" 
            AllowPaging="true" 
            PageSize="2" 
            OnPageIndexChanging="dgvListadoDiscos_PageIndexChanging"
            OnRowDataBound="dgvListadoDiscos_RowDataBound"
            OnSelectedIndexChanged="dgvListadoDiscos_SelectedIndexChanged"
            DataKeyNames="Id"
            RowStyle-VerticalAlign="Middle"
            HeaderStyle-CssClass="text-center"
            RowStyle-CssClass="text-center"
            >

            <%-- configuraciones del pager (navegacion entre paginas dentro de la tabla) --%>
            <PagerSettings
                Mode="NumericFirstLast"
                PageButtonCount="1"
                FirstPageText="First"
                LastPageText="Last"
                NextPageText="Next"
                PreviousPageText="Previous"
                />

            <%-- configuraciones de los estilos del pager --%>
            <PagerStyle
                HorizontalAlign="Center"
                />

            <%-- definicion de columnas a mostrar en la tabla --%>
            <Columns>
                <asp:BoundField 
                    HeaderText="Título" 
                    DataField="Titulo"
                    HeaderStyle-CssClass="bg-primary-subtle"
                    />
                <asp:BoundField 
                    HeaderText="Fecha de lanzamiento" 
                    DataField="FechaDeLanzamiento" 
                    HeaderStyle-CssClass="bg-primary-subtle"
                    />
                <asp:BoundField 
                    HeaderText="Cantidad de canciones" 
                    DataField="CantCanciones" 
                    HeaderStyle-CssClass="bg-primary-subtle"
                    />
                <asp:BoundField 
                    HeaderText="Estilo" 
                    DataField="Estilo.Descripcion" 
                    HeaderStyle-CssClass="bg-primary-subtle"
                    />
                <asp:BoundField 
                    HeaderText="Tipo de edición" 
                    DataField="TipoEdicion.Descripcion" 
                    HeaderStyle-CssClass="bg-primary-subtle"
                    />
                <asp:BoundField 
                    HeaderText="Activo" 
                    DataField="Activo" 
                    HeaderStyle-CssClass="bg-primary-subtle"
                    />
                <asp:CommandField 
                    HeaderText="Seleccionar" 
                    ShowSelectButton="true"
                    ButtonType="Button" 
                    SelectText="Ver Detalles"
                    ItemStyle-HorizontalAlign="Center"
                    HeaderStyle-CssClass="bg-primary-subtle"
                    />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>