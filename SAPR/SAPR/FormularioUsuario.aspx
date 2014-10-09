<%@ Page Title="" Language="C#" MasterPageFile="~/Neo.Master" AutoEventWireup="true" CodeBehind="FormularioUsuario.aspx.cs" Inherits="SAPR.FormularioUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div class="row row-botones">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAgregarUsuario" runat="server"  Text="Agregar" class= "btn btn-primary"/>
        <asp:Button ID="btnModificarUsuario" runat="server" Text="Modificar" class ="btn btn-primary "/>
        <asp:Button ID="btnEliminarUsuario" runat="server" Text="Eliminar" CssClass ="btn btn-primary" />

        <br />

    </div>


        <div class="col-lg-12">
            <br />
            <div class="well bs-component">
                <fieldset>
                    <legend>Información Personal</legend>

                    <div class="col-sm-4">
                    <div class="form-group">
                        <label for="textNombre" class="col-sm-3 control-label">Nombre: </label>
                        <div class="col-sm-9">
                            <div class=" input-group margin-bottom-sm">
                                <input runat="server" id="txtNombreUsuario" class="form-control" type="text" data-error="Ingresó un nombre inválido" title="Nombre" pattern="^[a-zA-Z0-9 ]+$" data-minlength="8" maxlength="44" required="required" />
                            </div>
                            <div class="help-block with-errors"></div>
                        </div></div>


                    <div class="form-group">
                        <label for="textObjetivo" class="col-sm-3 control-label">Cédula: </label>
                        <div class="col-sm-9">
                            <div class=" input-group margin-bottom-sm">
                                <input runat="server" id="txtCedula" class="form-control" type="text" data-error="Espacio requerido. Sólo letras." required="required" title= "cedula" pattern= "[0-9 ]+$" data-minlength="5" maxlength="299" />
                                <span class="input-group-addon"><i class="fa fa-check fa-fw"></i></span>
                            </div>
                            <div class="help-block with-errors">
                            </div>
                        </div>
                    </div>

                        </div>

                    <div class="col-sm-4">
                       

                     
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
                         
                    <div class="col-sm-4">
                    <div class="form-group">
                        <label for="textRoles" class="col-sm-3 control-label">Roles: </label>
                        <div class="dropdown-toggle">
                            <div class="help-block with-error"><asp:SqlDataSource ID="rolesBD" runat="server" ConnectionString="<%$ ConnectionStrings:ingegscarlosConnectionString %>" SelectCommand="SELECT [Nombre] FROM [Roles]"></asp:SqlDataSource>

                                <asp:DropDownList ID="cmbRol" runat="server" DataSourceID="rolesBD" DataTextField="Nombre" DataValueField="Nombre" Class ="dropdown">
                                </asp:DropDownList>

                            </div>
                        </div>
                    </div>


                    <div class="col-sm-4">
                    <div class="form-group">
                        <label for="textRoles" class="col-sm-3 control-label">Proyecto: </label>
                        <div class="dropdown-toggle">
                            <div class="help-block with-error">

                                <asp:DropDownList ID="cmbProyecto" runat="server" DataSourceID="nombreProyectos" DataTextField="Nombre" DataValueField="Nombre" Class ="dropdown">
                                </asp:DropDownList>

                                <asp:SqlDataSource ID="nombreProyectos" runat="server" ConnectionString="<%$ ConnectionStrings:ingegscarlosConnectionString %>" SelectCommand="SELECT [Nombre], [IdProyecto] FROM [Proyecto]"></asp:SqlDataSource>

                            </div>
                        </div>
                    </div>



                     
                                </div>
                </fieldset>
            </div>

        </div>
   

        








</asp:Content>


