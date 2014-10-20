<%@ Page Title="" Language="C#" MasterPageFile="~/Neo.Master" AutoEventWireup="true" CodeBehind="FormularioUsuario.aspx.cs" Inherits="SAPR.FormularioUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div class="page-header">
        <div class="row">
            <div class="col-lg-11">
                <h1><i class="fa fa-truck"></i>Usuarios</h1>
            </div>
            <div class="col-lg-1">
                <h2><a id="informacion" href="#modalInformacion" data-toggle="modal" runat="server"><i class="fa fa-question-circle text-info"></i></a></h2>
            </div>
        </div>
    </div>
    
    
    
    <div class="row row-botones">
        <button runat="server" onserverclick="btnAgregarUsuario_Click" id="btnAgregarUsuario" class="btn btn-primary" type="button"><i class="fa fa-plus"></i>Agregar</button>
        <button runat="server" onserverclick="btnModificarUsuario_Click" id="btnModificarUsuario" class="btn btn-primary" type="button"><i class="fa fa-pencil-square-o"></i>Modificar</button>
        <a id="btnEliminarUsuario" href="#modalEliminar" class="btn btn-primary" role="button" data-toggle="modal" runat ="server"><i class="fa fa-trash-o fa-lg"></i>Eliminar</a>

        

    </div>

    <div class="col-lg-7">
            <div id="alertAlerta" class="alert alert-danger fade in" runat="server" hidden="hidden">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <strong>
                    <asp:Label ID="labelTipoAlerta" runat="server" Text="Alerta! "></asp:Label></strong><asp:Label ID="labelAlerta" runat="server" Text="Mensaje de alerta"></asp:Label>
            </div>
    </div>


    <div class="col-lg-12">
        <br />
        <div class="well bs-component">
            <fieldset>
                <legend>Información Personal</legend>
                <div class="form-group-lg">
                
                <div class="col-lg-7">   
                    <div class="form-group">
                        <label for="textNombre" class="col-sm-3 control-label">Nombre: </label>
                            <div class="col-sm-9">
                                <input runat="server" id="txtNombreUsuario" placeholder= "Nombre completo" class="form-control" type="text" title="Nombre" required="required" />
                                <asp:RegularExpressionValidator runat=server 
            ControlToValidate="txtNombreUsuario" 
            ErrorMessage="Nombre Incorrecto. Debe tener entre 5 y 50 caracteres" 
            ValidationExpression="[a-zA-Z\s]{5,50}$" />
                                <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" errormessage="" forecolor="red" controltovalidate="txtNombreUsuario" validationgroup="A" initialvalue="" xmlns:asp="#unknown">Vacío</asp:requiredfieldvalidator>
                                <div class="help-block with-errors"></div>
                            </div>      
                    </div>
                
                    
                    <div class="form-group">
                        <label for="txtCedula" class="col-sm-3 control-label">Cédula: </label>
                            <div class= "col-sm-9">
                                <input runat="server" placeholder= "X XXX XXX" id ="txtCedula" class="form-control" type="text" required="required" title="cedula"/>
                                <asp:RegularExpressionValidator runat=server 
            ControlToValidate="txtCedula" 
            ErrorMessage="Cédula inválida. Formato con números X XXXX XXXX" 
            ValidationExpression="[1-9]\s[0-9]{4}\s[0-9]{4}$" />
                               <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" errormessage="" forecolor="red" controltovalidate="txtCedula" validationgroup="A" initialvalue="" xmlns:asp="#unknown">Vacío</asp:requiredfieldvalidator>
                                 <div class="help-block with-errors">
                            </div>
                            </div>
                    </div>
                </div>

                
                
                <div class="col-lg-7">
                    <div class="form-group">
                        <label for="textTelefono" class="col-sm-3 control-label">Teléfono: </label>
                        <div class="col-sm-7">
                            <input runat="server" id="textTelefono" class="form-control" type="tel" placeholder="Teléfono" title="telefono"/>
                            <asp:RegularExpressionValidator runat=server 
            ControlToValidate="textTelefono" 
            ErrorMessage="Teléfono incorrecto. Debe tener 8 números.  Sin espacios." 
            ValidationExpression="[0-9]{8}" />
                            <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" errormessage="" forecolor="red" controltovalidate="textTelefono" validationgroup="A" initialvalue="" xmlns:asp="#unknown">Vacío</asp:requiredfieldvalidator>
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="textCelular" class="col-sm-3 control-label">Celular: </label>
                        <div class="col-sm-7">
                            <input runat="server" id="textCelular" class="form-control" type="tel" placeholder="Celular" title="Celular"/>
                            <asp:RegularExpressionValidator runat=server 
            ControlToValidate="textCelular" 
            ErrorMessage="Teléfono incorrecto. Debe tener 8 números.  Sin espacios." 
            ValidationExpression="[0-9]{8}" />
                            <asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" errormessage="" forecolor="red" controltovalidate="textCelular" validationgroup="A" initialvalue="" xmlns:asp="#unknown">Vacío</asp:requiredfieldvalidator>
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>

                </div>

                <div class="col-sm-5">
                    <div class="form-group">
                        <label for="textEmail" class="col-sm-3 control-label">E-mail: </label>
                        <div class="col-sm-9">
                            <input runat="server" id="textEmail" class="form-control" type="email" placeholder="E-mail" data-error="Correo inválido" />
                            <asp:RegularExpressionValidator runat=server 
            ControlToValidate="textEmail" 
            ErrorMessage="Email incorrecto. Debe tener este formato : ejemplo@correo.com" 
            ValidationExpression="^[a-z][\w.-]+@\w[\w.-]+\.[\w.-]*[a-z][a-z]$" />
                            <asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" errormessage="" forecolor="red" controltovalidate="textEmail" validationgroup="A" initialvalue="" xmlns:asp="#unknown">Vacío</asp:requiredfieldvalidator>
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>
                </div>

                <div class="col-sm-5">
                    <div class="form-group">
                        <label for="txtPassword" class="col-sm-3 control-label">Contraseña: </label>
                        <div class="col-sm-9">
                            <input runat="server" id="password" class="form-control" type="password" placeholder="Contraseña" data-error="Contraseña inválida" />
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>
                        <label for="txtPassword2" class="col-sm-3 control-label">Confirme Contraseña: </label>
                        <div class="col-sm-9">
                            <input runat="server" id="password1" class="form-control" type="password" placeholder="Confirmar Contraseña" data-error="Confirmación Inválida" />
                            <asp:CompareValidator ID="cmpPass" ControlToCompare="password" 
                                     ControlToValidate="password1" Type="String" Operator="Equal"   
                                     ErrorMessage="Contraseñas no concuerdan" runat="server"></asp:CompareValidator>
                            <asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" errormessage="" forecolor="red" controltovalidate="password" validationgroup="A" initialvalue="" xmlns:asp="#unknown">Vacío</asp:requiredfieldvalidator>
                            <div class="help-block with-errors"></div>
                        </div>
                </div>
        

                <div class="col-lg-8">
                    <div class="form-group">
                        <label for="textRoles" class="col-sm-3 control-label">Roles: </label>
                        <div class="dropdown-toggle">
                            <div class="help-block with-error">

                                <asp:DropDownList ID="cmbRoles" runat="server" DataSourceID="rolesBD" DataTextField="Nombre" DataValueField="Nombre">
                                </asp:DropDownList>

                                <asp:SqlDataSource ID="rolesBD" runat="server" ConnectionString="<%$ ConnectionStrings:ingegscarlosConnectionString %>" SelectCommand="SELECT [Nombre] FROM [Roles]" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [Roles] WHERE [Nombre] = @original_Nombre" InsertCommand="INSERT INTO [Roles] ([Nombre]) VALUES (@Nombre)" OldValuesParameterFormatString="original_{0}">
                                    <DeleteParameters>
                                        <asp:Parameter Name="original_Nombre" Type="String" />
                                    </DeleteParameters>
                                    <InsertParameters>
                                        <asp:Parameter Name="Nombre" Type="String" />
                                    </InsertParameters>
                                </asp:SqlDataSource>

                            </div>
                        </div>
                    </div>
                    </div>
                    <div class="col-lg-8">
                    <div class="form-group">
                            <label for="textRoles" class="col-sm-3 control-label">Proyecto: </label>
                            <div class="dropdown-toggle">
                                <div class="help-block with-error">

                                    <asp:DropDownList ID="cmbProyecto" runat="server" DataSourceID="nombreProyectos" DataTextField="Nombre" DataValueField="Nombre" Class="dropdown">
                                    </asp:DropDownList>

                                    <asp:SqlDataSource ID="nombreProyectos" runat="server" ConnectionString="<%$ ConnectionStrings:ingegscarlosConnectionString %>" SelectCommand="SELECT [Nombre], [IdProyecto] FROM [Proyecto]"></asp:SqlDataSource>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>

    <div class =" col-lg-10">


        <asp:GridView ID="gridUsuarios" runat="server" AutoGenerateColumns="False" CssClass ="table"  DataSourceID="consultaGrideUsuarios" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
            <Columns>
                <asp:BoundField DataField="Cedula" HeaderText="Cedula" SortExpression="Cedula" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Rol" HeaderText="Rol" SortExpression="Rol" />
                <asp:CommandField ShowSelectButton="True" />
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
        <asp:SqlDataSource ID="consultaGrideUsuarios" runat="server" ConnectionString="<%$ ConnectionStrings:ingegscarlosConnectionString %>" SelectCommand="SELECT U.Cedula, U.Nombre, R.NombreRol AS Rol FROM Usuarios AS U INNER JOIN RolesUsuario AS R ON U.Cedula = R.Cedula"></asp:SqlDataSource>
   </div>   
     <div class="col-lg-12">
                    <div class="text-center">

                        <button runat="server" onserverclick="btnAceptar_Click" id="btnAceptar" class="btn btn-success" type="button" validationgroup="A" xmlns:asp="#unknown"><i class="fa fa-pencil-square-o"></i>Aceptar</button>
                        <a id="btnCancelar" href="#modalCancelar" class="btn btn-danger" role="button" data-toggle="modal" runat ="server"><i class="fa fa-trash-o fa-lg"></i>Cancelar</a>

     </div></div>

    <!--Modal Eliminar-->
    <div class="modal fade" id="modalEliminar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel"><i class="fa fa-exclamation-triangle text-danger fa-2x"></i>Confirmar eliminación</h4>
                </div>
                <div class="modal-body">
                    ¿Está seguro que desea eliminar el usuario seleccionado?
                </div>
                <div class="modal-footer">
                    <button type="button" id="botonCancelarModal" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    <button type="button" id="botonAceptarModal" class="btn btn-primary" runat="server" onserverclick="clickAceptarEliminar">Aceptar</button>
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


