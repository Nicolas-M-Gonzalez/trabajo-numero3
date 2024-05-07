<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ListaArticulo.aspx.cs" Inherits="Trabajo_Final_N_3_Gonzalez_Nicolas.ListaArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class=" p-3 m-auto bg-warning text-dark">
    <h1><u> lista de Articulos </u></h1>
    <asp:gridview id="DgvArticulo" runat="server" CssClass="table" ></asp:gridview>
     </div>  
</asp:Content>

