<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rPresupuesto.aspx.cs" Inherits="FinanzasLite2._0.Registros.rPresupuesto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container">
        <div class="row end-row">  
            <div class="col-md-6 col-sm-12">
                <div class="col-md-2 col-sm-2 text-center vertical-center">
                   Presupuesto:    
                </div>
                <div class="col-md-10 col-sm-10">
                    <asp:TextBox ID="PresupuestoTextBox" CssClass="col-md-4 col-sm-4" runat="server"  Height="2.5em"></asp:TextBox>         
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="PresupuestoTextBox" ErrorMessage="*" ValidationGroup="Buscar"></asp:RequiredFieldValidator>
                    <asp:Button ID="BuscarButton" CssClass="col-md-4 col-sm-4 btn btn-default" runat="server" Text="Buscar" Height="2.5em" Width="75px" OnClick="BuscarButton_Click" ValidationGroup="Buscar" />
                    <asp:RegularExpressionValidator ID="IdRegularExpressionValidator" CssClass="col-md-1 col-sm-1" runat="server" ControlToValidate="PresupuestoTextBox" ErrorMessage="Porfavor ingrese un numero" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Buscar"></asp:RegularExpressionValidator>

                </div>
            </div>
        </div>
        <div class="row end-row">
          
            <div class="col-md-6 col-sm-12">   
                <div class="col-md-2 col-sm-2 text-center vertical-center">
                    Descripcion
                </div>
                <div class="col-md-10 col-sm-10">
                    <asp:TextBox ID="DescripcionTextBox" CssClass="col-md-7 col-sm-8" runat="server"  Height="2.5em"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="col-md-5 col-sm-4" runat="server" ControlToValidate="DescripcionTextBox" Display="Dynamic" ErrorMessage="Por favor introduzca una descripcion valido..." ValidationGroup="AgregarNuevo">*</asp:RequiredFieldValidator>

                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 col-sm-12">  
                <div class="col-md-2 col-sm-2 text-center">
                    Tipo de Egreso
                </div>
                <div class="col-md-10 col-sm-10">
                    <asp:DropDownList ID="TipoEgresoDropDownList" CssClass="col-md-8 col-sm-8 dropdown" runat="server"  Height="2.5em" >
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="TipoEgresoRequiredFieldValidator" CssClass="col-md-4 col-sm-4" runat="server" ControlToValidate="TipoEgresoDropDownList" Display="Dynamic" ErrorMessage="Porfavor elige un tipo de egreso valido..." ValidationGroup="AgregarDetalle">Porfavor elige un tipo de egreso valido...</asp:RequiredFieldValidator>

                </div>
            </div>
            <div class="col-md-6 col-sm-12">
                <div class="col-md-2 col-sm-2 text-center vertical-center">
                    Monto
                </div>
                <div class="col-md-10 col-sm-10">
                    <asp:TextBox ID="MontoTextBox" CssClass="col-md-7 col-sm-7" runat="server" ValidationGroup="AgregarDetalle"  Height="2.5em"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="col-md-1 col-sm-1" runat="server" ControlToValidate="MontoTextBox" Display="Dynamic" ErrorMessage="Porfavor digite un monto valido..." ValidationGroup="AgregarDetalle">*</asp:RequiredFieldValidator>
                    <asp:Button ID="AgregarButton" CssClass="col-md-3 col-sm-3 btn btn-default" runat="server" Text="Agregar" Height="2.5em"  OnClick="AgregarButton_Click" ValidationGroup="AgregarDetalle"    />
                    <asp:RegularExpressionValidator ID="MontoRegularExpressionValidator" CssClass="col-md-1 col-sm-1" runat="server" ControlToValidate="MontoTextBox" ErrorMessage="Porfavor ingrese un numero" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="AgregarDetalle"></asp:RegularExpressionValidator>

                </div>
            </div>
        </div>
        <div class="row">
            <asp:GridView ID="DetalleGridView" CssClass="col-md-offset-4 col-sm-offset-4" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="244px" AutoGenerateColumns="False">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Tipo Egreso" HeaderText="Tipo Egreso" ReadOnly="True" />
                    <asp:BoundField DataField="Monto" HeaderText="Monto" ReadOnly="True" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>

        </div>
        <div class="row bottom-row">
            <div class="col-md-4 col-sm-4">
                <asp:Button ID="LimpiarButton" CssClass="col-md-3 col-sm-4 btn btn-primary" runat="server" Text="Limpiar" Height="2.5em" Width="10em"  OnClick="LimpiarButton_Click" />
            </div>
            <div class="col-md-4 col-sm-4">
                <asp:Button ID="GuardarButton" CssClass="col-md-3 col-sm-4 btn btn-success" runat="server" Text="Guardar"  Height="2.5em" Width="10em"  OnClick="GuardarButton_Click" ValidationGroup="AgregarNuevo"  />
            </div>
            <div class="col-md-4 col-sm-4">
                <asp:Button ID="EliminarButton" CssClass="col-md-3 col-sm-4 btn btn-danger" runat="server" Text="Eliminar"  Height="2.5em" Width="10em"  OnClick="EliminarButton_Click" ValidationGroup="Eliminar" />
                <asp:RequiredFieldValidator ID="EliminarRequiredFieldValidator" CssClass="col-md-1 col-sm-1" runat="server" ControlToValidate="PresupuestoTextBox" ErrorMessage="Es necesario elegir un Presupuesto valido para eliminar" ValidationGroup="Eliminar">Porfavor elige un Presupuesto valido.</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="EliminarRegularExpressionValidator" CssClass="col-md-1 col-sm-1 col-md-offset-1 col-sm-offset-1" runat="server" ControlToValidate="PresupuestoTextBox" ErrorMessage="RegularExpressionValidator" ValidationExpression="\d+ " ValidationGroup="Eliminar" Visible="False"></asp:RegularExpressionValidator>
            </div>
        </div>
    </div>
</asp:Content>
