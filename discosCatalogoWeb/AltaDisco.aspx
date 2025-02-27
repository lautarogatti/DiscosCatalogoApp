<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AltaDisco.aspx.cs" Inherits="discosCatalogoWeb.AltaDisco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div class="container-fluid">
        <%-- contenedor del título --%>
        <div class="text-center">
            <h1>Ingreso de nuevo disco</h1>
        </div>
        <%-- envoltura --%>
        <div class="container-fluid row">
            <div class="col-2"></div>
            <div class="col-6">
                <div class="my-3">
                    <label for="txbTitulo" class="form-label">Título:</label>
                    <asp:TextBox ID="txbTitulo" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="txbFecha" class="form-label">Fecha de lanzamiento:</label>
                    <asp:TextBox ID="txbFecha" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="txbCantCanciones" class="form-label">Cantidad de canciones:</label>
                    <asp:TextBox ID="txbCantCanciones" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="txbUrlImagen" class="form-label">Url de Caratula:</label>
                    <asp:TextBox ID="txbUrlImagen" runat="server" CssClass="form-control" OnTextChanged="txbUrlImagen_TextChanged" AutoPostBack="true"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="ddlEstilo" class="form-label">Estilo del disco:</label>
                    <asp:DropDownList ID="ddlEstilo" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="ddlEdicion" class="form-label">Tipo de edición:</label>
                    <asp:DropDownList ID="ddlEdicion" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>
            </div>
            
            <%-- contenedor de la img --%>
            <div class="col">
                <asp:Image ID="imgThumbnail" runat="server" ImageUrl="https://dynamoprojects.com/wp-content/uploads/2022/12/no-image.jpg" AlternateText="" CssClass="img-thumbnail mt-5"/>
            </div>
            <div class="col-1"></div>
        </div>
        <%-- contenedor del formulario --%>
        <%-- contenedor del boton agregar --%>
        <div class="d-flex justify-content-center my-2">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary" />
        </div>
    </div>
</asp:Content>
