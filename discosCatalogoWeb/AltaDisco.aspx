<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AltaDisco.aspx.cs" Inherits="discosCatalogoWeb.AltaDisco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <%-- contenedor del título --%>
                <div class="text-center">
                    <%if (Request.QueryString["id"] != null)
                        { %>
                    <h1>Modificar disco</h1>
                    <%}
                        else
                        { %>
                    <h1>Ingreso de nuevo disco</h1>
                    <%}%>
                </div>
                <%-- envoltura --%>
                <div class="container-fluid row">
                    <div class="col-2"></div>
                    <div class="col-6">
                        <div class="my-3">
                            <label class="form-label">Título:</label>
                            <asp:TextBox ID="txbTitulo" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Fecha de lanzamiento:</label>
                            <asp:TextBox ID="txbFecha" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Cantidad de canciones:</label>
                            <asp:TextBox ID="txbCantCanciones" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Url de Caratula:</label>
                            <asp:TextBox ID="txbUrlImagen" runat="server" CssClass="form-control" OnTextChanged="txbUrlImagen_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Estilo del disco:</label>
                            <asp:DropDownList ID="ddlEstilo" runat="server" CssClass="form-select"></asp:DropDownList>
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Tipo de edición:</label>
                            <asp:DropDownList ID="ddlEdicion" runat="server" CssClass="form-select"></asp:DropDownList>
                        </div>
                    </div>

                    <%-- contenedor de la img --%>
                    <div class="col">
                        <asp:Image ID="imgThumbnail" runat="server" ImageUrl="https://dynamoprojects.com/wp-content/uploads/2022/12/no-image.jpg" AlternateText="" CssClass="img-thumbnail mt-5" />
                    </div>
                    <div class="col-1"></div>
                </div>
                <%-- contenedor del formulario --%>
                <%-- contenedor del boton agregar --%>
                <div class="row">
                    <div class="col-4"></div>
                    <div class="col-4 d-flex justify-content-evenly my-2">
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
                        <%if (Request.QueryString["id"] != null)
                            {%>
                        <asp:Button ID="btnMenuEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnMenuEliminar_Click" />
                        <asp:Button ID="btnDesactivar" runat="server" Text="Desactivar Disco" CssClass="btn btn-warning" OnClick="btnDesactivar_Click"/>
                        <%} %>
                    </div>
                    <div class="col-4"></div>
                    <%if (menuEliminarActivo)
                        {%>
                    <div class="row">
                        <div class="col-4"></div>
                        <div class="col-4 d-flex flex-column my-3 border border-danger rounded-3 py-2">
                            <p class="text-center">Está seguro que desea eliminar? esta acción no se puede revertir</p>
                            <div class="d-flex justify-content-evenly align-items-center">
                                <div>
                                    <asp:CheckBox ID="ckbEliminarConfirmacion" runat="server" />
                                    <asp:Label ID="lblEliminarConfirmacion" runat="server" Text="Eliminar"></asp:Label>
                                </div>
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-outline-danger" OnClick="btnEliminar_Click" />
                            </div>
                        </div>
                        <div class="col-4"></div>
                    </div>
                    <%} %>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
