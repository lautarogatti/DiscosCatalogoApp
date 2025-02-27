<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="discosCatalogoWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <main class="d-flex flex-column align-items-center mt-3 mb-3">
        <h1 class="mb-4">Bienvenido al Catálogo de discos app!</h1>
        <p>En esta aplicación web, podras registrar y gestionar tu catálogo de discos que hayas registrado por este medio o en nuestra versión de escritorio</p>
        <div class="d-flex justify-content-center">
            <a href="Listado.aspx" class="btn btn-primary">Comenzar</a>
        </div>
    </main>
</asp:Content>
