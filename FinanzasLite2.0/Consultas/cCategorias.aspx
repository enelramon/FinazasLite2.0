<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cCategorias.aspx.cs" Inherits="FinanzasLite2._0.Consultas.cCategorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--GRID--%>
    <div class="row">
        <div class="col-md-1"></div>
        <div class="col-md-10">
            <asp:GridView ID="DatosGridView"
                runat="server" class="table table-condensed table-bordered table-responsive"
                CellPadding="4" ForeColor="#333333" GridLines="None">

                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:HyperLinkField ControlStyle-ForeColor="blue" DataNavigateUrlFields="CategoriaId" DataNavigateUrlFormatString="~/Registros/rCategorias.aspx?Id={0}" Text="Editar"></asp:HyperLinkField>
                </Columns>
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
            </asp:GridView>




        </div>
        <div class="col-md-1"></div>
    </div>
</asp:Content>
