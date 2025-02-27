<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="discosCatalogoWeb.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

    <main>
        <%-- forma de generar cards para cada disco con for each --%>
        <div class="container-fluid row row-cols-1 row-cols-md-4 g-3 mb-3 mt-1">
        <% foreach (dominio.Disco disco in listaDiscos)
            {%>
                <div class="col">
                    <div class="card h-100">
                        <img src="<%: disco.UrlImagen %>" class="card-img-top card-img-top" alt="<%: "tapa del disco " + disco.Titulo  %>">
                        <div class="card-body">
                            <h5 class="card-title"><%: disco.Titulo %></h5>
                            <p class="card-text"><%: "Fecha de lanzamiento: " + disco.FechaDeLanzamiento.ToShortDateString() %></p>
                            <p class="card-text"><%: "Cantidad de canciones: " + disco.CantCanciones.ToString() %></p>
                            <div class="d-flex justify-content-center">
                                <a class="btn btn-primary" href="AltaDisco.aspx?id=<%:disco.Id.ToString() %>">Ver       Detalles</a>
                            </div>
                        </div>
                    </div>
                </div>
            <%}%>
        </div>

        <%-- forma de generar cards para cada disco con repeater --%>
        <%--<div class="container-fluid row row-cols-1 row-cols-md-4 g-3 mb-3 mt-1">
            <asp:Repeater runat="server" Id="rptCards">
                <ItemTemplate>
                        <div class="col">
                            <div class="card h-100">
                                <img src="<%#Eval("UrlImagen") %>" class="card-img-top card-img-top" alt="<%# "Carátula del disco " + Eval("Titulo") %>">
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("Titulo") %></h5>
                                    <p class="card-text"><%# "Fecha de lanzamiento: " + ((DateTime)Eval("FechaDeLanzamiento")).ToShortDateString() %></p>
                                    <p class="card-text"><%# "Cantidad de canciones: " + Eval("CantCanciones").ToString() %></p>
                                </div>
                                <div>
                                    <asp:Button ID="btnDisco" runat="server" Text="Ver detalles" CommandArgument='<%#Eval("Id")%>' CommandName="discoId" OnClick="btnDisco_Click"/>
                                </div>
                            </div>
                        </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>--%>

    </main>

</asp:Content>
