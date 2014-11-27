<%@ Page Title="" Language="C#" MasterPageFile="~/Neo.Master" AutoEventWireup="true" CodeBehind="FormularioProyecto.aspx.cs" Inherits="SAPR.FormularioProyecto" %>
<%@ MasterType  virtualPath="~/Neo.Master"%>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat ="server" >
   </asp:ScriptManager>
    

    <div class="page-header">
        <div class="row">
            <div class="col-lg-11">
                <h1><i class="fa fa-truck"></i>Proyecto</h1>
            </div>
            <div class =" col-lg-1">
                <a id="AYUDA" href="#modalAyuda" class="btn alert-link" role="button" data-toggle="modal" runat="server"><h4>Ayuda</h4></a> 
            </div>
        </div>
    </div>
    <div class="row row-botones">
        <div class="col-lg-5">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <button runat="server" id="btnAgregarProyecto" onserverclick="btnAgregarProyecto_Click" class="btn btn-primary" type="button"><i class="fa fa-pencil-square-o"></i>Agregar</button>
            <button runat="server" id="btnModificarProyecto" onserverclick="modificar_Click" class="btn btn-primary" type="button" visible="True"><i class="fa fa-pencil-square-o"></i>Modificar</button>
            <a id="btnEliminarProyecto" href="#modalEliminar" class="btn btn-primary" role="button" data-toggle="modal" runat ="server"><i class="fa fa-trash-o fa-lg"></i>Eliminar</a>
          
    
          
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
        <div class="col-lg-12 text-center">
            <div class="well bs-component">
                <fieldset>
                    <legend>Información de Proyecto</legend>
                    <div class="row">

                            <div class="col-md-4">
                                <label for="textNombre" >Nombre del Proyecto  <font color='red'>*</font></label>

                                    <input runat="server" id="textNombre" class="form-control" type="text" placeholder="Debe tener entre 5 y 44 caracteres" title="Nombre" required="required" />
                                    <asp:RegularExpressionValidator runat=server 
                                        ControlToValidate="textNombre" 
                                        ErrorMessage="Nombre Proyecto Inválido. Debe tener entre 2 y 44 caracteres" 
                                        ValidationExpression="^[a-zA-Z0-9\s]{2,44}$" />
                                    <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" errormessage="" forecolor="black" controltovalidate="textNombre" validationgroup="A" initialvalue="" xmlns:asp="#unknown"></asp:requiredfieldvalidator>

                                <div class="help-block with-errors"></div>
                            </div>

                            <div class="col-md-4">
                                <label for="textObjetivo">Objetivo del Proyecto  <font color='red'>*</font></label>

                                    <textarea runat="server" id="textObjetivo" class="form-control" type="text" placeholder="Debe tener entre 5 y 300 caracteres"  title="Objetivos" required="required" />
                                    <asp:RegularExpressionValidator runat="server" 
                                     ControlToValidate="textObjetivo" 
                                     ErrorMessage="Objetivos Inválidos. Debe tener entre 5 y 300 caracteres" 
                                     ValidationExpression="^[a-zA-Z0-9\s]{5,300}$" />
                                    <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" errormessage="" forecolor="black" controltovalidate="textObjetivo" validationgroup="A" initialvalue="" xmlns:asp="#unknown"></asp:requiredfieldvalidator>

                                <div class="help-block with-errors"></div>
                            </div>

                        <div class="col-md-4">
                            <label for="text" >Estado del Proyecto <font color='red'>*</font></label>
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
                        </div>
                    </div>

                   </fieldset>
                &nbsp;
                    <fieldset>

                    <div class="row">

                        
                        <div class="col-md-4">
                            <label for="textFechaA">Fecha de Asignación  <font color='red'>*</font></label>
                            </div>
                            
                        

                         <div class="col-md-4">
                            <label for="textFechaI">Fecha de Inicio </label>
                         </div>
                            
                        

                        <div class="col-md-4">
                            <label for="textFechaF">Fecha de Finalización</label>
                              </div> 
                         </div>

                        <div class="row">
                            <div class="col-md-4">
                                <input runat="server" id="textFechaA" type="date" class="" placeholder="Clic Aquí" required="required"/>
                            <div class="help-block with-errors"></div>
                                </div>
                            <div class="col-md-5">
                                <input runat="server" id="textFechaI" type="date" class="" placeholder="Clic Aquí"/>
                            <asp:CompareValidator ID="CompareValidator1" ControlToCompare="textFechaA" 
                                        ControlToValidate="textFechaI" Type="Date" Operator="GreaterThanEqual"   
                                        ErrorMessage="Fecha inválida." runat="server"></asp:CompareValidator>
                            <div class="help-block with-errors"></div>
                                </div>
                            <div class="col-md-2">
                                 <input runat="server" id="textFechaF" type="date" class="" placeholder="Clic Aquí"/>
                                <asp:CompareValidator ID="CompareValidator0" ControlToCompare="textFechaI" 
                                            ControlToValidate="textFechaF" Type="Date" Operator="GreaterThanEqual"   Display="Dynamic" SetFocusOnError="true" CultureInvariantValues="true"
                                            ErrorMessage="Fecha inválida." runat="server"></asp:CompareValidator>
                                <div class="help-block with-errors"></div>
                                </div>
                            </div>
                               
                                   

                   

                    </fieldset>
            </div>
            </div>
    <!--Datos de contacto-->
    <div class="col-lg-12 text-center">
            <div class="well bs-component">
                <fieldset>
                    <legend>Información de Contacto</legend>
                    <div class="row">
                        <div class="col-md-4">                   
                            <label for="textRepresentante">Nombre del Representante  <font color='red'>*</font></label>                                                    
                                    <input runat="server" id="textRepresentante" class="form-control" type="text" placeholder="Debe tener entre 5 y 44 caracteres" title="Representante" required="required" />
                                    <asp:RegularExpressionValidator runat="server" 
                                    ControlToValidate="textRepresentante" 
                                    ErrorMessage="Nombre Representante Inválido. Debe tener entre 3 y 44 caracteres" 
                                    ValidationExpression="^[a-zA-Z\s]{3,50}$" />
                                
                                <div class="help-block with-errors"></div>
                        </div>

                        <div class="col-md-4">
                            <label for="textEmailRepresentante" >E-mail del Representante <font color='red'>*</font></label>                        
                                <input runat="server" id="textEmailRepresentante" class="form-control" type="email" placeholder="Debe tener este formato : ejemplo@correo.com" />
                                <asp:RegularExpressionValidator runat="server" 
                                    ControlToValidate="textEmailRepresentante" 
                                    ErrorMessage="Email incorrecto. Debe tener este formato : ejemplo@correo.com" 
                                    ValidationExpression="^[a-zA-Z][\w.-]+@\w[\w.-]+\.[\w.-]*[a-z][a-z]$" />
                                <asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" errormessage="" forecolor="black" controltovalidate="textEmailRepresentante" validationgroup="A" initialvalue="" xmlns:asp="#unknown"></asp:requiredfieldvalidator>
                                <div class="help-block with-errors"></div>                        
                        </div>

                    <div class="col-md-4">
                        <label for="textOficina">Oficina del Representante <font color='red'>*</font></label>                        
                            <input runat="server" id="TextOficina" class="form-control" type="tel" placeholder="Debe tener un largo de 5-15 caracteres." title="Oficina"/>
                            <asp:RegularExpressionValidator runat="server" 
                                ControlToValidate="TextOficina" 
                                ErrorMessage="Oficina incorrecta. Debe tener un largo de 5-15 caracteres." 
                                ValidationExpression="[a-zA-Z0-9\-\s]{5,15}$" />
                            <asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" errormessage="" forecolor="black" controltovalidate="TextOficina" validationgroup="A" initialvalue="" xmlns:asp="#unknown"></asp:requiredfieldvalidator>
                            <div class="help-block with-errors"></div>                        
                    </div>

                    </div>

                    </fieldset>
                
                    &nbsp;
                    <fieldset>

                    <div class="row">
                        <div class="col-md-4 col-md-offset-2">
                            <label for="textTelRepresentanre">Teléfono Principal del Representante  <font color='red'>*</font></label>                                                    
                                <input runat="server" id="textTelRepresentante" class="form-control" type="text" placeholder="Debe tener 8 números. Sin espacios."  title="Telefono" required="required"/>
                                <asp:RegularExpressionValidator runat="server" 
                                    ControlToValidate="textTelRepresentante" 
                                    ErrorMessage="Teléfono incorrecto. Debe tener 8-16 números. Sin espacios." 
                                    ValidationExpression="[0-9]{8,16}" />
                                <asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" errormessage="" forecolor="black" controltovalidate="textTelRepresentante" validationgroup="A" initialvalue="" xmlns:asp="#unknown"></asp:requiredfieldvalidator>                            
                                <div class="help-block with-errors"></div>                        
                        </div>

                        <div class="col-md-4">
                            <label for="textTelSecundario">Teléfono Secundario del Representante </label>                        
                                <input runat="server" id="textTelSecundario" class="form-control" type="tel" placeholder="Debe tener 8 números. Sin espacios." title="Telefono secundario"/>
                                 <asp:RegularExpressionValidator runat="server" 
                                    ControlToValidate="textTelSecundario" 
                                    ErrorMessage="Teléfono incorrecto. Debe tener 8-16 números. Sin espacios." 
                                    ValidationExpression="[0-9]{8,16}$" />
                                <div class="help-block with-errors"></div>                        
                        </div>

                    </div>

                    <div class="row">


                    </div>
                        
                </fieldset>
            </div>

        </div>
                            <label for="textObligatorio"><font color = "red"><i>Los campos con (*) son obligatorios</i> </font></label>
      <!--Información del equipo-->
            <div class="col-lg-12 text-center">
            <div class="well bs-component">
                <fieldset>
                    <legend>Información del Equipo</legend>

                    <div class="col-sm-6">

                        
                        <asp:GridView ID="gridUsuarios" Caption='<table width="100%" class="TestCssStyle"><tr><td class="text_Title">Usuarios Disponibles</td></tr></table>' cssClass="table" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black"  AllowPaging="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Lider">
                                            <ItemTemplate>    
                                                
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" ChildrenAsTriggers="True">
                                                    <ContentTemplate>  
                                                         <asp:CheckBox ID="cbLider" runat="server" OnCheckedChanged="cbLider_CheckedChanged1" AutoPostBack="True" /> 
                                                             </ContentTemplate>                                                 
                                                        <Triggers>      
                                                       <asp:AsyncPostBackTrigger ControlID="cbLider" EventName="CheckedChanged" /> 
                                                                    
                                                         </Triggers>       
                                                                                                       
                                                        </asp:UpdatePanel>                                                                                                                                                 
                                            </ItemTemplate>
                                            
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Miembro">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbMiembros" runat="server"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
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
                               
                                </div>

                    

                                <div class="col-sm-6">
                                <asp:GridView ID="gridUsuariosAsignados" Caption='<table width="100%" class="TestCssStyle"><tr><td class="text_Title">Usuarios Asignados</td></tr></table>' CssClass ="table" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True" >
                                    <Columns>
                                        <asp:TemplateField HeaderText="Lider">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbLiderAsignado" runat="server" AutoPostBack="True" OnCheckedChanged="cbLiderAsignado_CheckedChanged" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Miembros">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbMiembrosAsignados" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />
                                </asp:GridView>

                        </div>
                         
                                
                </fieldset>
                

        </div>
                <div class="row">
                <div class="col-lg-12">
                    <div class="text-center">
                <button runat="server" id="botonAceptar" onserverclick="btnAceptar_Click" class="btn btn-success" type="submit" validationgroup="A" xmlns:asp="#unknown">Aceptar</button>
                <%--<button runat="server" id="botonCancelar" class="btn btn-danger" type="reset">Cancelar</button>--%>
                <a id="botonCancelar" href="#modalCancelar" class="btn btn-danger" role="button" data-toggle="modal" runat ="server"><i class="fa fa-trash-o fa-lg"></i>Cancelar</a>
                        </div></div>
              
            </div>
                    
              </div>  
                
                <div class = " col-lg-7">    
                                      
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

     <!--Modal Eliminar-->
    <div class="modal fade" id="modalEliminar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel"><i class="fa fa-exclamation-triangle text-danger fa-2x"></i>Confirmar eliminación</h4>
                </div>
                <div class="modal-body">
                    ¿Está seguro que desea eliminar el proyecto seleccionado?
                </div>
                <div class="modal-footer">
                    <button type="button" id="botonCancelarModal" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    <button type="button" id="botonAceptarModal" class="btn btn-primary" runat="server" onserverclick="clickAceptarEliminarProyecto">Aceptar</button>
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
                    <button type="button" id="botonAceptarModal2" class="btn btn-primary" runat="server" onserverclick="btnCancelar_Click">Aceptar</button>
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
                    En esta página esta localizado el área de administración de Proyectos. 
                    <br />
                    <br />
                    Aquí se pueden <font color="blue" >Agregar</font>, <font color="green" >Modificar</font>, <font color="brown" size ="3px">Eliminar</font> y <font color ="grey">Consultar</font> proyectos. Como también asociar o desasociar usuarios a los mismos.
                    <br />
                    <br />
                     Se encuentran 3 botones (<font color="blue" >Agregar</font>, <font color="green" >Modificar</font> y <font color="brown" size ="3px">Eliminar</font>) los cuales sirven para las características descritas anteriormente. 
                    <br />
                    <br />
                    Para <font color ="grey">consultar</font> un proyecto se le da click a la opcion de <font color ="grey">Consultar</font> en la tabla de Proyectos creados al final de la página.
                    Luego los botones <font color="green" >Modificar</font> y <font color="brown" size ="3px">Eliminar</font> serán habilitados.
                    <br />
                    <br />
                    Al <font color="brown" size ="3px">eliminar</font> un proyecto se desasocian todos sus miembros asociados.
                    <br />
                    <br />
                    Un proyecto "Finalizado" no se puede eliminar.
                    <br />
                    <br />
                    Nota: Un proyecto siempre debe tener un líder asociado. (El lider debe ser marcado también como miembro).
                       
                </div>
                <div class="modal-footer">
                    <button type="button" id="botonSalir" class="btn btn-danger" data-dismiss="modal">Salir</button>
                </div>
            </div>
        </div>
    </div>

    
</asp:Content>
