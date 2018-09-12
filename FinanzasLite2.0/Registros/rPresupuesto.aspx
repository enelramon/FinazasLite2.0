<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rPresupuesto.aspx.cs" Inherits="FinanzasLite2._0.Registros.rPresupuesto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading text-center"><ins><h1>Registro de Presupuesto</h1></ins></div>


            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">

                    <div class="form-group">
                        <label for="PresupuestoTextBox" class="col-md-3 control-label input-sm">Presupuesto</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="PresupuestoTextBox" CssClass=" form-control " placeholder="Presupuesto" runat="server" Height="2.5em"></asp:TextBox>
                            <asp:Button ID="BuscarButton" CssClass=" form-control btn btn-primary" runat="server" Text="Buscar"  OnClick="BuscarButton_Click" ValidationGroup="Buscar" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="PresupuestoTextBox" ErrorMessage="*" ValidationGroup="Buscar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="IdRegularExpressionValidator" runat="server" ControlToValidate="PresupuestoTextBox" ErrorMessage="Porfavor ingrese un numero" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Buscar"></asp:RegularExpressionValidator>
                        </div>
                    </div>


                    <div class="form-group">
                        <label for="DescripcionTextBox" class="col-md-3 control-label input-sm">Descripcion</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="DescripcionTextBox" CssClass=" form-control" placeholder="Descripción" runat="server" Height="2.5em"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="col-md-5 col-sm-4" runat="server" ControlToValidate="DescripcionTextBox" Display="Dynamic" ErrorMessage="Por favor introduzca una descripcion valido..." ValidationGroup="AgregarNuevo">*</asp:RequiredFieldValidator>

                        </div>
                    </div>


                    <div class="form-group">
                        <label for="TipoEgresoDropDownList" class="col-md-3 control-label input-sm">Tipo Egreso</label>
                        <div class="col-md-8">
                            <asp:DropDownList ID="TipoEgresoDropDownList" CssClass=" form-control dropdown" AppendDataBoundItems="true" runat="server" Height="2.5em">
                                <asp:ListItem Text="Prueba" />
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="TipoEgresoRequiredFieldValidator" CssClass="col-md-4 col-sm-4" runat="server" ControlToValidate="TipoEgresoDropDownList" Display="Dynamic" ErrorMessage="Porfavor elige un tipo de egreso valido..." ValidationGroup="AgregarDetalle">Porfavor elige un tipo de egreso valido...</asp:RequiredFieldValidator>

                        </div>
                    </div>

                    <div class="form-group">
                        <label for="MontoTextBox" class="col-md-3 control-label input-sm">Monto</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="MontoTextBox" CssClass=" form-control " placeholder="Monto" runat="server" ValidationGroup="AgregarDetalle" Height="2.5em"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="MontoTextBox" Display="Dynamic" ErrorMessage="Porfavor digite un monto valido..." ValidationGroup="AgregarDetalle">*</asp:RequiredFieldValidator>
                            <asp:Button ID="AgregarButton" CssClass=" form-control btn btn-primary" runat="server" Text="Agregar" Height="2.5em" OnClick="AgregarButton_Click" ValidationGroup="AgregarDetalle" />
                            <asp:RegularExpressionValidator ID="MontoRegularExpressionValidator" runat="server" ControlToValidate="MontoTextBox" ErrorMessage="Porfavor ingrese un numero" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="AgregarDetalle"></asp:RegularExpressionValidator>

                        </div>
                    </div>


                    <div class="row">
                        <asp:GridView ID="DetalleGridView" CssClass=" col-md-offset-4 col-sm-offset-4" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="244px" AutoGenerateColumns="true">
                            <AlternatingRowStyle BackColor="White" />
                           
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

                </div>

            </div>
            <div class="panel-footer">
                <div class="text-center">
                    <div class="form-group" style="display: inline-block">


                        <asp:Button ID="LimpiarButton" CssClass=" col-md-4 col-sm-4 btn btn-primary" runat="server" Text="Limpiar" Height="2.5em" Width="10em" OnClick="LimpiarButton_Click" />
                        <asp:Button ID="GuardarButton" CssClass="col-md-4 col-sm-4 btn btn-success" runat="server" Text="Guardar" Height="2.5em" Width="10em" OnClick="GuardarButton_Click" ValidationGroup="AgregarNuevo" />
                        <asp:Button ID="EliminarButton" CssClass="col-md-4 col-sm-4 btn btn-danger" runat="server" Text="Eliminar" Height="2.5em" Width="10em" OnClick="EliminarButton_Click" ValidationGroup="Eliminar" />
                        <asp:RequiredFieldValidator ID="EliminarRequiredFieldValidator" CssClass="col-md-1 col-sm-1" runat="server" ControlToValidate="PresupuestoTextBox" ErrorMessage="Es necesario elegir un Presupuesto valido para eliminar" ValidationGroup="Eliminar">Porfavor elige un Presupuesto valido.</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="EliminarRegularExpressionValidator" CssClass="col-md-1 col-sm-1 col-md-offset-1 col-sm-offset-1" runat="server" ControlToValidate="PresupuestoTextBox" ErrorMessage="RegularExpressionValidator" ValidationExpression="\d+ " ValidationGroup="Eliminar" Visible="False"></asp:RegularExpressionValidator>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
