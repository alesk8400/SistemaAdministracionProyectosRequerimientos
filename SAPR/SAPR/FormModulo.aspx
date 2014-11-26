<%@ Page Title="" Language="C#" MasterPageFile="~/Neo.Master" AutoEventWireup="true" CodeBehind="FormModulo.aspx.cs" Inherits="SAPR.FormModulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <br />
    <div class="col-lg-7">
            <div id="alertAlerta" class="alert alert-danger fade in" runat="server" hidden="hidden">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <strong>
                    <asp:Label ID="labelTipoAlerta" runat="server" Text="Alerta! "></asp:Label></strong><asp:Label ID="labelAlerta" runat="server" Text="Mensaje de alerta"></asp:Label>
            </div>
    </div>
        <br />
        <br />

    <div class ="row">
    <div class="col-lg-6">
        <div style="width:100%; margin-right: 800px; margin-left: 400px; position:relative; float: left">   
                    <div class="well bs-component">
                        <div class="row text-center">

            <legend>Módulos</legend>          
        </div>
            <fieldset>
                <div class="row">
                 <button runat="server" id="btnAgregarModulo" onserverclick="btnAgregarModulo_Click" class="btn btn-primary" type="button"><i class="fa fa-plus"></i>Agregar</button>
                    <button runat="server"  id="btnModificarModulo" class="btn btn-primary" type="button" onserverclick="btnModificarModulo_Click"><i class="fa fa-pencil-square-o"></i>Modificar</button>
                    <a id="modaleliminarModulo" href="#modalEliminarModulo" class="btn btn-primary" role="button" data-toggle="modal" runat ="server"><i class="fa fa-trash-o fa-lg"></i>Eliminar</a>
                </div>
                <br />
                <div class="row text-center">
                    <div class="col-md-2">
                    <label for="Sprints">Sprints</label>              
                    </div>

                    <div class= "col-md-2">
                    <label for="Modulos">Módulos</label>
                    
                    </div>
                    <div class="col-md-4">
                    <label for="txtNombreM">Nombre <font color='red'>*</font> </label>
                  
                    </div>
                    <div class="col-md-4">
                    <label for="txtDescripcionM">Descripción  <font color='red'>*</font> </label>
           
                    </div>
                    </div>

                <div class="row text-center">
                    <div class="col-md-2">
                                
                    <div class="dropdown-toggle">
                    <asp:DropDownList ID="cmbSprints" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbSprints_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                        </div>
                  <div class="col-md-2">
                    <div class="dropdown-toggle">
                    <asp:DropDownList ID="cmbModulo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbModulo_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    </div>
                    <div class="col-md-4">
                 
                    <input id="txtNombreModulo" runat ="server" type="text" />
                    </div>
                    <div class="col-md-4">
                   
                    <textarea id="txtDescripcionModulo" runat ="server" cols="30" rows="3"></textarea>
                    </div>
                
                
                
                </div>

                    <br />
                    <div class="text-center">
                    <%--<button runat="server" id="Button1" class="btn btn-success" type="button" validationgroup="C" xmlns:asp="#unknown" onserverclick="btnAceptar2"><i class="fa fa-pencil-square-o"></i>Aceptar</button>--%>
                    <button runat="server" id="btnAceptarM" class="btn btn-success" type="button" validationgroup="C" xmlns:asp="#unknown" onserverclick="btnAceptar2"><i class="fa fa-pencil-square-o"></i>Aceptar</button>
                    <button runat="server" id="btnCancelarM" class="btn btn-danger" type="button"  xmlns:asp="#unknown" onserverclick="btnCancelar2"><i class="fa fa-pencil-square-o"></i>Cancelar</button>
                    <a id="btnRegresar" href="#modalConfirmar" class="btn btn-info" role="button" data-toggle="modal" runat="server"><i class="fa fa-trash-o fa-lg"></i>Regresar</a>
                    </div>
                
            </fieldset>
             <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" errormessage="" forecolor="black" controltovalidate="txtNombreModulo" validationgroup="C" initialvalue="" xmlns:asp="#unknown"></asp:requiredfieldvalidator>
            <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" errormessage="" forecolor="black" controltovalidate="txtDescripcionModulo" validationgroup="C" initialvalue="" xmlns:asp="#unknown"></asp:requiredfieldvalidator>
        </div>
            </div>
        </div>
    </div>

     <div class ="row">
     <div class ="text-center">
        <label for="textObligatorio"><font color = "red"><i>Los campos con (*) son obligatorios</i> </font></label>
    </div>
         </div>
    <!--Modal EliminarModulo-->
    <div class="modal fade" id="modalEliminarModulo" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="modalEliModulo"><i class="fa fa-exclamation-triangle text-danger fa-2x"></i>Confirmar eliminación</h4>
                </div>
                <div class="modal-body">
                    ¿Está seguro que desea eliminar el modulo seleccionado?
                </div>
                <div class="modal-footer">
                    <button type="button" id="botonCancelarModalModulo" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    <button type="button" id="Button3" class="btn btn-primary" runat="server" onserverclick="clickAceptarEliminarModulo">Aceptar</button>
                    
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
