<%@ Page Title="" Language="C#" MasterPageFile="~/Neo.Master" AutoEventWireup="true" CodeBehind="FormularioProyecto.aspx.cs" Inherits="SAPR.FormularioProyecto" %>
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
        <div class="col-lg-12">
            <div class="well bs-component">
                <fieldset>
                    <legend>Información de Proyecto</legend>

                    <div class="form-group">
                        <label for="textNombre" class="col-sm-1 control-label">Nombre: </label>
                        <div class="col-sm-4">
                            <div class=" input-group margin-bottom-sm"> 
                                <input runat="server" id="textNombre" class="form-control" type="text" placeholder="Nombre de Proyecto" data-error="Ingresó una nombre inválido" title="Nombre" pattern="^[a-zA-Z0-9 ]+$" data-minlength="5" maxlength="44" required="required" />
                            </div>
                            <div class="help-block with-errors"></div>
                        </div></div>
                    </fieldset>
                    <fieldset>
                    <div class="form-group">
                        <label for="textObjetivo" class="col-sm-1 control-label">Objetivo: </label>
                        <div class="col-sm-7">
                            <div class=" input-group margin-bottom-sm">
                                <input runat="server" id="textObjetivo" class="form-control" type="text" placeholder="Objetivo de Proyecto" data-error="Espacio requerido. Sólo letras." title="Objetivos" required="required" pattern="^[a-zA-Z0-9 ]+$" data-minlength="5" maxlength="299" />

                            </div>
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>
                   </fieldset>

                        <fieldset>
                   <div class="col-sm-7">
                    <div class="form-group">
                        <label for="fechaAsignacion" class="col-sm-4 control-label">Fecha de asignación:</label>
                            <div class="col-sm-5">
                                <input runat="server" id="textFechaA" type="text" class="datepicker" placeholder="Clic Aquí"/>
                                <div class="help-block with-errors"></div>
                            </div>
                    </div>

                    <div class="form-group">
                        <label for="DateFinish" class="col-sm-4 control-label">Fecha de finalización:</label>
                        <div class="col-sm-5">
                            <input runat="server" id="textFechaF" type="text" class="datepicker" placeholder="Clic Aquí"/>
                            <asp:CompareValidator ID="CompareValidator0" ControlToCompare="textFechaI" 
                                     ControlToValidate="textFechaF" Type="Date" Operator="GreaterThanEqual"   
                                     ErrorMessage="Fecha inválida." runat="server"></asp:CompareValidator>
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>
                </div>

                 <div class="col-md-5">
                    <div class="form-group">
                        <label for="dateStart" class="col-sm-5 control-label">Fecha de inicio: </label>
                        <div class="col-sm-4">
                            <input runat="server" id="textFechaI" type="text" class="datepicker" placeholder="Clic Aquí"/>
                            <asp:CompareValidator ID="cmpVal1" ControlToCompare="textFechaA" 
                                     ControlToValidate="textFechaI" Type="Date" Operator="GreaterThanEqual"   
                                     ErrorMessage="Fecha inválida." runat="server"></asp:CompareValidator>
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>
                       
 
                    <div class="form-group">
                        <label for="text" class="col-sm-5 control-label">Estado: </label>
                        <div class="col-sm-4">
                        <div class="dropdown-toggle"> 
                                <asp:DropDownList ID="cmbEstado" runat="server">
                                    <asp:ListItem>Sin Iniciar</asp:ListItem>
                                    <asp:ListItem>En proceso</asp:ListItem>
                                    <asp:ListItem>Finalizado</asp:ListItem>
                                </asp:DropDownList>
                            <div class="help-block with-errors"></div>
                        </div>
                        </div>
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

                    <div class="col-md-7">
                    <div class="form-group">
                        <label for="textRepresentante" class="col-sm-4 control-label">Representante: </label>
                        <div class="col-sm-5">
                            <div class=" input-group margin-bottom-sm">
                                <input runat="server" id="textRepresentante" class="form-control" type="text" placeholder="Nombre de Representante" data-error="Ingresó un nombre inválido" title="Representante" pattern="^[a-zA-Z0-9 ]+$" data-minlength="5" maxlength="30" required="required" />
                            </div>
                            <div class="help-block with-errors"></div>
                        </div></div>


                    <div class="form-group">
                        <label for="textTelRepresentanre" class="col-sm-4 control-label">Teléfono de Representante: </label>
                        <div class="col-sm-5">
                            <div class=" input-group margin-bottom-sm">
                                <input runat="server" id="textTelRepresentante" class="form-control" type="text" placeholder="Teléfono de Representante" data-error="Espacio requerido. Sólo letras y números." title="Telefono" required="required" pattern="^[0-9]*$"/>
                            </div>
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>

                        
                    <div class="form-group">
                        <label for="textEmailRepresentante" class="col-sm-4 control-label">E-mail: </label>
                        <div class="col-sm-5">
                            <input runat="server" id="textEmailRepresentante" class="form-control" type="email" placeholder="E-mail" data-error="Correo inválido" />
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>
                    
                       </div>

                 <div class="col-md-5">
                    <div class="form-group">
                        <label for="textOficina" class="col-sm-5 control-label">Oficina: </label>
                        <div class="col-sm-4">
                            <input runat="server" id="TextOficina" class="form-control" type="tel" placeholder="Oficina" data-error="Espacio Requerido" title="Oficina" pattern="^[a-zA-Z0-9 ]+$" data-minlength="8" maxlength="30" />
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="textTelSecundario" class="col-sm-5 control-label">Teléfono Secundario: </label>
                        <div class="col-sm-4">
                            <input runat="server" id="textTelSecundario" class="form-control" type="tel" placeholder="Teléfono Secundario" data-error="Número de teléfono inválido" title="Telefono secundario" pattern="^[0-9]*$" data-minlength="8" maxlength="12" />
                            <div class="help-block with-errors"></div>
                        </div>
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

                    <div class="col-sm-6">


                                <asp:GridView ID="gridUsuarios" cssClass="table" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnSelectedIndexChanged="gridUsuarios_SelectedIndexChanged">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Lider">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbLider" runat="server"  AutoPostBack="True" OnCheckedChanged="cbLider_CheckedChanged1" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Miembro">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbMiembros" runat="server" />
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
                                <asp:GridView ID="gridUsuariosAsignados" CssClass ="table" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Lider">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbLiderAsignado" runat="server" />
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
                <button runat="server" id="botonAceptar" onserverclick="btnAceptar_Click" class="btn btn-success" type="submit">Aceptar</button>
                <%--<button runat="server" id="botonCancelar" class="btn btn-danger" type="reset">Cancelar</button>--%>
                <a id="botonCancelar" href="#modalCancelar" class="btn btn-danger" role="button" data-toggle="modal" runat ="server"><i class="fa fa-trash-o fa-lg"></i>Cancelar</a>
                        </div></div>
              
            </div>
                    
              </div>  
                
                <div class = " col-lg-7">    
                                      
                    <asp:GridView ID="gridProyecto" runat="server" AutoGenerateColumns="False" CssClass ="table"  DataSourceID="ListaProyectos" ForeColor="Black" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                        <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                        <asp:BoundField DataField="Lider" HeaderText="Lider" SortExpression="Lider" />
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


</asp:Content>
