﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Neo.Master" AutoEventWireup="true" CodeBehind="FormularioRequerimientos.aspx.cs" Inherits="SAPR.FormularioRequerimientos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <div class="page-header">
        <div class="row">
            <div class="col-lg-11">
                <h1><i class="fa fa-truck"></i>Requerimientos</h1>
            </div>
           <div class =" col-lg-1">
                <a id="AYUDA" href="#modalAyuda" class="btn alert-link" role="button" data-toggle="modal" runat="server"><h4>Ayuda</h4></a> 
            </div>
        </div>
    </div>
<div class="well bs-component">
    <div class="row">
        <div class="col-md-4">
            <label for="text" > <font size ="3">Elegir Proyecto: </font> </label>
                
                         <asp:DropDownList ID="cmbProyecto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbProyecto_SelectedIndexChanged" AppendDataBoundItems="True">
                             <asp:ListItem>Seleccione...</asp:ListItem>
                         </asp:DropDownList>                 
        </div>
     </div>
    <legend class="text-center">Información de Proyecto</legend> 
     <div class="col-lg-6" style="margin-left:25%">    
                                         
                    <asp:GridView ID="gridProyecto" runat="server" AutoGenerateColumns="true" CssClass ="table  text-center"  ForeColor="Black" AllowPaging="True">
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Blue" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>                            
    </div>




    <legend class="text-center">Listado de Requerimientos</legend>

    <div class="row">
    <div class="col-lg-7" style="margin-left:22%">                                        
        
        <asp:GridView ID="gridRequerimientos" runat="server" cssClass="table table-bordered" BackColor="White" OnSelectedIndexChanged="GridRequerimientos_SelectedIndexChanged" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
            <Columns>
                <asp:ButtonField CommandName="Select" Text="Consultar" ShowHeader="True" HeaderText="Consultar"></asp:ButtonField>
            </Columns>

            <FooterStyle BackColor="#CCCC99" ForeColor="Black"></FooterStyle>

            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White"></HeaderStyle>

            <PagerStyle HorizontalAlign="Right" BackColor="White" ForeColor="Black"></PagerStyle>

            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

            <SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>

            <SortedAscendingHeaderStyle BackColor="#4B4B4B"></SortedAscendingHeaderStyle>

            <SortedDescendingCellStyle BackColor="#E5E5E5"></SortedDescendingCellStyle>

            <SortedDescendingHeaderStyle BackColor="#242121"></SortedDescendingHeaderStyle>
        </asp:GridView>
    </div>
        </div>
</div>
        <div class="row row-botones">
        <div class="col-lg-5">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <button runat="server" id="btnAgregarReque" onserverclick="btnAgregarReque_Click" class="btn btn-primary" type="button"><i class="fa fa-pencil-square-o"></i>Agregar</button>
            <button runat="server" id="btnModificarReque" onserverclick="btnModificarReque_Click" class="btn btn-primary" type="button" visible="True"><i class="fa fa-pencil-square-o"></i>Modificar</button>
            <a id="btnEliminarReque" href="#modalEliminar" class="btn btn-primary" role="button" data-toggle="modal" runat ="server"><i class="fa fa-trash-o fa-lg"></i>Eliminar</a>
          
    
          
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
    <div class="well bs-component">
        <div class="col-lg-12 text-center">
            <%--  <div class="well bs-component">--%>
            <%--    <fieldset>--%>
            <legend>Información de Requerimientos</legend>
            <div class="row">
                <div class="col-md-4">
                    <label for="textNombreR">Nombre del Requerimiento  <font color='red'>*</font></label>
                    <input runat="server" id="textNombreR" class="form-control" type="text" placeholder="Debe tener entre 5 y 44 caracteres" title="NombreR" required="required" />
                    <asp:RegularExpressionValidator runat="server"
                        ControlToValidate="textNombreR"
                        ErrorMessage="Nombre Requerimiento Inválido. Debe tener entre 2 y 44 caracteres"
                        ValidationExpression="^[a-zA-Z0-9\s]{2,44}$" />
                    <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" errormessage="" forecolor="black" controltovalidate="textNombreR" validationgroup="A" initialvalue="" xmlns:asp="#unknown"></asp:requiredfieldvalidator>

                    <div class="help-block with-errors"></div>
                </div>

                <div class="col-md-4">
                    <label for="textDescripcionR">Descripción del Requerimiento  <font color='red'>*</font></label>
                    <textarea runat="server" id="textD" class="form-control" type="text" placeholder="Debe tener entre 5 y 300 caracteres" title="Descripcion" required="required" />
                    <asp:RegularExpressionValidator runat="server"
                        ControlToValidate="textD"
                        ErrorMessage="Descripcion Requerimiento Inválido. Debe tener entre 2 y 44 caracteres"
                        ValidationExpression="^[a-zA-Z0-9\s]{2,44}$" />
                    <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" errormessage="dasd" forecolor="black" controltovalidate="textD" validationgroup="A" initialvalue="" xmlns:asp="#unknown"></asp:requiredfieldvalidator>
                </div>

                <div class="col-md-2">
                    <label for="textCantidadR">Cantidad Estimada: <font color='red'>*</font></label>
                    <input runat="server" id="txtCantidadR" class="form-control" type="text" placeholder="Estime una cantidad" title="CantidadR" required="required" />
                    <asp:RegularExpressionValidator runat="server"
                        ControlToValidate="txtCantidadR"
                        ErrorMessage="Inserte una cantidad. Solo números."
                        ValidationExpression="^[0-9]+$" />
                    <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" errormessage="Digite cantidad" forecolor="black" controltovalidate="txtCantidadR" validationgroup="A" initialvalue="" xmlns:asp="#unknown"></asp:requiredfieldvalidator>

                    <div class="help-block with-errors"></div>
                </div>

                <div class="col-md-2">
                    <label for="textMedi">Medida:</font></label>
                    <div class="dropdown-toggle">
                        <asp:DropDownList ID="cmbMedida" runat="server">
                            <asp:ListItem>Horas</asp:ListItem>
                            <asp:ListItem>Días</asp:ListItem>
                            <asp:ListItem>Puntos</asp:ListItem>
                        </asp:DropDownList>
                        <div class="help-block with-errors"></div>
                    </div>

                </div>

            </div>

            <div class="row">

                <div class="col-md-2">
                    <label for="textPrio">Prioridad:</font></label>
                    <div class="dropdown-toggle">
                        <asp:DropDownList ID="cmbPrioridad" runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                        </asp:DropDownList>
                        <div class="help-block with-errors"></div>
                    </div>
                    </asp:DropDownList>
                </div>

                <div class="col-md-2">
                    <label for="textPrio">Estado:</font></label>
                    <div class="dropdown-toggle">
                        <asp:DropDownList ID="cmbEstado" runat="server">
                            <asp:ListItem>Sin Asignar</asp:ListItem>
                            <asp:ListItem>Asignado</asp:ListItem>
                            <asp:ListItem>En ejecucion</asp:ListItem>
                            <asp:ListItem>Finalizado</asp:ListItem>
                            <asp:ListItem>Cerrado</asp:ListItem>
                        </asp:DropDownList>
                        <div class="help-block with-errors"></div>
                    </div>
                    </asp:DropDownList>
                </div>


                <div class="col-md-2">
                    <label for="textSprint">Sprint:</font></label>
                    <div class="dropdown-toggle">
                        <asp:DropDownList ID="cmbSprint" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbSprint_SelectedIndexChanged">
                        </asp:DropDownList>
                        <div class="help-block with-errors"></div>
                    </div>
                    </asp:DropDownList>
                </div>

                <div class="col-md-2">
                    <label for="textModulo">Módulo:</font></label>
                    <div class="dropdown-toggle">
                        <asp:DropDownList ID="cmbModulo" runat="server">
                        </asp:DropDownList>
                        <div class="help-block with-errors"></div>
                    </div>
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:FileUpload ID="subirArchivo" runat="server" class="btn btn-link" OnFileUploaded="UploadFile_FileUploaded" />
                </div>
            </div>

            <br />
            <br />

            <div class="row">
                <div class="col-lg-12">
                    <div class="text-center">
                        <button runat="server" id="botonAceptarR" onserverclick="botonAceptarR_ServerClick" class="btn btn-success" type="submit" xmlns:asp="#unknown">Aceptar</button>
                        <a id="botonCancelar" href="#modalCancelar" class="btn btn-danger" role="button" data-toggle="modal" runat="server"><i class="fa fa-trash-o fa-lg"></i>Cancelar</a>
                    </div>
                </div>
                <br />
        <br />
                <br />
        <br />
            </div>
        </div>
        
        

        <div class="col-lg-7">
            <div id="Div1" class="alert alert-danger fade in" runat="server" hidden="hidden">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <strong>
                    <asp:Label ID="label1" runat="server" Text="Alerta! "></asp:Label></strong><asp:Label ID="label2" runat="server" Text="Mensaje de alerta"></asp:Label>
            </div>
        </div>

                <legend class="text-center">Criterios de Aceptación</legend>

        <div class="row row-botones">
            <div class="col-lg-5">
            <button runat="server" id="btnAgregarCriterio" onserverclick="btnAgregarCriterio_ServerClick" class="btn btn-primary" type="button"><i class="fa fa-pencil-square-o"></i>Agregar</button>
                <button runat="server" id="btnModificarCriterio" onserverclick="btnModificarCriterio_ServerClick" class="btn btn-primary" type="button" visible="True"><i class="fa fa-pencil-square-o"></i>Modificar</button>
                <a id="btnEliminarCriterio" href="#modalEliminarCriterio" class="btn btn-primary" role="button" data-toggle="modal" runat="server"><i class="fa fa-trash-o fa-lg"></i>Eliminar</a>

            </div>          
            <br />
        </div>
        <div class="row" style= "width: 100%; margin-right: 550px; margin-left: 22%; position: relative; float: left">
            <div class="col-md-4">
                <label for="txtNombreCri">Nombre del Criterio  <font color='red'>*</font></label>
                <input runat="server" id="nombreCriterio" class="form-control" type="text" placeholder="Debe tener entre 5 y 44 caracteres" title="NombreC" required="required" />
                <asp:RegularExpressionValidator runat="server"
                    ControlToValidate="nombreCriterio"
                    ErrorMessage="Nombre Criterio Inválido. Debe tener entre 2 y 44 caracteres"
                    ValidationExpression="^[a-zA-Z0-9\s]{2,44}$" />
                <asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" errormessage="" forecolor="black" controltovalidate="nombreCriterio" validationgroup="A" initialvalue="" xmlns:asp="#unknown"></asp:requiredfieldvalidator>

                <div class="help-block with-errors"></div>
            </div>

            <div class="col-md-2">
                <label for="txtEscena">Escenario  <font color='red'>*</font></label>
                <input runat="server" id="txtEscenario" class="form-control" type="text" placeholder="Digitos" title="Escenario" required="required" />
                <asp:RegularExpressionValidator runat="server"
                    ControlToValidate="txtEscenario"
                    ErrorMessage="Escenario Inválido"
                    ValidationExpression="^[a-zA-Z0-9\s]{2,44}$" />
                <asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" errormessage="" forecolor="black" controltovalidate="txtEscenario" validationgroup="A" initialvalue="" xmlns:asp="#unknown"></asp:requiredfieldvalidator>

                <div class="help-block with-errors"></div>
            </div>
            </div>

            <div class="row" style= "width: 100%; margin-right: 550px; margin-left: 22%; position: relative; float: left">
                <div class="col-md-4">
                    <label for="textContexto">Contexto  <font color='red'>*</font></label>
                    <textarea runat="server" id="txtContexto" class="form-control" type="text" placeholder="Debe tener entre 5 y 300 caracteres" title="Descripcion" required="required" />
                    <asp:RegularExpressionValidator runat="server"
                        ControlToValidate="txtContexto"
                        ErrorMessage="Contexto Inválido."
                        ValidationExpression="^[a-zA-Z0-9\s]{2,44}$" />
                    <asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" errormessage="" forecolor="black" controltovalidate="txtContexto" validationgroup="A" initialvalue="" xmlns:asp="#unknown"></asp:requiredfieldvalidator>
                </div>
                <div class="col-md-4">
                    <label for="textResultado">Resultado  <font color='red'>*</font></label>
                    <textarea runat="server" id="txtRes" class="form-control" type="text" placeholder="Debe tener entre 5 y 300 caracteres" title="Resultado" required="required" />
                    <asp:RegularExpressionValidator runat="server"
                        ControlToValidate="txtRes"
                        ErrorMessage="Contexto Inválido."
                        ValidationExpression="^[a-zA-Z0-9\s]{2,44}$" />
                    <asp:requiredfieldvalidator id="RequiredFieldValidator7" runat="server" errormessage="" forecolor="black" controltovalidate="txtRes" validationgroup="A" initialvalue="" xmlns:asp="#unknown"></asp:requiredfieldvalidator>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="text-center">
                        <button runat="server" id="btnAcepCri" onserverclick="btnAceptarC_Click" class="btn btn-success" type="submit" validationgroup="A" xmlns:asp="#unknown">Aceptar</button>
                        <a id="btnCanCri" href="#modalCancelar" class="btn btn-danger" role="button" data-toggle="modal" runat="server"><i class="fa fa-trash-o fa-lg"></i>Cancelar</a>
                    </div>
                </div>
            </div>
        </div>
       
     <legend class="text-center">Listado de Criterios</legend>

    
                         
     <div class="row">
    <div class="col-lg-7" style="margin-left:25%">                                        
        
        <asp:GridView ID="gridCriterios" runat="server" cssClass="table table-bordered" OnSelectedIndexChanged="gridCriterios_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
            <Columns>
                <asp:ButtonField CommandName="Select" Text="Consultar" ShowHeader="True" HeaderText="Consultar"></asp:ButtonField>
            </Columns>

            <FooterStyle BackColor="#CCCC99" ForeColor="Black"></FooterStyle>

            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White"></HeaderStyle>

            <PagerStyle HorizontalAlign="Right" BackColor="White" ForeColor="Black"></PagerStyle>

            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

            <SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>

            <SortedAscendingHeaderStyle BackColor="#4B4B4B"></SortedAscendingHeaderStyle>

            <SortedDescendingCellStyle BackColor="#E5E5E5"></SortedDescendingCellStyle>

            <SortedDescendingHeaderStyle BackColor="#242121"></SortedDescendingHeaderStyle>
        </asp:GridView>
    </div>
        </div> 

     <!--Modal Eliminar-->
    <div class="modal fade" id="modalEliminar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel"><i class="fa fa-exclamation-triangle text-danger fa-2x"></i>Confirmar eliminación</h4>
                </div>
                <div class="modal-body">
                    ¿Está seguro que desea eliminar el Requerimiento seleccionado?
                </div>
                <div class="modal-footer">
                    <button type="button" id="botonCancelarModal" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    <button type="button" id="botonAceptarModal" class="btn btn-primary" runat="server" onserverclick ="botonAceptarModalReque_ServerClick">Aceptar</button>
                </div>
            </div>
        </div>
    </div>


    <!--Modal Cancelar-->
    <div class="modal fade" id="modalCancelar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myOtherModal"><i class="fa fa-exclamation-triangle text-danger fa-2x"></i>Confirmar cancelación</h4>
                </div>
                <div class="modal-body">
                    ¿Está seguro que desea cancelar los cambios? Perdería todos los datos ingresados hasta el momento.
                </div>
                <div class="modal-footer">
                    <button type="button" id="botonCancelarModal1" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    <button type="button" id="botonAceptarCancelar" class="btn btn-primary" runat="server" onserverclick="botonAceptarCancelar_ServerClick">Aceptar</button>
                </div>
            </div>
        </div>
    </div>


         <!--Modal Eliminar Criterio-->
    <div class="modal fade" id="modalEliminarCriterio" tabindex="-1" role="dialog" aria-labelledby="myModalLabelCriterio" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabelCriterio"><i class="fa fa-exclamation-triangle text-danger fa-2x"></i>Confirmar eliminación</h4>
                </div>
                <div class="modal-body">
                    ¿Está seguro que desea eliminar el Criterio de Aceptación seleccionado?
                </div>
                <div class="modal-footer">
                    <button type="button" id="botonCancelarModalCriterio" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    <button type="button" id="botonAceptarModalCriterio" class="btn btn-primary" runat="server" onserverclick="botonAceptarModalCriterio_ServerClick">Aceptar</button>
                </div>
            </div>
        </div>
    </div>


    <!--Modal Cancelar Criterio-->
    <div class="modal fade" id="modalCancelarCriterio" tabindex="-1" role="dialog" aria-labelledby="myModalLabelCriterio" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myOtherModalCriterio"><i class="fa fa-exclamation-triangle text-danger fa-2x"></i>Confirmar cancelación</h4>
                </div>
                <div class="modal-body">
                    ¿Está seguro que desea cancelar los cambios? Perdería todos los datos ingresados hasta el momento.
                </div>
                <div class="modal-footer">
                    <button type="button" id="botonCancelarModal1Criterio" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    <button type="button" id="botonAceptarCancelarCriterio" class="btn btn-primary" runat="server" onserverclick="botonAceptarCancelarCriterio_ServerClick">Aceptar</button>
                </div>
            </div>
        </div>
    </div>

    <%--Modal AYUDA--%>
     <div class="modal fade" id="modalAyuda" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h3 class="modal-title" id="modalAyudar"><i class="fa fa-exclamation-triangle text-danger fa-2x">Ayuda</i></h3>
                </div>
                <div class="modal-body">
                    En esta página se administran los requerimientos asociados a los módulos de un Proyecto.
                    <br />
                    <br />
                    Aquí se pueden <font color="blue" >Agregar</font>, <font color="green" >Modificar</font>, <font color="brown" size ="3px">Eliminar</font> y <font color ="grey">Consultar</font> requerimientos. 
                    También aquí se pueden <font color="blue" >Agregar</font>, <font color="green" >Modificar</font>, <font color="brown" size ="3px">Eliminar</font> los criterios de aceptación asociados a cada requerimiento. 
                    <br />
                    <br />
                    Primero se selecciona el proyecto al cual se le quiere agregar los requerimientos. Aparecerá un cuadro con información de ese proyecto. Luego de eso se cargará un cuadro con la lista de requerimientos.  
                    Se habilitará el botón de <font color="blue" >Agregar</font> requerimientos, y al presionarlo se habilitarán los campos para ingresar los datos y cuando se ingresan todos los datos se presiona Aceptar.
                    Si se elije algún requerimiento del cuadro, se habilitarán los botones <font color="green" >Modificar</font> y <font color="brown" size ="3px">Eliminar</font>.
                    <br />
                    <br />
                    Además si se elije algún requerimiento se habilitará el botón de <font color="blue" >Agregar</font> un criterio, y ahí se pueden ingresar los criterios de aceptación asociados a ese requerimiento.
                    Aparecerá un cuadro con la lista de criterios y se elije uno se habilitan los botones de <font color="green" >Modificar</font> y <font color="brown" size ="3px">Eliminar criterios</font>.
                                
                </div>
                <div class="modal-footer">
                    <button type="button" id="botonSalir" class="btn btn-danger" data-dismiss="modal">Salir</button>
                </div>
            </div>
        </div>
    </div>
        

</asp:Content>
