﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Neo.Master" AutoEventWireup="true" CodeBehind="FormularioProyecto.aspx.cs" Inherits="SAPR.FormularioProyecto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div class="page-header">
        <div class="row">
            <div class="col-lg-11">
                <h1><i class="fa fa-truck"></i>Proyecto</h1>
            </div>
            <div class="col-lg-1">
                <h2><a id="informacion" href="#modalInformacion" data-toggle="modal" runat="server"><i class="fa fa-question-circle text-info"></i></a></h2>
            </div>
        </div>
    </div>
    <div class="row row-botones">
        <div class="col-lg-5">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <button runat="server"  id="botonAgregar" class="btn btn-primary" type="button"><i class="fa fa-plus"></i>Agregar</button>
            <button runat="server" id="botonModificar" class="btn btn-primary" type="button"><i class="fa fa-pencil-square-o"></i>Modificar</button>
            <a id="botonEliminar" href="#modalEliminar" class="btn btn-primary" role="button" data-toggle="modal" runat="server"><i class="fa fa-trash-o fa-lg"></i>Eliminar</a>
        </div>
        <div class="col-lg-7">
            <div id="alertAlerta" class="alert alert-danger fade in" runat="server" hidden="hidden">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <strong>
                    <asp:Label ID="labelTipoAlerta" runat="server" Text="Alerta! "></asp:Label></strong><asp:Label ID="labelAlerta" runat="server" Text="Mensaje de alerta"></asp:Label>
            </div>
        </div>
        <br/>
    </div>

        <!--Datos del Proyecto-->
        <div class="col-lg-12">
            <div class="well bs-component">
                <fieldset>
                    <legend>Información de Proyecto</legend>

                    <div class="col-sm-4">
                    <div class="form-group">
                        <label for="textNombre" class="col-sm-3 control-label">Nombre: </label>
                        <div class="col-sm-9">
                            <div class=" input-group margin-bottom-sm">
                                <input runat="server" id="textNombre" class="form-control" type="text" placeholder="Nombre de Proyecto" data-error="Ingresó una nombre inválido" title="Nombre" pattern="^[a-zA-Z0-9 ]+$" data-minlength="5" maxlength="44" required="required" />
                                <span class="input-group-addon"><i class="fa fa-check fa-fw"></i></span>
                            </div>
                            <div class="help-block with-errors"></div>
                        </div></div>


                    <div class="form-group">
                        <label for="textObjetivo" class="col-sm-3 control-label">Objetivo: </label>
                        <div class="col-sm-9">
                            <div class=" input-group margin-bottom-sm">
                                <input runat="server" id="textObjetivo" class="form-control" type="text" placeholder="Objetivo de Proyecto" data-error="Espacio requerido. Sólo letras." title="Objetivos" required="required" pattern="^[a-zA-Z0-9 ]+$" data-minlength="5" maxlength="299" />
                                <span class="input-group-addon"><i class="fa fa-check fa-fw"></i></span>
                            </div>
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>

                        </div>

                    <div class="col-sm-4">

                       <%-- FALTA TRABAJARLO--%>
                    <div class="form-group">
                        <label for="dateAsignacion" class="col-sm-3 control-label">Fecha de asignación: </label>
                            <div class="col-sm-9">
                                <input type="text" class="datepicker"/>
                                <div class="help-block with-errors"></div>
                            </div>
                    </div>
             

                     
                    <div class="form-group">
                        <label for="textTelefono" class="col-sm-3 control-label">Teléfono: </label>
                        <div class="col-sm-9">
                            <input runat="server" id="textTelefono" class="form-control" type="tel" placeholder="Teléfono" data-error="Número de teléfono inválido" title="telefono" pattern="^[0-9]*$" data-minlength="8" maxlength="12" />
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="textCelular" class="col-sm-3 control-label">Celular: </label>
                        <div class="col-sm-9">
                            <input runat="server" id="textCelular" class="form-control" type="tel" placeholder="Celular" data-error="Número de teléfono inválido" title="Celular" pattern="^[0-9]*$" data-minlength="8" maxlength="12" />
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>
                        </div>
                        
                            <div class="col-sm-4">
                    <div class="form-group">
                        <label for="textEmail" class="col-sm-3 control-label">E-mail: </label>
                        <div class="col-sm-9">
                            <input runat="server" id="textEmail" class="form-control" type="email" placeholder="E-mail" data-error="Correo inválido" />
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>
                         

                     
                    <div class="form-group">
                        <label for="textURL" class="col-sm-3 control-label">Página web: </label>
                        <div class="col-sm-9">
                            <input runat="server" id="textURL" class="form-control" type="url" placeholder="Página web" data-error="Dirección inválida" />
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>
                         

                    <div class="form-group">
                        <span class="label label-primary pull-right"><i class="fa fa-check fa-fw"></i>Espacio requerido</span>
                    </div>
                                </div>
                </fieldset>
            </div>

        </div>
    <!--Datos de contacto-->
    <div class="col-lg-12">
            <div class="well bs-component">
                <fieldset>
                    <legend>Información de Contacto</legend>

                    <div class="col-sm-4">
                    <div class="form-group">
                        <label for="textCedula" class="col-sm-3 control-label">Cédula: </label>
                        <div class="col-sm-9">
                            <div class=" input-group margin-bottom-sm">
                                <input runat="server" id="text2" class="form-control" type="text" placeholder="Cédula" data-error="Ingresó una cédula inválida" title="Cédula" pattern="^[0-9]*$" data-minlength="9" maxlength="12" required="required" />
                                <span class="input-group-addon"><i class="fa fa-check fa-fw"></i></span>
                            </div>
                            <div class="help-block with-errors"></div>
                        </div></div>


                    <div class="form-group">
                        <label for="textNombre" class="col-sm-3 control-label">Empresa: </label>
                        <div class="col-sm-9">
                            <div class=" input-group margin-bottom-sm">
                                <input runat="server" id="text3" class="form-control" type="text" placeholder="Nombre" data-error="Espacio requerido. Sólo letras y números." title="Empresa" required="required" pattern="^[a-zA-Z0-9 ]+$" />
                                <span class="input-group-addon"><i class="fa fa-check fa-fw"></i></span>
                            </div>
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>

                        </div>

                    <div class="col-sm-4">
                    <div class="form-group">
                        <label for="textEncargado" class="col-sm-3 control-label">Encargado: </label>
                        <div class="col-sm-9">
                            <input runat="server" id="text4" class="form-control" type="text" placeholder="Encargado" data-error="Nombre de encargado no válido" title="Encargado" pattern="^[a-zA-Z ]*$" />
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>
                       

                     
                    <div class="form-group">
                        <label for="textTelefono" class="col-sm-3 control-label">Teléfono: </label>
                        <div class="col-sm-9">
                            <input runat="server" id="Tel1" class="form-control" type="tel" placeholder="Teléfono" data-error="Número de teléfono inválido" title="telefono" pattern="^[0-9]*$" data-minlength="8" maxlength="12" />
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="textCelular" class="col-sm-3 control-label">Celular: </label>
                        <div class="col-sm-9">
                            <input runat="server" id="Tel2" class="form-control" type="tel" placeholder="Celular" data-error="Número de teléfono inválido" title="Celular" pattern="^[0-9]*$" data-minlength="8" maxlength="12" />
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>
                        </div>
                        
                            <div class="col-sm-4">
                    <div class="form-group">
                        <label for="textEmail" class="col-sm-3 control-label">E-mail: </label>
                        <div class="col-sm-9">
                            <input runat="server" id="Email1" class="form-control" type="email" placeholder="E-mail" data-error="Correo inválido" />
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>
                         

                     
                    <div class="form-group">
                        <label for="textURL" class="col-sm-3 control-label">Página web: </label>
                        <div class="col-sm-9">
                            <input runat="server" id="Url1" class="form-control" type="url" placeholder="Página web" data-error="Dirección inválida" />
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>
                         

                    <div class="form-group">
                        <span class="label label-primary pull-right"><i class="fa fa-check fa-fw"></i>Espacio requerido</span>
                    </div>
                                </div>
                </fieldset>
            </div>

        </div>

      <!--Información del equipo-->
            <div class="col-lg-12">
            <div class="well bs-component">
                <fieldset>
                    <legend>Información del Equipo</legend>

                    <div class="col-sm-4">
                    <div class="form-group">
                        <label for="textCedula" class="col-sm-3 control-label">Cédula: </label>
                        <div class="col-sm-9">
                            <div class=" input-group margin-bottom-sm">
                                <input runat="server" id="text1" class="form-control" type="text" placeholder="Cédula" data-error="Ingresó una cédula inválida" title="Cédula" pattern="^[0-9]*$" data-minlength="9" maxlength="12" required="required" />
                                <span class="input-group-addon"><i class="fa fa-check fa-fw"></i></span>
                            </div>
                            <div class="help-block with-errors"></div>
                        </div></div>


<%--                    <div class="form-group">
                        <label for="textNombre" class="col-sm-3 control-label">Empresa: </label>
                        <div class="col-sm-9">
                            <div class=" input-group margin-bottom-sm">
                                <input runat="server" id="text2" class="form-control" type="text" placeholder="Nombre" data-error="Espacio requerido. Sólo letras y números." title="Empresa" required="required" pattern="^[a-zA-Z0-9 ]+$" />
                                <span class="input-group-addon"><i class="fa fa-check fa-fw"></i></span>
                            </div>
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>

                        </div>

                    <div class="col-sm-4">
                    <div class="form-group">
                        <label for="textEncargado" class="col-sm-3 control-label">Encargado: </label>
                        <div class="col-sm-9">
                            <input runat="server" id="text3" class="form-control" type="text" placeholder="Encargado" data-error="Nombre de encargado no válido" title="Encargado" pattern="^[a-zA-Z ]*$" />
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>
                       

                     
                    <div class="form-group">
                        <label for="textTelefono" class="col-sm-3 control-label">Teléfono: </label>
                        <div class="col-sm-9">
                            <input runat="server" id="Tel1" class="form-control" type="tel" placeholder="Teléfono" data-error="Número de teléfono inválido" title="telefono" pattern="^[0-9]*$" data-minlength="8" maxlength="12" />
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="textCelular" class="col-sm-3 control-label">Celular: </label>
                        <div class="col-sm-9">
                            <input runat="server" id="Tel2" class="form-control" type="tel" placeholder="Celular" data-error="Número de teléfono inválido" title="Celular" pattern="^[0-9]*$" data-minlength="8" maxlength="12" />
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>
                        </div>
                        
                            <div class="col-sm-4">
                    <div class="form-group">
                        <label for="textEmail" class="col-sm-3 control-label">E-mail: </label>
                        <div class="col-sm-9">
                            <input runat="server" id="Email1" class="form-control" type="email" placeholder="E-mail" data-error="Correo inválido" />
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>
                         

                     
                    <div class="form-group">
                        <label for="textURL" class="col-sm-3 control-label">Página web: </label>
                        <div class="col-sm-9">
                            <input runat="server" id="Url1" class="form-control" type="url" placeholder="Página web" data-error="Dirección inválida" />
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>--%>
                         

                    <div class="form-group">
                        <span class="label label-primary pull-right"><i class="fa fa-check fa-fw"></i>Espacio requerido</span>
                    </div>
                                </div>
                </fieldset>
            </div>
                                        <div class="row">
                <div class="col-lg-12">
                    <div class="text-center">
                <button runat="server" id="botonAceptar" class="btn btn-success" type="submit">Aceptar</button>
                <button runat="server" id="botonCancelar" class="btn btn-danger" type="reset">Cancelar</button>
                        </div></div>
            </div>
        </div>
</asp:Content>
