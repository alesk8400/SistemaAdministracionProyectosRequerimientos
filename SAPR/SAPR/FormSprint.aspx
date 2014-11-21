<%@ Page Title="" Language="C#" MasterPageFile="~/Neo.Master" AutoEventWireup="true" CodeBehind="FormSprint.aspx.cs" Inherits="SAPR.FormSprint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css"> 
        body {background-color: #B0C4DE ;} 
</style>
    <div class="col-lg-7">
            <div id="alertAlerta" class="alert alert-danger fade in" runat="server" hidden="hidden">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <strong>
                    <asp:Label ID="labelTipoAlerta" runat="server" Text="Alerta! "></asp:Label></strong><asp:Label ID="labelAlerta" runat="server" Text="Mensaje de alerta"></asp:Label>
            </div>
    </div>
    <div class="col-lg-6">
                    <div class="well bs-component">
                        <div class="row  text-center">
                            <legend>Sprints</legend>
                        </div>
                        <fieldset>
                            <div class="row">
                                <button runat="server" id="btnAgregarSprint" onserverclick="btnAgregarSprint_Click" class="btn btn-primary" type="button"><i class="fa fa-plus" ></i>Agregar</button>
                                <button runat="server" id="btnModificarSprint" class="btn btn-primary" type="button" onserverclick="btnModificarSprint_Click"><i class="fa fa-pencil-square-o"></i>Modificar</button>
                                <a id="btnEliminarSprint" href="#modalEliminarSprint" class="btn btn-primary" role="button" data-toggle="modal" runat="server"><i class="fa fa-trash-o fa-lg"></i>Eliminar</a>

                            </div>
                            <br />

                            <div class="row text-center">
                                <div class="col-md-3">
                                    <label for="Sprints">Sprints</label>
                                    <div class="dropdown-toggle">
                                        <asp:DropDownList ID="cmbSprints" runat="server" OnSelectedIndexChanged="cmbSprints_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <label for="txtNombreS">Nombre <font color='red'>*</font></label>
                                    <input id="txtNombreSprint" type="text" runat="server" enabled="false" />
                                </div>
                                <div class="col-md-5">
                                    <label for="txtDescripcionS">Descripción  <font color='red'>*</font></label>
                                    <textarea id="txtDescripcionSprint" cols="30" rows="3" runat="server"></textarea>
                                </div>
                            </div>
                            <br />
                            <div class="text-center">
                                <button runat="server" id="btnAceptarS" class="btn btn-success" type="button" validationgroup="B" xmlns:asp="#unknown" onserverclick="btnAceptar1"><i class="fa fa-pencil-square-o"></i>Aceptar</button>
                                <button runat="server" id="btnCancelarS" class="btn btn-danger" type="button" xmlns:asp="#unknown" onserverclick="btnCancelar1"><i class="fa fa-pencil-square-o"></i>Cancelar</button>
                                 <a id="btnRegresar" href="#modalConfirmar" class="btn btn-info" role="button" data-toggle="modal" runat="server"><i class="fa fa-trash-o fa-lg"></i>Regresar</a>
                            </div>

                        </fieldset>
                        <asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" errormessage="" forecolor="black" controltovalidate="txtNombreSprint" validationgroup="B" initialvalue="" xmlns:asp="#unknown"></asp:requiredfieldvalidator>
                        <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" errormessage="" forecolor="black" controltovalidate="txtDescripcionSprint" validationgroup="B" initialvalue="" xmlns:asp="#unknown"></asp:requiredfieldvalidator>
                    </div>
                </div>
     <div class ="text-center">
        <label for="textObligatorio"><font color = "red"><i>Los campos con (*) son obligatorios</i> </font></label>
    </div>
    <%--Modal Eliminar--%>
     <div class="modal fade" id="modalEliminarSprint" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="modalEliSprint"><i class="fa fa-exclamation-triangle text-danger fa-2x"></i>Confirmar eliminación</h4>
                </div>
                <div class="modal-body">
                    ¿Está seguro que desea eliminar el sprint seleccionado?
                </div>
                <div class="modal-footer">
                    <button type="button" id="botonCancelarModal" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    <button type="button" id="botonAceptarModal" class="btn btn-primary" runat="server" onserverclick="clickAceptarEliminarSprint">Aceptar</button>
                </div>
            </div>
        </div>
    </div>
    <%--Modal Seguro de regresar--%>
     <div class="modal fade" id="modalConfirmar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="modalConfirmacion"><i class="fa fa-exclamation-triangle text-danger fa-2x"></i>Confirmación de Salida</h4>
                </div>
                <div class="modal-body">
                    Todos los cambios que no han sido guardados se perderán. ¿Está seguro de seguir?
                </div>
                <div class="modal-footer">
                    <button type="button" id="botonCancelarModal1" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    <asp:Button ID="btnAceptarC" PostBackUrl="~/FormularioEstructura.aspx" CssClass="btn btn-primary" runat="server" Text="Aceptar" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
