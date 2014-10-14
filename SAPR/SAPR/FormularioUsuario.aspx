<%@ Page Title="" Language="C#" MasterPageFile="~/Neo.Master" AutoEventWireup="true" CodeBehind="FormularioUsuario.aspx.cs" Inherits="SAPR.FormularioUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div class="row row-botones">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAgregarUsuario" runat="server"  Text="Agregar" class= "btn btn-primary" OnClick="btnAgregarUsuario_Click"/>
        <asp:Button ID="btnModificarUsuario" runat="server" Text="Modificar" class ="btn btn-primary "/>
        <asp:Button ID="btnEliminarUsuario" runat="server" Text="Eliminar" CssClass ="btn btn-primary" OnClick="btnEliminarUsuario_Click" />

        <br />

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
                                <input runat="server" id="txtNombreUsuario" placeholder= "Nombre completo" class="form-control" type="text" data-error="Nombre inválido" title="Nombre" pattern="^[a-zA-Z0-9 ]+$" data-minlength="8" maxlength="44" required="required" />
                                <div class="help-block with-errors"></div>
                            </div>      
                    </div>
                
                    
                    <div class="form-group">
                        <label for="txtCedula" class="col-sm-3 control-label">Cédula: </label>
                            <div class= "col-sm-9">
                                <input runat="server" placeholder= "X XXX XXX" id ="txtCedula" class="form-control" type="text" data-error="Espacio requerido. Sólo letras." required="required" title="cedula" pattern="[0-9 ]+$" data-minlength="5" maxlength="10" />
                                <div class="help-block with-errors">
                            </div>
                            </div>
                    </div>
                </div>

                
                
                <div class="col-lg-7">
                    <div class="form-group">
                        <label for="textTelefono" class="col-sm-3 control-label">Teléfono: </label>
                        <div class="col-sm-7">
                            <input runat="server" id="textTelefono" class="form-control" type="tel" placeholder="Teléfono" data-error="Número de teléfono inválido" title="telefono" pattern="^[0-9]*$" data-minlength="8" maxlength="12" />
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="textCelular" class="col-sm-3 control-label">Celular: </label>
                        <div class="col-sm-7">
                            <input runat="server" id="textCelular" class="form-control" type="tel" placeholder="Celular" data-error="Número de teléfono inválido" title="Celular" pattern="^[0-9]*$" data-minlength="8" maxlength="12" />
                            <div class="help-block with-errors"></div>
                        </div>
                    </div>

                </div>

                <div class="col-sm-5">
                    <div class="form-group">
                        <label for="textEmail" class="col-sm-3 control-label">E-mail: </label>
                        <div class="col-sm-9">
                            <input runat="server" id="textEmail" class="form-control" type="email" placeholder="E-mail" data-error="Correo inválido" />
                            <div class="help-block with-errors"></div>
                        </div>
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
        <asp:SqlDataSource ID="consultaGrideUsuarios" runat="server" ConnectionString="<%$ ConnectionStrings:ingegscarlosConnectionString %>" SelectCommand="SELECT U.Cedula, U.Nombre, R.NombreRol AS Rol FROM Usuarios AS U INNER JOIN RolesUsuario AS R ON U.IdUsuario = R.IdUsuario"></asp:SqlDataSource>
   </div>   
     <div class="col-lg-12">
                    <div class="text-center">

                        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn-success" Height="39px" OnClick="btnAceptar_Click" OnClientClick="btnAceptar_OnClick" Width="97px"/>
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn-danger" OnClientClick="btn_CancelarOnClick" Height="39px" Width="97px" OnClick="btnCancelar_Click"/>

     </div></div>






</asp:Content>


