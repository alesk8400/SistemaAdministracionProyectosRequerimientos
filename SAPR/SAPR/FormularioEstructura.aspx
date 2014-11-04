﻿<%@ Page Title="Estructura" Language="C#" MasterPageFile="~/Neo.Master" AutoEventWireup="true" CodeBehind="FormularioEstructura.aspx.cs" Inherits="SAPR.Contact" %>

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
                <h1><i class="fa fa-truck"></i> ESTRUCTURA PROYECTO</h1>
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
    
    <div >
        <asp:GridView ID="gridSprints" runat="server" OnRowDataBound="OnRowDataBound" DataKeyNames="idSprint" CssClass=" table table-hover" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <img alt="" style="cursor: pointer" src="Images/plus.png" />
                        <asp:Panel ID="pnlModulos" runat="server" Style="display: none">
                            <asp:GridView ID="gridModulos" runat="server" OnRowDataBound="OnRowDataBound2" DataKeyNames="idModulo" CssClass="table table-hover " BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
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

    <div class="col-lg-8">
        <div class="well bs-component">
            <fieldset>
                <div class="form-group">
                    <asp:Label ID="lbSprint" runat="server" Text="SPRINTS"></asp:Label>
                    <asp:DropDownList ID="cmbSprints" runat="server" OnSelectedIndexChanged="cmbSprints_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                    <asp:Label ID="lbNomSprint" runat="server" Text="Nombre:"></asp:Label>
                    <input id="txtNombreSprint" type="text" runat="server" enabled = "false"/>
                    <asp:Label ID="lbDescripcion" runat="server" Text="Descripción:"></asp:Label>
                    <textarea id="txtDescripcionSprint" cols="20" rows="2" runat="server"></textarea>
                    <button runat="server" id="btnAgregarSprint" onserverclick="btnAgregarSprint_Click" class="btn btn-primary" type="button"><i class="fa fa-plus"></i>Agregar</button>
                    <button runat="server"  id="btnModificarSprint" class="btn btn-primary" type="button" onserverclick="btnModificarSprint_Click"><i class="fa fa-pencil-square-o"></i>Modificar</button>
                    <button runat="server"  id="btnEliminarSprint" class="btn btn-primary" type="button" onserverclick="btnEliminarSprint_Click"><i class="fa fa-pencil-square-o"></i>Eliminar</button>
                    <div>
                    <button runat="server" id="Button1" class="btn btn-success" type="button" validationgroup="A" xmlns:asp="#unknown" onserverclick="btnAceptar1"><i class="fa fa-pencil-square-o"></i>Aceptar</button>
                    <button runat="server" id="Button2" class="btn btn-danger" type="button" validationgroup="A" xmlns:asp="#unknown"><i class="fa fa-pencil-square-o"></i>Cancelar</button>
                    </div>
                </div>
                <a id="btnSprint" href="#modalSprint" class="btn btn-primary" role="button" data-toggle="modal" runat="server"><i class="fa fa-trash-o fa-lg"></i>Manejo Sprint</a>
            </fieldset>
        </div>
        <div class="well bs-component">
            <fieldset>
                <div class="form-group">
                    <asp:Label ID="lbModulo" runat="server" Text="MODULO"></asp:Label>
                    <asp:DropDownList ID="cmbModulo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbModulo_SelectedIndexChanged"></asp:DropDownList>
                    <asp:Label ID="lbNombreModulo" runat="server" Text="Nombre:"></asp:Label>
                    <input id="txtNombreModulo" runat ="server" type="text" />
                    <asp:Label ID="lbDescripModulo" runat="server" Text="Descripción:"></asp:Label>
                    <textarea id="txtDescripcionModulo" runat ="server" cols="20" rows="2"></textarea>
                    <button runat="server" id="btnAgregarModulo" onserverclick="btnAgregarModulo_Click" class="btn btn-primary" type="button"><i class="fa fa-plus"></i>Agregar</button>
                    <button runat="server"  id="btnModificarModulo" class="btn btn-primary" type="button" onserverclick="btnModificarModulo_Click"><i class="fa fa-pencil-square-o"></i>Modificar</button>
                    <button runat="server"  id="btnEliminarModulo" class="btn btn-primary" type="button" onserverclick="btnEliminarModulo_Click"><i class="fa fa-pencil-square-o"></i>Eliminar</button>
                    <div>
                    <button runat="server" id="Button6" class="btn btn-success" type="button" validationgroup="A" xmlns:asp="#unknown" onserverclick="btnAceptar2"><i class="fa fa-pencil-square-o"></i>Aceptar</button>
                    <button runat="server" id="Button7" class="btn btn-danger" type="button" validationgroup="A" xmlns:asp="#unknown"><i class="fa fa-pencil-square-o"></i>Cancelar</button>
                    </div>
                </div>
                <a id="A1" href="#modalSprint" class="btn btn-primary" role="button" data-toggle="modal" runat="server"><i class="fa fa-trash-o fa-lg"></i>Manejo Sprint</a>
            </fieldset>
        </div>



    </div>
        



</asp:Content>