<%@ Page Title="Estructura" Language="C#" MasterPageFile="~/Neo.Master" AutoEventWireup="true" CodeBehind="FormularioEstructura.aspx.cs" Inherits="SAPR.Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="head">

    
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
    $("[src*=plus]").live("click", function () {
        $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
        $(this).attr("src", "images/minus.png");
    });
    $("[src*=minus]").live("click", function () {
        $(this).attr("src", "images/plus.png");
        $(this).closest("tr").next().remove();
    });
</script>



    
        <div class="page-header">
        <div class="row">
            <div class="col-lg-11">
                <h1><i class="fa fa-truck"></i> Estructura Proyecto</h1>
            </div>
        </div>
    </div>
    
                    <div class="col-lg-8">
                    <div class="form-group">
                        <label for="textProyectos" class="col-sm-3 control-label">Proyectos: </label>
                        <div class="dropdown-toggle">
                            <div class="help-block with-error">
                                <asp:DropDownList ID="cmbProyecto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbProyecto_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                        </div>
                    </div>
                    </div>
    

    <div class="col-lg-7">
            <div id="alertAlerta" class="alert alert-danger fade in" runat="server" hidden="hidden">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <strong>
                    <asp:Label ID="labelTipoAlerta" runat="server" Text="Alerta! "></asp:Label></strong><asp:Label ID="labelAlerta" runat="server" Text="Mensaje de alerta"></asp:Label>
            </div>
    </div>

    <div >
        <asp:GridView ID="gridSprints" runat="server" OnRowDataBound="OnRowDataBound" DataKeyNames="Identificador" CssClass=" table table-hover" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <img alt="" style="cursor: pointer" src="Images/plus.png" />
                        <asp:Panel ID="pnlModulos" runat="server" Style="display: none">
                            <asp:GridView ID="gridModulos" runat="server" OnRowDataBound="OnRowDataBound2" DataKeyNames="Identificador" CssClass="table table-hover " BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <img alt="" style="cursor: pointer" src="Images/plus.png" />
                                            <asp:Panel ID="pnlReq" runat="server" Style="display: none">
                                                <asp:GridView ID="gridReq" runat="server" CssClass="table table-hover" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                                                    <FooterStyle BackColor="#CCCC99" ForeColor="Black"></FooterStyle>

                                                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White"></HeaderStyle>

                                                    <PagerStyle HorizontalAlign="Right" BackColor="White" ForeColor="Black"></PagerStyle>

                                                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

                                                    <SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>

                                                    <SortedAscendingHeaderStyle BackColor="#4B4B4B"></SortedAscendingHeaderStyle>

                                                    <SortedDescendingCellStyle BackColor="#E5E5E5"></SortedDescendingCellStyle>

                                                    <SortedDescendingHeaderStyle BackColor="#242121"></SortedDescendingHeaderStyle>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
                        </asp:Panel>
                    </ItemTemplate>
                </asp:TemplateField>
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
    
   <%-- modal SPRINT--%>
    <div class="modal fade" id="modalSprint" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel"><i class="fa fa-exclamation-triangle text-danger fa-2x"></i> Gestion de Sprints</h4>
                </div>
                <div class="modal-body col-lg-12">
                    
                    <div class =" col-sm-6">

                    </div>
                    <div class =" col-sm-12">
                        <div class =" form-group">

                         </div>
                    
                    </div>
                </div>
                <div class="modal-footer">
                     <button runat="server" id="btnAceptar" class="btn btn-success" type="button" validationgroup="A" xmlns:asp="#unknown"><i class="fa fa-pencil-square-o"></i>Aceptar</button>
                    <button runat="server" id="btnCancelar" class="btn btn-danger" type="button" validationgroup="A" xmlns:asp="#unknown"><i class="fa fa-pencil-square-o"></i>Cancelar</button>
                </div>
            </div>
        </div>
    </div>

    <!--Modal EliminarSprint-->
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

    <div class="col-lg-12">
   
        
        <div class ="col-lg-6">           
        <div class="well bs-component">
         <div class="row  text-center">
             <legend>Sprints</legend>
        </div>

        
            <fieldset>
                <div class="row">
                    <button runat="server" id="btnAgregarSprint" onserverclick="btnAgregarSprint_Click" class="btn btn-primary" type="button"><i class="fa fa-plus"></i>Agregar</button>
                    <button runat="server"  id="btnModificarSprint" class="btn btn-primary" type="button" onserverclick="btnModificarSprint_Click"><i class="fa fa-pencil-square-o"></i>Modificar</button>
                    <a id="btnEliminarSprint" href="#modalEliminarSprint" class="btn btn-primary" role="button" data-toggle="modal" runat ="server"><i class="fa fa-trash-o fa-lg"></i>Eliminar</a>

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
                    <label for="txtNombreS">Nombre <font color='red'>*</font> </label>
                    <input id="txtNombreSprint" type="text" runat="server" enabled = "false"/>
                    </div>
                    <div class="col-md-5">
                    <label for="txtDescripcionS">Descripción  <font color='red'>*</font> </label>
                    <textarea id="txtDescripcionSprint" cols="30" rows="3" runat="server"></textarea> 
                     </div>   
                     </div>
                <br />          
                    <div class ="text-center">
                    <button runat="server" id="btnAceptarS" class="btn btn-success" type="button" validationgroup="B" xmlns:asp="#unknown" onserverclick="btnAceptar1"><i class="fa fa-pencil-square-o"></i>Aceptar</button>
                    <button runat="server" id="btnCancelarS" class="btn btn-danger" type="button" xmlns:asp="#unknown" onserverclick="btnCancelar1"><i class="fa fa-pencil-square-o"></i>Cancelar</button>
                         </div>
                
            </fieldset>
            <asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" errormessage="" forecolor="black" controltovalidate="txtNombreSprint" validationgroup="B" initialvalue="" xmlns:asp="#unknown"></asp:requiredfieldvalidator>
            <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" errormessage="" forecolor="black" controltovalidate="txtDescripcionSprint" validationgroup="B" initialvalue="" xmlns:asp="#unknown"></asp:requiredfieldvalidator>

        </div>       
 </div>

        <div class =" col-lg-6">
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
                    <div class="col-md-3">
                    <label for="Modulos">Módulos</label>
                    <div class="dropdown-toggle">
                    <asp:DropDownList ID="cmbModulo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbModulo_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    </div>
                    <div class="col-md-4">
                    <label for="txtNombreM">Nombre <font color='red'>*</font> </label>
                    <input id="txtNombreModulo" runat ="server" type="text" />
                    </div>
                    <div class="col-md-4">
                    <label for="txtDescripcionM">Descripción  <font color='red'>*</font> </label>
                    <textarea id="txtDescripcionModulo" runat ="server" cols="30" rows="3"></textarea>
                    </div>
                    </div>

                    <br />
                    <div class="text-center">
                    <button runat="server" id="btnAceptarM" class="btn btn-success" type="button" validationgroup="C" xmlns:asp="#unknown" onserverclick="btnAceptar2"><i class="fa fa-pencil-square-o"></i>Aceptar</button>
                    <button runat="server" id="btnCancelarM" class="btn btn-danger" type="button"  xmlns:asp="#unknown" onserverclick="btnCancelar2"><i class="fa fa-pencil-square-o"></i>Cancelar</button>
                    </div>
                
            </fieldset>
             <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" errormessage="" forecolor="black" controltovalidate="txtNombreModulo" validationgroup="C" initialvalue="" xmlns:asp="#unknown"></asp:requiredfieldvalidator>
            <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" errormessage="" forecolor="black" controltovalidate="txtDescripcionModulo" validationgroup="C" initialvalue="" xmlns:asp="#unknown"></asp:requiredfieldvalidator>
        </div>
            </div>



    </div>
    <div class ="text-center">
        <label for="textObligatorio"><font color = "red"><i>Los campos con (*) son obligatorios</i> </font></label>
    </div>
        



</asp:Content>