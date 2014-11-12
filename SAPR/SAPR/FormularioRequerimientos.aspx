<%@ Page Title="" Language="C#" MasterPageFile="~/Neo.Master" AutoEventWireup="true" CodeBehind="FormularioRequerimientos.aspx.cs" Inherits="SAPR.FormularioRequerimientos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <div class="page-header">
        <div class="row">
            <div class="col-lg-11">
                <h1><i class="fa fa-truck"></i>Requerimientos</h1>
            </div>
            <div class="col-lg-1">
                <h2><a id="informacion" href="#modalInformacion" data-toggle="modal" runat="server"><i class="fa fa-question-circle text-info"></i></a></h2>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <label for="text" > <font size ="6">Proyectos: </font> </label>
                
                         <asp:DropDownList ID="cmbProyecto" runat="server">
                         </asp:DropDownList>
                         <div class="help-block with-errors"></div>
                  
        </div>
    </div>

    <div class="row">
    <div class="col-lg-7">                                        
                    <asp:GridView ID="gridProyecto" runat="server" AutoGenerateColumns="False" CssClass ="table"  DataSourceID="ListaProyectos" ForeColor="Black" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                        <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                        <asp:BoundField DataField="Lider" HeaderText="Lider" SortExpression="Lider" />
                        <asp:CommandField HeaderText="Seleccion" SelectText="Consultar" ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
                                
                <asp:SqlDataSource ID="ListaProyectos" runat="server" ConnectionString="<%$ ConnectionStrings:ingegscarlosConnectionString %>" SelectCommand="SELECT P.Nombre, P.Estado, U.Nombre AS Lider FROM Proyecto AS P INNER JOIN Usuarios AS U ON P.Lider = U.Cedula"></asp:SqlDataSource>

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

    <div class="col-lg-12 text-center">
            <div class="well bs-component">
                <fieldset>
                    <legend>Información de Requerimientos</legend>
                     <div class="row">
                          <div class="col-md-4">
                                <label for="textNombreR" >Nombre del Requerimiento  <font color='red'>*</font></label>
                                <input runat="server" id="textNombreR" class="form-control" type="text" placeholder="Debe tener entre 5 y 44 caracteres" title="NombreR" required="required" />
                                    <asp:RegularExpressionValidator runat=server 
                                        ControlToValidate="textNombreR" 
                                        ErrorMessage="Nombre Requerimiento Inválido. Debe tener entre 2 y 44 caracteres" 
                                        ValidationExpression="^[a-zA-Z0-9\s]{2,44}$" />
                                    <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" errormessage="" forecolor="black" controltovalidate="textNombreR" validationgroup="A" initialvalue="" xmlns:asp="#unknown"></asp:requiredfieldvalidator>

                                <div class="help-block with-errors"></div>
                            </div>

                            <div class="col-md-4">
                                <label for="textDescripcionR" >Descripción del Requerimiento  <font color='red'>*</font></label>
                                <textarea runat="server" id="textD" class="form-control" type="text" placeholder="Debe tener entre 5 y 300 caracteres"  title="Descripcion" required="required" />
                                    <asp:RegularExpressionValidator runat=server 
                                        ControlToValidate="textD" 
                                        ErrorMessage="Descripcion Requerimiento Inválido. Debe tener entre 2 y 44 caracteres" 
                                        ValidationExpression="^[a-zA-Z0-9\s]{2,44}$" />
                                    <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" errormessage="" forecolor="black" controltovalidate="textD" validationgroup="A" initialvalue="" xmlns:asp="#unknown"></asp:requiredfieldvalidator>
                            </div>
                            
                            <div class="col-md-4">
                                  <label for="textPrio" >Prioridad:</font></label>
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

                          </div>

                           <div class="row">
                               <div class="col-md-4">
                                  <label for="textPrio" >Estado:</font></label>
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

                               <div class="col-md-4">
                                    <label for="textCantidadR" >Cantidad Estimada: <font color='red'>*</font></label>
                                    <input runat="server" id="txtCantidadR" class="form-control" type="text" placeholder="Estime una cantidad" title="CantidadR" required="required" />
                                    <asp:RegularExpressionValidator runat=server 
                                        ControlToValidate="txtCantidadR" 
                                        ErrorMessage="Inserte una cantidad. Solo números." 
                                        ValidationExpression="^[0-9]+$" />
                                    <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" errormessage="" forecolor="black" controltovalidate="txtCantidadR" validationgroup="A" initialvalue="" xmlns:asp="#unknown"></asp:requiredfieldvalidator>

                                    <div class="help-block with-errors"></div>
                               </div>

                               <div class="col-md-4">
                                    <label for="textMedi" >Medida:</font></label>
                                    <div class="dropdown-toggle"> 
                                    <asp:DropDownList ID="cmbMedida" runat="server">
                                        <asp:ListItem>Horas</asp:ListItem>
                                        <asp:ListItem>Días</asp:ListItem>
                                        <asp:ListItem>Puntos</asp:ListItem>
                                    </asp:DropDownList>
                                  <div class="help-block with-errors"></div>
                                  </div>
                                  </asp:DropDownList>

                              </div>
                     </div>

                    <div class="row">
                        <div class="col-lg-12">
                            <div class="text-center">
                                <button runat="server" id="botonAceptarR" onserverclick="btnAceptarR_Click" class="btn btn-success" type="submit" validationgroup="A" xmlns:asp="#unknown">Aceptar</button>
                                <a id="botonCancelar" href="#modalCancelar" class="btn btn-danger" role="button" data-toggle="modal" runat ="server"><i class="fa fa-trash-o fa-lg"></i>Cancelar</a>
                            </div>
                        </div>              
                    </div>

                </fieldset>
            </div>
    </div>

        <div class="row">
    <div class="col-lg-7">                                        
                    <asp:GridView ID="gridRequerimientos" runat="server" AutoGenerateColumns="False" CssClass ="table"  DataSourceID="ListaProyectos" ForeColor="Black" OnSelectedIndexChanged="GridViewReque_SelectedIndexChanged" AllowPaging="True">
                </asp:GridView>
    </div>
        </div>


</asp:Content>
